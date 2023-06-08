using System.Security.Claims;
using codebattle_api.DTO;
using codebattle_api.Exceptions;
using codebattle_api.Services.AuthServices;
using codebattle_api.Services.UserServices;
using codebattle_api.Services.GameServices;
using codebattle_api.utils;
using codebattle_api.utils.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Collections.Specialized;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using codebattle_api.Services.ParticipantServices;
using codebattle_api.Enums;

namespace codebattle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CodeController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IUserService _userService;

        private readonly IParticipantService _participantService;

        static readonly HttpClient client = new HttpClient();

        private readonly IConfiguration Configuration;

        public CodeController(IGameService gameService, IConfiguration configuration, IUserService userService, IParticipantService participantService)
        {
            _gameService = gameService;
            Configuration = configuration;
            _userService = userService;
            _participantService = participantService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Validate([FromBody] CodeDTO codeDTO)
        {
            try
            {
                if (codeDTO.Code == null)
                {
                    return NoContent();
                }

                GameDetailDTO game = await _gameService.GetById(Int32.Parse(codeDTO?.BattleId));

                if (game == null)
                {
                    return BadRequest();
                }

                var self = game.Participants?.First((participant) => participant.UserId == this.User.GetUserId());
                var currentStep = game.Steps?.ElementAt((int)self.CurrentStep);
                var code = codeDTO.Code + " " + game.Language?.Validator;

                var judge0url = Configuration["Judge0"];
                var judge0token = Configuration["Judge0-Key"];

                bool CodeSuccess = true;


                if (currentStep != null)
                {

                    foreach (var validation in currentStep.Validations)
                    {
                        JudgeDTO judge = new JudgeDTO
                        {
                            source_code = code,
                            language_id = game.Language.Judge0Id.ToString(),
                            stdin = JsonConvert.SerializeObject(validation.EntryValue) //Creacion del objeto de envio de datos
                        };
                        var stringContent = new StringContent(JsonConvert.SerializeObject(judge), UnicodeEncoding.UTF8, "application/json");

                        using HttpResponseMessage response = await client.PostAsync(judge0url +
                        "submissions?base64_encoded=false&wait=true&X-Judge0-Token=" + judge0token, stringContent);

                        var jsonReader = new JsonTextReader(new StringReader(await response.Content.ReadAsStringAsync()));
                        jsonReader.Read();
                        if (jsonReader != null)
                        {
                            CodeResponseDTO? responseBody = JsonSerializer.CreateDefault().Deserialize<CodeResponseDTO>(jsonReader);

                            if (responseBody != null && responseBody.status != null && responseBody.status.description == "Accepted" && responseBody.stdout != null)
                            {
                                var jsonReader2 = new JsonTextReader(new StringReader(responseBody.stdout));
                                string? stdOut = JsonSerializer.CreateDefault().Deserialize<string>(jsonReader2);

                                if (validation.ExitValue != stdOut)
                                {
                                    CodeSuccess = false;
                                }
                            }
                            else
                            {
                                CodeSuccess = false;
                            }
                        }
                    }

                    if (CodeSuccess)
                    {
                        await AddUserExperience(100);
                        var result = await GoNextStep(self);
                        await CloseGame(game, result);
                    }
                    else
                    {
                        throw new CodeBattleException(ErrorCode.CodeNotSuccesfull);
                    }

                }

                return Ok();
            }
            catch (CodeBattleException ex)
            {
                return BadRequest(new ErrorResponse(ex));
            }
        }

        private async Task CloseGame(GameDetailDTO game, ParticipantDTO participant)
        {
            if (game.Steps.Count() == participant.CurrentStep)
            {
                var postDto = new GameDTO()
                {
                    Id = game.Id,
                    GameStatus = GameStatusEnum.Ended,
                };
                await _gameService.EditById(postDto);
            }
        }
        private async Task AddUserExperience(int expAmmount)
        {
            int userId = User.GetUserId();
            var result = await _userService.GetById(userId);

            var userDTO = new UserDTO()
            {
                Id = userId,
                Experience = result.Experience + expAmmount,
            };

            await _userService.EditById(userDTO);
        }

        private async Task<ParticipantDTO> GoNextStep(ParticipantDTO participant)
        {
            var updateDTO = new ParticipantDTO()
            {
                Id = participant.Id,
                CurrentStep = participant.CurrentStep + 1,
            };
            return await _participantService.EditById(updateDTO);
        }

    }
}
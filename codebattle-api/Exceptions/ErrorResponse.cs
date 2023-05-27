namespace codebattle_api.Exceptions
{
    public class ErrorResponse
    {
        public ErrorResponse(CodeBattleException exception)
        {
            ErrorCode = exception.ErrorCode;
            ErrorTranslation = exception.ErrorTranslation;
            Message = exception.Message;
        }
        public ErrorCode ErrorCode { get; }

        public string ErrorTranslation { get; }

        public string Message { get; }
    }
}
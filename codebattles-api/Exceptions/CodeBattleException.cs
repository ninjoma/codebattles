namespace codebattle_api.Exceptions
{
    [System.Serializable]
    public class CodeBattleException : System.Exception
    {
        public ErrorCode ErrorCode { get; }
        
        public string ErrorTranslation {get;}

        private static readonly Dictionary<ErrorCode, string> ErrorMessages = new Dictionary<ErrorCode, string> {
            { ErrorCode.InvalidInput, "La entrada proporcionada es inválida." },
            { ErrorCode.NotFound, "No se encontró el recurso solicitado." },
            { ErrorCode.Unauthorized, "No está autorizado para acceder a este recurso." },
            { ErrorCode.WrongLoginData, "Los datos de inicio de sesion proporcionados son incorrectos" },
            { ErrorCode.PasswordsDontMatch, "Las contraseñas no coinciden" },
            { ErrorCode.MissingTokenData, "El token suministrado no tiene todos los campos o estan mal formados" },
            { ErrorCode.CodeNotSuccesfull, "El codigo que has suministrado no compila o no pasa las validaciones" },
        };

        public CodeBattleException(ErrorCode errorCode) : base(GetErrorMessage(errorCode))
        {
            ErrorCode = errorCode;
            ErrorTranslation = GetErrorTranslationMessage(errorCode);
        }

        /// <summary>
        /// Method used to define the error message returned by the exception
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        private static string GetErrorMessage(ErrorCode errorCode)
        {
            if (ErrorMessages.TryGetValue(errorCode, out var message))
            {
                return message;
            }

            return "Ocurrió un error inesperado.";
        }

        /// <summary>
        /// Method that returns a translatable ready error message Format
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        private static string GetErrorTranslationMessage(ErrorCode errorCode){
            var Errorname = ErrorCode.GetName(typeof(ErrorCode), errorCode);
            if (Errorname != null){
                return "ERROR." + Errorname.ToUpperInvariant();
            }
            return "ERROR.UNEXPECTED";
        }
    }
}
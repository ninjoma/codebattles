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
            { ErrorCode.WrongPassword, "La contraseña proporcionada es incorrecta" },
            { ErrorCode.PasswordsDontMatch, "Las contraseñas no coinciden" }
        };

        public CodeBattleException(ErrorCode errorCode) : base(GetErrorMessage(errorCode))
        {
            ErrorCode = ErrorCode;
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
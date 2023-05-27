[System.Serializable]
public class CodeBattleExceptionException : System.Exception
{
    public CodeBattleExceptionException() { }
    public CodeBattleExceptionException(string message) : base(message) { }
    public CodeBattleExceptionException(string message, System.Exception inner) : base(message, inner) { }
    protected CodeBattleExceptionException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
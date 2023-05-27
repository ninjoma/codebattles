using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace codebattle_api.filter
{
    public class FilterRequest
    {
        public string? Property { get; set; }
        public string? Operator { get; set; }
        public string? Value { get; set; }

        public ExpressionType ExpressionGetter
        {
            get
            {
                if (Operator != null){
                    switch (Operator.Trim().ToUpperInvariant())
                    {
                        case "EQUALS":
                            return ExpressionType.Equal;
                        case "NOTEQUALS":
                            return ExpressionType.NotEqual;
                        case "CONTAINS":
                            return ExpressionType.Call;
                        // Agrega más operadores según tus necesidades
                        default:
                            throw new NotSupportedException($"Operator '{Operator}' is not supported.");
                    }
                }
                throw new NotSupportedException($"Operator '{Operator}' is not supported.");
            }
        }
    }
}
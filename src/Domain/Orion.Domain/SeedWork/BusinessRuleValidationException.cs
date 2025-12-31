namespace Orion.Domain.SeedWork
{
    public class BusinessRuleValidationException: Exception
    {
        public List<string> Errors { get; set; }

        public BusinessRuleValidationException(List<string> errors)
        {
            Errors = errors;
        }

        public BusinessRuleValidationException(string error)
        {
            Errors = new List<string> { error };
        }
    }
}

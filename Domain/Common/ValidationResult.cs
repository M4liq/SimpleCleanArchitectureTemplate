namespace Domain.Common;

public class ValidationResult
{
    public bool IsSuccessful { get; set; } = true;
    public string  ErrorMessage { get; set; }

    public static ValidationResult Success => new ValidationResult();

    public static ValidationResult Fail(string errorMessage) => new ValidationResult
        { IsSuccessful = false, ErrorMessage = errorMessage };
}
namespace BuberDinner.Application.Common.Errors;

public class DuplicateEmailException(string email) : Exception($"Email {email} is already in use.")
{
}

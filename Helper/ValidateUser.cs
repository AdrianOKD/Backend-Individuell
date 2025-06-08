public class ValidateUser
{
    public static string UserValidation(string? userId)
    {
        if (string.IsNullOrEmpty(userId))
            throw new UnauthorizedAccessException();
        return userId;
    }
}

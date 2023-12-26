using System.Text.RegularExpressions;

namespace Application.Requests.ValueObjects;

public class PasswordValue
{
    public string Password { get; set; }

    public PasswordValue(string password)
    {
        ValidatePassword(password);
        Password = password;
    }


    public void ValidatePassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentNullException("password cannot be null or empty");
        }

        if (!Regex.IsMatch(password, @"[!@#$%^&*(),.?""':{}|<>]"))
        {
            throw new ArgumentException("password must contain at least one special character", nameof(password));
        }

        if (!Regex.IsMatch(password, @"\d"))
        {
            throw new ArgumentException("password must contain at least one digit", nameof(password));
        }

        if (!Regex.IsMatch(password, @"[a-z]"))
        {
            throw new ArgumentException("password must contain at least one lowercase letter", nameof(password));
        }

        if (!Regex.IsMatch(password, @"[A-Z]"))
        {
            throw new ArgumentException("password must contain at least one uppercase letter", nameof(password));
        }
    }
}

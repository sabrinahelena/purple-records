using Application.Requests.Enums;
using Application.Requests.ValueObjects;

namespace Application.Requests;

public class UserRequest
{
    public EmailValue Email { get; set; }
    public PasswordValue Password { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public UserType Type { get; set; }
}

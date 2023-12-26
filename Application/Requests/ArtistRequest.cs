using Application.Requests.Enums;

namespace Application.Requests;

public class ArtistRequest : UserRequest
{
    /// <summary>
    /// NomeArtístico
    /// </summary>
    public string ArtistName { get; set; } = string.Empty;


    public void UpdateArtist(string email, string password, string name, string lastName, string artistName)
    {
        if (!string.IsNullOrEmpty(email))
            Email = new ValueObjects.EmailValue(email);

        if (!string.IsNullOrEmpty(password))
            Password = new ValueObjects.PasswordValue(password);

        if (!string.IsNullOrEmpty(name))
            Name = name;

        if (!string.IsNullOrEmpty(lastName))
            LastName = lastName;

        if (!string.IsNullOrEmpty(artistName))
            ArtistName = artistName;
    }


}

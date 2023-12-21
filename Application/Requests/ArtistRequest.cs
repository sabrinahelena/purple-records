namespace Application.Requests
{
    public class ArtistRequest : UserRequest
    {
        /// <summary>
        /// NomeArtístico
        /// </summary>
        public string ArtistName { get; set; } = string.Empty;

    }
}

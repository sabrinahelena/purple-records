namespace Application.Requests
{
    public class MusicRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ArtistRequest Singer { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}

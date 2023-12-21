using Domain.AggregatesModel;

namespace Application.Requests
{
    public class AlbumRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public ProducerRequest Producer { get; set; }
        public List<MusicModel> Musics { get; set; } = new();
    }
}

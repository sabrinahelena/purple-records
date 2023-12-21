namespace Domain.AggregatesModel
{
    public class AlbumModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public List<MusicModel> Musics { get; set;} = new();
    }
}

namespace Domain.AggregatesModel
{
    public class MusicModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int UserId { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}

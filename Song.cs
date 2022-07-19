namespace RythmsGonnaGetYou
{
    public class Song
    {
        public int Id { get; set; }
        public int TrackNumber { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }

        // 'Song' has a 121 relationship with Band and Album
        // public int BandId { get; set; }
        public int AlbumId { get; set; }

        // public Band Band { get; set; }
        public Album Album { get; set; }
    }
}
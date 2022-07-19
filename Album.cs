using System;
using System.Collections.Generic;

namespace RythmsGonnaGetYou
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string IsExplicit { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int BandId { get; set; }

        // Album has a 121 relationship with Band and a 1 to many relationship with Song
        public Band Band { get; set; }


        public List<Song> Songs { get; set; }
    }
}
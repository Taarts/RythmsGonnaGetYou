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

        // public Band Band { get; set; }
        public Song Song { get; set; }

        // public List<Song> Songs { get; set; }
    }
}
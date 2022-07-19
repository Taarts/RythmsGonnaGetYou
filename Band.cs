using System.Collections.Generic;

namespace RythmsGonnaGetYou
{
    public class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }
        public int NumberOfMembers { get; set; }
        public string Website { get; set; }
        public string Style { get; set; }
        public bool IsSigned { get; set; }
        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }

        // is it possible to have vvv ASWELL? | does interfere with 1/many? | is it superfluous?
        public Album Album { get; set; }

        // one to many relationship from Band to Albums & Songs
        // public List<Album> Albums { get; set; }
        // public List<Song> Songs { get; set; }
    }
}
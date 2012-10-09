using System.Collections.Generic;

namespace JsonVsXML.Models
{
/*
    public class MovieModel
    {
        public List<string> Actors { get; set; }
        public List<string> Directors { get; set; }
        public List<string> Awards { get; set; }
        public List<string> ShowTimes { get; set; }
        public string Language { get; set; }
        public string Duration { get; set; }
        public string Producer { get; set; }
        public string MusicDirector { get; set; }
        public string Synopsis { get; set; }
        public string Synopsis2 { get; set; }
        public string Synopsis3 { get; set; }

        public string Poster { get; set; }
    }
*/

    public class MovieModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public List<string> genres { get; set; }
        public string mpaa_rating { get; set; }
        public int runtime { get; set; }
        public string critics_consensus { get; set; }
        public ReleaseDates release_dates { get; set; }
        public Ratings ratings { get; set; }
        public string synopsis { get; set; }
        public Posters posters { get; set; }
        public List<AbridgedCast> abridged_cast { get; set; }
        public List<AbridgedDirector> abridged_directors { get; set; }
        public string studio { get; set; }
        public AlternateIds alternate_ids { get; set; }
        public Links links { get; set; }
    }
}
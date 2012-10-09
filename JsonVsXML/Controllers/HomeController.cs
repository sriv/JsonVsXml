using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using JsonVsXML.Models;
using XmlSerializer = System.Xml.Serialization.XmlSerializer;

namespace JsonVsXML.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private MovieModel _model = new MovieModel
            {
                abridged_cast = new List<AbridgedCast>
                    {
                        new AbridgedCast {characters = new List<string>{"Woody"}, name = "Tom Hanks", id = "162655641"}, 
                        new AbridgedCast {characters = new List<string>{"Buzz Lightyear"}, name = "Tim Allen", id = "162655909"}, 
                        new AbridgedCast {characters = new List<string>{"Jessie the Cowgirl"}, name = "Joan Cusack", id = "162655020"}, 
                        new AbridgedCast {characters = new List<string>{"Lots-o'-Huggin' Bear", "Lotso"}, name = "Ned Beatty", id = "162672460"}, 
                        new AbridgedCast {characters = new List<string>{"Mr. Potato Head"}, name = "Don Rickles", id = "341817905"}, 
                        new AbridgedCast {characters = new List<string>{"Rex"}, name = "Wallace Shawn", id = "341817922"}
                    },
                abridged_directors = new List<AbridgedDirector> {new AbridgedDirector {name = "Lee Unkrich"}},
                alternate_ids = new AlternateIds { imdb = "0435761" },
                critics_consensus =
                    "Deftly blending comedy, adventure, and honest emotion, Toy Story 3 is a rare second sequel that really works.",
                genres = new List<string> { "Animation", "Kids & Family", "Science Fiction & Fantasy", "Comedy" },
                id = 770672122,
                links = new Links
                    {
                        self = "http://api.rottentomatoes.com/api/public/v1.0/movies/770672122.json", alternate = "http://www.rottentomatoes.com/m/toy_story_3/", cast = "http://api.rottentomatoes.com/api/public/v1.0/movies/770672122/cast.json", clips = "http://api.rottentomatoes.com/api/public/v1.0/movies/770672122/clips.json", reviews = "http://api.rottentomatoes.com/api/public/v1.0/movies/770672122/reviews.json", similar = "http://api.rottentomatoes.com/api/public/v1.0/movies/770672122/similar.json"
                    },
                mpaa_rating = "G",
                posters = new Posters
                    {
                        thumbnail = "http://content6.flixster.com/movie/11/13/43/11134356_mob.jpg", profile = "http://content6.flixster.com/movie/11/13/43/11134356_pro.jpg", detailed = "http://content6.flixster.com/movie/11/13/43/11134356_det.jpg", original = "http://content6.flixster.com/movie/11/13/43/11134356_ori.jpg"
                    },
                ratings = new Ratings
                {
                    critics_rating = "Certified Fresh",
                    critics_score = 99,
                    audience_rating = "Upright",
                    audience_score = 91
                },
                release_dates = new ReleaseDates { theater = "2010-06-18", dvd = "2010-11-02" },
                runtime = 103,
                studio = "Walt Disney Pictures",
                synopsis = "Pixar returns to their first success with Toy Story 3. The movie begins with Andy leaving for college and donating his beloved toys -- including Woody (Tom Hanks) and Buzz (Tim Allen) -- to a daycare. While the crew meets new friends, including Ken (Michael Keaton), they soon grow to hate their new surroundings and plan an escape. The film was directed by Lee Unkrich from a script co-authored by Little Miss Sunshine scribe Michael Arndt. ~ Perry Seibert, Rovi",
                title = "Toy Story 3",
                year = 2010
            };
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult GetXml()
        {
            var xmlSerializer = new XmlSerializer(typeof (MovieModel));
            var memoryStream = new MemoryStream();
            var xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.Unicode);
            xmlSerializer.Serialize(xmlTextWriter, _model);
            return Content(Encoding.Unicode.GetString(((MemoryStream)xmlTextWriter.BaseStream).ToArray()),"text/xml");
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult GetJson()
        {
            return Json(_model, JsonRequestBehavior.AllowGet);
        }

    }
}

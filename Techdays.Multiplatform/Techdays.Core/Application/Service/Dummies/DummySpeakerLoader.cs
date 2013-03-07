using System.Collections.Generic;
using System.Linq;
using Techdays.Core.Application.Interfaces;
using Techdays.Core.Application.Model;

namespace Techdays.Core.Application.Service.Dummies
{
    public class DummySpeakerLoader : ILoadSpeakers
    {
        private List<Speaker> _speakers;

        private void InitSpeakers()
        {
            _speakers = new List<Speaker>
                               {
                                   new Speaker
                                       {
                                           FirstName = "Jef",
                                           LastName = "De Lathouwer",
                                           PictureUrl = "http://events.feed.comportal.be/techdays/speaker.aspx?name=GitteVermeiren",
                                           Company = "Ginderachter",
                                           Function = "Aanmodderaar",
                                           Bio = "Yada yada yada",
                                           Twitter = "@GitteTitter",
                                           LinkedIn = "trala",
                                           Blog = "http://proq.blogspot.com",
                                           Email = "hier@daar.be",
                                           HomePage = "http://proq.blogspot.com"
                                       },
                                   new Speaker
                                       {
                                           FirstName = "Knal",
                                           LastName = "De Pot",
                                           PictureUrl = "http://events.feed.comportal.be/techdays/speaker.aspx?name=GitteVermeiren",
                                           Company = "Ginderachter",
                                           Function = "Aanmodderaar",
                                           Bio = "Yada yada yada",
                                           Twitter = "@GitteTitter",
                                           LinkedIn = "trala",
                                           Blog = "http://proq.blogspot.com",
                                           Email = "hier@daar.be",
                                           HomePage = "http://proq.blogspot.com"
                                       },
                                   new Speaker
                                       {
                                           FirstName = "Alain",
                                           LastName = "Vandamme",
                                           PictureUrl = "http://events.feed.comportal.be/techdays/speaker.aspx?name=GitteVermeiren",
                                           Company = "Ginderachter",
                                           Function = "Aanmodderaar",
                                           Bio = "Yada yada yada",
                                           Twitter = "@GitteTitter",
                                           LinkedIn = "trala",
                                           Blog = "http://proq.blogspot.com",
                                           Email = "hier@daar.be",
                                           HomePage = "http://proq.blogspot.com"
                                       },
                                   new Speaker
                                       {
                                           FirstName = "Ons",
                                           LastName = "Moemoe",
                                           PictureUrl = "http://events.feed.comportal.be/techdays/speaker.aspx?name=GitteVermeiren",
                                           Company = "Ginderachter",
                                           Function = "Aanmodderaar",
                                           Bio = "Yada yada yada",
                                           Twitter = "@GitteTitter",
                                           LinkedIn = "trala",
                                           Blog = "http://proq.blogspot.com",
                                           Email = "hier@daar.be",
                                           HomePage = "http://proq.blogspot.com"
                                       },
                                   new Speaker
                                       {
                                           FirstName = "Ons",
                                           LastName = "Vava",
                                           PictureUrl = "http://events.feed.comportal.be/techdays/speaker.aspx?name=GitteVermeiren",
                                           Company = "Ginderachter",
                                           Function = "Aanmodderaar",
                                           Bio = "Yada yada yada",
                                           Twitter = "@GitteTitter",
                                           LinkedIn = "trala",
                                           Blog = "http://proq.blogspot.com",
                                           Email = "hier@daar.be",
                                           HomePage = "http://proq.blogspot.com"
                                       },
                                   new Speaker
                                       {
                                           FirstName = "Steve",
                                           LastName = "Stevaert",
                                           PictureUrl = "http://events.feed.comportal.be/techdays/speaker.aspx?name=GitteVermeiren",
                                           Company = "Ginderachter",
                                           Function = "Aanmodderaar",
                                           Bio = "Yada yada yada",
                                           Twitter = "@GitteTitter",
                                           LinkedIn = "trala",
                                           Blog = "http://proq.blogspot.com",
                                           Email = "hier@daar.be",
                                           HomePage = "http://proq.blogspot.com"
                                       },
                                   new Speaker
                                       {
                                           FirstName = "Bart",
                                           LastName = "Peeters",
                                           PictureUrl = "http://events.feed.comportal.be/techdays/speaker.aspx?name=GitteVermeiren",
                                           Company = "Ginderachter",
                                           Function = "Aanmodderaar",
                                           Bio = "Yada yada yada",
                                           Twitter = "@GitteTitter",
                                           LinkedIn = "trala",
                                           Blog = "http://proq.blogspot.com",
                                           Email = "hier@daar.be",
                                           HomePage = "http://proq.blogspot.com"
                                       },
                                   new Speaker
                                       {
                                           FirstName = "Willy",
                                           LastName = "Sommers",
                                           PictureUrl = "http://events.feed.comportal.be/techdays/speaker.aspx?name=GitteVermeiren",
                                           Company = "Ginderachter",
                                           Function = "Aanmodderaar",
                                           Bio = "Yada yada yada",
                                           Twitter = "@GitteTitter",
                                           LinkedIn = "trala",
                                           Blog = "http://proq.blogspot.com",
                                           Email = "hier@daar.be",
                                           HomePage = "http://proq.blogspot.com"
                                       },
                                   new Speaker
                                       {
                                           FirstName = "Jacobus",
                                           LastName = "En Corneel",
                                           PictureUrl = "http://events.feed.comportal.be/techdays/speaker.aspx?name=GitteVermeiren",
                                           Company = "Ginderachter",
                                           Function = "Aanmodderaar",
                                           Bio = "Yada yada yada",
                                           Twitter = "@GitteTitter",
                                           LinkedIn = "trala",
                                           Blog = "http://proq.blogspot.com",
                                           Email = "hier@daar.be",
                                           HomePage = "http://proq.blogspot.com"
                                       },
                                   new Speaker
                                       {
                                           FirstName = "Will",
                                           LastName = "Tura",
                                           PictureUrl = "http://events.feed.comportal.be/techdays/speaker.aspx?name=GitteVermeiren",
                                           Company = "Ginderachter",
                                           Function = "Aanmodderaar",
                                           Bio = "Yada yada yada",
                                           Twitter = "@GitteTitter",
                                           LinkedIn = "trala",
                                           Blog = "http://proq.blogspot.com",
                                           Email = "hier@daar.be",
                                           HomePage = "http://proq.blogspot.com"
                                       },
                               };

            int i = 0;
            foreach (var speaker in _speakers)
            {
                speaker.Id = ++i;
                speaker.Bio = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum. Typi non habent claritatem insitam; est usus legentis in iis qui facit eorum claritatem. Investigationes demonstraverunt lectores legere me lius quod ii legunt saepius. Claritas est etiam processus dynamicus, qui sequitur mutationem consuetudium lectorum. Mirum est notare quam littera gothica, quam nunc putamus parum claram, anteposuerit litterarum formas humanitatis per seacula quarta decima et quinta decima. Eodem modo typi, qui nunc nobis videntur parum clari, fiant sollemnes in futurum.";
            }            
        }

        public IEnumerable<Speaker> GetAll()
        {
            if (_speakers == null)
                InitSpeakers();

            return _speakers;
        }

        public Speaker GetById(int id)
        {
            if (_speakers == null)
                InitSpeakers();

            return (from speaker in _speakers
                    where speaker.Id == id
                    select speaker).First();
        }
    }
}
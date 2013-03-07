using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Newtonsoft.Json;
using Techdays.Core.Application.Service;

namespace Techdays.JsonTest
{
    class Program
    {
        private static XNamespace jsonns;
        private static XDocument doc;

        static void Main(string[] args)
        {
            doc = XDocument.Load("http://events.feed.comportal.be/agenda.aspx?event=TechDays&year=2013&speakerlist=c|Experts");

            jsonns = "http://james.newtonking.com/projects/json";
            doc.Root.SetAttributeValue(XNamespace.Xmlns + "json", jsonns);

            CleanSection("bio");
            CleanSection("description");

            ToJsonArray("timeslot");
            ToJsonArray("session");
            ToJsonArray("tag");
            ToJsonArray("speaker");

            var wrdoc = File.CreateText("sessions.xml");
            wrdoc.Write(doc);
            wrdoc.Close();

            var jsonstring = JsonConvert.SerializeXNode(doc);

            var wr = File.CreateText("sessions.json");
            wr.Write(jsonstring);
            wr.Close();

            var rdr = File.OpenText("sessions.json");
            var json = rdr.ReadToEnd();
            rdr.Close();

            var theevent = JsonConvert.DeserializeObject<TopXml>(json);


            //Console.WriteLine("done");
            //Console.ReadLine();
        }

        private static void CleanSection(string element)
        {
            var cdatasection = from el in doc.Descendants(element)
                               select el;

            foreach (var cdata in cdatasection)
            {
                cdata.Value = Clean(cdata.Value);
            }

        }

        private static void ToJsonArray(string elementName)
        {
            var timeslots = from el in doc.Descendants(elementName)
                select el;

            foreach (var timeslot in timeslots)
            {
                timeslot.SetAttributeValue(jsonns + "Array", "true");
            }

        }

        private static string Clean(string value)
        {
            var tagsExpression = new Regex(@"</?.+?>");
            string cleanedHtml = tagsExpression.Replace(value, " ");

            var stringBuilder = new StringBuilder(cleanedHtml);
            stringBuilder.Replace("&nbsp;", " ");
            stringBuilder.Replace("&quot;", "\"");
            stringBuilder.Replace("&apos;", "\'");
            stringBuilder.Replace("'", "&apos;");
            stringBuilder.Replace("“", "&#8220;");
            stringBuilder.Replace("”", "&#8221;");

            stringBuilder.Replace("\n", "");
            return stringBuilder.ToString().Trim();
        }
    }
}

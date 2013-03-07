using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Techdays.Core.Application.Service
{
    public class TopXml
    {
        public Event @event { get; set; }
    }

    public class Event
    {
        public Agenda agenda { get; set; }
        public Detail details { get; set; }
    }

    public class Agenda
    {
        public IEnumerable<Day> day { get; set; }
    }

    public class Day
    {
        public IEnumerable<TimeSlot> timeslot { get; set; }
        [JsonProperty("@date")]
        public string date { get; set; }
        [JsonProperty("@id")]
        public int id { get; set; }
    }

    public class TimeSlot
    {
        [JsonProperty("@id")]
        public int id { get; set; }
        [JsonProperty("@end")]
        public DateTime end { get; set; }
        [JsonProperty("@start")]
        public DateTime start { get; set; }

        public IEnumerable<Sessionke> session { get; set; }
    }

    public class Sessionke
    {
        [JsonProperty("@type")]
        public string type { get; set; }
        [JsonProperty("@id")]
        public int id { get; set; }
    }

    public class Detail
    {
        public SpeakerList speakers { get; set; }
        public SessionList sessions { get; set; }
    }

    public class SpeakerList
    {
        public IEnumerable<Speakerke> speaker { get; set; }
    }

    public class Speakerke
    {
        [JsonProperty("@id")]
        public int id { get; set; }
        public string fullname { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string company { get; set; }
        [JsonConverter(typeof(MyConverter))]
        public CData bio { get; set; }
        public string twitter { get; set; }
        public IEnumerable<string> linkedin { get; set; }
        public string blog { get; set; }
        public string email { get; set; }
        public string homepage { get; set; }
        public string picture { get; set; }
    }

    public class MyConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return new CData {cdata = reader.Value.ToString()};
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }

    public class CData
    {
        public string cdata { get; set; }
    }

    public class SessionList
    {
        public IEnumerable<SessionDetail> sessionextract { get; set; } 
    }

    public class SessionDetail
    {
        [JsonProperty("@id")]
        public int id { get; set; }
        public string published { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public int level { get; set; }
        public IEnumerable<string> tag { get; set; }
        public string description { get; set; }
        public string language { get; set; }
        public string ppt { get; set; }
        public string shortvideo { get; set; }
        public string longvideo { get; set; }
        public RelatedSession relatedsessions { get; set; }
        public IEnumerable<SpeakerId> speaker { get; set; }
        public int room { get; set; }
    }

    public class SpeakerId
    {
        [JsonProperty("@id")]
        public int id { get; set; }
    }

    public class RelatedSession
    {
        public IEnumerable<Related> session { get; set; }
    }

    public class Related
    {
        [JsonProperty("@id")]
        public int id { get; set; }
    }
}
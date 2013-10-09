using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpotifyMetaDataAPI
{
    public class Responses
    {
        public class TrackContainer
        {
            [JsonProperty("track")]
            public Track track { get; set; }

            public class Track {
                [JsonProperty("name")]
                public string name { get; set; }

                [JsonProperty("album")]
                public Album album { get; set; }

                [JsonProperty("popularity")]
                public double popularity { get; set; }

                [JsonProperty("length")]
                public double length { get; set; }

                [JsonProperty("href")]
                public string uri { get; set; }

                [JsonProperty("artists")]
                public List<Artist> artists { get; set; }
            }

            public class Artist {
                [JsonProperty("name")]
                public string name { get; set; }

                [JsonProperty("href")]
                public string uri { get; set; }
            }

            public class Album {
                [JsonProperty("released")]
                public string released { get; set; }

                [JsonProperty("href")]
                public string uri { get; set; }

                [JsonProperty("name")]
                public string name { get; set; }
            }

        }

    }
}

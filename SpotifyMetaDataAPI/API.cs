using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyMetaDataAPI
{
    public class API
    {
        WebClient wc;


        public API() {
            wc = new WebClient();
        }
        

        public Responses.TrackContainer.Track getTrackInfo(string trackUri) {
            string data = lookup(trackUri);
            Responses.TrackContainer trackcontainer = (Responses.TrackContainer)JsonConvert.DeserializeObject(data, typeof(Responses.TrackContainer));
            return trackcontainer.track;
        }

        public string lookup(string uri) {
            return this.request("lookup/1/.json?uri=" + uri);
        }

        private string request(string uri) {
            string baseUrl = "http://ws.spotify.com/";
            string url = baseUrl + uri;
            string data = "";
            try {
                data = wc.DownloadString(url);
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            return data;
        }
    }
}

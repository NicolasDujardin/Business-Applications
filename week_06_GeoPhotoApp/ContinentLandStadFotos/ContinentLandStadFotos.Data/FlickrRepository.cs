using ContinentLandStadFotos.Data.Helpers;
using ContinentLandStadFotos.Models.Flickr;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ContinentLandStadFotos.Data
{
    public class FlickrRepository : IFlickrRepository
    {
        public virtual async Task<IEnumerable<Photo>> Get(String tags)
        {
            HttpClient client = new HttpClient();
            String url = "https://api.flickr.com/services/rest/";

            url += @"?method=flickr.photos.search&api_key=" + APIKeys.Flickr
                + $"&tags={tags}&format=json&nojsoncallback=1";
            string flickrJson = await client.GetStringAsync(url);

            FlickrData flickrData = JsonConvert.DeserializeObject<FlickrData>(flickrJson);
            if (flickrData.stat == "ok")
                return flickrData.photos.photo;
            else
                return null;
        }
    }
}

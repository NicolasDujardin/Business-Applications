using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContinentLandStadFotos.Models.Flickr
{
    public class Photo : ModelBaseClass
    {
        public string id { get; set; }
        public string owner { get; set; }
        public string secret { get; set; }
        public string server { get; set; }
        public int farm { get; set; }
        public string title { get; set; }
        public int ispublic { get; set; }
        public int isfriend { get; set; }
        public int isfamily { get; set; }
        public String PhotoUrl
        {
            get
            {
                return $"http://farm{farm}.staticflickr.com/{server}/{id}_{secret}_n.jpg";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContinentLandStadFotos.Models.Flickr
{
    public class FlickrData : ModelBaseClass
    {
        public Photos photos { get; set; }
        public string stat { get; set; }
    }
}

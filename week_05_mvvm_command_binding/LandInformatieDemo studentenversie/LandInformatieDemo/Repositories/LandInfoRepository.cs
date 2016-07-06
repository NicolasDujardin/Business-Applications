using LandInformatieDemo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandInformatieDemo.Repositories
{
    public class LandInfoRepository
    {
        private static ObservableCollection<LandInfo> _landen;
        public static ObservableCollection<LandInfo> Landen
        {
            get
            {
                if (_landen == null) VerzamelLanden();
                return _landen;
            }
        }
        private static void VerzamelLanden()
        {
            _landen = new ObservableCollection<LandInfo>();
            _landen.Add(new LandInfo() { LandNaam = "Afhanistan", VlagURL = "http://www.flagchart.net/f/p/land/afghanis.gif" });
            _landen.Add(new LandInfo() { LandNaam = "Albanië", VlagURL = "http://www.flagchart.net/f/p/land/albanie.gif" });
            _landen.Add(new LandInfo() { LandNaam = "Algerije", VlagURL = "http://www.flagchart.net/f/p/land/algerije.gif" });
            _landen.Add(new LandInfo() { LandNaam = "België", IsEuropees = true, VlagURL = "http://www.flagchart.net/f/p/land/belgie.gif" });
            _landen.Add(new LandInfo() { LandNaam = "Bhutan", VlagURL = "http://www.flagchart.net/f/p/land/bhutan.gif" });
            _landen.Add(new LandInfo() { LandNaam = "Canada", VlagURL = "http://www.flagchart.net/f/p/land/canada.gif" });
            _landen.Add(new LandInfo() { LandNaam = "Uganda", VlagURL = "http://www.flagchart.net/f/p/land/oeganda.gif" });
            _landen.Add(new LandInfo() { LandNaam = "Verenigd Koninkrijk", IsEuropees = true, VlagURL = "http://www.flagchart.net/f/p/land/uk.gif" });
            _landen.Add(new LandInfo() { LandNaam = "Verenigde Staten", VlagURL = "http://www.flagchart.net/f/p/land/usa.gif" });
        }

        internal static void DeleteLandInfo(LandInfo landInfo)
        {
            Boolean b = _landen.Remove(landInfo);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace ZesDaagseGent.UWP.StateTriggers
{
    public class NetworkStateTrigger : StateTriggerBase
    {
        public NetworkStateTrigger()
        {
            NetworkInformation.NetworkStatusChanged += NetworkInformation_NetworkStatusChanged;
        }

        private void NetworkInformation_NetworkStatusChanged(object sender)
        {
            var isInternetConnected = false;
            var connectionProfile = NetworkInformation.GetInternetConnectionProfile();

            if(connectionProfile != null)
            {
                var connectivityLevel = connectionProfile.GetNetworkConnectivityLevel();
                isInternetConnected = connectivityLevel == NetworkConnectivityLevel.InternetAccess;
            }

            Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => this.SetActive(isInternetConnected = IsConnected));
        }

        public Boolean IsConnected { get; set; }
    }
}

using ParkerenInGent.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace ParkerenInGent.Controls
{
    public sealed partial class ParkingUserControl : UserControl
    {
        public ParkingUserControl()
        {
            this.InitializeComponent();
        }

        public void ToonInfo(Parking p)
        {

            if (p.ParkingStatus.AvailableCapacity <1)
                grid.Style = Application.Current.Resources["Full"] as Style;
            else if (p.ParkingStatus.AvailableCapacity < 194)
                grid.Style = Application.Current.Resources["Swarming"] as Style;


            txbDescription.Text = p.Description;
            txbCapacity.Text = p.ParkingStatus.AvailableCapacity + " / " + p.ParkingStatus.TotalCapacity;
        }
    }
}

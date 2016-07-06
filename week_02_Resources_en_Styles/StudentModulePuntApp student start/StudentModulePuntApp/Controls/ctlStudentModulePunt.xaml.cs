using StudentModulePuntApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace StudentModulePuntApp.Controls
{
    public sealed partial class ctlStudentModulePunt : UserControl
    {
        public StudentModulePunt SMP { get; set; }
        public ctlStudentModulePunt()
        {
            this.InitializeComponent();
        }

        public void ToonStudentModulePunt(StudentModulePunt smp)
        {
            SMP = smp;
            txbModule.Text = SMP.Module;
            txbPunt.Text = "" + smp.Punt;
            if (SMP.Punt >= 10)
                grd.Style = this.FindName("Geslaagd") as Style;
            else
                grd.Style = this.FindName("Gebuisd") as Style;
            //grd.Background = new SolidColorBrush( (SMP.Punt >= 10) ? Colors.LightGreen : Colors.Coral );
        }
    }
}

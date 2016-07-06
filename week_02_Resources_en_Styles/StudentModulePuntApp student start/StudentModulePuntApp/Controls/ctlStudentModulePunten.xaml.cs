using StudentModulePuntApp.Models;
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

namespace StudentModulePuntApp.Controls
{
    public sealed partial class ctlStudentModulePunten : UserControl
    {
        public List<StudentModulePunt> SMPs { get; set; }
        public ctlStudentModulePunten()
        {
            this.InitializeComponent();
        }

        public void ToonStudentModulePunten(List<StudentModulePunt> smps)
        {
            SMPs = smps;
            lstModulePunten.Items.Clear();
            foreach(StudentModulePunt smp in SMPs)
            {
                ctlStudentModulePunt ctl = new ctlStudentModulePunt();
                ctl.ToonStudentModulePunt(smp);
                lstModulePunten.Items.Add(ctl);
            }
        }
        public ListBox ListBoxModulePunten { get { return lstModulePunten; } }
    }
}

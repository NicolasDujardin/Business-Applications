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
    public sealed partial class ctlStudent : UserControl
    {
        private Student _student;
        public ctlStudent()
        {
            this.InitializeComponent();
        }
        public void ToonStudent(Student student)
        {
            _student = student;
            runFamilienaam.Text = GetoondeStudent.Familienaam;
            runGeboorteplaats.Text = GetoondeStudent.GeboortePlaats;
            runVoorNaam.Text = GetoondeStudent.Voornaam;
        }
        public Student GetoondeStudent { get { return _student; } }
    }
}

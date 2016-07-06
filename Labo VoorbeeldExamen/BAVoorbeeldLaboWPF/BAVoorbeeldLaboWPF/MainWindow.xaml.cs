using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BAVoorbeeldLaboWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String ExcelDocument = AppDomain.CurrentDomain.BaseDirectory + "/Weather.xlsx";
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<WeatherInfo> lijst = WeatherInfoRepository.WeatherInfos;

            InsertToExcel("A", 1, "VillageName");
            InsertToExcel("B", 1, "Title");
            InsertToExcel("C", 1, "Min Temp.");
            InsertToExcel("D", 1, "Max Temp.");

            int row = 3;
            foreach(WeatherInfo info in lijst)
            {
                InsertToExcel("A", row, info.Village);
                InsertToExcel("B", row, info.Title);
                InsertToExcel("C", row, info.Min.ToString());
                InsertToExcel("D", row, info.Max.ToString());
                row++;
            }
        }

        private void InsertToExcel(String col, int row, String value)
        {
            OpenXMLDemo.OpenXMLExcel.XLInsertText(ExcelDocument, "WeatherInfo", col, uint.Parse(row.ToString()), value);
        }
    }
}

using BALaboVoorbeeld.Data;
using BALaboVoorbeeld.UWP.Pages;
using BALaboVoorbeeld.UWP.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALaboVoorbeeld.UWP.Services
{
    public class IocContainer
    {
        static IocContainer()
        {
            SimpleIoc.Default.Register<YahooWeatherRepository>(false);
            SimpleIoc.Default.Register<WeatherInfoRepository>(false);

            SimpleIoc.Default.Register<ApplicationViewModel>(false);
            SimpleIoc.Default.Register<ShowWeatherViewModel>(false);
            SimpleIoc.Default.Register<ShowWeatherDetailsViewModel>(false);

            SimpleIoc.Default.Register<ShowWeatherPage>(false);
            SimpleIoc.Default.Register<ShowWeatherDetailPage>(false);
        }

        public static YahooWeatherRepository YahooWeatherRepository
        {
            get { return SimpleIoc.Default.GetInstance<YahooWeatherRepository>(); }
        }
        public static WeatherInfoRepository WeatherInfoRepository
        {
            get { return SimpleIoc.Default.GetInstance<WeatherInfoRepository>(); }
        }
        public static ShowWeatherPage ShowWeatherPage
        {
            get { return SimpleIoc.Default.GetInstance<ShowWeatherPage>(); }
        }
        public static ShowWeatherDetailPage ShowWeatherDetailPage
        {
            get { return SimpleIoc.Default.GetInstance<ShowWeatherDetailPage>(); }
        }
        public static ShowWeatherViewModel ShowWeatherViewModel
        {
            get { return SimpleIoc.Default.GetInstance<ShowWeatherViewModel>(); }
        }
        public static ShowWeatherDetailsViewModel ShowWeatherDetailsViewModel
        {
            get { return SimpleIoc.Default.GetInstance<ShowWeatherDetailsViewModel>(); }
        }
        public static ApplicationViewModel ApplicationViewModel
        {
            get { return SimpleIoc.Default.GetInstance<ApplicationViewModel>(); }
        }
    }
}

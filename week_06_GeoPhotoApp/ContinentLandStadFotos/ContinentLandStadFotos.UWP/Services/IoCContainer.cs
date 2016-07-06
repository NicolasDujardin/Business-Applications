using ContinentLandStadFotos.Data;
using ContinentLandStadFotos.UWP.Pages;
using ContinentLandStadFotos.UWP.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace ContinentLandStadFotos.UWP.Services
{
    public class IoCContainer
    {
        static IoCContainer()
        {
            SimpleIoc.Default.Register<IFlickrRepository, FlickrRepository>(false);
            SimpleIoc.Default.Register<IContinentRepository, ContinentRepository>(false);
            SimpleIoc.Default.Register<ICountryRepository, CountryRepository>(false);
            SimpleIoc.Default.Register<ICityRepository, CityRepository>(false);

            if(DesignMode.DesignModeEnabled)
                SimpleIoc.Default.Register<IPhotoOverviewViewModel, PhotoOverviewDesignViewModel>(false);
            else
                SimpleIoc.Default.Register<IPhotoOverviewViewModel, PhotoOverviewViewModel>(false);
            SimpleIoc.Default.Register<IPhotoDetailViewModel, PhotoDetailViewModel>(false);

            SimpleIoc.Default.Register<PhotoOverviewPage>(false);
            SimpleIoc.Default.Register<PhotoDetailPage>(false);
   
            SimpleIoc.Default.Register<ApplicationViewModel>(false);
        }

        public static IoCContainer IoC
        {
            get { return App.Current.Resources["ioc"] as IoCContainer; }
        }

        public static IFlickrRepository FlickrRepository
        {
            get { return SimpleIoc.Default.GetInstance<IFlickrRepository>(); }
        }

        public static IContinentRepository ContinentRepository
        {
            get { return SimpleIoc.Default.GetInstance<IContinentRepository>(); }
        }

        public static ICountryRepository CountryRepository
        {
            get { return SimpleIoc.Default.GetInstance<ICountryRepository>(); }
        }

        public static ICityRepository CityRepository
        {
            get { return SimpleIoc.Default.GetInstance<ICityRepository>(); }
        }

        public static ApplicationViewModel ApplicationViewModel
        {
            get { return SimpleIoc.Default.GetInstance<ApplicationViewModel>(); }
        }

        public static IPhotoOverviewViewModel PhotoOverviewViewModel
        {
            get { return SimpleIoc.Default.GetInstance<IPhotoOverviewViewModel>(); }
        }

        public static IPhotoDetailViewModel PhotoDetailViewModel
        {
            get { return SimpleIoc.Default.GetInstance<IPhotoDetailViewModel>(); }
        }

        public static PhotoOverviewPage PhotoOverviewPage
        {
            get { return SimpleIoc.Default.GetInstance<PhotoOverviewPage>(); }
        }

        public static PhotoDetailPage PhotoDetailPage
        {
            get { return SimpleIoc.Default.GetInstance<PhotoDetailPage>(); }
        }
    }
}

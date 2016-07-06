using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using ZesDaagseGent.Data;
using ZesDaagseGent.Models;
using ZesDaagseGent.UWP.Pages;
using ZesDaagseGent.UWP.ViewModels;

namespace ZesDaagseGent.UWP.Services
{
    public class IocContainer
    {
        static IocContainer()
        {
            SimpleIoc.Default.Register<IRepository<Cyclist>, CyclistRepository>(false);
            SimpleIoc.Default.Register<IRepository<Team>, TeamRepository>(true);
            SimpleIoc.Default.Register<LandingPage>(false);
            SimpleIoc.Default.Register<LandingPageViewModel>(false);
            SimpleIoc.Default.Register<CreateTeamPage>(false);
            SimpleIoc.Default.Register<CreateTeamViewModel>(false);
            SimpleIoc.Default.Register<DernysViewModel>(false);
            SimpleIoc.Default.Register<DernysPage>(false);
            SimpleIoc.Default.Register<EditCyclistPage>(false);
            SimpleIoc.Default.Register<ApplicationViewModel>(false);
        }


        public static LandingPageViewModel LandingPageViewModel
        {
            get { return SimpleIoc.Default.GetInstance<LandingPageViewModel>(); }
        }
        public static LandingPage LandingPage
        {
            get { return SimpleIoc.Default.GetInstance<LandingPage>(); }
        }
        public static DernysPage DernysPage
        {
            get { return SimpleIoc.Default.GetInstance<DernysPage>(); }
        }
        public static DernysViewModel DernysViewModel
        {
            get { return SimpleIoc.Default.GetInstance<DernysViewModel>(); }
        }
        public static CreateTeamViewModel CreateTeamViewModel
        {
            get { return SimpleIoc.Default.GetInstance<CreateTeamViewModel>(); }
        }
        public static CreateTeamPage CreateTeamPage
        {
            get { return SimpleIoc.Default.GetInstance<CreateTeamPage>(); }
        }
        public static IRepository<Cyclist> CyclistRepository
        {
            get { return SimpleIoc.Default.GetInstance<IRepository<Cyclist>>(); }
        }

        public static ApplicationViewModel ApplicationViewModel
        {
            get { return SimpleIoc.Default.GetInstance<ApplicationViewModel>(); }
        }
    }
}

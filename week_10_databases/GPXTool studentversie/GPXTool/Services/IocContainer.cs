using GalaSoft.MvvmLight.Ioc;
using GPXTool.Data;
using GPXTool.Models;
using GPXTool.Pages;
using GPXTool.Repositories;
using GPXTool.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPXTool.Services
{
    public class IocContainer
    {
        static IocContainer()
        {

            SimpleIoc.Default.Register<NewTrackViewModel>(false);
            SimpleIoc.Default.Register<NewTrackPage>(false);
            SimpleIoc.Default.Register<ApplicationViewModel>(false);
            SimpleIoc.Default.Register<ViewTrackPage>(false);
            SimpleIoc.Default.Register<ViewTrackViewModel>(false);
            SimpleIoc.Default.Register<TrkRepository>(false);
            SimpleIoc.Default.Register<TrkPtRepository>(false);
        }

        public static ViewTrackPage ViewTrackPage
        {
            get { return SimpleIoc.Default.GetInstance<ViewTrackPage>(); }
        }
        public static ViewTrackViewModel ViewTrackViewModel
        {
            get { return SimpleIoc.Default.GetInstance<ViewTrackViewModel>(); }
        }
        public static ApplicationViewModel ApplicationViewModel
        {
            get { return SimpleIoc.Default.GetInstance<ApplicationViewModel>(); }
        }
        public static NewTrackPage NewTrackPage
        {
            get { return SimpleIoc.Default.GetInstance<NewTrackPage>(); }
        }
        public static NewTrackViewModel NewTrackViewModel
        {
            get { return SimpleIoc.Default.GetInstance<NewTrackViewModel>(); }
        }
        public static Tracker Tracker
        {
            get { return SimpleIoc.Default.GetInstance<Tracker>(); }
        }
        public static TrkPtRepository TrkPtRepository
        {
            get { return SimpleIoc.Default.GetInstance<TrkPtRepository>(); }
        }
        public static TrkRepository TrkRepository
        {
            get { return SimpleIoc.Default.GetInstance<TrkRepository>(); }
        }
    }
}

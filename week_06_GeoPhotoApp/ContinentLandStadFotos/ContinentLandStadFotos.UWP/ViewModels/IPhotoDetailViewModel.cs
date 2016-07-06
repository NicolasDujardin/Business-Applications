using ContinentLandStadFotos.Models.Flickr;
using GalaSoft.MvvmLight.Command;

namespace ContinentLandStadFotos.UWP.ViewModels
{
    public interface IPhotoDetailViewModel
    {
        RelayCommand<object> BackCMD { get; }
        Photo Photo { get; set; }
    }
}
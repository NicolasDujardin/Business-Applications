using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LandInformatieDemo.ViewModels
{
    public interface INestedPropertyChangedListener
    {
        void OnNestedPropertyChanged(object sender,[CallerMemberName] string propertyName="");
    }
}

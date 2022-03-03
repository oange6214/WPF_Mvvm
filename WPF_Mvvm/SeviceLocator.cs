using SideProject.IconSet;
using WPF_Mvvm.ViewModels;

namespace WPF_Mvvm
{
    public class SeviceLocator
    {
        public IIconSet IconSource => new FooIconSet();

        public MainViewModel MainViewModel => new MainViewModel();

    }
}

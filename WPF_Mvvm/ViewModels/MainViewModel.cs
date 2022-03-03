using SideProject.Base;
using System;
using System.Windows;

namespace WPF_Mvvm.ViewModels
{
    public class MainViewModel : NotifyPropertyChanged
    {
        public MainViewModel()
        {
            SearchCommand = new RelayCommand(() =>
            {
                MessageBox.Show(SearchText);
            });
        }

        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set 
            { 
                _searchText = value; 
                RaisePropertyChanged(nameof(SearchText)); 
            }
        }

        public RelayCommand SearchCommand { get; private set; }

    }
}

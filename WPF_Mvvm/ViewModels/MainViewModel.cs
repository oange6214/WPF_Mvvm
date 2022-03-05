using SideProject.Base;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using WPF_Mvvm.Models;

namespace WPF_Mvvm.ViewModels
{
    public class MainViewModel : NotifyPropertyChanged
    {
        public MainViewModel()
        {

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

        public RelayCommand SearchCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MessageBox.Show(SearchText);
                });
            }
        }

        private ObservableCollection<IconModel> _iconModels;
        /// <summary>
        /// 方法一、Icon 資料集（自動取得屬性名稱）
        /// </summary>
        public ObservableCollection<IconModel> IconModels
        {
            get { return _iconModels; }
            set 
            {
                _iconModels = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<IconModel> _iconModels2;
        /// <summary>
        /// 方法二、Icon 資料集（封裝 OnPropertyChanged）
        /// </summary>
        public ObservableCollection<IconModel> IconModels2
        {
            get { return _iconModels2; }
            set
            {
                Set(ref _iconModels2, value);
            }
        }
    }
}

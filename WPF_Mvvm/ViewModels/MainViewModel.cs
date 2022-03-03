using SideProject.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using WPF_Mvvm.Models;

namespace WPF_Mvvm.ViewModels
{
    public class MainViewModel : NotifyPropertyChanged
    {
        SeviceLocator Locator = new SeviceLocator();

        public MainViewModel()
        {
            SearchCommand = new RelayCommand(() =>
            {
                MessageBox.Show(SearchText);
            });

            var list = FindDititsInfo(Locator.IconSource);
        }

        private string _searchText;
        /// <summary>
        /// 屬性
        /// </summary>
        public string SearchText
        {
            get { return _searchText; }
            set 
            { 
                _searchText = value; 
                RaisePropertyChanged(nameof(SearchText));   // 需要傳入屬性名稱
            }
        }

        public RelayCommand SearchCommand { get; private set; }

        private ObservableCollection<IconModel> _searchedIcons;
        /// <summary>
        /// 屬性集合
        /// </summary>
        public ObservableCollection<IconModel>  SearchedIcons
        {
            get { return _searchedIcons; }
            set 
            { 
                _searchedIcons = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<IconModel> _searchedIcons2;
        /// <summary>
        /// 屬性集合 2
        /// </summary>
        public ObservableCollection<IconModel> SearchedIcons2
        {
            get { return _searchedIcons2; }
            set
            {
                Set(ref _searchedIcons2, value);
            }
        }

        /// <summary>
        /// 獲取 model 物件鐘的屬性訊息
        /// </summary>
        /// <typeparam name="T">物件類型</typeparam>
        /// <param name="model">物件</param>
        /// <returns></returns>
        List<IconModel> FindDititsInfo<T> (T model)
        {
            List<IconModel> icons = new List<IconModel>();
            var newType = model.GetType();
            
            foreach(var item in newType.GetProperties())
            {
                IconModel icon = new IconModel
                {
                    IconName = item.Name,
                    IconPath = item.GetValue(model).ToString(),
                };

                icons.Add(icon);
            }
            return icons;
        }
    }
}

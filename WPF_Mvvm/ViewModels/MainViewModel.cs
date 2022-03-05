using SideProject.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WPF_Mvvm.Models;

namespace WPF_Mvvm.ViewModels
{
    public class MainViewModel : NotifyPropertyChanged
    {
        /// <summary>
        /// 默認建構函數
        /// </summary>
        public MainViewModel()
        {
            // 取得 Icon 資料集
            var list = FindDititsInfo(Locator.IconSource);

            // 初始化資料源
            OriginalIcons = list;

            // 初始化界面
            SearchText = "";
        }

        #region Fields


        /// <summary>
        /// 本地服務物件
        /// </summary>
        SeviceLocator Locator = new SeviceLocator();
        /// <summary>
        /// 原始資料
        /// </summary>
        private IEnumerable<IconModel> OriginalIcons;
        #endregion


        #region Properties

        private string _searchText;
        /// <summary>
        /// 搜尋輸入框
        /// </summary>
        public string SearchText
        {
            get { return _searchText; }
            set 
            { 
                _searchText = value; 
                RaisePropertyChanged(nameof(SearchText));
                OnSearchTextChanged();
            }
        }
        /// <summary>
        /// 當搜尋輸入框發生變化時，修改搜尋匹配的圖標集合
        /// </summary>
        private void OnSearchTextChanged()
        {
            if(string.IsNullOrEmpty(SearchText))
            {
                SetIconModels = new ObservableCollection<IconModel>(OriginalIcons);
                return;
            }

            // 根據輸入值，搜尋原始資料中相同的圖標，並更新界面的綁定資料源
            SetIconModels = new ObservableCollection<IconModel>(OriginalIcons.Where(item => item.IconName.ToLowerInvariant().Contains(SearchText.ToLowerInvariant())));
        }

        private IconModel _selectedIcon;
        /// <summary>
        /// 當前選中的圖標
        /// </summary>
        public IconModel SelectedIcon
        {
            get { return _selectedIcon; }
            set { _selectedIcon = value; OnPropertyChanged(); }
        }


        private ObservableCollection<IconModel> _iconModels;
        /// <summary>
        /// 當前搜索匹配的圖標集合
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

        private ObservableCollection<IconModel> _setIconModels;
        /// <summary>
        /// 當前搜索匹配的圖標集合
        /// 方法二、Icon 資料集（封裝 OnPropertyChanged）
        /// </summary>
        public ObservableCollection<IconModel> SetIconModels
        {
            get { return _setIconModels; }
            set
            {
                Set(ref _setIconModels, value);
            }
        }

        #endregion


        #region Command
        /// <summary>
        /// 搜尋命令
        /// </summary>
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

        public RelayCommand<IconModel> ChooseCommand
        {
            get
            {
                return new RelayCommand<IconModel>(arg =>
                {
                    SelectedIcon = arg; 
                });
            }
        }
        #endregion


        #region Methods
        /// <summary>
        /// 獲取 model 物件鐘的屬性資訊
        /// </summary>
        /// <typeparam name="T">物件類型</typeparam>
        /// <param name="model">物件</param>
        /// <returns></returns>
        public List<IconModel> FindDititsInfo<T>(T model)
        {
            List<IconModel> icons = new List<IconModel>();
            var newType = model.GetType();
            foreach(var item in newType.GetProperties())
            {
                IconModel icon = new IconModel();
                icon.IconName = item.Name;
                icon.IconData = item.GetValue(model).ToString();
                icons.Add(icon);
            }
            return icons;
        }
        #endregion
    }
}

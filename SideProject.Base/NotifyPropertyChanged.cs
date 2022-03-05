using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SideProject.Base
{
    /// <summary>
    /// 通知屬性更改基礎類，ViewModel 需要通知界面時，需要繼承 <see cref="INotifyPropertyChanged"/>這個接口
    /// </summary>
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (s, e) => { };

        /// <summary>
        /// 通知屬性更改
        /// </summary>
        /// <param name="propertyName"></param>
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 通知屬性更改，可自動抓取 Property Name
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            RaisePropertyChanged(propertyName);
        }

        /// <summary>
        /// 利用泛型，簡化屬性 set 功能
        /// </summary>
        /// <typeparam name="T">屬性類型</typeparam>
        /// <param name="field">字段</param>
        /// <param name="value">設定值</param>
        /// <param name="propertyName">屬性名稱</param>
        /// <returns></returns>
        protected bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if(EqualityComparer<T>.Default.Equals(field, value)) return false;

            field = value;

            RaisePropertyChanged(propertyName);

            return true;
        }

        /// <summary>
        /// 通知所有屬性更新（通知繼承當前類別所有的屬性）
        /// </summary>
        protected void RaiseAllChanged()
        {
            RaisePropertyChanged("");
        }
    }
}

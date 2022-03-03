using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SideProject.Base
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 通知屬性更改
        /// </summary>
        /// <param name="propertyName"></param>
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 通知屬性更改，可以不用每個屬性增加名稱
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field">私有字段</param>
        /// <param name="value">設定值</param>
        /// <param name="PropertyName"></param>
        /// <returns></returns>
        protected bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;

            field = value;

            RaisePropertyChanged(PropertyName);

            return true;
        }


        /// <summary>
        /// 通知 繼承的類別內部所有的屬性，進行更新。（重點在名稱沒有指定）
        /// </summary>
        protected void RaiseAllChanged()
        {
            RaisePropertyChanged("");
        }
    }
}

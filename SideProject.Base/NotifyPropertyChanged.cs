using System.ComponentModel;

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
    }
}

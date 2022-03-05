using System;
using System.Windows.Input;

namespace SideProject.Base
{
    public class RelayCommand : ICommand
    {
        Action action;
        Action<object> mOneParamAction;

        public RelayCommand(Action action)
        {
            this.action = action;
        }

        public RelayCommand(Action<object> action)
        {
            this.mOneParamAction = action;
        }

        public event EventHandler CanExecuteChanged = (s, e) => { };

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action?.Invoke();
            mOneParamAction?.Invoke(parameter);
        }
    }

    public class RelayCommand<T> : ICommand
    {
        Action<T> action;

        public RelayCommand(Action<T> action)
        {
            this.action = action;
        }

        public event EventHandler CanExecuteChanged = (s, e) => { };

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action?.Invoke((T)parameter);
        }
    }
}

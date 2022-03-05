using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF_Mvvm
{
    /// <summary>
    /// 依照步驟 1a 或 1b 執行，然後執行步驟 2，以便在 XAML 檔中使用此自訂控制項。
    ///
    /// 步驟 1a) 於存在目前專案的 XAML 檔中使用此自訂控制項。
    /// 加入此 XmlNamespace 屬性至標記檔案的根項目為 
    ///要使用的: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:WPF_Mvvm"
    ///
    ///
    /// 步驟 1b) 於存在其他專案的 XAML 檔中使用此自訂控制項。
    /// 加入此 XmlNamespace 屬性至標記檔案的根項目為 
    ///要使用的: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:WPF_Mvvm;assembly=WPF_Mvvm"
    ///
    /// 您還必須將 XAML 檔所在專案的專案參考加入
    /// 此專案並重建，以免發生編譯錯誤: 
    ///
    ///     在 [方案總管] 中以滑鼠右鍵按一下目標專案，並按一下
    ///     [加入參考]->[專案]->[瀏覽並選取此專案]
    ///
    ///
    /// 步驟 2)
    /// 開始使用 XAML 檔案中的控制項。
    ///
    ///     <MyNamespace:CommandCustomControl/>
    ///
    /// </summary>
    public class CommandCustomControl : ContentControl
    {
        static CommandCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CommandCustomControl), new FrameworkPropertyMetadata(typeof(CommandCustomControl)));
        }
        public CommandCustomControl()
        {
            MouseLeftButtonDown += CommandControlCC_MouseLeftButtonDown;
        }

        private void CommandControlCC_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(Command != null)
            {
                if (Command.CanExecute(CommandParameter))
                {
                    Command.Execute(CommandParameter);
                }
            }
        }

        #region Dependency Properties
        /// <summary>
        /// 命令
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                nameof(Command), 
                typeof(ICommand), 
                typeof(CommandCustomControl), 
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None));

        /// <summary>
        /// 命令參數
        /// </summary>
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register(
                nameof(CommandParameter), 
                typeof(object), 
                typeof(CommandCustomControl),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None));
        #endregion
    }
}

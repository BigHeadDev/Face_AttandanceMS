using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
namespace 人脸识别考勤系统.View
{
    /// <summary>
    /// MainMenu.xaml 的交互逻辑
    /// </summary>
    public partial class MainMenu : MetroWindow
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        private static MainWindow mainWindow;
        private static MainAdminWindow mainAdminWindow; 
        private void Menu_Selected(object sender, RoutedEventArgs e)
        {
            int index = (sender as ListView).SelectedIndex;
            (sender as ListView).SelectedIndex = -1;
            switch (index)
            {
                case 0:
                    mainAdminWindow = new MainAdminWindow();
                    mainAdminWindow.Show();
                    //this.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    mainWindow = new MainWindow();
                    mainWindow.Show();
                    //this.Visibility = Visibility.Collapsed;
                    break;
                default:
                    break;
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

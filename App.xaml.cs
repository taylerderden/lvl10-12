using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TRRK
{
    /// <summary>
    /// отлов фатальных ошибок 
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DispatcherUnhandledException += App_DispatchedUnhandledException;
        }
        private void App_DispatchedUnhandledException(object sender,System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Ошибка подключения к базе данных, пожалуйста проверьте подключение к Интернету." + "Если проблему решить не удалось обратитесь к администратору!");
            e.Handled= true;
        }
    }
}

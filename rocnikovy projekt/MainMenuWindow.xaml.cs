using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace rocnikovy_projekt
{
    /// <summary>
    /// Interakční logika pro MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        // TOTO TI TAM CHYBĚLO! 
        // Tento blok propojuje C# kód s XAML designem.
        public MainMenuWindow()
        {
            InitializeComponent();
        }

        public void StartHry_Click(object sender, RoutedEventArgs e)
        {
            MainWindow hra = new MainWindow();
            hra.Show();
            this.Close();
        }

        public void Konec_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
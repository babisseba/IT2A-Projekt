using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace rocnikovy_projekt
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Metoda, která se spustí při kliknutí na jakýkoli hotspot
        private void OnHotspotClick(object sender, RoutedEventArgs e)
        {
            // Získání tlačítka, na které bylo kliknuto
            Button clickedButton = sender as Button;

            // Získání textu, který je uložen v `Tag`
            string feedbackText = clickedButton.Tag.ToString();

            // Nastavení textu v dialogovém okně
            DialogText.Text = feedbackText;

            // Zobrazení dialogového okna
            DialogBox.Visibility = Visibility.Visible;
        }

            private void StartHry_Click(object sender, RoutedEventArgs e)
        {
            MainWindow hra = new MainWindow();
            hra.Show(); // Otevře tvou rozdělanou scénu v cele
            this.Close(); // Zavře menu
        }

        private void Konec_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Vypne program
        }
        private void ZpetMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow menu = new MainMenuWindow();
            menu.Show();
            this.Close();
        }
    }
    }

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
using static System.Net.Mime.MediaTypeNames;

namespace Reiskost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            flightClassTextBox.ToolTip = "Voer de klassen in:\r\n1: Business\r\n2: Standaard\r\n3: Charter";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //input
            string bestemming;
            double vluchtPrijs;
            double verblijfsPrijs;
            double reisPrijs;
            double korting;
            double betalen;
            double baseprice = double.Parse(basePriceTextBox.Text);
            int people = int.Parse(numberOfPersonsTextBox.Text);

            //berekingen
            bestemming = destinationTextBox.Text;
            vluchtPrijs = double.Parse(baseFlightTextBox.Text) * double.Parse(numberOfPersonsTextBox.Text);
            verblijfsPrijs = baseprice * double.Parse(numberOfDaysTextBox1.Text) * people;

            //flightclass calculations
            int flightclass = int.Parse(flightClassTextBox.Text);
            switch (flightclass)
            {
                case 1: //busniss
                    vluchtPrijs *= 1.30f;
                    break;
                case 2:
                    vluchtPrijs = vluchtPrijs;
                    break;
                case 3:
                    vluchtPrijs *= 0.8f;
                    break;
            }

            if (people == 3)
            {
                verblijfsPrijs = (baseprice * 2 + baseprice * 0.5) * double.Parse(numberOfDaysTextBox1.Text);
            }
            else if (people >= 4)
                {
                verblijfsPrijs = (baseprice * 2 + baseprice * 0.5 + (baseprice * 0.3)*(people-3)) * double.Parse(numberOfDaysTextBox1.Text);
            }
            else 
            {
                verblijfsPrijs = baseprice * double.Parse(numberOfDaysTextBox1.Text) * people;
            }

            reisPrijs = vluchtPrijs + verblijfsPrijs;
            korting = reisPrijs / 100 * double.Parse(reductionPercentageTextBox.Text);
            betalen = reisPrijs - korting;

            //output
            resultTextBox.Text = $"REISKOST VOLGENS BESTELLING NAAR {bestemming}\r\n\r\n" +
                $"Totale vluchtprijs: {vluchtPrijs:c}\r\n" +
                $"Totale verblijfprijs: {verblijfsPrijs:c}\r\n" +
                $"totale reisprijs: {reisPrijs:c}\r\n" +
                $"korting: {korting:c}\r\n\r\n" +
                $"Te Betalen: {betalen:c}";

        }
    }
}
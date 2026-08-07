using HibaKovetoWpf.Models;
using HibaKovetoWpf.Services;
using System;
using System.Collections.Generic;
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

namespace HibaKovetoWpf.Views
{
    /// <summary>
    /// Interaction logic for UjHibajegyPage.xaml
    /// </summary>
    public partial class UjHibajegyPage : Page
    {
        public UjHibajegyPage()
        {
            InitializeComponent();
        }

        private void MentesGomb_Click(object sender, RoutedEventArgs e)
        {
            string cim = CimBox.Text.Trim();
            string leiras = LeirasBox.Text.Trim();

            if (cim.Length == 0 || leiras.Length == 0)
            {
                HibaText.Text = "A cím és a leírás nem lehet üres!";
                HibaText.Visibility = Visibility.Visible;
                return;
            }

            var komponensItem = KomponensCombo.SelectedItem as ComboBoxItem;
            ComboBoxItem? sulyossagItem = SulyossagCombo.SelectedItem as ComboBoxItem;

            Hibajegy ujHiba = new Hibajegy
            {
                Cim = cim,
                Leiras = leiras,
                Komponens = komponensItem != null ? komponensItem.Content.ToString() : "",
                Sulyossag = sulyossagItem != null ? sulyossagItem.Content.ToString() : "",
                SurgosBeavatkozas = SurgosCheckBox.IsChecked == true,
                Megoldva = false,
                Bejelentve = DateTime.Now
            };

            HibaTar.HibajegyHozzaadas(ujHiba);

            NavigationService.Navigate(new DashBoardPage());

        }

        private void MegseGomb_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DashBoardPage());
        }
    }
}

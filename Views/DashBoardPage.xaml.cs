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
    /// Interaction logic for DashBoardPage.xaml
    /// </summary>
    public partial class DashBoardPage : Page
    {
        public DashBoardPage()
        {
            InitializeComponent();
            AdatokBetoltese();
        }

        public void AdatokBetoltese()
        {
            int osszes = 0;
            int nyitott = 0;
            int megoldva = 0;

            NyitottHibakListBox.Items.Clear();

            foreach (var hiba in HibaTar.Hibajegyek)
            {
                osszes++;
                if(hiba.Megoldva == true)
                {
                    megoldva++;
                }
                else
                {
                    nyitott++;
                    NyitottHibakListBox.Items.Add(hiba);
                }
            }

            OsszesText.Text = osszes.ToString();
            NyitottText.Text = nyitott.ToString();
            MegoldvaText.Text = megoldva.ToString();

            int szazalek = 0;
            if (osszes > 0)
            {
                szazalek = (megoldva * 100) / osszes;
            }

            MegoldottsagBar.Value = szazalek;
            MegoldottsagText.Text = szazalek+"%";
        }
        private void UjHibajegyButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UjHibajegyPage());
        }

        private void OsszesHibajegyButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HibaListaPage());
        }
    }
}

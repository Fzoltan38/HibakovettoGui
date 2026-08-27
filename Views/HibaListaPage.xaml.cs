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
    /// Interaction logic for HibaListaPage.xaml
    /// </summary>
    public partial class HibaListaPage : Page
    {
        private bool _listaFrissitesFolyamatban;
        private bool _oldalBetoltve;

        public HibaListaPage()
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                _oldalBetoltve = true;
                ListaFrissites();
            };
        }

        private void ListaFrissites()
        {
            _listaFrissitesFolyamatban = true;

            string szuro = "Összes";
            ComboBoxItem? kivalasztott = SzuroCombo.SelectedItem as ComboBoxItem;
            if (kivalasztott != null && kivalasztott.Content != null)
            {
                szuro = kivalasztott.Content.ToString() ?? "Összes";
            }

            HibaListBox.Items.Clear();

            int szurtOsszes = 0;
            int szurtMegoldva = 0;

            foreach (Hibajegy hiba in HibaTar.Hibajegyek)
            {
                bool megjelenitendo = false;

                if (szuro == "Összes")
                {
                    megjelenitendo = true;
                }
                else if (szuro == "Nyitott" && !hiba.Megoldva)
                {
                    megjelenitendo = true;
                }
                else if (szuro == "Megoldott" && hiba.Megoldva)
                {
                    megjelenitendo = true;
                }

                if (megjelenitendo)
                {
                    HibaListBox.Items.Add(hiba);
                    szurtOsszes++;
                    if (hiba.Megoldva)
                    {
                        szurtMegoldva++;
                    }
                }
            }

            int szazalek = 0;
            if (szurtOsszes > 0)
            {
                szazalek = (szurtMegoldva * 100) / szurtOsszes;
            }
            SzuroProgressBar.Value = szazalek;
            SzuroSzazalekText.Text = szazalek + "%";

            ReszletekTorlese();

            _listaFrissitesFolyamatban = false;
        }

        private void ReszletekTorlese()
        {
            ReszletCimText.Text = "";
            ReszletLeirasText.Text = "";
            ReszletKomponensText.Text = "";
            ReszletSulyossagText.Text = "";
            ReszletBejelentveText.Text = "";
            ReszletMegoldvaCheckBox.IsChecked = false;
            ReszletMegoldvaCheckBox.IsEnabled = false;
        }

        private void SzuroCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_oldalBetoltve && !_listaFrissitesFolyamatban)
            {
                ListaFrissites();
            }
        }

        private void HibaListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Hibajegy? kivalasztott = HibaListBox.SelectedItem as Hibajegy;
            if (kivalasztott == null)
            {
                ReszletekTorlese();
                return;
            }

            _listaFrissitesFolyamatban = true;

            ReszletCimText.Text = kivalasztott.Cim;
            ReszletLeirasText.Text = kivalasztott.Leiras;
            ReszletKomponensText.Text = kivalasztott.Komponens;
            ReszletSulyossagText.Text = kivalasztott.Sulyossag;
            ReszletBejelentveText.Text = kivalasztott.Bejelentve.ToString();
            ReszletMegoldvaCheckBox.IsEnabled = true;
            ReszletMegoldvaCheckBox.IsChecked = kivalasztott.Megoldva;

            _listaFrissitesFolyamatban = false;
        }

        private void ReszletMegoldvaCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (_listaFrissitesFolyamatban)
            {
                return;
            }

            Hibajegy? kivalasztott = HibaListBox.SelectedItem as Hibajegy;
            if (kivalasztott == null)
            {
                return;
            }

            kivalasztott.Megoldva = ReszletMegoldvaCheckBox.IsChecked == true;
            ListaFrissites();
        }

        private void VisszaGomb_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new DashBoardPage());
        }
    }
}

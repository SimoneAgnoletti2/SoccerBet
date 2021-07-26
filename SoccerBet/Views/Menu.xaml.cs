using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SoccerBet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent(); 
            navigationDrawer.DrawerWidth = 200;
            hamburgerButton.Image = (FileImageSource)ImageSource.FromFile("burgericon.png");
            List<string> list = new List<string>();
            list.Add("Menu");
            list.Add("Nuova Schedina");
            list.Add("Schedine In Corso");
            list.Add("Storico Schedine");
            list.Add("Classifiche Campionati");
            list.Add("Classifiche Giocatori");
            list.Add("Impostazioni");
            list.Add("Logout");

            listView.ItemsSource = list;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            navigationDrawer.ToggleDrawer();

        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem.ToString() == "Nuova Schedina")
            {
                navigationDrawer.ContentView = new NuovaSchedina().Content;
                headerLabel.Text = "Nuova Schedina";
            }
            else if (e.SelectedItem.ToString() == "Schedine In Corso")
            {
                navigationDrawer.ContentView = new SchedineInCorso().Content;
                headerLabel.Text = "Schedine In Corso";
            }
            else if (e.SelectedItem.ToString() == "Storico Schedine")
            {
                navigationDrawer.ContentView = new StoricoSchedine().Content;
                headerLabel.Text = "Storico Schedine";
            }
            else if (e.SelectedItem.ToString() == "Classifiche Campionati")
            {
                navigationDrawer.ContentView = new ClassificheCampionati().Content;
                headerLabel.Text = "Classifiche Campionati";
            }
            else if (e.SelectedItem.ToString() == "Classifiche Giocatori")
            {
                navigationDrawer.ContentView = new ClassificheGiocatori().Content;
                headerLabel.Text = "Classifiche Giocatori";
            }
            else if (e.SelectedItem.ToString() == "Impostazioni")
            {
                navigationDrawer.ContentView = new Impostazioni().Content;
                headerLabel.Text = "Impostazioni";
            }
            else if (e.SelectedItem.ToString() == "Logout")
            {
                navigationDrawer.ContentView = new Logout().Content;
                headerLabel.Text = "Logout";
            }
            navigationDrawer.ToggleDrawer();


        }
    }
}
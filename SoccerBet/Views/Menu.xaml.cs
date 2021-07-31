using SoccerBet.Models;
using SoccerBet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
            BindingContext = new MenuViewModel();
            navigationDrawer.DrawerWidth = 300;
            navigationDrawer.ContentView = new Home().Content;
            hamburgerButton.ImageSource = (FileImageSource)ImageSource.FromFile("burgericon.png");
            Nome.Text = Preferences.Get("Nome", "");
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            navigationDrawer.ToggleDrawer();

        }

        private async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var temp = e.SelectedItem as MenuItemCustom;
            if (temp.Nome == "Home")
            {
                navigationDrawer.ContentView = new Home().Content;
                headerLabel.Text = "Home";
                navigationDrawer.ToggleDrawer();
            }
            else if (temp.Nome == "New Tickets")
            {
                navigationDrawer.ContentView = new NuovaSchedina();
                headerLabel.Text = "New Tickets";
                navigationDrawer.ToggleDrawer();
            }
            else if (temp.Nome == "Live Tickets")
            {
                navigationDrawer.ContentView = new SchedineInCorso();
                headerLabel.Text = "Live Tickets";
                navigationDrawer.ToggleDrawer();
            }
            else if (temp.Nome == "Historical Tickets")
            {
                navigationDrawer.ContentView = new StoricoSchedine();
                headerLabel.Text = "Historical Tickets";
                navigationDrawer.ToggleDrawer();
            }
            else if (temp.Nome == "Standings")
            {
                navigationDrawer.ContentView = new ClassificheCampionati();
                headerLabel.Text = "Standings";
                navigationDrawer.ToggleDrawer();
            }
            else if (temp.Nome == "Standings Players")
            {
                navigationDrawer.ContentView = new ClassificheGiocatori();
                headerLabel.Text = "Standings Players";
                navigationDrawer.ToggleDrawer();
            }
            else if (temp.Nome == "Tools")
            {
                navigationDrawer.ContentView = new Impostazioni();
                headerLabel.Text = "Tools";
                navigationDrawer.ToggleDrawer();
            }
            else if (temp.Nome == "Logout")
            {
                navigationDrawer.ContentView = new Logout();
                headerLabel.Text = "Logout";
            }


        }
    }
}
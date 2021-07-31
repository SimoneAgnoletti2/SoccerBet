using SoccerBet.Controls;
using SoccerBet.Models;
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
    public partial class Logout : ContentView
    {
        public Logout()
        {
            InitializeComponent();
            DatabaseUser dbu = new DatabaseUser();
            Task<Utente> task = Task.Run<Utente>(async () => await dbu.setMantainUserDisable());

            Application.Current.MainPage = new NavigationPage(new Login());
        }
    }
}
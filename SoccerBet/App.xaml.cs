using SoccerBet.Controls;
using SoccerBet.Models;
using SoccerBet.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SoccerBet
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DatabaseUser dbu = new DatabaseUser();
            Task<Utente> task = Task.Run<Utente>(async () => await dbu.getUserMantain());
            var user = task.Result;
            if (user != null)
            {
                Preferences.Set("Nome", user.Nome); 
                Application.Current.MainPage = new Views.Menu();
            }
            else
            {
                MainPage = new NavigationPage(new Login());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

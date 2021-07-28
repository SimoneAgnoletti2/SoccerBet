
using SoccerBet.Controls;
using SoccerBet.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SoccerBet.ViewModels
{
    public class ClassificheCampionatiViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Paese> listaCountry { get; set; }
        public ObservableCollection<Paese> ListaCountry
        {
            get { return listaCountry; }
            set
            {
                if (listaCountry != value)
                    listaCountry = value;
                OnPropertyChanged("ListaCountry");
            }
        }
        public ClassificheCampionatiViewModel()
        {

            DatabasePaesi dtp = new DatabasePaesi();
            Task<List<Paese>> task = Task.Run<List<Paese>>(async () => await dtp.getPaesi());
            List<Paese> lsc = new List<Paese>();
            listaCountry = new ObservableCollection<Paese>();
            lsc = task.Result;
            foreach (Paese p in lsc)
            {
                ListaCountry.Add(p);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}



using SoccerBet.Controls;
using SoccerBet.Models;
using Syncfusion.ListView.XForms;
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
        private Command<ItemSelectionChangedEventArgs> selectionChangedCommand;
        public Command<ItemSelectionChangedEventArgs> SelectionChanged
        {
            get { return selectionChangedCommand; }
            set { selectionChangedCommand = value; }
        }
        private void OnSelectionChanged(ItemSelectionChangedEventArgs eventArgs)
        {

        }
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
                p.LinkImage = "Bandiere/" + p.LinkImage;
                ListaCountry.Add(p);
            }
            SelectionChanged = new Command<ItemSelectionChangedEventArgs>(OnSelectionChanged);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        

        private Command preferred;
        public Command Preferred
        {
            get { return this.preferred; }
            set { this.preferred = value; }
        }


    }
}


using SoccerBet.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace SoccerBet.ViewModels
{
    public class MenuViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<MenuItemCustom> menuItem { get; set; }

        public ObservableCollection<MenuItemCustom> MenuItem
        {
            get { return menuItem; }
            set
            {
                if (menuItem != value)
                    menuItem = value;
                OnPropertyChanged("MenuItem");
            }
        }
        
        public MenuViewModel()
        {
            menuItem = new ObservableCollection<MenuItemCustom>();
            MenuItemCustom mi = new MenuItemCustom("menu.png", "Home");
            menuItem.Add(mi);

            mi = new MenuItemCustom("newtickets.png", "New Tickets");
            menuItem.Add(mi);


            mi = new MenuItemCustom("reload.png", "Live Tickets");
            menuItem.Add(mi);


            mi = new MenuItemCustom("storico.png", "Historical Tickets");
            menuItem.Add(mi);


            mi = new MenuItemCustom("lader.png", "Standings");
            menuItem.Add(mi);


            mi = new MenuItemCustom("ladder.png", "Standings Players");
            menuItem.Add(mi);


            mi = new MenuItemCustom("tools.png", "Tools");
            menuItem.Add(mi);


            mi = new MenuItemCustom("logout.png", "Logout");
            menuItem.Add(mi);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using SampleBrowser.Core;
using SoccerBet.ViewModels;
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
    public partial class ClassificheCampionati : ContentView
    {
        public ClassificheCampionati()
        {
            InitializeComponent();
            BindingContext = new ClassificheCampionatiViewModel();
        }

        private void ListView_SelectionChanged(object sender, Syncfusion.ListView.XForms.ItemSelectionChangedEventArgs e)
        {
        }

        private void listView_ItemHolding(object sender, Syncfusion.ListView.XForms.ItemHoldingEventArgs e)
        {
            var lista = e.ItemData;
        }

        private void listView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            var lista = e.ItemData;
        }
    }
}
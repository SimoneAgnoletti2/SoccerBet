using Syncfusion.ListView.XForms;
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
    public partial class ClassificheCampionati2 : ContentPage
    {
        public ClassificheCampionati2()
        {
            InitializeComponent();
        }

        private void listView_ScrollStateChanged(object sender, Syncfusion.ListView.XForms.ScrollStateChangedEventArgs e)
        {
            if (e.ScrollState == ScrollState.Idle)
            {
                //foreach (var item in this.viewModel.ContactsInfo)
                //{
                //    item.Animation = AnimationEasing.Linear;
                //}
            }
            else
            {
                //foreach (var item in this.viewModel.ContactsInfo)
                //{
                //    item.Animation = AnimationEasing.None;
                //}
            }
        }
    }
}
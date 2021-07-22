using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using System.Reflection;

using Syncfusion.SfDataGrid.XForms.UWP;

using Syncfusion.SfPullToRefresh.XForms.UWP;

using Syncfusion.ListView.XForms.UWP;

using Syncfusion.XForms.UWP.PopupLayout;

namespace SoccerBet.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDc2NzcyQDMxMzkyZTMyMmUzMG9TTUd3dmNoTDFTK2tnM1I5ZWFWencraVoreVpsTG01ZHJ3blJJZnI1U1E9");
            this.InitializeComponent();

            

            SfPopupLayoutRenderer.Init();

			SfListViewRenderer.Init();

			SfPullToRefreshRenderer.Init();

			SfDataGridRenderer.Init();

            

            LoadApplication(new SoccerBet.App());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IntecLoginPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageXample : MasterDetailPage
    {
        public MasterDetailPageXample()
        {
            InitializeComponent();
            Detail = new NavigationPage(new HomeOption());
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new HomeOption());
        }

        private void ButtonClicked2(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Option1());
        }

        private void ButtonClicked3(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Option2());

        }
    }
}
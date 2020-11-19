using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IntecLoginPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageXampleMaster : ContentPage
    {
        public ListView ListView;

        public MasterDetailPageXampleMaster()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPageXampleMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailPageXampleMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPageXampleMasterMenuItem> MenuItems { get; set; }

            public MasterDetailPageXampleMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPageXampleMasterMenuItem>(new[]
                {
                    new MasterDetailPageXampleMasterMenuItem { Id = 0, Title = "Page 1" },
                    new MasterDetailPageXampleMasterMenuItem { Id = 1, Title = "Page 2" },
                    new MasterDetailPageXampleMasterMenuItem { Id = 2, Title = "Page 3" },
                    new MasterDetailPageXampleMasterMenuItem { Id = 3, Title = "Page 4" },
                    new MasterDetailPageXampleMasterMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}
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

namespace gogoal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GoGoalMaster : ContentPage
    {
        public ListView ListView;

        public GoGoalMaster()
        {
            InitializeComponent();

            BindingContext = new GoGoalMasterViewModel();
            ListView = MenuItemsListView;
        }

        class GoGoalMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<GoGoalMenuItem> MenuItems { get; set; }

            public GoGoalMasterViewModel()
            {
                MenuItems = new ObservableCollection<GoGoalMenuItem>(new[]
                {
                    new GoGoalMenuItem("Today", "calendar.png", typeof(Today)),
                    new GoGoalMenuItem ("Goals", "goals.png", typeof(Goals)),
                    new GoGoalMenuItem ("Grocery", "grocery.png", typeof(Goals)),
                    new GoGoalMenuItem ("QuickNotes", "note.png", typeof(Goals)),
                    new GoGoalMenuItem ("Settings", "settings.png", typeof(Goals))
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

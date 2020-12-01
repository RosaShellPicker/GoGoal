using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using System.Collections.Generic;
namespace gogoal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Today : ContentPage
    {
        public Today()
        {
            InitializeComponent();
            DateTime dateToday = DateTime.Now;
            this.BindingContext = new TodayViewModel(dateToday);
        }

        public Today(DateTime selectedDate)
        {
            InitializeComponent();
            this.BindingContext = new TodayViewModel(selectedDate);
        }
    }
}

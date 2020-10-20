using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace gogoal
{
    public partial class EditGoalPage : ContentPage
    {
        public DateTime Today { get { return DateTime.Now; }}

        public EditGoalPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}

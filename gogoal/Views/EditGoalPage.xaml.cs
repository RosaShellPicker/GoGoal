using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace gogoal
{
    public partial class EditGoalPage : ContentPage
    {
        public EditGoalPage()
        {
            InitializeComponent();

            this.BindingContext = new EditGoalViewModel(); ;
        }

        public EditGoalPage(GoalModel goal)
        {
            InitializeComponent();
            this.BindingContext = new EditGoalViewModel(goal);
        }
    }
}

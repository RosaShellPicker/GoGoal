using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace gogoal
{
    public partial class EditGoalPage : ContentPage
    {
        public DateTime Today { get { return DateTime.Now; }}

        public GoalModel GoalModel { get; set; }

        public EditGoalPage()
        {
            InitializeComponent();
            if (GoalModel == null)
            {
                GoalModel = new GoalModel.Builder(Guid.NewGuid(), "A").Build();
            }
            
            BindingContext = this;
        }

        async void newToDoBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            await this.Navigation.PushAsync(new EditToDoItem(GoalModel.GoalId, GoalModel.Title));
        }
    }
}

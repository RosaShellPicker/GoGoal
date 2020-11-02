using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace gogoal
{
    public partial class EditToDoItem : ContentPage
    {
        public string  GoalName { get; set; }
        public Guid? goalId;
        public EditToDoItem(Guid? goalId, string goalName)
        {
            InitializeComponent();
            this.goalId = goalId;
            GoalName = goalName;
            BindingContext = this;
        }
    }
}

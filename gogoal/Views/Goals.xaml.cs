using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace gogoal
{
    public partial class Goals : ContentPage
    {
        public List<GoalModel> GoalsSource { get; set; } = new List<GoalModel>();

        public Goals()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadDataAsync();
        }
        async void LoadDataAsync()
        {
            GoalsSource = await App.Database.GetGoals();
            GoalList.ItemsSource = GoalsSource;
        }

        async void NewGoal_Clicked(System.Object sender, System.EventArgs e)
        {
            await this.Navigation.PushAsync(new EditGoalPage());
        }

        async void GoalList_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            GoalModel goal = (GoalModel)e.SelectedItem;
            await this.Navigation.PushAsync(new EditGoalPage(goal));
        }
    }
}

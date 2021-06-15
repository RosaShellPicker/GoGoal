using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace gogoal
{
    public partial class Goals : ContentPage
    {
        public List<GoalModel> GoalsSource { get; set; } = new List<GoalModel>();
        //{
        //    new GoalModel.Builder(Guid.NewGuid(), "Happy family")
        //    .WithDetails(null)
        //    .WithProgress(0)
        //    .WithGoalStatus(GoalStatusEnumeration.Created)
        //    .Build(),
        //    new GoalModel.Builder(Guid.NewGuid(), "Healthier life")
        //    .WithDetails(null)
        //    .WithProgress(0)
        //    .WithGoalStatus(GoalStatusEnumeration.Created)
        //    .Build(),
        //    new GoalModel.Builder(Guid.NewGuid(), "Reading more books")
        //    .WithDetails(null)
        //    .WithProgress(0)
        //    .WithGoalStatus(GoalStatusEnumeration.Created)
        //    .Build(),
        //    new GoalModel.Builder(Guid.NewGuid(), "Help more people")
        //    .WithDetails(null)
        //    .WithProgress(0)
        //    .WithGoalStatus(GoalStatusEnumeration.Created)
        //    .Build(),
        //    new GoalModel.Builder(Guid.NewGuid(), "Create more relationships")
        //    .WithDetails(null)
        //    .WithProgress(0)
        //    .WithGoalStatus(GoalStatusEnumeration.Created)
        //    .Build()
        //};

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
    }
}

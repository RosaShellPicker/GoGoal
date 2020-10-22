using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace gogoal
{
    public partial class Goals : ContentPage
    {
        public ObservableCollection<GoalModel> GoalsCollection { get; } = new ObservableCollection<GoalModel>()
        {
            new GoalModel.Builder(Guid.NewGuid(), "Happy family")
            .WithDetails(null)
            .WithProgress(0)
            .WithGoalStatus(GoalStatusEnumeration.Created)
            .WithGoalStages(null)
            .Build(),
            new GoalModel.Builder(Guid.NewGuid(), "Healthier life")
            .WithDetails(null)
            .WithProgress(0)
            .WithGoalStatus(GoalStatusEnumeration.Created)
            .WithGoalStages(null)
            .Build(),
            new GoalModel.Builder(Guid.NewGuid(), "Reading more books")
            .WithDetails(null)
            .WithProgress(0)
            .WithGoalStatus(GoalStatusEnumeration.Created)
            .WithGoalStages(null)
            .Build(),
            new GoalModel.Builder(Guid.NewGuid(), "Help more people")
            .WithDetails(null)
            .WithProgress(0)
            .WithGoalStatus(GoalStatusEnumeration.Created)
            .WithGoalStages(null)
            .Build(),
            new GoalModel.Builder(Guid.NewGuid(), "Create more relationships")
            .WithDetails(null)
            .WithProgress(0)
            .WithGoalStatus(GoalStatusEnumeration.Created)
            .WithGoalStages(null)
            .Build()
        };

        public Goals()
        {
            InitializeComponent();
            GoalList.ItemsSource = GoalsCollection;
        }

        async void NewGoal_Clicked(System.Object sender, System.EventArgs e)
        {
            await this.Navigation.PushAsync(new EditGoalPage());
        }
    }
}

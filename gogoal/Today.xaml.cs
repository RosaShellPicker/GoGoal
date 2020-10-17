using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
namespace gogoal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Today : TabbedPage
    {
        public ObservableCollection<ToDoItemGroupedModel> ToDoItemsGrouped { get; } = new ObservableCollection<ToDoItemGroupedModel>();

        public ObservableCollection<GoalModel> Goals { get; } = new ObservableCollection<GoalModel>()
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

        public Today()
        {
            InitializeComponent();
            var goalTodoItems = new ToDoItemGroupedModel("Goal","G");
            var generalToDoItems = new ToDoItemGroupedModel("General", "GNR");
            goalTodoItems.Add(
                new ToDoItemModel.Builder(Guid.NewGuid(), "Call Erica's house owner")
                .WithColor("green")
                .WithDetails("details")
                .WithDueDate(DateTime.Now.AddDays(7))
                .WithGoalId(Guid.NewGuid())
                .WithImportantLevel(ImportantLevelEnumeration.ImportantNonImergency)
                .WithIsChecked(true)
                .Build());
            goalTodoItems.Add(
                 new ToDoItemModel.Builder(Guid.NewGuid(), "Grooming Tony")
                .WithColor("red")
                .WithDetails("details")
                .WithDueDate(DateTime.Now.AddDays(7))
                .WithGoalId(Guid.NewGuid())
                .WithImportantLevel(ImportantLevelEnumeration.ImergencyNonimportant)
                .WithIsChecked(false)
                .Build());
            generalToDoItems.Add(
                new ToDoItemModel.Builder(Guid.NewGuid(), "Call Erica's house owner")
                .WithColor("green")
                .WithDetails("details")
                .WithDueDate(DateTime.Now.AddDays(7))
                .WithGoalId(null)
                .WithImportantLevel(ImportantLevelEnumeration.ImportantNonImergency)
                .WithIsChecked(true)
                .Build());
            generalToDoItems.Add(
                 new ToDoItemModel.Builder(Guid.NewGuid(), "Grooming Tony")
                .WithColor("red")
                .WithDetails("details")
                .WithDueDate(DateTime.Now.AddDays(7))
                .WithGoalId(null)
                .WithImportantLevel(ImportantLevelEnumeration.ImergencyNonimportant)
                .WithIsChecked(false)
                .Build());
            ToDoItemsGrouped.Add(goalTodoItems);
            ToDoItemsGrouped.Add(generalToDoItems);
            TodayTodoList.ItemsSource = ToDoItemsGrouped;
            GoalList.ItemsSource = Goals;
        }

        void TodoItemEntry_Completed(System.Object sender, System.EventArgs e)
        {
            if (String.IsNullOrEmpty(((Entry)sender).Text))
                return;
            ToDoItemsGrouped[1].Add(
                new ToDoItemModel.Builder(Guid.NewGuid(), ((Entry)sender).Text)
                .WithColor(null)
                .WithDetails(null)
                .WithDueDate(DateTime.Today.AddDays(1))
                .WithGoalId(null)
                .WithImportantLevel(ImportantLevelEnumeration.Undefined)
                .WithIsChecked(false)
                .Build());
            ((Entry)sender).Text = null;
        }
    }
}

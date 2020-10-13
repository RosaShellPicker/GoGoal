using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
namespace gogoal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Today : TabbedPage
    {
        public ObservableCollection<ToDoItemModel> ToDoItems { get; } = new ObservableCollection<ToDoItemModel>()
        {
            new ToDoItemModel.Builder(Guid.NewGuid(), "Call Erica's house owner")
            .WithColor("green")
            .WithDetails("details")
            .WithDueDate(DateTime.Now.AddDays(7))
            .WithGoalId(Guid.NewGuid())
            .WithImportantLevel(ImportantLevelEnumeration.ImportantNonImergency)
            .WithIsChecked(true)
            .Build(),
            new ToDoItemModel.Builder(Guid.NewGuid(), "Grooming Tony")
            .WithColor("red")
            .WithDetails("details")
            .WithDueDate(DateTime.Now.AddDays(7))
            .WithGoalId(Guid.NewGuid())
            .WithImportantLevel(ImportantLevelEnumeration.ImergencyNonimportant)
            .WithIsChecked(false)
            .Build(),
            new ToDoItemModel.Builder(Guid.NewGuid(), "Grooming Tony")
            .WithColor("red")
            .WithDetails("details")
            .WithDueDate(DateTime.Now.AddDays(7))
            .WithGoalId(Guid.NewGuid())
            .WithImportantLevel(ImportantLevelEnumeration.ImergencyNonimportant)
            .WithIsChecked(false)
            .Build(),
            new ToDoItemModel.Builder(Guid.NewGuid(), "Grooming Tony")
            .WithColor("red")
            .WithDetails("details")
            .WithDueDate(DateTime.Now.AddDays(7))
            .WithGoalId(Guid.NewGuid())
            .WithImportantLevel(ImportantLevelEnumeration.ImergencyNonimportant)
            .WithIsChecked(false)
            .Build(),
            new ToDoItemModel.Builder(Guid.NewGuid(), "Grooming Tony")
            .WithColor("red")
            .WithDetails("details")
            .WithDueDate(DateTime.Now.AddDays(7))
            .WithGoalId(Guid.NewGuid())
            .WithImportantLevel(ImportantLevelEnumeration.ImergencyNonimportant)
            .WithIsChecked(false)
            .Build()
        };

        public ObservableCollection<GoalModel> Goals { get; } = new ObservableCollection<GoalModel>()
        {
            new GoalModel.Builder(Guid.NewGuid(), "Happy family")
            .WithChildrenGoals(null)
            .WithDetails(null)
            .WithParentGoalId(null)
            .WithProgress(0)
            .WithGoalStatus(GoalStatusEnumeration.Created)
            .WithToDoItems(null)
            .Build(),
            new GoalModel.Builder(Guid.NewGuid(), "Healthier life")
            .WithChildrenGoals(null)
            .WithDetails(null)
            .WithParentGoalId(null)
            .WithProgress(0)
            .WithGoalStatus(GoalStatusEnumeration.Created)
            .WithToDoItems(null)
            .Build(),
            new GoalModel.Builder(Guid.NewGuid(), "Reading more books")
            .WithChildrenGoals(null)
            .WithDetails(null)
            .WithParentGoalId(null)
            .WithProgress(0)
            .WithGoalStatus(GoalStatusEnumeration.Created)
            .WithToDoItems(null)
            .Build(),
            new GoalModel.Builder(Guid.NewGuid(), "Help more people")
            .WithChildrenGoals(null)
            .WithDetails(null)
            .WithParentGoalId(null)
            .WithProgress(0)
            .WithGoalStatus(GoalStatusEnumeration.Created)
            .WithToDoItems(null)
            .Build(),
            new GoalModel.Builder(Guid.NewGuid(), "Create more relationships")
            .WithChildrenGoals(null)
            .WithDetails(null)
            .WithParentGoalId(null)
            .WithProgress(0)
            .WithGoalStatus(GoalStatusEnumeration.Created)
            .WithToDoItems(null)
            .Build()
        };

        public Today()
        {
            InitializeComponent();
            TodayTodoList.ItemsSource = ToDoItems;
            GoalList.ItemsSource = Goals;
        }

        void TodoItemEntry_Completed(System.Object sender, System.EventArgs e)
        {
            if (String.IsNullOrEmpty(((Entry)sender).Text))
                return;

            ToDoItems.Add(
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

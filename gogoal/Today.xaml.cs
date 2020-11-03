using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
namespace gogoal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Today : ContentPage
    {
        public ObservableCollection<ToDoItemGroupedModel> ToDoItemsGrouped { get; } = new ObservableCollection<ToDoItemGroupedModel>();

        public DateTime DateToday { get { return DateTime.Now; } }

        public DateTime SelectedDate { get; set; }

        public Today()
        {
            InitializeComponent();
            SelectedDate = DateToday;
            InitializeData();
        }

        public Today(DateTime dateTime)
        {
            InitializeComponent();
            SelectedDate = dateTime;
            InitializeData();
        }

        void InitializeData()
        {
            var goalTodoItems = new ToDoItemGroupedModel("Goal", "G");
            var generalToDoItems = new ToDoItemGroupedModel("General", "GNR");
            goalTodoItems.Add(
                new ToDoItemModel.Builder(Guid.NewGuid(), "Call Erica's house owner")
                .WithColor("green")
                .WithDetails("details")
                .WithStartDate(DateTime.Now.AddDays(7))
                .WithGoalId(Guid.NewGuid())
                .WithImportantLevel(ImportantLevelEnumeration.ImportantNonImergency)
                .WithIsChecked(true)
                .WithIsRepeat(false)
                .WithDuration(new TimeSpan(30, 0, 0, 0, 0))
                .Build());
            goalTodoItems.Add(
                 new ToDoItemModel.Builder(Guid.NewGuid(), "Grooming Tony")
                .WithColor("red")
                .WithDetails("details")
                .WithStartDate(DateTime.Now.AddDays(7))
                .WithGoalId(Guid.NewGuid())
                .WithImportantLevel(ImportantLevelEnumeration.ImergencyNonimportant)
                .WithIsChecked(false)
                .WithIsRepeat(false)
                .WithDuration(new TimeSpan(30, 0, 0, 0, 0))
                .Build());
            generalToDoItems.Add(
                new ToDoItemModel.Builder(Guid.NewGuid(), "Call Erica's house owner")
                .WithColor("green")
                .WithDetails("details")
                .WithStartDate(DateTime.Now.AddDays(7))
                .WithGoalId(null)
                .WithImportantLevel(ImportantLevelEnumeration.ImportantNonImergency)
                .WithIsChecked(true)
                .WithIsRepeat(false)
                .WithDuration(new TimeSpan(30, 0, 0, 0, 0))
                .Build());
            generalToDoItems.Add(
                 new ToDoItemModel.Builder(Guid.NewGuid(), "Grooming Tony")
                .WithColor("red")
                .WithDetails("details")
                .WithStartDate(DateTime.Now.AddDays(7))
                .WithGoalId(null)
                .WithImportantLevel(ImportantLevelEnumeration.ImergencyNonimportant)
                .WithIsChecked(false)
                .WithIsRepeat(false)
                .WithDuration(new TimeSpan(30, 0, 0, 0, 0))
                .Build());
            ToDoItemsGrouped.Add(goalTodoItems);
            ToDoItemsGrouped.Add(generalToDoItems);
            TodayTodoList.ItemsSource = ToDoItemsGrouped;
        }
        
        void DatePicker_DateSelected(System.Object sender, DateChangedEventArgs e)
        {
            //TODO to show todo items for the choosen date
        }

        void TodoItemEntry_Completed(System.Object sender, System.EventArgs e)
        {
            if (String.IsNullOrEmpty(((Entry)sender).Text))
                return;
            ToDoItemsGrouped[1].Add(
                new ToDoItemModel.Builder(Guid.NewGuid(), ((Entry)sender).Text)
                .WithColor(null)
                .WithDetails(null)
                .WithStartDate(DateTime.Today.AddDays(1))
                .WithGoalId(null)
                .WithImportantLevel(ImportantLevelEnumeration.Undefined)
                .WithIsChecked(false)
                .Build());
            ((Entry)sender).Text = null;
        }

        
    }
}

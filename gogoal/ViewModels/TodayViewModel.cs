using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace gogoal
{
    public class TodayViewModel : ExtendedBindableObject
    {
        public DateTime DateToday { get { return DateTime.Now; } }

        private DateTime selectedDate;
        public DateTime SelectedDate
        {
            get
            {
                return selectedDate;
            }
            set
            {
                if(selectedDate != value)
                {
                    selectedDate = value;
                    DateChanged();
                }
            }
        }

        private string entryText;
        public string EntryText
        {
            get
            {
                return entryText;
            }
            set
            {
                if (value != entryText)
                {
                    entryText = value;
                    RaisePropertyChanged(() => EntryText);
                }
            }
        }

        public ObservableCollection<ToDoItemGroupedModel> ToDoItemsGrouped { get; }
            = new ObservableCollection<ToDoItemGroupedModel>();

        public ICommand TextEntryCompleted { private set; get; }


        public TodayViewModel(DateTime dateTime)
        {
            SelectedDate = dateTime;
            InitializeCommand();
            InitializeData();
        }

        void InitializeCommand()
        {
            TextEntryCompleted = new Command( async() => await InsertGeneralTodoItem()
            );

        }

        void DateChanged()
        {
                //TODO to show todo items for the choosen date
                //不刷新页面，只刷新数据，同时控制“Today的显示”
        }

        async Task InsertGeneralTodoItem()
        {
            if (String.IsNullOrEmpty(EntryText))
                return;
            ToDoItemsGrouped[1].Add(
            new ToDoItemModel.Builder(Guid.NewGuid(), EntryText)
            .WithColor(null)
            .WithDetails(null)
            .WithStartDate(DateTime.Today.AddDays(1))
            .WithGoalId(null)
            .WithImportantLevel(ImportantLevelEnumeration.Undefined)
            .WithIsChecked(false)
            .Build());

            //Add data into local database
            await App.Database.InsertItemAsync(new ToDoItemModel.Builder(Guid.NewGuid(), EntryText)
                .WithColor(null)
                .WithDetails(null)
                .WithStartDate(DateTime.Today.AddDays(1))
                .WithGoalId(null)
                .WithImportantLevel(ImportantLevelEnumeration.Undefined)
                .WithIsChecked(false)
                .Build());

            //Set Entry text as null again
            EntryText = null;
        }

        async void InitializeData()
        {
            //TODO Need to Group todoList fetched from database
            List<ToDoItemModel> todoList = await App.Database.GetItemsAsync();
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
        }


    }
}

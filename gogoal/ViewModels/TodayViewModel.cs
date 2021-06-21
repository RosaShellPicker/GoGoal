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
                    selectedDate = value.Date;
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

        public ICommand CheckedChangedCommand { private set; get; }

        //A parameterless contructor for binding ViewModel in Xaml page
        public TodayViewModel()
        {
            SelectedDate = DateToday;
            InitializeCommand();
        }

        public TodayViewModel(DateTime dateTime)
        {
            SelectedDate = dateTime;
            InitializeCommand();
        }

        void InitializeCommand()
        {
            TextEntryCompleted = new Command( async() => await InsertGeneralTodoItem());
            CheckedChangedCommand = new Command<BaseToDoItemModel>((toDoItemModel) => UpdateCheckedStatus(toDoItemModel));
        }

        void DateChanged()
        {
            InitializeData();
        }

        async Task InsertGeneralTodoItem()
        {
            if (String.IsNullOrEmpty(EntryText))
                return;

            var toDoItem = new ToDoItemModel.Builder(Guid.NewGuid(), EntryText, SelectedDate)
            .WithColor(null)
            .WithDetails(null)
            .WithGoalId(null)
            .WithImportantLevel(ImportantLevelEnumeration.NonimportantNonimergency)
            .WithIsChecked(false).Build();

            ToDoItemsGrouped[1].Add(toDoItem);
            
            //Add data into local database
            await App.Database.InsertItemAsync(toDoItem);

            //Set Entry text as null again
            EntryText = null;
        }

        void  UpdateCheckedStatus(BaseToDoItemModel toDoItemModel)
        {
            toDoItemModel.UpdateToDoItemCheckedStatus(toDoItemModel.IsChecked);
        }

        async void InitializeData()
        {
            ToDoItemsGrouped.Clear();//TODO CheckedChanged when this observableCollection changed.
            List<BaseToDoItemModel> todoList = await App.Database.GetGeneralToDoItemsByDateAsync(selectedDate);
            List<RecurringToDoItemModel> recurringToDoItems = await App.Database.GetRecurringToDoItemsByDate(selectedDate);
            var goalTodoItems = new ToDoItemGroupedModel("Goal", "G");
            var generalToDoItems = new ToDoItemGroupedModel("General", "GNR");
            foreach(var item in todoList)
            {
                if (item.GoalId != null)
                    goalTodoItems.Add(item);
                else
                    generalToDoItems.Add(item);
            }
            foreach (var item in recurringToDoItems)
            {
                if (item.GoalId != null)
                    goalTodoItems.Add(item);
                else
                    generalToDoItems.Add(item);
            }
            //Mock data
            //goalTodoItems.Add(
            //    new RecurringToDoItemModel.Builder(Guid.NewGuid(), "Call Erica's house owner")
            //    .WithDuration(new TimeSpan(30, 0, 0, 0, 0))
            //    .WithStartDate(DateTime.Now.AddDays(7))
            //    .WithColor("green")
            //    .WithDetails("details")
            //    .WithGoalId(Guid.NewGuid())
            //    .WithImportantLevel(ImportantLevelEnumeration.ImportantNonImergency)
            //    .WithIsChecked(true)
            //    .Build());
            //goalTodoItems.Add(
            //     new RecurringToDoItemModel.Builder(Guid.NewGuid(), "Grooming Tony")
            //    .WithStartDate(DateTime.Now.AddDays(7))
            //    .WithDuration(new TimeSpan(30, 0, 0, 0, 0))
            //    .WithColor("red")
            //    .WithDetails("details")
            //    .WithGoalId(Guid.NewGuid())
            //    .WithImportantLevel(ImportantLevelEnumeration.ImergencyNonimportant)
            //    .WithIsChecked(false)
            //    .Build());
            //generalToDoItems.Add(
            //    new ToDoItemModel.Builder(Guid.NewGuid(), "Call Erica's house owner", SelectedDate)
            //    .WithColor("green")
            //    .WithDetails("details")
            //    .WithGoalId(null)
            //    .WithImportantLevel(ImportantLevelEnumeration.ImportantNonImergency)
            //    .WithIsChecked(true)
            //    .Build());
            //generalToDoItems.Add(
            //     new ToDoItemModel.Builder(Guid.NewGuid(), "Grooming Tony", SelectedDate)
            //    .WithColor("red")
            //    .WithDetails("details")
            //    .WithGoalId(null)
            //    .WithImportantLevel(ImportantLevelEnumeration.ImergencyNonimportant)
            //    .WithIsChecked(false)
            //    .Build());
            ToDoItemsGrouped.Add(goalTodoItems);
            ToDoItemsGrouped.Add(generalToDoItems);
        }


    }
}

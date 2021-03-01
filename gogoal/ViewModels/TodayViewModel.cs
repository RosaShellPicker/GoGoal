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
        }

        public TodayViewModel(DateTime dateTime)
        {
            SelectedDate = dateTime;
            InitializeCommand();
            InitializeData();
        }

        void InitializeCommand()
        {
            TextEntryCompleted = new Command( async() => await InsertGeneralTodoItem());
            CheckedChangedCommand = new Command<BaseToDoItemModel>(async(toDoItemModel) => await UpdateCheckedStatus(toDoItemModel));
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

            var toDoItem = new ToDoItemModel.Builder(Guid.NewGuid(), EntryText, SelectedDate)
            .WithColor(null)
            .WithDetails(null)
            .WithGoalId(null)
            .WithImportantLevel(ImportantLevelEnumeration.Undefined)
            .WithIsChecked(false).Build();

            ToDoItemsGrouped[1].Add(toDoItem);
            
            //Add data into local database
            await App.Database.InsertItemAsync(toDoItem);

            //Set Entry text as null again
            EntryText = null;
        }

        async Task UpdateCheckedStatus(BaseToDoItemModel toDoItemModel)
        {
            await App.Database.UpdateItemAsync(toDoItemModel);
            if (toDoItemModel is RecurringToDoItemModel)
            {
                var model = new RecurringToDoItemCheckedModel(toDoItemModel.ToDoItemId, selectedDate);
                await App.Database.UpdateRecurringCheckedResultModel(model, toDoItemModel.IsChecked);
            }
        }

        async void InitializeData()
        {
            //TODO Need to Group todoList fetched from database
            List<ToDoItemModel> todoList = await App.Database.GetGeneralToDoItemsByDateAsync(selectedDate);
            List<RecurringToDoItemModel> recurringToDoItems = await App.Database.getRecurringToDoItemsByDate(selectedDate);
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
            goalTodoItems.Add(
                new RecurringToDoItemModel.Builder(Guid.NewGuid(), "Call Erica's house owner")
                .WithDuration(new TimeSpan(30, 0, 0, 0, 0))
                .WithStartDate(DateTime.Now.AddDays(7))
                .WithColor("green")
                .WithDetails("details")
                .WithGoalId(Guid.NewGuid())
                .WithImportantLevel(ImportantLevelEnumeration.ImportantNonImergency)
                .WithIsChecked(true)
                .Build());
            goalTodoItems.Add(
                 new RecurringToDoItemModel.Builder(Guid.NewGuid(), "Grooming Tony")
                .WithStartDate(DateTime.Now.AddDays(7))
                .WithDuration(new TimeSpan(30, 0, 0, 0, 0))
                .WithColor("red")
                .WithDetails("details")
                .WithGoalId(Guid.NewGuid())
                .WithImportantLevel(ImportantLevelEnumeration.ImergencyNonimportant)
                .WithIsChecked(false)
                .Build());
            generalToDoItems.Add(
                new ToDoItemModel.Builder(Guid.NewGuid(), "Call Erica's house owner", SelectedDate)
                .WithColor("green")
                .WithDetails("details")
                .WithGoalId(null)
                .WithImportantLevel(ImportantLevelEnumeration.ImportantNonImergency)
                .WithIsChecked(true)
                .Build());
            generalToDoItems.Add(
                 new ToDoItemModel.Builder(Guid.NewGuid(), "Grooming Tony", SelectedDate)
                .WithColor("red")
                .WithDetails("details")
                .WithGoalId(null)
                .WithImportantLevel(ImportantLevelEnumeration.ImergencyNonimportant)
                .WithIsChecked(false)
                .Build());
            ToDoItemsGrouped.Add(goalTodoItems);
            ToDoItemsGrouped.Add(generalToDoItems);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace gogoal.ViewModels
{
    public class TodayViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime DateToday { get { return DateTime.Now; } }

        public DateTime SelectedDate { get; set; }

        public ObservableCollection<ToDoItemGroupedModel> ToDoItemsGrouped { get; }
            = new ObservableCollection<ToDoItemGroupedModel>();


        public TodayViewModel(DateTime dateTime)
        {
            SelectedDate = dateTime;
            InitializeData();
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

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

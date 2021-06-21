using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace gogoal
{
    public class EditGoalViewModel : ExtendedBindableObject
    {
        public GoalModel goal { get; set; }
        public List<BaseToDoItemModel> ToDoItems { get; set; }
        private bool isNewGoal = false;

        public string Title { get; set; }
        public string Note { get; set; }
        public string ImportantLevel { get; set; }

        public ICommand NewToDoButtonClicked { private set; get; }

        public ICommand SaveButtonClicked { private set; get; }
        public EditGoalViewModel()
        {
            goal = new GoalModel.Builder(Guid.NewGuid(), "").Build();
            isNewGoal = true;
            InitializeCommand();
        }

        public EditGoalViewModel(GoalModel goal)
        {
            this.goal = goal;
            InitializeCommand();
            InitializeData(this.goal.GoalId);
        }

        void InitializeCommand()
        {
            NewToDoButtonClicked = new Command(async () => {
                await Application.Current.MainPage.Navigation.PushAsync(new EditToDoItem(goal.GoalId, goal.Title));
            });
            SaveButtonClicked = new Command(async () => await SaveGoal());
        }

        async Task SaveGoal()
        {
            goal.Title = Title;
            goal.Notes = Note;
            ImportantLevelEnumeration importantLevel;
            Enum.TryParse(ImportantLevel, out importantLevel);
            goal.ImportantLevel = importantLevel;
            if (isNewGoal)
            {
                await App.Database.InsertGoalItemAsync(goal);
            }
            else
            {
                await App.Database.UpdateGoalItemAsync(goal);
            }
        }

        public async void InitializeData(Guid? goalId)
        {
            if (goal.GoalId != null || goal.GoalId != default)
            {
                Title = goal.Title;
                Note = goal.Notes;
                ImportantLevel = goal.ImportantLevel.ToString();
                ToDoItems = await App.Database.GetGeneralToDoItemsByGoalId(goal.GoalId);
            }
        }
    }
}

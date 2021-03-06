using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace gogoal
{
    public class EditGoalViewModel : ExtendedBindableObject
    {
        public GoalModel goal { get; set; }

        public ICommand NewToDoButtonClicked { private set; get; }

        public ICommand SaveButtonClicked { private set; get; }
        public EditGoalViewModel()
        {
            goal = new GoalModel.Builder(Guid.NewGuid(), "").Build();
            InitializeCommand();
        }

        public EditGoalViewModel(GoalModel goal)
        {
            this.goal = goal;
        }

        void InitializeCommand()
        {
            NewToDoButtonClicked = new Command(async () => {
                await Application.Current.MainPage.Navigation.PushAsync(new EditToDoItem(goal.GoalId, goal.Title));
            });
            //SaveButtonClicked = new Command(async () => await UpdateGoal());
        }

        //async Task UpdateGoal()
        //{
        //   // await App.Database.UpdateGoalItemAsync(goal);
        //}
    }
}

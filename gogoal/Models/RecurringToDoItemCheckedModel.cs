using System;
namespace gogoal
{
    public class RecurringToDoItemCheckedModel
    {
        public Guid? GoalId { get; set; }
        public Guid ToDoItemId { get; set; }
        public DateTime Date { get; set; }

        public RecurringToDoItemCheckedModel()
        {
        }

        public RecurringToDoItemCheckedModel(Guid toDoItemId, Guid? goalId, DateTime date)
        {
            this.ToDoItemId = toDoItemId;
            this.GoalId = goalId;
            this.Date = date;
        }
    }
}

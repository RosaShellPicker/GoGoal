using System;
namespace gogoal
{
    public class RecurringToDoItemCheckedModel
    {
        public Guid ToDoItemId { get; set; }
        public DateTime Date { get; set; }

        public RecurringToDoItemCheckedModel()
        {
        }

        public RecurringToDoItemCheckedModel(Guid toDoItemId, DateTime date)
        {
            this.ToDoItemId = toDoItemId;
            this.Date = date;
        }
    }
}

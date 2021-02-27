using System;
namespace gogoal
{
    public class RecurringToDoItemModel:BaseToDoItemModel
    {
        public DateTime StartDate { get; set; }
        public TimeSpan? Duration { get; set; }

        public RecurringToDoItemModel()
        {
        }

        public class Builder:BaseToDoItemModel.BaseBuilder<RecurringToDoItemModel>
        {
            private DateTime StartDate { get; set; }
            private TimeSpan? Duration { get; set; }

            public Builder(Guid toDoItemId, string title) : base(toDoItemId, title)
            {
            }

            public Builder WithStartDate(DateTime startDate)
            {
                this.StartDate = startDate;
                return this;
            }

            public Builder WithDuration(TimeSpan? duration)
            {
                this.Duration = duration;
                return this;
            }

            public override RecurringToDoItemModel Build()
            {
                return new RecurringToDoItemModel()
                {
                    ToDoItemId = this.ToDoItemId,
                    GoalId = this.GoalId,
                    StageId = this.StageId,
                    Title = this.Title,
                    IsChecked = this.IsChecked,
                    Color = this.Color,
                    ImportantLevel = this.ImportantLevel,
                    Details = this.Details,
                    StartDate = this.StartDate,
                    Duration = this.Duration,
                };
            }
        }
    }
}

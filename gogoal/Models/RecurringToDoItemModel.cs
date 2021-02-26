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

        public class RecurringBuilder:BaseToDoItemModel.BaseBuilder<RecurringToDoItemModel>
        {
            private DateTime StartDate { get; set; }
            private TimeSpan? Duration { get; set; }

            public RecurringBuilder(Guid toDoItemId, string title) : base(toDoItemId, title)
            {
                this.ToDoItemId = toDoItemId;
                this.Title = title;
            }

            public RecurringBuilder WithStartDate(DateTime startDate)
            {
                this.StartDate = startDate;
                return this;
            }

            public RecurringBuilder WithDuration(TimeSpan? duration)
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

using System;
using System.Collections.ObjectModel;
namespace gogoal
{
    /// <summary>
    /// The last 
    /// </summary>
    public class ToDoItemModel
    {
        public Guid ToDoItemId { get; set; }
        public Guid? GoalId { get; set; }
        public string Title { get; set; }
        public bool IsChecked { get; set; }
        public string Color { get; set; }
        public ImportantLevelEnumeration ImportantLevel { get; set; }
        public string Details { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsRepeat { get; set; }
        public TimeSpan? Duration { get; set; }

        public ToDoItemModel()
        {
        }

        public ToDoItemModel(Guid toDoItemId,
            Guid goalId,
            string title,
            bool isChecked,
            string color,
            ImportantLevelEnumeration importantLevel,
            string details,
            DateTime startDate,
            bool isRepeat,
            TimeSpan? duration)
        {
            this.ToDoItemId = toDoItemId;
            this.GoalId = goalId;
            this.Title = title;
            this.IsChecked = isChecked;
            this.Color = color;
            this.ImportantLevel = importantLevel;
            this.Details = details;
            this.StartDate = startDate;
            this.IsRepeat = isRepeat;
            this.Duration = duration;
        }

        public class Builder
        {
            private Guid ToDoItemId { get; set; }
            private Guid? GoalId { get; set; }
            private string Title { get; set; }
            private bool IsChecked { get; set; }
            private string Color { get; set; }
            private ImportantLevelEnumeration ImportantLevel { get; set; }
            private string Details { get; set; }
            private DateTime StartDate { get; set; }
            private bool IsRepeat { get; set; }
            private TimeSpan? Duration { get; set; }

            public Builder (Guid toDoItemId, string title)
            {
                this.ToDoItemId = toDoItemId;
                this.Title = title;
            }

            public Builder WithGoalId(Guid? goalId)
            {
                this.GoalId = goalId;
                return this;
            }

            public Builder WithIsChecked(bool isChecked)
            {
                this.IsChecked = isChecked;
                return this;
            }

            public Builder WithColor(string color)
            {
                this.Color = color;
                return this;
            }

            public Builder WithImportantLevel(ImportantLevelEnumeration importantLevelEnumeration)
            {
                this.ImportantLevel = importantLevelEnumeration;
                return this;
            }

            public Builder WithDetails(string details)
            {
                this.Details = details;
                return this;
            }

            public Builder WithStartDate(DateTime startDate)
            {
                this.StartDate = startDate;
                return this;
            }

            public Builder WithIsRepeat(bool isRepeat)
            {
                this.IsRepeat = isRepeat;
                return this;
            }

            public Builder WithDuration(TimeSpan? duration)
            {
                this.Duration = duration;
                return this;
            }

            public ToDoItemModel Build()
            {
                return new ToDoItemModel()
                {

                    ToDoItemId = this.ToDoItemId,
                    GoalId = this.GoalId,
                    Title = this.Title,
                    IsChecked = this.IsChecked,
                    Color = this.Color,
                    ImportantLevel = this.ImportantLevel,
                    Details = this.Details,
                    StartDate = this.StartDate,
                    IsRepeat = this.IsRepeat,
                    Duration = this.Duration
                };
            }
        }
    }

    public class ToDoItemGroupedModel:ObservableCollection<ToDoItemModel>
    {
        public string GroupTitle { get; set; }

        public string ShortName { get; set; }

        public ToDoItemGroupedModel(string groupTitle, string shortName)
        {
            this.GroupTitle = groupTitle;
            this.ShortName = shortName;
        }
    }
}

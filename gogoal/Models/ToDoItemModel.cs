using System;
using System.Collections.ObjectModel;

namespace gogoal
{
    /// <summary>
    /// The last 
    /// </summary>
    public class ToDoItemModel:BaseToDoItemModel
    {
        public DateTime Date { get; set; }

        public ToDoItemModel()
        {
        }

        public class Builder : BaseToDoItemModel.BaseBuilder<ToDoItemModel>
        {
            public DateTime Date { get; set; }

            public Builder(Guid toDoItemId, string title, DateTime date) : base(toDoItemId, title)
            {
                this.Date = date;
            }

            public Builder WithStartDate(DateTime Date)
            {
                this.Date = Date;
                return this;
            }

            public override ToDoItemModel Build()
            {
                return new ToDoItemModel()
                {
                    ToDoItemId = this.ToDoItemId,
                    GoalId = this.GoalId,
                    StageId = this.StageId,
                    Title = this.Title,
                    Date = this.Date,
                    IsChecked = this.IsChecked,
                    Color = this.Color,
                    ImportantLevel = this.ImportantLevel,
                    Details = this.Details,
                };
            }
        }
    }

    public class ToDoItemGroupedModel:ObservableCollection<BaseToDoItemModel>
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

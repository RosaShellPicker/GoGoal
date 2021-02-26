using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using SQLite;

namespace gogoal
{
    /// <summary>
    /// The last 
    /// </summary>
    public class ToDoItemModel:BaseToDoItemModel
    {
        
        

        public ToDoItemModel()
        {
        }

        public class GeneralBuilder : BaseToDoItemModel.BaseBuilder<ToDoItemModel>
        {
            public GeneralBuilder(Guid toDoItemId, string title) : base(toDoItemId, title)
            {
                this.ToDoItemId = toDoItemId;
                this.Title = title;
            }
            

            public override ToDoItemModel Build()
            {
                return new ToDoItemModel()
                {
                    ToDoItemId = this.ToDoItemId,
                    GoalId = this.GoalId,
                    StageId = this.StageId,
                    Title = this.Title,
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

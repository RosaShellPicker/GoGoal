using System;
using SQLite;
namespace gogoal
{
    public abstract class BaseToDoItemModel
    {
        [PrimaryKey]
        public Guid ToDoItemId { get; set; }
        public Guid? GoalId { get; set; }
        public Guid? StageId { get; set; }
        public string Title { get; set; }
        public bool IsChecked { get; set; }
        public string Color { get; set; }
        public ImportantLevelEnumeration ImportantLevel { get; set; }
        public string Details { get; set; }

        public BaseToDoItemModel()
        {
        }

        public abstract class BaseBuilder<TToBoItemModel>
            where TToBoItemModel : BaseToDoItemModel
        {
            protected Guid ToDoItemId { get; set; }
            protected Guid? GoalId { get; set; }
            protected Guid? StageId { get; set; }
            protected string Title { get; set; }
            protected bool IsChecked { get; set; }
            protected string Color { get; set; }
            protected ImportantLevelEnumeration ImportantLevel { get; set; }
            protected string Details { get; set; }

            public BaseBuilder(Guid toDoItemId, string title)
            {
                this.ToDoItemId = toDoItemId;
                this.Title = title;
            }

            public BaseBuilder<TToBoItemModel> WithGoalId(Guid? goalId)
            {
                this.GoalId = goalId;
                return this;
            }

            public BaseBuilder<TToBoItemModel> WithStageId(Guid? stageId)
            {
                this.StageId = stageId;
                return this;
            }

            public BaseBuilder<TToBoItemModel> WithIsChecked(bool isChecked)
            {
                this.IsChecked = isChecked;
                return this;
            }

            public BaseBuilder<TToBoItemModel> WithColor(string color)
            {
                this.Color = color;
                return this;
            }

            public BaseBuilder<TToBoItemModel> WithImportantLevel(ImportantLevelEnumeration importantLevelEnumeration)
            {
                this.ImportantLevel = importantLevelEnumeration;
                return this;
            }

            public BaseBuilder<TToBoItemModel> WithDetails(string details)
            {
                this.Details = details;
                return this;
            }

            public abstract TToBoItemModel Build();
        }

    }

    
}

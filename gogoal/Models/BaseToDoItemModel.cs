using System;
using System.Collections.Generic;
using SQLite;
namespace gogoal
{
    public abstract class BaseToDoItemModel
    {
        [PrimaryKey]
        public Guid ToDoItemId { get; set; }
        public Guid? GoalId { get; set; }
        public string Title { get; set; }
        public bool IsChecked { get; set; }
        public string Color { get; set; }
        public ImportantLevelEnumeration ImportantLevel { get; set; }
        public string Details { get; set; }
        //[ManyToMany]
        //TODO Need to install an extension for this child model
        //And to declare the relations of these two classes
        public string Tag1 { get; set; }
        public string Tag2 { get; set; }
        public string Tag3 { get; set; }

        public BaseToDoItemModel()
        {
        }

        public abstract class BaseBuilder<TToBoItemModel>
            where TToBoItemModel : BaseToDoItemModel
        {
            protected Guid ToDoItemId { get; set; }
            protected Guid? GoalId { get; set; }
            protected string Title { get; set; }
            protected bool IsChecked { get; set; }
            protected string Color { get; set; }
            protected ImportantLevelEnumeration ImportantLevel { get; set; }
            protected string Details { get; set; }
            protected TagModel Tag1 { get; set; }
            protected TagModel Tag2 { get; set; }
            protected TagModel Tag3 { get; set; }

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

            public BaseBuilder<TToBoItemModel> WithTag1(TagModel tag1)
            {
                this.Tag1 = tag1;
                return this;
            }

            public BaseBuilder<TToBoItemModel> WithTag2(TagModel tag2)
            {
                this.Tag2 = tag2;
                return this;
            }

            public BaseBuilder<TToBoItemModel> WithTag3(TagModel tag3)
            {
                this.Tag3 = tag3;
                return this;
            }
            public abstract TToBoItemModel Build();
        }

        public virtual void UpdateToDoItemCheckedStatus(bool Checked)
        {
        }

    }
}

using System;
using System.Collections.Generic;
namespace gogoal
{
    public class GoalModel
    {
        /// <summary>
        /// A model describe a long term or short term goal, which may inlcude
        /// a parent goal and a list of children goals, so that we can split a
        /// big goal into several ones, and finally become a can do todoitem in daily life
        /// </summary>
        public Guid GoalId { get; set; }
        public Guid? ParentGoalId { get; set; }
        public List<Guid> ChildrenGoals { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public double Progress { get; set; }
        public GoalStatusEnumeration GoalStatus { get; set; }
        public List<ToDoItemModel> ToDoItems { get; set; }

        public GoalModel()
        {
        }

        /// <summary>
        /// Using Builder to help maintain long parameters in constructor
        /// </summary>
        public class Builder    
        {
            private Guid GoalId { get; set; }
            private Guid? ParentGoalId { get; set; }
            private List<Guid> ChildrenGoals{ get; set; }
            private string Title { get; set; }
            private string Details { get; set; }
            private double Progress { get; set; }
            private GoalStatusEnumeration GoalStatus { get; set; }
            private List<ToDoItemModel> ToDoItems { get; set; }

            /// <summary>
            /// Not nullable value for one GoalModel in constructor
            /// </summary>
            /// <param name="goalId"></param>
            /// <param name="title"></param>
            public Builder (Guid goalId, string title)
            {
                this.GoalId = goalId;
                this.Title = title;
            }

            public Builder WithParentGoalId(Guid? parentGoalId)
            {
                ParentGoalId = parentGoalId;
                return this;
            }

            public Builder WithChildrenGoals(List<Guid> childrenGoals)
            {
                this.ChildrenGoals = childrenGoals;
                return this;
            }

            public Builder WithDetails(string details)
            {
                this.Details = details;
                return this;
            }

            public Builder WithProgress(double progress)
            {
                this.Progress = progress;
                return this;
            }

            public Builder WithGoalStatus(GoalStatusEnumeration goalStatus)
            {
                this.GoalStatus = goalStatus;
                return this;
            }

            public Builder WithToDoItems(List<ToDoItemModel> toDoItems)
            {
                this.ToDoItems = toDoItems;
                return this;
            }

            public GoalModel Build()
            {
                return new GoalModel
                {
                    GoalId = this.GoalId,
                    ParentGoalId = this.ParentGoalId,
                    Title = this.Title,
                    ChildrenGoals = this.ChildrenGoals,
                    Detail = this.Details,
                    Progress = this.Progress,
                    GoalStatus = this.GoalStatus,
                    ToDoItems = this.ToDoItems
                };
            }
        }
    }
}

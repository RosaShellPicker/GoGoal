using System;
using System.Collections.Generic;
using SQLite;

namespace gogoal
{
    public class GoalModel
    {
        /// <summary>
        /// A model describe a long term or short term goal, which may inlcude
        /// a parent goal and a list of children goals, so that we can split a
        /// big goal into several ones, and finally become a can do todoitem in daily life
        /// </summary>

        [PrimaryKey]
        public Guid GoalId { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public double Progress { get; set; }
        public ImportantLevelEnumeration ImportantLevel { get; set; }
        public GoalStatusEnumeration GoalStatus { get; set; }

        public GoalModel()
        {
        }

        /// <summary>
        /// Using Builder to help maintain long parameters in constructor
        /// </summary>
        public class Builder    
        {
            private Guid GoalId { get; set; }
            private string Title { get; set; }
            private string Notes { get; set; }
            private double Progress { get; set; }
            private ImportantLevelEnumeration ImportantLevel { get; set; }
            private GoalStatusEnumeration GoalStatus { get; set; }

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

            public Builder WithDetails(string notes)
            {
                this.Notes = notes;
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

            public Builder WithImportantLevel(ImportantLevelEnumeration importantLevel)
            {
                this.ImportantLevel = importantLevel;
                return this;
            }


            public GoalModel Build()
            {
                return new GoalModel
                {
                    GoalId = this.GoalId,
                    Title = this.Title,
                    Notes = this.Notes,
                    Progress = this.Progress,
                    GoalStatus = this.GoalStatus,
                    ImportantLevel = this.ImportantLevel,
                };
            }
        }
    }
}

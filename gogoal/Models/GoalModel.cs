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
        public string Title { get; set; }
        public string Detail { get; set; }
        public double Progress { get; set; }
        public ImportantLevelEnumeration ImportantLevel { get; set; }
        public DateTime StartDate { get; set; } // The date this goal started
        public GoalStatusEnumeration GoalStatus { get; set; }
        public List<GoalStageModel> GoalStages { get; set; } // for group todoitem of one goal, just use stage title to 

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
            private string Details { get; set; }
            private double Progress { get; set; }
            private ImportantLevelEnumeration ImportantLevel { get; set; }
            private DateTime StartDate { get; set; }
            private GoalStatusEnumeration GoalStatus { get; set; }
            private List<GoalStageModel> GoalStageModels { get; set; }

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

            public Builder WithImportantLevel(ImportantLevelEnumeration importantLevel)
            {
                this.ImportantLevel = importantLevel;
                return this;
            }

            public Builder WithStartDate(DateTime startDate)
            {
                this.StartDate = startDate;
                return this;
            }

            public Builder WithGoalStages(List<GoalStageModel> goalStageModels)
            {
                this.GoalStageModels = goalStageModels;
                return this;
            }

            public GoalModel Build()
            {
                return new GoalModel
                {
                    GoalId = this.GoalId,
                    Title = this.Title,
                    Detail = this.Details,
                    Progress = this.Progress,
                    StartDate = this.StartDate,
                    GoalStatus = this.GoalStatus,
                    ImportantLevel = this.ImportantLevel,
                    GoalStages = this.GoalStageModels
                };
            }
        }
    }
}

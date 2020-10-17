using System;
using System.Collections.ObjectModel;
namespace gogoal
{
    public class GoalStageModel
    {
        public Guid GoalId { get; set; }
        public uint StageOrder { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public ObservableCollection<ToDoItemModel> ToDoItems { get; set; }

        public GoalStageModel(Guid goalId, uint stageOrder, string title, string detail, ObservableCollection<ToDoItemModel> toDoItemModels)
        {
            this.GoalId = goalId;
            this.StageOrder = stageOrder;
            this.Title = title;
            this.Detail = detail;
            this.ToDoItems = toDoItemModels;
        }
    }
}

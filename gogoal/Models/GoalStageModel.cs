﻿using System;
using System.Collections.ObjectModel;
namespace gogoal
{
    public class GoalStageModel
    {
        public Guid GoalId { get; set; }
        public Guid StageId { get; set; }
        public uint StageOrder { get; set; }
        public string Title { get; set; }
        public ObservableCollection<ToDoItemModel> ToDoItems { get; set; }

        public GoalStageModel(Guid goalId, Guid stageId, uint stageOrder, string title, ObservableCollection<ToDoItemModel> toDoItemModels)
        {
            this.GoalId = goalId;
            this.StageId = stageId;
            this.StageOrder = stageOrder;
            this.Title = title;
            this.ToDoItems = toDoItemModels;
        }
    }
}

﻿using System;
using System.Collections.ObjectModel;

namespace gogoal
{

    public class ToDoItemModel:BaseToDoItemModel
    {
        public DateTime Date { get; set; }

        public ToDoItemModel()
        {
        }

        public async override void UpdateToDoItemCheckedStatus(bool Checked)
        {
            IsChecked = Checked;
            await App.Database.UpdateItemAsync(this);
        }

        public class Builder : BaseToDoItemModel.BaseBuilder<ToDoItemModel>
        {
            public DateTime Date { get; set; }

            public Builder(Guid toDoItemId, string title, DateTime date) : base(toDoItemId, title)
            {
                this.Date = date;
            }

          
            public override ToDoItemModel Build()
            {
                return new ToDoItemModel()
                {
                    ToDoItemId = this.ToDoItemId,
                    GoalId = this.GoalId,
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

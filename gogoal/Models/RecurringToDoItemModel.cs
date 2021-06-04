using System;
namespace gogoal
{
    public class RecurringToDoItemModel:BaseToDoItemModel
    {
        public DateTime StartDate { get; set; }
        public int Days { get; set; }
        //+1 when user click one checkbox
        public int CheckedDays { get; set; }
        //3 days duration TODO item,
        //give it a default value as "000"
        //When user checked in one day in UI,
        //Just Update the string Value to "100"
        public string CheckedDetails { get; set; }
        public RecurringToDoItemModel()
        {
        }

        public async override void UpdateToDoItemCheckedStatus(bool Checked)
        {
            CheckedDays++;
            //TODO caculate the correct postion of this checked, and update CheckedDetails
            var days = DateTime.Now.Date.Subtract(StartDate.Date);
            await App.Database.UpdateRecurringToDoItemAsync(this);
        }
        public class Builder:BaseToDoItemModel.BaseBuilder<RecurringToDoItemModel>
        {
            private DateTime StartDate { get; set; }
            private int Days { get; set; }
            private int CheckedDays { get; set; }
            private String CheckedDetails { get; set; }

            public Builder(Guid toDoItemId, string title, DateTime startDate) : base(toDoItemId, title)
            {
                this.StartDate = startDate;
            }

            public Builder WithDays(int days)
            {
                this.Days = days;
                return this;
            }

            public override RecurringToDoItemModel Build()
            {
                return new RecurringToDoItemModel()
                {
                    ToDoItemId = this.ToDoItemId,
                    GoalId = this.GoalId,
                    Title = this.Title,
                    IsChecked = this.IsChecked,
                    Color = this.Color,
                    ImportantLevel = this.ImportantLevel,
                    Details = this.Details,
                    StartDate = this.StartDate,
                    Days = this.Days,
                    CheckedDays = this.CheckedDays,
                    CheckedDetails = this.CheckedDetails
                };
            }
        }
    }
}

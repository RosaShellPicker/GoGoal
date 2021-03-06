﻿using System;
using SQLite;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace gogoal
{
    public class GogoalDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public GogoalDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ToDoItemModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(ToDoItemModel)).ConfigureAwait(false);
                }

                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(RecurringToDoItemModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(RecurringToDoItemModel)).ConfigureAwait(false);
                }

                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(RecurringToDoItemCheckedModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(RecurringToDoItemCheckedModel)).ConfigureAwait(false);
                }

                //if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(GoalStageModel).Name))
                //{
                //    await Database.CreateTablesAsync(CreateFlags.None, typeof(GoalStageModel)).ConfigureAwait(false);
                //}

                //if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(GoalModel).Name))
                //{
                //    await Database.CreateTablesAsync(CreateFlags.None, typeof(GoalModel)).ConfigureAwait(false);
                //}


                initialized = true;
            }
        }

        /// <summary>
        /// Data manipulation methods
        /// </summary>
        /// <returns></returns>
        public Task<List<ToDoItemModel>> GetGeneralToDoItemsAsync()
        {
            return Database.Table<ToDoItemModel>().ToListAsync();
        }

        //TODOItem
        /// <summary>
        /// Select all the items for today include items from goals and general items,
        /// to select a goal todoItems is hard, due to goal items have start time and duration.
        /// </summary>
        /// <returns></returns>
        public Task<List<ToDoItemModel>> GetGeneralToDoItemsByDateAsync(DateTime date)
        {
            return Database.Table<ToDoItemModel>().Where(i => i.Date == date).ToListAsync();
        }

        public Task<List<ToDoItemModel>> GetToDoItemsByGoalId(Guid goalId)
        {
            return Database.Table<ToDoItemModel>().Where(i => i.GoalId == goalId).ToListAsync();
        }

        public Task<ToDoItemModel> GetToDoItemAsync(Guid id)
        {
            return Database.Table<ToDoItemModel>().Where(i => i.ToDoItemId == id).FirstOrDefaultAsync();
        }

        public Task<int> InsertItemAsync(ToDoItemModel item)
        {
            return Database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(ToDoItemModel item)
        {
            return Database.DeleteAsync(item);
        }

        public Task<int> DeleteToDoItemByGaolIdAsync(Guid goalId)
        {
            return Database.Table<ToDoItemModel>().DeleteAsync(toDoItem => toDoItem.GoalId == goalId);

        }

        public Task<int> UpdateItemAsync(BaseToDoItemModel item)
        {
            return Database.UpdateAsync(item);
        }

        //RecurringToDoItem
        public Task<List<RecurringToDoItemModel>> getRecurringToDoItemsByDate(DateTime date)
        {
            //TODO need to confirm the status of goal and the status of todo items
            return Database.Table<RecurringToDoItemModel>().Where(i => i.StartDate < date).ToListAsync();
        }

        public Task<int> UpdateRecurringCheckedResultModel(RecurringToDoItemCheckedModel model, bool isChecked)
        {
            if (isChecked)
            {
                return Database.InsertAsync(model);
            }
            else
            {
                return Database.DeleteAsync(model);
            }
        }

        public Task<int> DeleteReucrringToDoItemByGoalId(Guid goalId)
        {
            Database.Table<RecurringToDoItemCheckedModel>().DeleteAsync(i => i.GoalId == goalId);
            return Database.Table<RecurringToDoItemModel>().DeleteAsync(i => i.GoalId == goalId);
        }


        //Goal
        public Task<List<GoalModel>> GetGoals()
        {
            return Database.Table<GoalModel>().ToListAsync();
        }

        public Task<int> InsertGoalItemAsync(GoalModel item)
        {
            return Database.InsertAsync(item);
        }

        public Task<int> UpdateGoalItemAsync(GoalModel item)
        {
            return Database.UpdateAsync(item);
        }

        public Task<int> DeleteGoalItemAsync(GoalModel item)
        {
            return Database.DeleteAsync(item);
        }
    }
}

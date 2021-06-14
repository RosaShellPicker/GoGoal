using System;
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
                //Child model need to be create first
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(TagModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(TagModel)).ConfigureAwait(false);
                }

                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(GoalModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(GoalModel)).ConfigureAwait(false);
                }
                //await Database.DropTableAsync<ToDoItemModel>();
                //if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ToDoItemModel).Name))
                //{
                    await Database.DropTableAsync<ToDoItemModel>();
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(ToDoItemModel)).ConfigureAwait(false);
                //}

                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(RecurringToDoItemModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(RecurringToDoItemModel)).ConfigureAwait(false);
                }

                

                //if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(GoalStageModel).Name))
                //{
                //    await Database.CreateTablesAsync(CreateFlags.None, typeof(GoalStageModel)).ConfigureAwait(false);
                //}

               


                initialized = true;
            }
        }

        #region BaseToDoItemModel
        //TODOItem
        /// <summary>
        /// Select all the items for today include items from goals and general items,
        /// to select a goal todoItems is hard, due to goal items have start time and duration.
        /// </summary>
        /// <returns></returns>
        public async Task<List<BaseToDoItemModel>> GetGeneralToDoItemsByDateAsync(DateTime date)
        {
            var toDoItemModels = await GetToDoItemsByDateAsync(date);
            var recurToDoItemModels = await GetRecurringToDoItemsByDate(date);

            List<BaseToDoItemModel> baseItems = new List<BaseToDoItemModel>();
            foreach(var toDoItem in toDoItemModels)
            {
                baseItems.Add(toDoItem);
            }
            foreach(var recurToDoItem in recurToDoItemModels)
            {
                baseItems.Add(recurToDoItem);
            }
            return baseItems;
        }

        public async Task<List<BaseToDoItemModel>> GetGeneralToDoItemsByGoalId(Guid goalId)
        {
            var toDoItemModels = await GetToDoItemsByGoalId(goalId);
            var recurToDoItemModels = await GetRecurringToDoItemsByGoalId(goalId);

            List<BaseToDoItemModel> baseItems = new List<BaseToDoItemModel>();
            foreach (var toDoItem in toDoItemModels)
            {
                baseItems.Add(toDoItem);
            }
            foreach (var recurToDoItem in recurToDoItemModels)
            {
                baseItems.Add(recurToDoItem);
            }
            return baseItems;
        }
        #endregion


        #region ToDoItemModel
        /// <summary>
        /// Data manipulation methods
        /// </summary>
        /// <returns></returns>
        public Task<List<ToDoItemModel>> GetToDoItemsAsync()
        {
            return Database.Table<ToDoItemModel>().ToListAsync();
        }

        //TODOItem
        /// <summary>
        /// Select all the items for today include items from goals and general items,
        /// to select a goal todoItems is hard, due to goal items have start time and duration.
        /// </summary>
        /// <returns></returns>
        public Task<List<ToDoItemModel>> GetToDoItemsByDateAsync(DateTime date)
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

        public Task<int> UpdateItemAsync(ToDoItemModel item)
        {
            return Database.UpdateAsync(item);
        }
        #endregion

        #region RecurringTODOItem
        //RecurringToDoItem
        public Task<List<RecurringToDoItemModel>> GetRecurringToDoItemsByDate(DateTime date)
        {
            //TODO need to confirm the status of goal and the status of todo items
            //return Database.Table<RecurringToDoItemModel>().Where(i => i.StartDate.Add(new TimeSpan(i.Days,0,0,0)) > date).ToListAsync();
            return Database.Table<RecurringToDoItemModel>().ToListAsync();
        }

        public Task<List<RecurringToDoItemModel>> GetRecurringToDoItemsByGoalId(Guid goalId)
        {
            return Database.Table<RecurringToDoItemModel>().Where(i => i.GoalId == goalId).ToListAsync();
        }

        public Task<int> UpdateRecurringToDoItemAsync(RecurringToDoItemModel item)
        {
            return Database.UpdateAsync(item);
        }
        #endregion

        #region Goals
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
        #endregion
    }
}

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
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ToDoItemModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(ToDoItemModel)).ConfigureAwait(false);
                }
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

        //TODO
        /// <summary>
        /// Select all the items for today include items from goals and general items,
        /// to select a goal todoItems is hard, due to goal items have start time and duration.
        /// </summary>
        /// <returns></returns>
        public Task<List<ToDoItemModel>> GetGeneralToDoItemsByDateAsync(DateTime date)
        {
            // SQL queries are also possible
            //return Database.QueryAsync<ToDoItemModel>("SELECT * FROM [ToDoItemModel] " +
            //    "WHERE [StartDate] != null" +
            //    "Add [StartTime]+[Duration] >=  ");

            Database.QueryAsync<ToDoItemModel>("Select * from [ToDoItemModel]" +
                "WHERE [Date] = ?", date);
            return null;
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

        public Task<int> UpdateItemAsync(ToDoItemModel item)
        {
            return Database.UpdateAsync(item);
        }

        public Task<int> DeleteItemAsync(ToDoItemModel item)
        {
            return Database.DeleteAsync(item);
        }
    }
}

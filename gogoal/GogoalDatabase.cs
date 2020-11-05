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
        public Task<List<ToDoItemModel>> GetItemsAsync()
        {
            return Database.Table<ToDoItemModel>().ToListAsync();
        }

        public Task<List<ToDoItemModel>> GetItemsNotDoneAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<ToDoItemModel>("SELECT * FROM [ToDoItemModel] WHERE [Done] = 0");
        }

        public Task<ToDoItemModel> GetItemAsync(Guid id)
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

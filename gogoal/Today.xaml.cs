using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
namespace gogoal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Today : TabbedPage
    {
        public ObservableCollection<ToDoItemModel> ToDoItems { get; } = new ObservableCollection<ToDoItemModel>()
            {
                new ToDoItemModel.Builder(Guid.NewGuid(), "Call Erica's house owner")
                .withColor("green")
                .withDetails("details")
                .withDueDate(DateTime.Now.AddDays(7))
                .withGoalId(Guid.NewGuid())
                .withImportantLevel(ImportantLevelEnumeration.ImportantNonImergency)
                .withIsChecked(true)
                .Build(),
                new ToDoItemModel.Builder(Guid.NewGuid(), "Grooming Tony")
                .withColor("red")
                .withDetails("details")
                .withDueDate(DateTime.Now.AddDays(7))
                .withGoalId(Guid.NewGuid())
                .withImportantLevel(ImportantLevelEnumeration.ImergencyNonimportant)
                .withIsChecked(false)
                .Build(),
                new ToDoItemModel.Builder(Guid.NewGuid(), "Grooming Tony")
                .withColor("red")
                .withDetails("details")
                .withDueDate(DateTime.Now.AddDays(7))
                .withGoalId(Guid.NewGuid())
                .withImportantLevel(ImportantLevelEnumeration.ImergencyNonimportant)
                .withIsChecked(false)
                .Build(),
                new ToDoItemModel.Builder(Guid.NewGuid(), "Grooming Tony")
                .withColor("red")
                .withDetails("details")
                .withDueDate(DateTime.Now.AddDays(7))
                .withGoalId(Guid.NewGuid())
                .withImportantLevel(ImportantLevelEnumeration.ImergencyNonimportant)
                .withIsChecked(false)
                .Build(),
                new ToDoItemModel.Builder(Guid.NewGuid(), "Grooming Tony")
                .withColor("red")
                .withDetails("details")
                .withDueDate(DateTime.Now.AddDays(7))
                .withGoalId(Guid.NewGuid())
                .withImportantLevel(ImportantLevelEnumeration.ImergencyNonimportant)
                .withIsChecked(false)
                .Build()
            };

        public Today()
        {
            InitializeComponent();
            TodayTodoList.ItemsSource = ToDoItems;
        }

        
    }
}

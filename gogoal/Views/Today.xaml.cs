using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace gogoal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Today : ContentPage
    {
        public Today()
        {
            InitializeComponent();
            this.BindingContext = new TodayViewModel();
        }
    }
}

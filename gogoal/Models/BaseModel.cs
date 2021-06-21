using System;
using System.ComponentModel;
namespace gogoal
{
    public class BaseModel : INotifyPropertyChanged
    {
        public BaseModel()
        {
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gogoal
{
    public class GoGoalMenuItem
    {
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Type TargetType { get; set; }
        public GoGoalMenuItem(string title, string iconSource, Type targetType)
        {
            Title = title;
            IconSource = iconSource;
            TargetType = targetType;
        }
    }
}

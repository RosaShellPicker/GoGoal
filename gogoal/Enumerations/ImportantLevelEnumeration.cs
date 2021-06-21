using System.ComponentModel;

namespace gogoal
{
    public enum ImportantLevelEnumeration
    {
        [Description("Forget about it!")]
        NonimportantNonimergency = 0,
        [Description("Not Important but Imergency")]
        ImergencyNonimportant = 1,
        [Description("Important but Not Imergency")]
        ImportantNonImergency = 2,
        [Description("Important and Imergency")]
        ImportantAndImergency = 3
    }
}

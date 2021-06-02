using System;
using SQLite;

namespace gogoal
{
    public class TagModel
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TagModel(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}

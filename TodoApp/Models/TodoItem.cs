using System;

namespace TodoApp.Models
{
    class TodoItem
    {
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public DateTime TimeStamp { get; set; }

        public string Day { get; set; }
    }
}

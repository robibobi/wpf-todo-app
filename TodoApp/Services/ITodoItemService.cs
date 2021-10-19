using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Services
{
    interface ITodoItemService
    {
        IEnumerable<TodoItem> ReadTodos();

        void WriteTodos(IEnumerable<TodoItem> todoItems);
    }
}

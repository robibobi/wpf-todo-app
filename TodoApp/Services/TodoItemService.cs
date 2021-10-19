using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Services
{
    class TodoItemService : ITodoItemService
    {
        private const string TodoFileExtension = ".txt";
        private const string TodoFileName = "Todos" + TodoFileExtension;

        public IEnumerable<TodoItem> ReadTodos()
        {
            if (!File.Exists(TodoFileName))
                return new List<TodoItem>();

            var jsonString = File.ReadAllText(TodoFileName);

            return JsonConvert.DeserializeObject<List<TodoItem>>(jsonString);
        }

        public void WriteTodos(IEnumerable<TodoItem> todoItems)
        {
            if (!File.Exists(TodoFileName))
            {
                using (var file = File.Create(TodoFileName)) { };
            }

            var jsonString = JsonConvert.SerializeObject(todoItems, Formatting.Indented);

            File.WriteAllText(TodoFileName, jsonString);
        }
    }
}

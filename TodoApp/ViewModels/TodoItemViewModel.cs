using System;
using System.Collections.Generic;
using System.Linq;
using TodoApp.Models;
using TodoApp.Services;

namespace TodoApp.ViewModels
{
    class TodoItemViewModel
    {
        private readonly ITodoItemService _todoItemService;
        private readonly IEnumerable<TodoItem> _allTodos;

        public string Name
        {
            get
            {
                return TodoItem.Name;
            } 
            set
            {
                TodoItem.Name = value;
            }
        }

        public DateTime TimeStamp
        {
            get
            {
                return TodoItem.TimeStamp;
            }
            set
            {
                TodoItem.TimeStamp = value;
            }
        }

        public bool IsDone
        {
            get
            {
                return TodoItem.IsDone;
            }
            set
            {
                TodoItem.IsDone = value;
                _todoItemService.WriteTodos(_allTodos);
            }
        }


        public TodoItem TodoItem { get; }

        public TodoItemViewModel(
            TodoItem todoItem,
            ITodoItemService todoItemService,
            IEnumerable<TodoItemViewModel> allTodos)
        {
            TodoItem = todoItem;
            _todoItemService = todoItemService;
            _allTodos = allTodos.Select(vm => vm.TodoItem);
        }
    }

}

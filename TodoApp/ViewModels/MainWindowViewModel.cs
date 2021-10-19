using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using TodoApp.Commands;
using TodoApp.Models;
using TodoApp.Services;

namespace TodoApp.ViewModels
{
    class MainWindowViewModel
    {
        private readonly ITodoItemService _todoItemService;
        private readonly IDateTimeService _dateTimeService;
        private string _newTodoName;

        public ObservableCollection<TodoItemViewModel> TodoItems { get; set; }

        private TodoItemViewModel _selectedTodoItem;

        public TodoItemViewModel SelectedTodoItem
        {
            get { return _selectedTodoItem; }
            set { _selectedTodoItem = value; DeleteTodoCommand?.RaiseCanExecuteChanged(); }
        }

        public string NewTodoName
        {
            get { return _newTodoName; }
            set { _newTodoName = value; AddTodoCommand?.RaiseCanExecuteChanged(); }
        }

        public ActionCommand AddTodoCommand { get; }
        public ActionCommand DeleteTodoCommand { get;  }

        public MainWindowViewModel(
            ITodoItemService todoItemService,
            IDateTimeService dateTimeService)
        {
            _todoItemService = todoItemService;
            _dateTimeService = dateTimeService;
            TodoItems = new ObservableCollection<TodoItemViewModel>();
            var todoItemModels = _todoItemService.ReadTodos();

            foreach(var item in todoItemModels)
            {
                TodoItems.Add(CreateTodoViewModel(item));
            }

            AddTodoCommand = new ActionCommand(AddNewTodo, CanAddNewTodo);
            DeleteTodoCommand = new ActionCommand(DeleteSelectedTodo, CanDeleteTodo);
        }

        private TodoItemViewModel CreateTodoViewModel(TodoItem todoItem)
        {
            return new TodoItemViewModel(todoItem, _todoItemService, TodoItems);
        }

        private void DeleteSelectedTodo()
        {
            if(SelectedTodoItem != null)
            {
                TodoItems.Remove(SelectedTodoItem);
            }
        }

        private bool CanDeleteTodo()
        {
            return SelectedTodoItem != null;
        }

        private bool CanAddNewTodo()
        {
            return !String.IsNullOrWhiteSpace(NewTodoName);
        }

        private void AddNewTodo()
        {
            if (!String.IsNullOrWhiteSpace(NewTodoName))
            {
                var newItem = new TodoItem()
                {
                    Name = NewTodoName,
                    IsDone = false,
                    TimeStamp = _dateTimeService.Now(),
                };
                TodoItems.Add(CreateTodoViewModel(newItem));
                
                _todoItemService.WriteTodos(TodoItems.Select(vm => vm.TodoItem));
            }
        }

     

        private void DeleteTodoButtonClicked(object sender, RoutedEventArgs e)
        {
            if (SelectedTodoItem != null)
            {
                TodoItems.Remove(SelectedTodoItem);
            }
        }

    }
}

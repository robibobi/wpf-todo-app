using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Models;
using TodoApp.Services;
using TodoApp.ViewModels;

namespace TodoApp.UnitTests.ViewModels
{
    class FakeTodoService : ITodoItemService
    {
        public IEnumerable<TodoItem> ReadTodos()
        {
            return new List<TodoItem>();
        }

        public void WriteTodos(IEnumerable<TodoItem> todoItems)
        {

        }
    }

    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void AddNewTodo_NewTodoNameIsEmpty_AddTodoButtonCannotBeExecuted()
        {
            // Arrange
            var viewModel = CreateSut();
            viewModel.NewTodoName = "";
            // Act
            var canExecute = viewModel.AddTodoCommand.CanExecute(null);

            // Assert
            canExecute.ShouldBeFalse();
        }

        [TestMethod]
        public void AddNewTodo_TodoNameIsNotEmpty_AddTodoButtonCanBeExecuted()
        {
            // Arrange
            var viewModel = CreateSut();
            viewModel.NewTodoName = "Some Todo...";
            // Act
            var canExecute = viewModel.AddTodoCommand.CanExecute(null);
            // Assert
            canExecute.ShouldBeTrue();
        }

        [TestMethod]
        public void AddNewTodo_TodoNameIsWhitespace_AddTodoButtonCanNotBeExecuted()
        {
            // Arrange
            var viewModel = CreateSut();
            viewModel.NewTodoName = " ";
            // Act
            var canExecute = viewModel.AddTodoCommand.CanExecute(null);

            // Assert
            canExecute.ShouldBeFalse();
        }

        [TestMethod]
        public void ExecuteAddNewTodo_TodoNameNotEmpty_TodoItemIsAddedToList()
        {
            // Arrange
            var viewModel = CreateSut();
            viewModel.NewTodoName = "Staubsaugen";
            // Act
            viewModel.AddTodoCommand.Execute(null);
            // Assert
            viewModel.TodoItems.Single().Name.ShouldBe("Staubsaugen");    
        }

        [TestMethod]
        public void AddNewTodo_NewTodoHasCurrentTimeAsTimeStamp()
        {
            // Arrange
            var testTimeStamp = DateTime.Now;
            var viewModel = CreateSut(testTimeStamp);
            viewModel.NewTodoName = "Zeitstempel test";
            // Act
            viewModel.AddTodoCommand.Execute(null);
            // Assert
            var todo = viewModel.TodoItems.Single();
            todo.TimeStamp.Ticks.ShouldBe(testTimeStamp.Ticks);

        }

        private MainWindowViewModel CreateSut(DateTime fakeNow = default(DateTime))
        {
            var dateTimeServiceMock = new Mock<IDateTimeService>();
            var dateTimeService = dateTimeServiceMock.Object;

            dateTimeServiceMock.Setup(service => service.Now()).Returns(fakeNow);

            
            return new MainWindowViewModel(new FakeTodoService(), dateTimeService);
        }

    }
}

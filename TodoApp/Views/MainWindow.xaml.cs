using System.Windows;
using TodoApp.Services;
using TodoApp.ViewModels;

namespace TodoApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(
                new TodoItemService(),
                new DateTimeService());
        }
    }
}

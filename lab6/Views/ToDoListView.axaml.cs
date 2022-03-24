using Avalonia;
using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using lab6.ViewModels;

namespace lab6.Views
{
    public partial class ToDoListView : UserControl
    {
        public ToDoListView()
        {
            InitializeComponent();
            var date = this.FindControl<DatePicker>("dtPicker");
            var today = DateTime.Today;
            date.SelectedDate = today;
            date.SelectedDateChanged += delegate
            {
                var context = this.DataContext as ToDoListViewModel;
                if(context!= null)
                    context.ChangeListByDate();
            };
        }

        
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using lab6.Models;
using lab6.Views;
using System.Reactive;
using ReactiveUI;

namespace lab6.ViewModels
{
    public class ToDoListViewModel:ViewModelBase
    {
        private Dictionary< DateTimeOffset, List<Case> > ToDoDataBase;
        private DateTimeOffset currentDate;

        public DateTimeOffset CurrentDate
        {
            get => currentDate;
            set => this.RaiseAndSetIfChanged(ref currentDate, value);
        }
        public ToDoListViewModel()
        {
            ToDoDataBase = new Dictionary<DateTimeOffset, List<Case>>();
            ToDoDataBase.Add(new DateTime(2022, 3, 23), new List<Case> { new Case("First", "123"), new Case("Second", "1111") });
            ToDoDataBase.Add(new DateTime(2022, 3, 24), new List<Case> { new Case("Second", "12332" )});
            ToDoDataBase.Add(new DateTime(2022, 3, 25), new List<Case> { new Case("Third", "123sdsd"), new Case("Second", "123009") });
            ToDoList = new ObservableCollection<Case>(ToDoDataBase[new DateTime(2022, 3, 25)]);
            CurrentDate = DateTime.Today;
        }
        public ObservableCollection<Case> ToDoList { get; set; }

        public void addCase(Case nt)
        {
            if(ToDoDataBase.ContainsKey(CurrentDate))
                ToDoDataBase[CurrentDate].Add(nt);
            else
                ToDoDataBase.Add(CurrentDate, new List<Case> { nt });
        }

        public void ChangeListByDate()
        {
            ToDoList.Clear();
            if (ToDoDataBase.ContainsKey(currentDate))
            {
                foreach (Case ptr in ToDoDataBase[currentDate])
                {
                    ToDoList.Add(ptr);
                }
            }
                
        }
    }
}

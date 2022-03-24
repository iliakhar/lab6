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
        public Dictionary< DateTimeOffset, List<Case> > ToDoDataBase;
        private DateTimeOffset currentDate;
        public DateTimeOffset CurrentDate
        {
            get => currentDate;
            set => this.RaiseAndSetIfChanged(ref currentDate, value);
        }
        public ToDoListViewModel()
        {
            ToDoDataBase = new Dictionary<DateTimeOffset, List<Case>>();
            ToDoDataBase.Add(new DateTime(2022, 3, 23), new List<Case> { new Case("Заметка 1 1", "123"), new Case("Заметка 1 2", "1111") });
            ToDoDataBase.Add(new DateTime(2022, 3, 24), new List<Case> { new Case("Заметка 2 1", "12332" )});
            ToDoDataBase.Add(new DateTime(2022, 3, 25), new List<Case> { new Case("Заметка 3 1", "123sdsd"), new Case("Заметка 3 1", "123009") });
            ToDoList = new ObservableCollection<Case>(ToDoDataBase[DateTime.Today]);
            CurrentDate = DateTime.Today;
        }
        public ObservableCollection<Case> ToDoList { get; set; }
        //public delegate void AddOrChange(Case cs);
        public void addCase(Case nt)
        {
            if(ToDoDataBase.ContainsKey(CurrentDate))
                ToDoDataBase[CurrentDate].Add(nt);
            else
                ToDoDataBase.Add(CurrentDate, new List<Case> { nt });
        }

        public void changeCase(Case oldCs, Case newCs )
        {
            if (ToDoDataBase[CurrentDate].Find(p => p == oldCs) != null)
            {
                ToDoDataBase[CurrentDate].Find(p => p == oldCs).Header = newCs.Header;
                ToDoDataBase[CurrentDate].Find(p => p == oldCs).Text = newCs.Text;
            }
            //ToDoDataBase[CurrentDate][SelectedIndex] = nt;
        }
        public void delCase(Case cs)
        {
            ToDoDataBase[CurrentDate].Remove(cs);
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

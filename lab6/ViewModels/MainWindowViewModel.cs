using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using lab6.Models;
using System.Reactive;
using ReactiveUI;
using System.Reactive.Linq;

namespace lab6.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase currentView;
        public MainWindowViewModel()
        {
            CurrentView = mainView = new ToDoListViewModel();
            
        }
        public ToDoListViewModel mainView { get;}

        public ViewModelBase CurrentView
        {
            set => this.RaiseAndSetIfChanged(ref currentView, value);
            get => currentView;
        }
        
        public void Change(Case cs)
        {
            NoteViewModel addView;
            
            if (cs==null)
            {
                addView = new NoteViewModel();
            }
            else 
                addView = new NoteViewModel(cs);
            Observable.Merge(addView.Add, addView.Cancel.Select(_ => (Case?)null))
                .Take(1)
                .Subscribe(newNote =>
                {
                    if (newNote != null)
                    {
                        if(cs == null)
                            mainView.addCase(newNote);
                        else
                            mainView.changeCase(cs, newNote);
                    }
                    CurrentView = mainView;
                    mainView.ChangeListByDate();

                }

                );

            CurrentView = addView;
        }

        public void DelItem(Case cs)
        {
            mainView.delCase(cs);
            mainView.ChangeListByDate();
        }


    }
    
    
}

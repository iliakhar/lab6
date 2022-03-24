using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using lab6.Models;
using System.Reactive;

namespace lab6.ViewModels
{
    internal class NoteViewModel : ViewModelBase
    {
        private string name;
        private string text;
        public NoteViewModel()
        {
            var addEnabled = this.WhenAnyValue(
                newNote => newNote.Name,
                newNote => !string.IsNullOrWhiteSpace(newNote));

            Add = ReactiveCommand.Create(() => UpdateNote(), addEnabled);
            Cancel = ReactiveCommand.Create(() => { });
        }
        public NoteViewModel(Case nt) : this()
        {
            Name = nt.Header;
            Text = nt.Text;
        }

        public ReactiveCommand<Unit, Case> Add { get; }
        public ReactiveCommand<Unit, Unit> Cancel { get; }

        public Case UpdateNote()
        {
            Case NewNoteData = new Case(name, text);

            return NewNoteData;
        }

        private string Name
        {
            get => name;
            set => this.RaiseAndSetIfChanged(ref name, value);
        }

        private string Text
        {
            get => text;
            set => this.RaiseAndSetIfChanged(ref text, value);
        }
    }
}

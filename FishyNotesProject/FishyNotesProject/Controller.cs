using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishyNotesProject
{
    class Controller : IController
    {
        int _InstanceCounter;
        Dictionary<int, FishyNote> _FishyNoteList;
        Dictionary<int, ITextBoxStorage> _textBoxDictionary;

        IEventPublisher _noteData;
        public Controller()
        {
            _InstanceCounter = 0;
            _FishyNoteList = new Dictionary<int, FishyNote>();
            _textBoxDictionary = new Dictionary<int, ITextBoxStorage>();

            _noteData = new NoteData();
        }

        public void MoreFish()
        {
            _textBoxDictionary.Add(_InstanceCounter, new TextBoxStorage());

            _FishyNoteList.Add(_InstanceCounter, new FishyNote(RemoveNote, _InstanceCounter, _textBoxDictionary[_FishyNoteList.Count], _noteData.ChangeText));

            _FishyNoteList[_InstanceCounter].Show();

            _noteData.Subscribe(_FishyNoteList[_InstanceCounter].NewText); //FishyNote.NewText

            _InstanceCounter++;
        }

        public void Subscribe(EventHandler<MyArgs> listener)
        {
            
        }

        private void RemoveNote(int id)
        {
            _FishyNoteList[id].Dispose();

            _FishyNoteList.Remove(id);
        }
    }
}

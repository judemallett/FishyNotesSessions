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
        Dictionary<int, IEventPublisher> _textEventDictionary;

        public Controller()
        {
            _InstanceCounter = 0;
            _FishyNoteList = new Dictionary<int, FishyNote>();
            _textEventDictionary = new Dictionary<int, IEventPublisher>();

        }

        public void MoreFish()
        {
            _textEventDictionary.Add(_InstanceCounter, new NoteData());

            _FishyNoteList.Add(_InstanceCounter, new FishyNote(RemoveNote, _InstanceCounter, _textEventDictionary[_InstanceCounter].ChangeText));

            _FishyNoteList[_InstanceCounter].Show();

            _textEventDictionary[_InstanceCounter].Subscribe(_FishyNoteList[_InstanceCounter].NewText); //FishyNote.NewText

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

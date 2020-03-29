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

        public Controller()
        {
            _InstanceCounter = 0;
            _FishyNoteList = new Dictionary<int, FishyNote>();
            _textBoxDictionary = new Dictionary<int, ITextBoxStorage>();
        }

        public void MoreFish()
        {
            _textBoxDictionary.Add(_InstanceCounter, new TextBoxStorage());

            _FishyNoteList.Add(_InstanceCounter, new FishyNote(RemoveNote, _InstanceCounter, _textBoxDictionary[_FishyNoteList.Count]));

            _FishyNoteList[_InstanceCounter].Show();

            _InstanceCounter++;
        }

        private void RemoveNote(int id)
        {
            _FishyNoteList[id].Dispose();

            _FishyNoteList.Remove(id);
        }
    }
}

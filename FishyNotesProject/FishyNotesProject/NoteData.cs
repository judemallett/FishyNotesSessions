using System;

namespace FishyNotesProject
{
    public class NoteData : IEventPublisher
    {
        public NoteData()
        {
        }

        public event EventHandler<MyArgs> NewData;

        private void OnDataChanged(String data)
        {
            Console.WriteLine("ondatachanged event");
            MyArgs args = new MyArgs(data);
            NewData(this, args);
        }

        public void Subscribe(EventHandler<MyArgs> listener)
        {
            //confused why we need to add equals listeners rather than just equals
            NewData += listener;
        }

        public void ChangeText(String newText)
        {
            Console.WriteLine("change text event");
            OnDataChanged(newText); //When change detected, call event publish method
        }

    }

}
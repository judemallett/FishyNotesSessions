using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishyNotesProject
{
    interface IEventPublisher
    {
        void Subscribe(EventHandler<MyArgs> listener);

        void ChangeText(String newText);
    }
}

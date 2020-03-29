using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishyNotesProject
{
    interface IEventSubscriber
    {

        void NewText(object source, MyArgs args);

    }
}

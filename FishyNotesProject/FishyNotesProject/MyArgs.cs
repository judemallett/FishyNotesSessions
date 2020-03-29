using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishyNotesProject
{
    public class MyArgs : EventArgs
    {

        public String Data { get; }

        public MyArgs(String data)
        {
            Data = data;
        }
    }
}

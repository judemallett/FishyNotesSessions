using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FishyNotesProject
{
    public partial class FishyNotes : Form
    {
        //CREATE List called FishyNoteList of Type FishyNote

        IController _controller;
        ReturnVoidCommand _MoreFishInstance;


        public FishyNotes()
        {
            InitializeComponent();

            //INITIALISE FishyNoteList & FishyNoteDictionary
            _controller = new Controller();

            _MoreFishInstance = _controller.MoreFish;

        }

        //ON Click Event
        //CREATE new FishyNote instance in FishyNoteList
        //SHOW last created FishyNoteList index
        private void AddNote_Click(object sender, EventArgs e)
        {
            _MoreFishInstance();

        }


    }
}

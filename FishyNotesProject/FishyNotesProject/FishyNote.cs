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
    public partial class FishyNote : Form , IEventSubscriber
    {

        bool _collapsedBool;

        string _defaultText;
        int _ID;
        RemoveNoteDelegate _removeThis;

        IEventPublisher _eventPublisher;

        StringVoidDelegate _changeText;

        public FishyNote(RemoveNoteDelegate pRemoveNote, int pID, StringVoidDelegate pChangeText)
        {
            InitializeComponent();

            _defaultText = "Enter your note here...";
            _ID = pID;
            _removeThis = pRemoveNote;

            _collapsedBool = false;

            _changeText = pChangeText;

            _eventPublisher = new NoteData();
        }

        public void NewText(object source, MyArgs args)
        {
            TextBox.Text = args.Data;
        }
        private void TextBox_Click(object sender, EventArgs e)
        {

            if (TextBox.Text == _defaultText)
            {
                TextBox.Text = "";
            }
            
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            _changeText(TextBox.Text);

        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            _removeThis(_ID);
        }

        private void CollapseButton_Click(object sender, EventArgs e)
        {

            //collapse note
            if (!_collapsedBool)
            {
                _collapsedBool = true;

                this.TextBox.Hide();
                this.CollapseButton.Height = 23;
                this.CollapseButton.Width = 39;
                this.CollapseButton.Text = "+";
                this.DeleteButton.Location = new Point(60, 12);
                this.Size = new Size(110, 50);
            }
            //enlarge note
            else
            {
                _collapsedBool = false;

                this.TextBox.Show();
                this.CollapseButton.Height = 115;
                this.CollapseButton.Width = 145;
                this.CollapseButton.Text = "-";
                this.DeleteButton.Location = new Point(749, 12);
                this.Size = new Size(800, 450);
            }

        }

        

        #region Code Snippet: makes this borderless window movable
        // Modified from https://stackoverflow.com/a/24561946 and attributed to user jay_t55

        // DECLARE a boolean that is set to true when a mouse down event is detected, call it _mouseDown:
        private bool _mouseDown = false;

        // DECLARE a Point object to store the last location of the window origin (ie memory), call it _lastLocation:
        private Point _lastLocation;

        // Mouse down event handler
        private void FishyNote_MouseDown(object sender, MouseEventArgs e)
        {
            // SET _mouseDown true:
            _mouseDown = true;

            // STORE current location to _lastLocation:
            _lastLocation = e.Location;
        }

        // Mouse move event handler
        private void FishyNote_MouseMove(object sender, MouseEventArgs e)
        {
            // Only act if mouse button is down...
            if (_mouseDown)
            {
                // SET new location according to mouse movement from _lastLocation:
                this.Location = new Point(
                    (this.Location.X - _lastLocation.X) + e.X, (this.Location.Y - _lastLocation.Y) + e.Y);

                // UPDATE this window:
                this.Update();
            }
        }

        // Mouse up event handler
        private void FishyNote_MouseUp(object sender, MouseEventArgs e)
        {
            // RESET _mouseDown to false:
            _mouseDown = false;
        }
        #endregion
    }
}

namespace FishyNotesProject
{

    public class TextBoxStorage : ITextBoxStorage
    {

        string _defaultText;
        string _userText;

        public TextBoxStorage()
        {
            _defaultText = "Enter your note here...";
        }

        void ITextBoxStorage.LoadText(System.Windows.Forms.TextBox pTextBox)
        {
            pTextBox.Text = _defaultText;
            pTextBox.Select(0, 0);
        }

        void ITextBoxStorage.Click(System.Windows.Forms.TextBox pTextBox)
        {
            if (pTextBox.Text == _defaultText)
            {
                pTextBox.Text = "";
            }

        }

        void ITextBoxStorage.TextChanged(System.Windows.Forms.TextBox pTextBox)
        {
            _userText = pTextBox.Text;
        }
    }
}
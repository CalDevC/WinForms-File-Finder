

namespace File_Finder {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            phraseTextBox.Hide();
            lowerBound.Hide();
            upperBound.Hide();
            label3.Hide();
            label4.Hide();
        }

        private void searchTermType_Change(object sender, EventArgs e) {
            label4.Show();
            if (searchTermType.Text == "Keyword Phrase") {
                //Show phrase textbox and hide numbe range boxes
                phraseTextBox.Show();
                lowerBound.Hide();
                upperBound.Hide();
                label3.Hide();
            } else if (searchTermType.Text == "Number Range") {
                //Hide phrase textbox and show numbe range boxes
                phraseTextBox.Hide();
                lowerBound.Show();
                upperBound.Show();
                label3.Show();
            }
        }

        //Search button clicked
        private void button1_Click(object sender, EventArgs e) {
            string path = pathTextBox.Text;
            string searchType = searchTermType.Text;
            bool recursive = recurCheckBox.Checked;
            string searchTerm;

            var fileList = Directory.GetFiles(path);
            foreach (var file in fileList) {
                System.Diagnostics.Debug.WriteLine(file);
            }

            if (searchType == "Keyword Phrase") {
                searchTerm = phraseTextBox.Text;
                Search search = new Search(path, recursive, searchTerm);

            } else if(searchType == "Number Range") {
                //int lower = Int32.Parse(lowerBound.Text);
                //int upper = Int32.Parse(upperBound.Text);
                searchTerm = lowerBound.Text + "-" + upperBound.Text;
            } else {
                //Select a seach type
            }

        }

    }
}
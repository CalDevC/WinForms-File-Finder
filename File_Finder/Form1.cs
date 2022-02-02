

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
            string fileTypes = fileTypesTextBox.Text;

            //Clear results box
            foundFiles.Items.Clear();

            //Instantiate search object
            //Search search = new Search(path, recursive, fileTypes);
            Search search = new Search("\\\\upifile1\\vidar", false, ".pdf");

            if (searchType == "Keyword Phrase") {
                string searchTerm = phraseTextBox.Text;
                List<string> results = search.phraseSearch(searchTerm);
                System.Diagnostics.Debug.WriteLine("Exited function\n" + results.Count);

                foreach (var filepath in results) {
                    foundFiles.Items.Add(filepath);
                    System.Diagnostics.Debug.WriteLine("Added " + filepath);
                }

            } else if(searchType == "Number Range") {
                int lower = Int32.Parse(lowerBound.Text);
                int upper = Int32.Parse(upperBound.Text);
                search.rangeSearch(lower, upper);
            } else {
                //Select a seach type
            }

        }

    }
}
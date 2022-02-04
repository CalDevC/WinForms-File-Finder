

namespace File_Finder {
    public partial class File_Finder : Form {
        public File_Finder() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            phraseTextBox.Hide();
            lowerBound.Hide();
            upperBound.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
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
            Search search = new Search(path, fileTypes);
            Utils util = new Utils();

            //Clear results box and make new result List
            foundFiles.Items.Clear();
            List<string> results = new List<string>();

            //button1.Hide();
            //label5.Show();

            if (searchType == "Keyword Phrase") {  //PHRASE SEARCH  
                string searchTerm = phraseTextBox.Text;

                if (recursive)
                    results = search.phraseSearchRecur(searchTerm, path);
                else
                    results = search.phraseSearch(searchTerm);

                //Output found files to the form
                foreach (var filepath in results) {
                    string filename = filepath.Split("\\").Last();
                    foundFiles.Items.Add(filename);
                }

            } else if(searchType == "Number Range") {  //RANGE SEARCH
                int lower = Int32.Parse(lowerBound.Text);
                int upper = Int32.Parse(upperBound.Text);

                if (recursive)
                    results = search.rangeSearchRecur(lower, upper, path);
                else
                    results = search.rangeSearch(lower, upper);

                //Output found files to the form
                foreach (var filepath in results) {
                    string filename = filepath.Split("\\").Last();
                    foundFiles.Items.Add(filename);
                }

            } else {
                //Select a seach type
            }
            //button1.Show();
            //label5.Show();

        }

    }
}
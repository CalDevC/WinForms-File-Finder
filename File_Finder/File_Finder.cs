
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

        //Output results to the GUI
        private void outputResults(Dictionary<string, bool> results) {
            //Output found files to the form
            foreach (KeyValuePair<string, bool> entry in results) {
                if (entry.Value == true) {
                    string filepath = entry.Key;
                    string filename = filepath.Split("\\").Last();
                    foundFiles.Items.Add(filename);
                    foundFilesPath.Items.Add(filepath);
                } else if (entry.Value == false) {
                    notDetected.Items.Add(entry.Key);
                } else {
                    //Error
                }

            }
        }

        //Search button clicked
        private void button1_Click(object sender, EventArgs e) {
            string path = pathTextBox.Text;
            string searchType = searchTermType.Text;
            bool recursive = recurCheckBox.Checked;
            string fileTypes = fileTypesTextBox.Text;
            Search search = new Search(path, fileTypes);

            //Clear results box and make new result List
            foundFiles.Items.Clear();
            foundFilesPath.Items.Clear();
            notDetected.Items.Clear();
            Dictionary<string, bool> results = new Dictionary<string, bool>();

            //Check path validity
            if (path == "" || !Directory.Exists(path)) {
                pathTextBox.BackColor = Color.LightCoral;
                return;
            }

            pathTextBox.BackColor = SystemColors.Window;
            button1.Cursor = Cursors.WaitCursor;

            if (searchType == "Keyword Phrase") {  //PHRASE SEARCH  
                string searchTerm = phraseTextBox.Text;

                if (recursive)
                    results = search.phraseSearchRecur(searchTerm, path);
                else
                    results = search.phraseSearch(searchTerm);

                //Output found files to the form
                outputResults(results);

            } else if(searchType == "Number Range") {  //RANGE SEARCH
                int lower = Int32.Parse(lowerBound.Text);
                int upper = Int32.Parse(upperBound.Text);

                if (recursive)
                    results = search.rangeSearchRecur(lower, upper, path);
                else
                    results = search.rangeSearch(lower, upper);

                //Output found files to the form
                outputResults(results);

            } else {
                //Select a seach type
            }

            button1.Cursor = Cursors.Default;
        }





    }
}
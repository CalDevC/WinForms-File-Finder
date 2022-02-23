
namespace File_Finder {
    public partial class File_Finder : Form {

        Utils util = new Utils();
        bool cancel = false;

        public File_Finder() {
            InitializeComponent();
        }

        public void setUIValues(string path, string fileTypes, int searchTypeIdx, string searchTerm, bool recursive) {
            pathTextBox.Text = path;
            fileTypesTextBox.Text = fileTypes;
            searchTermType.SelectedIndex = searchTypeIdx;
            if(searchTypeIdx == 0) {
                phraseTextBox.Text = searchTerm;
            } else if(searchTypeIdx == 1){
                string[] searchTermParts = searchTerm.Split('-');
                lowerBound.Text = searchTermParts[0];
                upperBound.Text = searchTermParts[1];
            }
            
            recurCheckBox.Checked = recursive;
        }

        private void Form1_Load(object sender, EventArgs e) {
            Tests test = new Tests(this);

            phraseTextBox.Hide();
            lowerBound.Hide();
            upperBound.Hide();
            label3.Hide();
            label4.Hide();
            cancelBtn.Enabled = false;

            test.test3();
        }

        //Called when the dropdown value is changed
        private void searchTermType_Change(object sender, EventArgs e) {
            label4.Show();
            if (searchTermType.Text == "Keyword Phrase") {
                //Show phrase textbox and hide number range boxes
                phraseTextBox.Show();
                lowerBound.Hide();
                upperBound.Hide();
                label3.Hide();
            } else if (searchTermType.Text == "Number Range") {
                //Hide phrase textbox and show number range boxes
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

        //update the status bar
        public void updateStatus(string text) {
            statusBar.Text = text;
        }

        //Launch an error pop-up
        private void errorPopup(string exceptionMsg, string popupTitle, string? additionalMsg="") {
            MessageBox.Show(
                exceptionMsg + additionalMsg,
                popupTitle,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        //Launch info pop-up
        private DialogResult infoPopup(string msg, string popupTitle) {
            return MessageBox.Show(
                msg,
                popupTitle,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Exclamation
            );
        }
        
        public bool getCancel() {
            return cancel;
        }

        //Search button clicked
        private async void searchBtn_Click(object sender, EventArgs e) {
            cancel = false;
            cancelBtn.Enabled = true;
            searchBtn.Enabled = false;

            string path = pathTextBox.Text;
            string searchType = searchTermType.Text;
            bool recursive = recurCheckBox.Checked;
            string fileTypes = fileTypesTextBox.Text;

            //Ask to confirm search for all file types
            if (fileTypes == "") {
                DialogResult selection = infoPopup(
                    "The current search criteria specify no file types. " +
                    "This will cause the File Finder to return all matching " +
                    "search results regardless of file type.",
                    "Search Warning");

                if(selection == DialogResult.Cancel) {
                    return;
                }
            }

            Search search = new Search(this, path, fileTypes);

            //Clear results box and make new result List
            foundFiles.Items.Clear();
            foundFilesPath.Items.Clear();
            notDetected.Items.Clear();
            Dictionary<string, bool> results = new Dictionary<string, bool>();

            //Check path validity
            if (path == "" || !Directory.Exists(path)) {
                errorPopup("Invalid search path", "Search Error", ", please enter a valid directory to search. Begin path with: \\\\");
                return;
            }

            //Set wait cursor
            searchBtn.Cursor = Cursors.WaitCursor;

            //Try to do a search and catch if there is an invalid search type
            try {
                if (searchType == "Keyword Phrase") {  //PHRASE SEARCH  
                    string searchTerm = phraseTextBox.Text;

                    if (searchTerm == "") {
                        throw new Exception("No search term was entered, aborting search");
                    }

                    if (recursive) {
                        results = await Task.Run(() => { return search.phraseSearchRecur(searchTerm, path); });

                    } else {
                        results = await Task.Run(() => { return search.phraseSearch(searchTerm); });
                    }

                } else if (searchType == "Number Range") {  //RANGE SEARCH
                    int lower = Int32.Parse(lowerBound.Text);
                    int upper = Int32.Parse(upperBound.Text);

                    if (recursive) {
                        results = await Task.Run(() => { return search.rangeSearchRecur(lower, upper, path); });
                    } else {
                        results = await Task.Run(() => { return search.rangeSearch(lower, upper); });
                    }

                } else {
                    throw new Exception("Invalid search type, please select a valid search type from the dropdown");
                }

            } catch(Exception err){ //Catch if there is an invalid search type
                util.consoleLog(err.Message);
                errorPopup(err.Message, "Search Error");
            }

            searchBtn.Cursor = Cursors.Default;

            if (cancel) {
                statusBar.Text = "CANCELLED";
                return;
            } else {
                statusBar.Text = "DONE";
            }

            //Output found files to the form
            outputResults(results);

            //Enable proper buttons
            cancelBtn.Enabled = false;
            searchBtn.Enabled = true;
        }

        private void cancelBtn_Click(object sender, EventArgs e) {
            cancel = true;
            cancelBtn.Enabled = false;
            searchBtn.Enabled = true;
        }
    }
}
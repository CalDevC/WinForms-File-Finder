
namespace File_Finder {
    public partial class File_Finder : Form {

        Utils util = new Utils();
        bool cancel = false;

        //Constructor
        public File_Finder() {
            InitializeComponent();
        }

        //On form load
        private void Form1_Load(object sender, EventArgs e) {
            Tests test = new Tests(this);

            phraseTextBox.Hide();
            lowerBound.Hide();
            upperBound.Hide();
            label3.Hide();
            label4.Hide();
            cancelBtn.Enabled = false;
            darkModeOn();
            test.test3();
        }

        //Set Dark Mode
        private void darkModeOn() {
            Color dark = SystemColors.ControlDark;
            Color darker = SystemColors.ControlDarkDark;
            Color light = SystemColors.Control;

            ForeColor = light;
            BackColor = dark;
            foundFiles.BackColor = darker;
            foundFilesPath.BackColor = darker;
            notDetected.BackColor = darker;
        }

        //Allows unit tests to fill out the form
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

        //On dropdown value change
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
            foreach (KeyValuePair<string, bool> entry in results) {
                if (entry.Value == true) {
                    string filepath = entry.Key;
                    string filename = filepath.Split("\\").Last();
                    foundFiles.Items.Add(filename);
                    foundFilesPath.Items.Add(filepath);
                } else if (entry.Value == false) {
                    notDetected.Items.Add(entry.Key);
                } else {
                    errorPopup("Result dictionary error: key value was neither true nor false.", "Error");
                }

            }
        }

        //Update the status bar
        public void updateStatus(string text) {
            statusBar.Text = text;
        }

        //Launch an error pop-up
        private void errorPopup(string exceptionMsg, string popupTitle) {
            MessageBox.Show(
                exceptionMsg,
                popupTitle,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        //Launch an info pop-up
        private DialogResult infoPopup(string msg, string popupTitle) {
            return MessageBox.Show(
                msg,
                popupTitle,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Exclamation
            );
        }
        
        //Get the value of the cancel flag
        public bool getCancel() {
            return cancel;
        }

        //On cancel button clicked
        private void cancelBtn_Click(object sender, EventArgs e) {
            cancel = true;
            cancelBtn.Enabled = false;
            searchBtn.Enabled = true;
        }

        //On Search button clicked
        private async void searchBtn_Click(object sender, EventArgs e) {
            //Initialize variables with user input
            string path = pathTextBox.Text;
            string searchType = searchTermType.Text;
            bool recursive = recurCheckBox.Checked;
            string fileTypes = fileTypesTextBox.Text;

            //Check path validity
            if (path == "" || !Directory.Exists(path)) {
                errorPopup("Invalid search path, please enter a valid directory to search. Begin path with: \\\\", "Search Error");
                return;
            }

            //Ask to confirm search for all file types
            if (fileTypes == "") {
                DialogResult selection = infoPopup(
                    "The current search criteria specify no file types. " +
                    "This will cause the File Finder to return all matching " +
                    "search results regardless of file type.",
                    "Search Warning"
                );

                if(selection == DialogResult.Cancel) {
                    return;
                }
            }

            //Update UI elements
            cancel = false;
            cancelBtn.Enabled = true;
            searchBtn.Enabled = false;
            foundFiles.Items.Clear();
            foundFilesPath.Items.Clear();
            notDetected.Items.Clear();

            Search search = new Search(this, path, fileTypes);
            Dictionary<string, bool> results = new Dictionary<string, bool>();

            //Try to do a search and catch any additioanl user input issues
            try {
                if (searchType == "Keyword Phrase") {  //PHRASE SEARCH  
                    string searchTerm = phraseTextBox.Text;

                    if (searchTerm == "") {
                        throw new Exception("No search term was entered, aborting search.");
                    }

                    //Run either recursive or nonrecursive phrase search
                    results = await Task.Run(() => { return recursive ? search.phraseSearchRecur(searchTerm, path) : search.phraseSearch(searchTerm); } );

                } else if (searchType == "Number Range") {  //RANGE SEARCH
                    int lower = Int32.Parse(lowerBound.Text);
                    int upper = Int32.Parse(upperBound.Text);

                    if (lower > upper) {
                        throw new Exception("Invalid range: lower bound must be less than or equal to upper value.");
                    }

                    //Run either recursive or nonrecursive range search
                    results = await Task.Run(() => { return recursive ? search.rangeSearchRecur(lower, upper, path) : search.rangeSearch(lower, upper); });

                } else {
                    throw new Exception("Invalid search type, please select a valid search type from the dropdown.");
                }

            } catch(Exception err){ //Catch if there is an invalid search type
                util.consoleLog(err.Message);
                errorPopup(err.Message + " Aborting search.", "Search Error");
            }

            if (cancel) {
                statusBar.Text = "CANCELLED";
                return;
            }

            statusBar.Text = "DONE";

            //Output found files to the form
            outputResults(results);

            //Enable proper buttons
            cancelBtn.Enabled = false;
            searchBtn.Enabled = true;
        }


    }
}
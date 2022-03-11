using System.Diagnostics;

namespace File_Finder {
    public partial class File_Finder : Form {

        Utils util = new Utils();
        bool cancel = false;
        Stopwatch performanceTimer = new Stopwatch();

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
            //darkModeOn();
            test.test9();
        }

        //Set Dark Mode
        private void darkModeOn() {
            Color dark = SystemColors.ControlDark;
            Color darker = SystemColors.ControlDarkDark;
            Color light = SystemColors.Control;

            ForeColor = light;
            BackColor = darker;
            foundFiles.BackColor = dark;
            foundFilesPath.BackColor = dark;
            notDetected.BackColor = dark;
            searchBtn.BackColor = dark;
            
        }

        //Allows unit tests to fill out the form
        public void setUIValues(string path, string fileTypes, int searchTypeIdx, string searchTerm, bool recursive) {
            //Pass info into text fields
            pathTextBox.Text = path;
            fileTypesTextBox.Text = fileTypes;
            searchTermType.SelectedIndex = searchTypeIdx;

            
            if(searchTypeIdx == 0) {
                //If a phrase search is selected then fill out the phrase search text fields
                phraseTextBox.Text = searchTerm;
            } else if(searchTypeIdx == 1){
                //If a range search is selected then fill out the range search text fields
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

        //Output results to the GUI search
        private void outputResults(List<string> files, string searchType, string searchTerm) {
            if(searchType == "Keyword Phrase") {  //Output phrase search results
                foreach (var filepath in files) {
                    //If search term was found in the returned file list then no match was found
                    if (filepath == searchTerm) {
                        notDetected.Items.Add(filepath);
                    } else {  //If the term was found then record its full path and filename
                        string filename = filepath.Split("\\").Last();
                        foundFiles.Items.Add(filename);
                        foundFilesPath.Items.Add(filepath);
                    }
                }
            } else if(searchType == "Number Range"){  //Output range search results
                int lower = Int32.Parse(searchTerm.Split("-")[0]);
                int upper = Int32.Parse(searchTerm.Split("-")[1]);

                //Make a list containing all of the numbers that were searched for
                List<string> rangeVals = new List<string>();
                for (int i = lower; i <= upper; i++) {
                    rangeVals.Add(i.ToString());
                }

                foreach (var filepath in files) {
                    string filename = filepath.Split("\\").Last();
                    //If the filename is equal to any of the values in the
                    //returned file list then no match was found
                    if (rangeVals.Any(filename.Equals)) {
                        notDetected.Items.Add(filename);
                    } else {  //If the term was found then record its full path and filename
                        foundFiles.Items.Add(filename);
                        foundFilesPath.Items.Add(filepath);
                    }
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

        //Convert performance timer output to human readable format
        string convertTime(long timeMS) {
            if (timeMS < 1000)
                return $"Search completed in {timeMS} milliseconds";
            else if (timeMS < 60000)
                return $"Search completed in {timeMS / 1000} seconds";
            else
                return $"Search completed in {timeMS / 60000} minutes and {(timeMS % 60000) / 1000} seconds";
        }

        //On Search button clicked
        private async void searchBtn_Click(object sender, EventArgs e) {
            //Initialize variables with user input
            string path = pathTextBox.Text;
            string searchType = searchTermType.Text;
            bool recursive = recurCheckBox.Checked;
            string fileTypes = fileTypesTextBox.Text;
            string searchTerm = "";

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

                if (selection == DialogResult.Cancel) {
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
            List<string> results = new List<string>();

            //Try to do a search and catch any additioanl user input issues
            try {
                if (searchType == "Keyword Phrase") {  //PHRASE SEARCH  
                    searchTerm = phraseTextBox.Text;

                    if (searchTerm == "") {
                        throw new Exception("No search term was entered, aborting search.");
                    }

                    performanceTimer.Restart();
                    //Run either recursive or nonrecursive phrase search
                    results = await Task.Run(() => { return recursive ? search.phraseSearchRecur(searchTerm) : search.phraseSearch(searchTerm); });

                } else if (searchType == "Number Range") {  //RANGE SEARCH
                    searchTerm = lowerBound.Text + "-" + upperBound.Text;
                    int lower = Int32.Parse(lowerBound.Text);
                    int upper = Int32.Parse(upperBound.Text);

                    if (lower > upper) {
                        throw new Exception("Invalid range: lower bound must be less than or equal to upper value.");
                    }

                    performanceTimer.Restart();
                    //Run either recursive or nonrecursive range search
                    results = await Task.Run(() => { return recursive ? search.rangeSearchRecur(lower, upper) : search.rangeSearch(lower, upper); });

                } else {
                    throw new Exception("Invalid search type, please select a valid search type from the dropdown.");
                }

            } catch (Exception err) { //Catch if there is an invalid search type
                util.consoleLog(err.Message);
                errorPopup(err.Message + " Aborting search.", "Search Error");
            }

            performanceTimer.Stop();

            if (cancel) {
                statusBar.Text = "CANCELLED";
                return;
            }

            cancelBtn.Enabled = false;

            //Output found files to the form
            outputResults(results, searchType, searchTerm);

            string timeOutput = convertTime(performanceTimer.ElapsedMilliseconds);
            statusBar.Text = timeOutput;
            util.consoleLog(timeOutput);

            //Enable proper buttons
            searchBtn.Enabled = true;
        }

        private void fileItemCM_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            //Get the object that called the context menu
            ContextMenuStrip strip = (ContextMenuStrip) sender;
            ListBox stripParent = (ListBox) strip.SourceControl;
            string path = "";

            //Get the selected item
            if(stripParent.SelectedIndex < 0) {
                util.consoleLog("ERROR: Selected item's index was less than 0");
                errorPopup("Select an item to open", "Open file error");
                return;
            } else {
                path = foundFilesPath.GetItemText(foundFilesPath.Items[stripParent.SelectedIndex]);
            }

            strip.Hide();

            if (e.ClickedItem.Name == "open_file") {
                openFile(path);
            } else if(e.ClickedItem.Name == "open_explorer") {
                openFileExp();
            }
        }

        //Opens a file located at path
        private void openFile(string path) {
            //Open the file located at path
            if (File.Exists(path)) {
                new Process {
                    StartInfo = new ProcessStartInfo($@"{path}") {
                        UseShellExecute = true,
                        FileName = path
                    }
                }.Start();
            } else {
                util.consoleLog("ERROR: Selected item was not a valid file path");
                errorPopup("Select an item to open", "Open file error");
                return;
            }
            
        }

        private void openFileExp() {
            //Open the directory of the file that was clicked on using the File Explorer
            OpenFileDialog dialog = new OpenFileDialog();
            if (DialogResult.OK == dialog.ShowDialog()) {
                string selectedItemPath = dialog.FileName;

                //Open the file selected using the File Explorer with its default application
                new Process {
                    StartInfo = new ProcessStartInfo($@"{selectedItemPath}") {
                        UseShellExecute = true,
                        FileName = selectedItemPath
                    }
                }.Start();
            }
        }

        //On a found files item double clicked
        private void foundFilesPath_DoubleClick(object sender, EventArgs e) {
            if (foundFilesPath.SelectedItem != null) {
                //Open the file that was double clicked on with its default application
                openFile(foundFilesPath.GetItemText(foundFilesPath.SelectedItem));
            }
        }

        //On a found files (full path) item double clicked
        private void foundFiles_DoubleClick(object sender, EventArgs e) {
            if (foundFiles.SelectedItem != null) {
                //Open the file that was double clicked on with its default application
                openFile(foundFilesPath.GetItemText(foundFilesPath.Items[foundFiles.SelectedIndex]));
            }
        }
    }
}
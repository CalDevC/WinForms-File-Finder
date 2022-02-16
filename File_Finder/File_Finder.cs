using System.Threading;

namespace File_Finder {
    public partial class File_Finder : Form {
        public File_Finder() {
            InitializeComponent();
        }

        //***** Output writer *****//
        public void consoleLog(string msg) {
            System.Diagnostics.Debug.WriteLine(msg);
        }

        public void test1() {
            pathTextBox.Text = "\\\\upifile1\\vidar";
            fileTypesTextBox.Text = ".pdf,.png,.tif,.jpg,.dwg";
            searchTermType.SelectedIndex = 0;
            phraseTextBox.Text = "motor";
        }

        public void test2() {
            pathTextBox.Text = "\\\\upifile1\\vidar";
            fileTypesTextBox.Text = ".pdf,.png,.tif,.jpg,.dwg";
            //searchTermType.SelectedIndex = 0;
            phraseTextBox.Text = "motor";
        }

        private void Form1_Load(object sender, EventArgs e) {
            phraseTextBox.Hide();
            lowerBound.Hide();
            upperBound.Hide();
            label3.Hide();
            label4.Hide();

            #if DEBUG
                test2();
            #endif

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

        //update the status bar
        public void updateStatus(string text) {
            statusBar.Text = text;
        }

        //Search button clicked
        private void button1_Click(object sender, EventArgs e) {
            string path = pathTextBox.Text;
            string searchType = searchTermType.Text;
            bool recursive = recurCheckBox.Checked;
            string fileTypes = fileTypesTextBox.Text;
            Search search = new Search(this, path, fileTypes);

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

            //Set wait cursor
            button1.Cursor = Cursors.WaitCursor;

            //Start a new thread to perfrom the search so taht UI can be updated
            var thread = new Thread(() => {
                Thread.CurrentThread.IsBackground = true;
                try {
                    if (searchType == "Keyword Phrase") {  //PHRASE SEARCH  
                        string searchTerm = phraseTextBox.Text;

                        if (recursive) {
                            results = search.phraseSearchRecur(searchTerm, path);
                        } else {
                            results = search.phraseSearch(searchTerm);
                        }

                    } else if (searchType == "Number Range") {  //RANGE SEARCH
                        int lower = Int32.Parse(lowerBound.Text);
                        int upper = Int32.Parse(upperBound.Text);

                        if (recursive) {
                            results = search.rangeSearchRecur(lower, upper, path);
                        } else {
                            results = search.rangeSearch(lower, upper);
                        }

                    } else {
                        throw new Exception("Invalid search type");
                    }
                } catch(Exception e){
                    consoleLog(e.Message);
                }

                statusBar.Text = "DONE";
            });
            thread.Start();
            thread.Join();
            //Output found files to the form
            outputResults(results);
            button1.Cursor = Cursors.Default;
        }





    }
}
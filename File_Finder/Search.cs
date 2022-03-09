using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace File_Finder {
    internal class Search {

        //Message strings
        private string searchMsg = "Searching ";

        private string[] fileTypes;
        private string path;
        private File_Finder ui;
        private Utils util;

        //***** Constructor *****//
        public Search(File_Finder sender, string path, string fileTypes) {
            this.path = path;
            this.fileTypes = fileTypes.Split(',');
            this.ui = sender;
            this.util = new Utils();
        }

        //***** Non-recursive phrase search *****//
        public List<string> phraseSearch(string searchTerm) {
            List<string> fileList = new List<string>();
            searchTerm = searchTerm.ToLower();

            //Update UI
            ui.Invoke((MethodInvoker)delegate { ui.updateStatus(searchMsg + path); });

            //For each found directory do a recursive phrase search
            foreach (var type in fileTypes) {
                fileList.AddRange(Directory.GetFiles(path, $"*{searchTerm}*{type}"));
                if (fileList.Count == 0) {
                    util.consoleLog("NOT FOUND\n");
                    fileList.Add(searchTerm);
                }
            }
            
            return fileList;
        }

        //Gather files
        private List<string> getAllFiles(string path, List<string> fileList, string searchTerm) {
            foreach(var type in fileTypes) {
                if (ui.getCancel()) { return fileList; }
                fileList.AddRange(Directory.GetFiles(path, $"*{searchTerm}*{type}"));
            }

            Parallel.ForEach(Directory.GetDirectories(path), (d, state) => {
                if (ui.getCancel()) {
                    state.Stop();
                    return; 
                }
                ui.Invoke((MethodInvoker)delegate { ui.updateStatus(searchMsg + d); });
                getAllFiles(d, fileList, searchTerm);
            });
            return fileList;
        }

        //***** Recursive phrase search *****//
        public List<string> phraseSearchRecur(string searchTerm, string path) {
            searchTerm = searchTerm.ToLower();
            List<string> fileList = new List<string>();

            //For each found directory do a recursive phrase search
            fileList = getAllFiles(path, fileList, searchTerm);
            if(fileList.Count == 0) {
                util.consoleLog("NOT FOUND\n");
                fileList.Add(searchTerm);
            }

            return fileList;
        }



        //***** Non-recursive range search *****//
        public Dictionary<string, bool> rangeSearch(int lower, int upper) {
            Dictionary<string, bool> results = new Dictionary<string, bool>();

            //For each file type
            foreach (var type in fileTypes) {
                //Get all file names of the current type that contain the search term
                var fileList = Directory.GetFiles(path, "*" + type);

                //Get all filenames that contain the search term
                foreach (string filepath in fileList) {
                    //Update UI status bar
                    ui.Invoke((MethodInvoker)delegate { ui.updateStatus(searchMsg + filepath); });

                    string filename = filepath.Split("\\").Last();

                    //For each number in the range
                    for (int searchTerm = lower; searchTerm <= upper; searchTerm++) {
                        if (ui.getCancel()) {
                            return results;
                        }

                        if (filename.Contains(searchTerm.ToString())) {
                            if (!results.ContainsKey(filepath)) {
                                results.Add(filepath, true);  //Append the found file
                            }
                        }
                    }
                }
            }

            //If term was not found
            for (int searchTerm = lower; searchTerm <= upper; searchTerm++) {
                bool notFound = true;
                foreach (var entry in results) {
                    if (entry.Key.Contains(searchTerm.ToString())) {
                        notFound = false;
                        break;
                    }
                }

                if (notFound) {
                    results.Add(searchTerm.ToString(), false);
                }
            }


            return results;
        }

        //public List<string> rangeSearch(int lower, int upper) {
        //    List<string> results = new List<string>();
        //    List<string> prev = results.ToList();

        //    //For each file type
        //    foreach (var type in fileTypes) {
        //        //Get all file names of the current type that contain the search term
        //        var fileList = Directory.GetFiles(path, "*" + type);

        //        //Get all filenames that contain the search term
        //        foreach (string filepath in fileList) {
        //            //Update UI status bar
        //            ui.Invoke((MethodInvoker)delegate { ui.updateStatus(searchMsg + filepath); });

        //            string filename = filepath.Split("\\").Last();

        //            //For each number in the range
        //            for (int searchTerm = lower; searchTerm <= upper; searchTerm++) {
        //                if (ui.getCancel()) {
        //                    return results;
        //                }

        //                if (filename.Contains(searchTerm.ToString())) {
        //                    if (!results.Contains(filepath)) {
        //                        results.Add(filepath);  //Append the found file
        //                    }
        //                }
        //            }
        //        }
        //    }

        //Gather files
        private List<string> getAllFilesRange(string path, List<string> fileList, List<string> rangeVals) {
            foreach (var type in fileTypes) {
                if (ui.getCancel()) { return fileList; }
                fileList.AddRange(Directory.GetFiles(path, $"*{type}").Where(filename => rangeVals.Any(filename.Split("\\").Last().Contains)));
            }

            Parallel.ForEach(Directory.GetDirectories(path), (d, state) => {
                if (ui.getCancel()) {
                    state.Stop();
                    return;
                }
                ui.Invoke((MethodInvoker)delegate { ui.updateStatus(searchMsg + d); });
                getAllFilesRange(d, fileList, rangeVals);
            });
            return fileList;
        }

        //***** Recursive range search *****//
        public List<string> rangeSearchRecur(int lower, int upper, string path) {
            List<string> fileList = new List<string>();
            List<string> rangeVals = new List<string>();

            for (int i = lower; i <= upper; i++) {
                rangeVals.Add(i.ToString());
            }

            List<string> notFound = rangeVals.ToList();
            fileList = getAllFilesRange(path, fileList, rangeVals);
            fileList.RemoveAll(item => item == null);

            foreach (var filepath in fileList) {
                string filename = filepath.Split("\\").Last();
                for (int i = lower; i <= upper; i++) {
                    if (filename.Contains(i.ToString())) {
                        notFound.Remove(i.ToString());
                    }
                }
            }

            fileList.AddRange(notFound);

            return fileList;
        }

    }
}

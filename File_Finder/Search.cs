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
            string originalSearchTerm = searchTerm;
            searchTerm = searchTerm.ToLower();

            //Update UI
            ui.Invoke((MethodInvoker)delegate { ui.updateStatus(searchMsg + path); });

            //For each found directory do a recursive phrase search
            foreach (var type in fileTypes) {
                try {
                    fileList.AddRange(Directory.GetFiles(path, $"*{searchTerm}*{type}"));
                }
                catch (Exception err) {
                    util.consoleLog(err.Message);
                }

                if (fileList.Count == 0) {
                    util.consoleLog("NOT FOUND\n");
                    fileList.Add(originalSearchTerm);
                }
            }
            
            return fileList;
        }

        //Gather files
        private List<string> getAllFiles(string path, List<string> fileList, string searchTerm) {
            foreach(var type in fileTypes) {
                if (ui.getCancel()) { return fileList; }
                try {
                    fileList.AddRange(Directory.GetFiles(path, $"*{searchTerm}*{type}"));
                }catch(Exception err){
                    util.consoleLog(err.Message);
                    continue;
                }
            }
            try {
                Parallel.ForEach(Directory.GetDirectories(path), (d, state) => {
                    if (ui.getCancel()) {
                        state.Stop();
                        return; 
                    }
                    ui.Invoke((MethodInvoker)delegate { ui.updateStatus(searchMsg + d); });
                    getAllFiles(d, fileList, searchTerm);
                });
            }catch(Exception err){
                util.consoleLog(err.Message);
            }

            return fileList;
        }

        //***** Recursive phrase search *****//
        public List<string> phraseSearchRecur(string searchTerm) {
            string originalSearchTerm = searchTerm;
            searchTerm = searchTerm.ToLower();
            List<string> fileList = new List<string>();

            //For each found directory do a recursive phrase search
            fileList = getAllFiles(path, fileList, searchTerm);

            fileList.RemoveAll(item => item == null);

            if (fileList.Count == 0) {
                util.consoleLog("NOT FOUND\n");
                fileList.Add(originalSearchTerm);
            }

            //Update UI
            ui.Invoke((MethodInvoker)delegate { ui.updateStatus("Outputting found files..."); });

            return fileList;
        }



        //***** Non-recursive range search *****//
        public List<string> rangeSearch(int lower, int upper) {
            List<string> fileList = new List<string>();
            List<string> rangeVals = new List<string>();

            //Update UI
            ui.Invoke((MethodInvoker)delegate { ui.updateStatus(searchMsg + path); });

            for (int i = lower; i <= upper; i++) {
                rangeVals.Add(i.ToString());
            }

            List<string> notFound = rangeVals.ToList();

            foreach (var type in fileTypes) {
                if (ui.getCancel()) { return fileList; }

                try {
                    fileList.AddRange(Directory.GetFiles(path, $"*{type}").Where(filename => rangeVals.Any(filename.Split("\\").Last().Contains)));
                }
                catch (Exception err) {
                    util.consoleLog(err.Message);
                    continue;
                }
            }

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

            //Update UI
            ui.Invoke((MethodInvoker)delegate { ui.updateStatus("Outputting found files..."); });

            return fileList;
        }

        //Gather files
        private List<string> getAllFilesRange(string path, List<string> fileList, List<string> rangeVals) {
            foreach (var type in fileTypes) {
                if (ui.getCancel()) { return fileList; }
                try { 
                fileList.AddRange(Directory.GetFiles(path, $"*{type}").Where(filename => rangeVals.Any(filename.Split("\\").Last().Contains)));
                }
                catch (Exception err) {
                    util.consoleLog(err.Message);
                    continue;
                }
            }

            try {
                Parallel.ForEach(Directory.GetDirectories(path), (d, state) => {
                    if (ui.getCancel()) {
                        state.Stop();
                        return;
                    }
                    ui.Invoke((MethodInvoker)delegate { ui.updateStatus(searchMsg + d); });
                    getAllFilesRange(d, fileList, rangeVals);
                });
            }
            catch (Exception err) {
                util.consoleLog(err.Message);
            }
            return fileList;
        }

        //***** Recursive range search *****//
        public List<string> rangeSearchRecur(int lower, int upper) {
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

            //Update UI
            ui.Invoke((MethodInvoker)delegate { ui.updateStatus("Outputting found files..."); });

            return fileList;
        }

    }
}

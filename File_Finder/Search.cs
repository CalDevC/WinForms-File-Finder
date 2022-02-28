﻿using System;
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
        public Dictionary<string, bool> phraseSearch(string searchTerm) {
            Dictionary<string, bool> results = new Dictionary<string, bool>();
            searchTerm = searchTerm.ToLower();

            //For each file type
            foreach (var type in fileTypes) {

                //Get all file names of the current type that contain the search term
                var fileList = Directory.GetFiles(path, "*" + type);

                //Get all filenames that contain the search term
                foreach (string filepath in fileList) {
                    if (ui.getCancel()) {
                        return results;
                    }
                    
                    //Update UI status bar
                    ui.Invoke((MethodInvoker)delegate { ui.updateStatus(searchMsg + filepath); });

                    string filename = filepath.Split("\\").Last();
                    if (filename.ToLower().Contains(searchTerm)) {
                        results.Add(filepath, true);  //Append the found file names to temp found
                    }

                }
            }

            if (results.Count == 0) {
                results.Add(searchTerm, false);
            }

            return results;
        }



        //***** Recursive phrase search *****//
        public Dictionary<string, bool> phraseSearchRecur(string searchTerm, string path) {
            Dictionary<string, bool> results = new Dictionary<string, bool>();
            searchTerm = searchTerm.ToLower();

            //var thread = new Thread(() => {
            Parallel.ForEach(Directory.GetDirectories(path), (directory, state) => {
                if (ui.getCancel()) {
                    state.Stop();
                    return;
                }

                Dictionary<string, bool> subdirResults = phraseSearchRecur(searchTerm, directory);

                //Remove any non-detections that may have been added by a subdirectory
                foreach (var item in subdirResults.Where(x => x.Value == false).ToList()) {
                    subdirResults.Remove(item.Key);
                }

                //Combine the subdirectory results with the overall results
                subdirResults.ToList().ForEach(x => results[x.Key] = x.Value);
            });
            //});
            //    thread.Start();
            //    thread.Join();

            //*************** CODE THAT WAS REPLACED BY Parallel.ForEach() **************//
            ////For each found directory do a recursive phrase search
            //foreach (var directory in Directory.GetDirectories(path)) {
            //    if (ui.getCancel()) {
            //        return results;
            //    }

            //    Dictionary<string, bool> subdirResults = phraseSearchRecur(searchTerm, directory);

            //    //Remove any non-detections that may have been added by a subdirectory
            //    foreach (var item in subdirResults.Where(x => x.Value == false).ToList()) {
            //        subdirResults.Remove(item.Key);
            //    }

            //    //Combine the subdirectory results with the overall results
            //    subdirResults.ToList().ForEach(x => results[x.Key] = x.Value);
            //}
            //*************** END OF CODE THAT WAS REPLACED BY Parallel.ForEach() **************//

            //For each file type
            foreach (var type in fileTypes) {

                //Get all file names of the current type that contain the search term
                var fileList = Directory.GetFiles(path, "*" + type);

                //Get all filenames that contain the search term
                foreach (string filepath in fileList) {
                    if (ui.getCancel()) {
                        return results;
                    }
                    
                    //Update UI status bar
                    ui.Invoke((MethodInvoker)delegate { ui.updateStatus(searchMsg + filepath); });

                    string filename = filepath.Split("\\").Last();
                    if (filename.ToLower().Contains(searchTerm)) {
                        results.Add(filepath, true);  //Append the found file names to temp found
                    }
                }
            }

            if (results.Count == 0) {
                results.Add(searchTerm, false);
            }

            return results;
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



        //***** Recursive range search *****//
        public Dictionary<string, bool> rangeSearchRecur(int lower, int upper, string path) {
            Dictionary<string, bool> results = new Dictionary<string, bool>();

            //For each found directory do a recursive range search
            foreach (var directory in Directory.GetDirectories(path)) {
                if (ui.getCancel()) {
                    return results;
                }

                Dictionary<string, bool> subdirResults = rangeSearchRecur(lower, upper, directory);

                //Remove any non-detections that may have been added by a subdirectory
                foreach (var item in subdirResults.Where(x => x.Value == false).ToList()) {
                    subdirResults.Remove(item.Key);
                }

                //Combine the subdirectory results with the overall results
                subdirResults.ToList().ForEach(x => results[x.Key] = x.Value);
            }

            //For each file type
            foreach (var type in fileTypes) {

                //Get all file names of the current type that contain the search term
                var fileList = Directory.GetFiles(path, "*" + type);

                //Get all filenames that contain the search term
                foreach (string filepath in fileList) {
                    if (ui.getCancel()) {
                        return results;
                    }

                    //Update UI status bar
                    ui.Invoke((MethodInvoker)delegate { ui.updateStatus(searchMsg + filepath); });

                    string filename = filepath.Split("\\").Last();

                    //For each number in the range
                    for (int searchTerm = lower; searchTerm <= upper; searchTerm++) {
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

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Finder {
    internal class Search {

        private string[] fileTypes;
        private string path;

        //***** Constructor *****//
        public Search(string path, string fileTypes) {
            this.path = path;
            this.fileTypes = fileTypes.Split(',');
        }


        //***** Non-recursive phrase search *****//
        public Dictionary<string, bool> phraseSearch(string searchTerm) {
            Dictionary<string, bool> results = new Dictionary<string, bool> ();
            searchTerm = searchTerm.ToLower();

            //For each file type
            foreach (var type in fileTypes) {

                //Get all file names of the current type that contain the search term
                var fileList = Directory.GetFiles(path, "*" + type);

                //Get all filenames that contain the search term
                foreach (string filepath in fileList) {
                    string filename = filepath.Split("\\").Last();
                    if (filename.ToLower().Contains(searchTerm)) {
                        results.Add(filepath, true);  //Append the found file names to temp found
                        System.Diagnostics.Debug.WriteLine("Added " + filepath);
                    }
                    
                }
            }

            if(results.Count == 0) {
                results.Add (searchTerm, false);
            }

            return results;      
        }


        //***** Recursive phrase search *****//
        public Dictionary<string, bool> phraseSearchRecur(string searchTerm, string path) {
            Dictionary<string, bool> results = new Dictionary<string, bool>();
            searchTerm = searchTerm.ToLower();

            //For each found directory do a recursive phrase search
            foreach (var directory in Directory.GetDirectories(path)) {
                Dictionary<string, bool> subdirResults = phraseSearchRecur(searchTerm, directory);

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
                    string filename = filepath.Split("\\").Last();
                    if (filename.ToLower().Contains(searchTerm)) {
                        results.Add(filepath, true);  //Append the found file names to temp found
                        System.Diagnostics.Debug.WriteLine("Added " + filepath);
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
            int prevCount = 0;

            //For each number in the range
            for (int searchTerm = lower; searchTerm <= upper; searchTerm++) {
                //For each file type
                foreach (var type in fileTypes) {

                    //Get all file names of the current type that contain the search term
                    var fileList = Directory.GetFiles(path, "*" + type);

                    //Get all filenames that contain the search term
                    foreach (string filepath in fileList) {
                        string filename = filepath.Split("\\").Last();
                        if (filename.Contains(searchTerm.ToString())) {
                            results.Add(filepath, true);  //Append the found file names to temp found
                            System.Diagnostics.Debug.WriteLine("Added " + filepath);
                        }
                    }
                }

                //If term was not found
                if (results.Count == prevCount) {
                    results.Add(searchTerm.ToString(), false);
                } else {
                    prevCount = results.Count;
                }
            }

            return results;
        }


        //***** Recursive range search *****//
        public Dictionary<string, bool> rangeSearchRecur(int lower, int upper, string path) {
            Dictionary<string, bool> results = new Dictionary<string, bool>();
            int prevCount = 0;

            //For each number in the range
            for (int searchTerm = lower; searchTerm <= upper; searchTerm++) {

                //For each found directory do a recursive range search
                foreach (var directory in Directory.GetDirectories(path)) {
                    rangeSearchRecur(lower, upper, directory).ToList().ForEach(x => results[x.Key] = x.Value);
                }

                //For each file type
                foreach (var type in fileTypes) {

                    //Get all file names of the current type that contain the search term
                    var fileList = Directory.GetFiles(path, "*" + type);

                    //Get all filenames that contain the search term
                    foreach (string filepath in fileList) {
                        string filename = filepath.Split("\\").Last();
                        if (filename.Contains(searchTerm.ToString())) {
                            results.Add(filepath, true);  //Append the found file names to temp found
                            System.Diagnostics.Debug.WriteLine("Added " + filepath);
                        }
                    }
                }

                //If term was not found
                if (results.Count == prevCount) {
                    results.Add(searchTerm.ToString(), false);
                } else {
                    prevCount = results.Count;
                }

            }

            return results;
        }


    }
}

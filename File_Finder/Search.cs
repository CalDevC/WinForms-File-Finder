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
            //List<string> foundFiles = new List<string>();
            Dictionary<string, bool> results = new Dictionary<string, bool> ();

            //For each file type
            foreach (var type in fileTypes) {

                //Get all file names of the current type that contain the search term
                var fileList = Directory.GetFiles(path, "*" + type);

                //Get all filenames that contain the search term
                foreach (string filepath in fileList) {
                    string filename = filepath.Split("\\").Last();
                    if (filename.Contains(searchTerm)) {
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
        public List<string> phraseSearchRecur(string searchTerm, string path) {
            List<string> foundFiles = new List<string>();

            //For each found directory do a recursive phrase search
            foreach (var directory in Directory.GetDirectories(path)) {
                foundFiles.AddRange(phraseSearchRecur(searchTerm, directory));
            }

            //For each file type
            foreach (var type in fileTypes) {

                //Get all file names of the current type that contain the search term
                var fileList = Directory.GetFiles(path, "*" + type);

                //Get all filenames that contain the search term
                foreach (string filepath in fileList) {
                    string filename = filepath.Split("\\").Last();
                    if (filename.Contains(searchTerm)) {
                        foundFiles.Add(filepath);  //Append the found file names to temp found
                        System.Diagnostics.Debug.WriteLine("Added " + filepath);
                    }
                }
            }

            return foundFiles;
        }


        //***** Non-recursive range search *****//
        public List<string> rangeSearch(int lower, int upper) {
            List<string> foundFiles = new List<string>();
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
                            foundFiles.Add(filepath);  //Append the found file names to temp found
                            System.Diagnostics.Debug.WriteLine("Added " + filepath);
                        }
                    }
                }

                //If term was not found
                if (foundFiles.Count == prevCount) {
                    
                } else {
                    prevCount = foundFiles.Count;
                }
            }

            return foundFiles;
        }


        //***** Recursive range search *****//
        public List<string> rangeSearchRecur(int lower, int upper, string path) {
            List<string> foundFiles = new List<string>();

            //For each number in the range
            for (int searchTerm = lower; searchTerm <= upper; searchTerm++) {

                //For each found directory do a recursive range search
                foreach (var directory in Directory.GetDirectories(path)) {
                    foundFiles.AddRange(rangeSearchRecur(lower, upper, directory));
                }

                //For each file type
                foreach (var type in fileTypes) {

                    //Get all file names of the current type that contain the search term
                    var fileList = Directory.GetFiles(path, "*" + type);

                    //Get all filenames that contain the search term
                    foreach (string filepath in fileList) {
                        string filename = filepath.Split("\\").Last();
                        if (filename.Contains(searchTerm.ToString())) {
                            foundFiles.Add(filepath);  //Append the found file names to temp found
                            System.Diagnostics.Debug.WriteLine("Added " + filepath);
                        }
                    }
                }
            }

            return foundFiles;
        }


    }
}

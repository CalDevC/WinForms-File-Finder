using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Finder {
    internal class Search {

        private string[] fileTypes;
        private string path;

        public Search(string path, string fileTypes) {
            this.path = path;
            this.fileTypes = fileTypes.Split(',');
        }

        public List<string> phraseSearch(string searchTerm) {
            List<string> foundFiles = new List<string>();
            //For each file type
            foreach (var type in fileTypes) {
                //Get all file names of the current type that contain the search term
                var fileList = Directory.GetFiles(path, "*" + type);
                foreach (string filepath in fileList) {
                    string filename = filepath.Split("\\").Last();
                    if (filename.Contains(searchTerm)) {
                        foundFiles.Add(filepath);  //Append the found file names to temp found
                        System.Diagnostics.Debug.WriteLine(filepath + "   " + foundFiles.Count);
                    }
                }
            }

            return foundFiles;      
        }

        public List<string> phraseSearchRecur(string searchTerm, string path) {
            List<string> foundFiles = new List<string>();
            //For each directory including the root one
            foreach (var directory in Directory.GetDirectories(path)) {
                foundFiles.AddRange(phraseSearchRecur(searchTerm, directory));
            }
            //For each file type
            foreach (var type in fileTypes) {
                //Get all file names of the current type that contain the search term
                var fileList = Directory.GetFiles(path, "*" + type);
                foreach (string filepath in fileList) {
                    string filename = filepath.Split("\\").Last();
                    if (filename.Contains(searchTerm)) {
                        foundFiles.Add(filepath);  //Append the found file names to temp found
                        System.Diagnostics.Debug.WriteLine(filepath + "   " + foundFiles.Count);
                    }
                }
            }

            return foundFiles;
        }

        public List<string> rangeSearch(int lower, int upper) {
            //Do a range search
            List<string> foundFiles = new List<string>();

            for (int searchTerm = lower; searchTerm <= upper; searchTerm++) {
                //For each file type
                foreach (var type in fileTypes) {
                    //Get all file names of the current type that contain the search term
                    var fileList = Directory.GetFiles(path, "*" + type);
                    foreach (string filepath in fileList) {
                        string filename = filepath.Split("\\").Last();
                        if ( filename.Contains(searchTerm.ToString()) ) {
                            foundFiles.Add(filepath);  //Append the found file names to temp found
                            System.Diagnostics.Debug.WriteLine(filepath + "   " + foundFiles.Count);
                        }
                    }
                }
            }
            return foundFiles;
        }

        public List<string> rangeSearchRecur(int lower, int upper, string path) {
            //Do a range search
            List<string> foundFiles = new List<string>();

            for (int searchTerm = lower; searchTerm <= upper; searchTerm++) {
                foreach (var directory in Directory.GetDirectories(path)) {
                    foundFiles.AddRange(rangeSearchRecur(lower, upper, directory));
                }
                //For each file type
                foreach (var type in fileTypes) {
                    //Get all file names of the current type that contain the search term
                    var fileList = Directory.GetFiles(path, "*" + type);
                    foreach (string filepath in fileList) {
                        string filename = filepath.Split("\\").Last();
                        if ( filename.Contains(searchTerm.ToString()) ) {
                            foundFiles.Add(filepath);  //Append the found file names to temp found
                            System.Diagnostics.Debug.WriteLine(filepath + "   " + foundFiles.Count);
                        }
                    }
                }
            }
            return foundFiles;
        }
    }
}

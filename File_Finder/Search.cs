using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Finder {
    internal class Search {

        private string[] fileTypes;
        private string path;

        //Constructor
        public Search(string path, string fileTypes) {
            this.path = path;
            this.fileTypes = fileTypes.Split(',');
        }

        //Non-recursive phrase search
        public List<string> phraseSearch(string searchTerm) {
            List<string> foundFiles = new List<string>();

            //For each file type
            foreach (var type in fileTypes) {

                //Get all file names of the current type that contain the search term
                var fileList = Directory.GetFiles(path, "*" + type);

                //Get all filenames that contain the search term
                foreach (string filepath in fileList) {
                    string filename = filepath.Split("\\").Last();
                    if (filename.Contains(searchTerm)) {
                        foundFiles.Add(filepath);  //Append the found file names to temp found
                    }
                }
            }

            return foundFiles;      
        }

        //Recursive phrase search
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
                    }
                }
            }

            return foundFiles;
        }

        //Non-recursive range search
        public List<string> rangeSearch(int lower, int upper) {
            List<string> foundFiles = new List<string>();

            //For each number in the range
            for (int searchTerm = lower; searchTerm <= upper; searchTerm++) {

                //For each file type
                foreach (var type in fileTypes) {

                    //Get all files of the current type
                    var fileList = Directory.GetFiles(path, "*" + type);

                    //Get all filenames that contain the search term
                    foreach (string filepath in fileList) {
                        string filename = filepath.Split("\\").Last();
                        if ( filename.Contains(searchTerm.ToString()) ) {
                            foundFiles.Add(filepath);  //Append the found file names to temp found
                        }
                    }
                }
            }
            return foundFiles;
        }

        //Recursive range search
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

                    //Get all files of the current type
                    var fileList = Directory.GetFiles(path, "*" + type);

                    //Get all filenames that contain the search term
                    foreach (string filepath in fileList) {
                        string filename = filepath.Split("\\").Last();
                        if ( filename.Contains(searchTerm.ToString()) ) {
                            foundFiles.Add(filepath);  //Append the found filenames to temp found
                        }
                    }
                }
            }

            return foundFiles;
        }

        //TODO: Refactor by inserting non-recursive range search into other functions
    }
}

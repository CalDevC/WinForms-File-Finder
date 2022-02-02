using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Finder {
    internal class Search {

        private string[] fileTypes;
        private string path;
        private bool recursive;

        public Search(string path, bool recursive, string fileTypes) {
            this.path = path;
            this.recursive = recursive;
            this.fileTypes = fileTypes.Split(',');
        }

        public List<string> phraseSearch(string searchTerm) {
            List<string> foundFiles = new List<string>();
            //For each file type
            foreach (var type in this.fileTypes) {
                if (recursive) {
                    //do a recursive search
                } else {
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
            }

            return foundFiles;      
        }

        public void rangeSearch(int lower, int upper) {
            //Do a range search
        }
    }
}

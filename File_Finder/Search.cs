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

        public string[] phraseSearch(string searchTerm) {
            string[] foundFiles = {};
            //For each file type
            foreach (var type in this.fileTypes) {
                if (recursive) {
                    //do a recursive search
                } else {
                    //Get all file names of the current type that contain the search term
                    var fileList = Directory.GetFiles(path, "*" + type);
                    foreach (var filepath in fileList) {
                        var filename = filepath.Split("\\").Last();
                        foundFiles.Append(filepath);  //Append the found file names to temp found
                        System.Diagnostics.Debug.WriteLine(filepath);
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

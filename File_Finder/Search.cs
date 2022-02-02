using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Finder {
    internal class Search {

        private string path;
        private bool recursive;

        public Search(string path, bool recursive) {
            this.path = path;
            this.recursive = recursive;
        }

        public void phraseSearch(string searchTerm) {
            //Do a phrase search
            var fileList = Directory.GetFiles(path);
            foreach (var file in fileList) {
                System.Diagnostics.Debug.WriteLine(file);
            }
        }

        public void rangeSearch(int lower, int upper) {
            //Do a range search
        }
    }
}

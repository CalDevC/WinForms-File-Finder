using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 This class holds utility functions 
 to be used throughout the program.
 */

namespace File_Finder {
    internal class Utils {

        //Constructor
        public Utils() { }

        //Get the total number of directories withint the given directory
        //either recursively or nonrecursively
        public int getNumDirs(string path, bool recursive) {
            int sum = 0;

            if (recursive) {
                foreach (var directory in Directory.GetDirectories(path)) {
                    sum += getNumDirs(directory, recursive);
                }
            } else {
                sum = Directory.GetFiles(path).Length;
            }

            return sum;
        }

        //Write message to debug console
        public void consoleLog(string msg) {
            System.Diagnostics.Debug.WriteLine(msg);
        }
    }
}

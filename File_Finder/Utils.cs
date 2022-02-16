using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Finder {
    internal class Utils {

        public Utils() { }

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

        public void consoleLog(string msg) {
            System.Diagnostics.Debug.WriteLine(msg);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Finder {
    internal class Tests {

        private File_Finder ui;

        public Tests(File_Finder ui) {
            this.ui = ui;
        }

        public void test1() {
            ui.setUIValues("\\\\upifile1\\vidar", ".pdf,.png,.tif,.jpg,.dwg", 0, "motor", false);
        }

        public void test2() {
            ui.setUIValues("\\\\upifile1\\vidar", ".pdf,.png,.tif,.jpg,.dwg", -1, "motor", false);
        }

        public void test3() {
            ui.setUIValues("\\\\upifile1\\vidar", ".pdf", 0, "motor", true);
        }
    }
}

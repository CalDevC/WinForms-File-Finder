﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 This file holds unit test functions that will
 fill out the form to test different search types
 or error scenarios.
 */


namespace File_Finder {
    internal class Tests {

        private File_Finder ui;

        //Constructor
        public Tests(File_Finder ui) {
            this.ui = ui;
        }

        //Unit tests
        public void test1() {
            ui.setUIValues("\\\\upifile1\\vidar", ".pdf,.png,.tif,.jpg,.dwg", 0, "motor", false);
        }

        public void test2() {
            ui.setUIValues("\\\\upifile1\\vidar", ".pdf,.png,.tif,.jpg,.dwg", -1, "motor", false);
        }

        public void test3() {
            ui.setUIValues("\\\\upifile1\\vidar", ".pdf", 1, "0-10000", true);
        }

        public void test4() {
            ui.setUIValues("\\\\upifile1\\vidar\\MAXIMO_Linked_Documents", ".pdf,.jpg", 0, "vk", true);
        }
    }
}

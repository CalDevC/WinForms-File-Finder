namespace File_Finder {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new File_Finder());

        }
    }

    /*
     System.ArgumentOutOfRangeException
  HResult=0x80131502
  Message=Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')
  Source=System.Private.CoreLib
  StackTrace:
   at System.Collections.ArrayList.get_Item(Int32 index)
   at System.Windows.Forms.ToolStripItemCollection.get_Item(Int32 index)
   at System.Windows.Forms.ToolStrip.OnPaint(PaintEventArgs e)
   at System.Windows.Forms.Control.PaintWithErrorHandling(PaintEventArgs e, Int16 layer)
   at System.Windows.Forms.Control.WmPaint(Message& m)
   at System.Windows.Forms.Control.WndProc(Message& m)
   at System.Windows.Forms.ScrollableControl.WndProc(Message& m)
   at System.Windows.Forms.ToolStrip.WndProc(Message& m)
   at System.Windows.Forms.StatusStrip.WndProc(Message& m)
   at System.Windows.Forms.Control.ControlNativeWindow.WndProc(Message& m)
   at System.Windows.Forms.NativeWindow.Callback(IntPtr hWnd, WM msg, IntPtr wparam, IntPtr lparam)

  This exception was originally thrown at this call stack:
    System.Collections.ArrayList.this[int].get(int)
    System.Windows.Forms.ToolStripItemCollection.this[int].get(int)
    System.Windows.Forms.ToolStrip.OnPaint(System.Windows.Forms.PaintEventArgs)
    System.Windows.Forms.Control.PaintWithErrorHandling(System.Windows.Forms.PaintEventArgs, short)
    System.Windows.Forms.Control.WmPaint(ref System.Windows.Forms.Message)
    System.Windows.Forms.Control.WndProc(ref System.Windows.Forms.Message)
    System.Windows.Forms.ScrollableControl.WndProc(ref System.Windows.Forms.Message)
    System.Windows.Forms.ToolStrip.WndProc(ref System.Windows.Forms.Message)
    System.Windows.Forms.StatusStrip.WndProc(ref System.Windows.Forms.Message)
    System.Windows.Forms.Control.ControlNativeWindow.WndProc(ref System.Windows.Forms.Message)
    ...
    [Call Stack Truncated]
     */
}
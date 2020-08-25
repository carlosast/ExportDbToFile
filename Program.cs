using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ExportDbToFile
{
    static class Program
    {

        const string Title = "ExportDbToFile";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }

        public static void ShowError(string message)
        {
            MessageBox.Show(message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowError(Exception ex)
        {
            ShowError(ex.Message);
        }

        public static void ShowError(Exception ex, string message)
        {
            ShowError(message + " --> " + ex.Message);
        }

        public static void ShowInformation(string message)
        {
            MessageBox.Show(message, Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool Confirm(string message)
        {
            return MessageBox.Show(message, Title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
        }

        public static bool Confirm(string title, string message)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
        }

        public static void RunSafe(Form owner, Action action)
        {
            try
            {
                owner.Cursor = Cursors.WaitCursor;
                action();
                owner.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                owner.Cursor = Cursors.Default;
                ShowError(ex);
            }
        }

    }
}

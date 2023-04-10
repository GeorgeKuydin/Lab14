using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class SaveAsThread
    {
        private int[] array;
        private string fileName;
        private ProgressBar progressBar;

        public SaveAsThread(int[] array, string fileName, ProgressBar progressBar)
        {
            this.array = array;
            this.fileName = fileName;
            this.progressBar = progressBar;
        }

        public void SaveArrayToFile()
        {
            Thread saveThread = new Thread(() =>
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        writer.WriteLine(array[i]);

                        progressBar.Invoke((MethodInvoker)delegate
                        {
                            progressBar.Value = (int)(((double)i / array.Length) * 100);
                        });
                    }
                }
            });

            saveThread.Start();
        }
    }
}

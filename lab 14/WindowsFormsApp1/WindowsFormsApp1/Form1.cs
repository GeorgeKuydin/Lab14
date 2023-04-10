using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] array1 = { 1, 2, 3 };
            int[] array2 = { 4, 5, 6 };
            int[] array3 = { 7, 8, 9 };

            SaveAsThread thread1 = new SaveAsThread(array1, "array1.txt", progressBar1);
            SaveAsThread thread2 = new SaveAsThread(array2, "array2.txt", progressBar2);
            SaveAsThread thread3 = new SaveAsThread(array3, "array3.txt", progressBar3);

            Thread t1 = new Thread(new ThreadStart(thread1.SaveArrayToFile));
            Thread t2 = new Thread(new ThreadStart(thread2.SaveArrayToFile));
            Thread t3 = new Thread(new ThreadStart(thread3.SaveArrayToFile));

            t1.Start();
            t2.Start();
            t3.Start();
        }
    }
}

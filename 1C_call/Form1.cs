using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using _1C_call.main;
namespace _1C_call
{
    public partial class Form1 : Form
    {
        private Connection connection;
        public Form1()
        {
            InitializeComponent();
            connection = new Connection();
            if (!connection.CallsAllowed)
            {
                requestField.Text = "Необходимо проверить настроечные файлы: 1 или несколько файлов отсутствуют или повреждены.";
                return;
            }
            try
            {
                foreach (Host h in connection.Hosts)
                {
                    this.hostLink.Items.Add(h.Name);
                }

                foreach (Method m in connection.Methods)
                {
                    methodName.Items.Add(m.Name);
                }
                if (connection.Authorization == null)
                    button1.Enabled = false;
            }
            catch
            {
                requestField.Text = "Необходимо проверить настроечные файлы: 1 или несколько файлов отсутствуют или повреждены.";
                return;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            toolStripStatusLabel1.Text = "Calling in progress";
            string requestBody = requestField.Text;
            bananaBox.Visible = true;
            bananaBox.Refresh();
            Response[] responce = null;
            Host host = connection.Hosts[hostLink.SelectedIndex];
            Method method = connection.Methods[methodName.SelectedIndex];
            //Starting the new task with calling 1C
            //Because I want to show funny banana
            //While request is executing
            Task t = Task.Run(() =>
            {
                Request request = new Request(host,
                    method,
                    connection.Authorization,
                    requestBody);
                Caller caller = new Caller(request);
                responce = caller.Call();
            });
            while (!t.IsCompleted)
            {
                bananaBox.Refresh();
            }
            Debug.Print("1С вернула данные.");
            bananaBox.Visible = false;
            if (responce == null)
            {
                toolStripStatusLabel1.Text = "Done";
                button1.Enabled = true;
                return;
            }

            toolStripStatusLabel1.Text = "Saving";

            Stopwatch sw = new Stopwatch();
            sw.Start();
            List<Task> tasks = new List<Task>();
            string PathToOpen = default;
            string methodNameT = methodName.Text;
            foreach (Response r in responce)
            {
                r.FileContent = r.FileContent.Replace("\r\n", "");
                FileSaver fs = new FileSaver();
                
                tasks.Add(Task.Run(() =>
                {
                    Debug.Print("Следующий поток стартовал");
                    fs.SaveFile(methodNameT, r.FileName, Convert.FromBase64String(r.FileContent));
                    Debug.Print("Отправлено на сохранение");
                    PathToOpen = fs.FinalPath;
                }));
            }
            Task.WaitAll(tasks.ToArray());
            


            sw.Stop();
            Debug.Print(sw.ElapsedMilliseconds.ToString());

            toolStripStatusLabel1.Text = "Done";
            button1.Enabled = true;
            Debug.Print(PathToOpen);
            if (PathToOpen != default)
            {
                System.Diagnostics.Process.Start("explorer.exe", PathToOpen);
            }
        }

        private void hostLink_SelectedValueChanged(object sender, EventArgs e)
        {
            if (hostLink.Text != "" && methodName.Text != "" && requestField.Text.Length > 16)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        /// <summary>
        /// отдельный метод на случай если текстовое поле будет меняться
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void requestField_TextChanged(object sender, EventArgs e)
        {
            if (hostLink.Text != "" && methodName.Text != "" && requestField.Text.Length > 16)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

    }
}

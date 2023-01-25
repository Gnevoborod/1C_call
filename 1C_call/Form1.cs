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

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            toolStripStatusLabel1.Text = "Calling in progress";
            string requestBody = requestField.Text;
            bananaBox.Visible = true;
            bananaBox.Refresh();
            Response[] responce = null;
            Host host= connection.Hosts[hostLink.SelectedIndex];
            Method method = connection.Methods[methodName.SelectedIndex];
            //Starting the new task with calling 1C
            //Because I want to show funny banana
            //While request is executing
            Task t=Task.Run(()=>
            {
                Request request = new Request(host,
                    method,
                    connection.Authorization,
                    requestBody);
                Caller caller = new Caller(request);
                responce = caller.Call();
            });
            while(!t.IsCompleted)
            {
                bananaBox.Refresh();
            }
            bananaBox.Visible = false;
            if (responce == null)
            {
                toolStripStatusLabel1.Text = "Done";
                button1.Enabled = true;
                return;
            }

            FileSaver fs = new FileSaver();
            toolStripStatusLabel1.Text = "Saving";
            string PathToOpen = null;
            foreach (Response r in responce)
            {
                r.FileContent = r.FileContent.Replace("\r\n", "");
                PathToOpen=fs.SaveFile(methodName.Text, r.FileName, Convert.FromBase64String(r.FileContent));
            }
            toolStripStatusLabel1.Text = "Done";
            button1.Enabled = true;
            if (PathToOpen!=null)
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

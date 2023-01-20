using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void button1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Start calling";
            string requestBody = requestField.Text;
            
            Request request = new Request(connection.Hosts.First(a => a.Name == hostLink.Text),
                connection.Methods.First(a => a.Name == methodName.Text),
                connection.Authorization,
                requestBody);
            Caller caller = new Caller(request);
            Response[] responce=caller.Call();
            if (responce == null)
            {
                toolStripStatusLabel1.Text = "Done";
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
            if(PathToOpen!=null)
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

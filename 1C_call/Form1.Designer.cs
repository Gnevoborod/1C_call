using _1C_call.main;

namespace _1C_call
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            connection = new Connection();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.methodName = new System.Windows.Forms.ComboBox();
            this.hostLink = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(337, 363);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Отправить";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(15, 49);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(406, 292);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // methodName
            // 
            this.methodName.FormattingEnabled = true;
            this.methodName.Location = new System.Drawing.Point(267, 12);
            this.methodName.Name = "methodName";
            this.methodName.Size = new System.Drawing.Size(151, 21);
            this.methodName.TabIndex = 3;
            // 
            // hostLink
            // 
            this.hostLink.FormattingEnabled = true;
            this.hostLink.Location = new System.Drawing.Point(55, 12);
            this.hostLink.Name = "hostLink";
            this.hostLink.Size = new System.Drawing.Size(121, 21);
            this.hostLink.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Стенд";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Эндпоинт";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 400);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hostLink);
            this.Controls.Add(this.methodName);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "1C call";
            this.ResumeLayout(false);
            this.PerformLayout();


            foreach (Host h in connection.hosts)
            {
                this.hostLink.Items.Add(h.Name);
            }

            foreach (Method m in connection.methods)
            {
                this.methodName.Items.Add(m.Name);
            }

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox methodName;
        private System.Windows.Forms.ComboBox hostLink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Connection connection;
    }
}


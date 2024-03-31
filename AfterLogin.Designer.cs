namespace mpp_project
{
    partial class AfterLogin
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
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            numericUpDown1 = new NumericUpDown();
            label4 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label5 = new Label();
            textBox4 = new TextBox();
            label6 = new Label();
            button2 = new Button();
            button3 = new Button();
            listView1 = new ListView();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(663, 17);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Log Out";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(115, 17);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 20);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 2;
            label1.Text = "Destinatie";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 64);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 3;
            label2.Text = "Data";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(115, 59);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 248);
            label3.Name = "label3";
            label3.Size = new Size(89, 20);
            label3.TabIndex = 5;
            label3.Text = "Nume client";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(142, 281);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 283);
            label4.Name = "label4";
            label4.Size = new Size(95, 20);
            label4.TabIndex = 7;
            label4.Text = "Numar turisti";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(142, 245);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(142, 325);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 328);
            label5.Name = "label5";
            label5.Size = new Size(95, 20);
            label5.TabIndex = 10;
            label5.Text = "Adresa client";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(142, 366);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(29, 369);
            label6.Name = "label6";
            label6.Size = new Size(90, 20);
            label6.TabIndex = 12;
            label6.Text = "Nume turisti";
            // 
            // button2
            // 
            button2.Location = new Point(106, 409);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 13;
            button2.Text = "Rezervare";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(115, 109);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 15;
            button3.Text = "Cautare";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // listView1
            // 
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(387, 59);
            listView1.Name = "listView1";
            listView1.Size = new Size(359, 359);
            listView1.TabIndex = 16;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.Columns.Add("Id", 50);
            listView1.Columns.Add("Destinatie", 100);
            listView1.Columns.Add("Data", 100);
            listView1.Columns.Add("Aeroport", 100);
            listView1.Columns.Add("NrLocuri", 100);
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            // hide id
            listView1.Columns[0].Width = 0;
            // 
            // AfterLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listView1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label6);
            Controls.Add(textBox4);
            Controls.Add(label5);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label4);
            Controls.Add(numericUpDown1);
            Controls.Add(label3);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "AfterLogin";
            Text = "AfterLogin";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private NumericUpDown numericUpDown1;
        private Label label4;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label5;
        private TextBox textBox4;
        private Label label6;
        private Button button2;
        private Button button3;
        private ListView listView1;
    }
}
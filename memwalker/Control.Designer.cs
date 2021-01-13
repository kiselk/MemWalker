namespace memwalker
{
    partial class Control
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.bFly = new System.Windows.Forms.Button();
            this.ePID = new System.Windows.Forms.TextBox();
            this.eStAddr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.eEndAddr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bRefresh = new System.Windows.Forms.Button();
            this.tZoom = new System.Windows.Forms.TrackBar();
            this.tAccuracy = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tAccuracy)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(108, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(144, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // bFly
            // 
            this.bFly.Location = new System.Drawing.Point(258, 67);
            this.bFly.Name = "bFly";
            this.bFly.Size = new System.Drawing.Size(78, 49);
            this.bFly.TabIndex = 1;
            this.bFly.Text = "Fly";
            this.bFly.UseVisualStyleBackColor = true;
            this.bFly.Click += new System.EventHandler(this.bFly_Click);
            // 
            // ePID
            // 
            this.ePID.Location = new System.Drawing.Point(108, 39);
            this.ePID.Name = "ePID";
            this.ePID.Size = new System.Drawing.Size(144, 20);
            this.ePID.TabIndex = 2;
            // 
            // eStAddr
            // 
            this.eStAddr.Location = new System.Drawing.Point(108, 65);
            this.eStAddr.Name = "eStAddr";
            this.eStAddr.Size = new System.Drawing.Size(144, 20);
            this.eStAddr.TabIndex = 4;
            this.eStAddr.TextChanged += new System.EventHandler(this.eStAddr_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Process ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Process Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Start Address:";
            // 
            // eEndAddr
            // 
            this.eEndAddr.Location = new System.Drawing.Point(108, 95);
            this.eEndAddr.Name = "eEndAddr";
            this.eEndAddr.Size = new System.Drawing.Size(144, 20);
            this.eEndAddr.TabIndex = 9;
            this.eEndAddr.TextChanged += new System.EventHandler(this.eEndAddr_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "End Address:";
            // 
            // bRefresh
            // 
            this.bRefresh.Location = new System.Drawing.Point(258, 12);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(78, 49);
            this.bRefresh.TabIndex = 12;
            this.bRefresh.Text = "Refresh";
            this.bRefresh.UseVisualStyleBackColor = true;
            this.bRefresh.Click += new System.EventHandler(this.bRefresh_Click);
            // 
            // tZoom
            // 
            this.tZoom.Location = new System.Drawing.Point(108, 121);
            this.tZoom.Minimum = 1;
            this.tZoom.Name = "tZoom";
            this.tZoom.Size = new System.Drawing.Size(144, 45);
            this.tZoom.TabIndex = 13;
            this.tZoom.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tZoom.Value = 1;
            // 
            // tAccuracy
            // 
            this.tAccuracy.Location = new System.Drawing.Point(108, 158);
            this.tAccuracy.Minimum = 1;
            this.tAccuracy.Name = "tAccuracy";
            this.tAccuracy.Size = new System.Drawing.Size(144, 45);
            this.tAccuracy.TabIndex = 14;
            this.tAccuracy.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tAccuracy.Value = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Zoom:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Accuracy:";
            // 
            // Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 203);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tAccuracy);
            this.Controls.Add(this.tZoom);
            this.Controls.Add(this.bRefresh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.eEndAddr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eStAddr);
            this.Controls.Add(this.ePID);
            this.Controls.Add(this.bFly);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Control";
            this.Text = "Control";
            this.Load += new System.EventHandler(this.Control_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tAccuracy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button bFly;
        private System.Windows.Forms.TextBox ePID;
        private System.Windows.Forms.TextBox eStAddr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox eEndAddr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bRefresh;
        private System.Windows.Forms.TrackBar tZoom;
        private System.Windows.Forms.TrackBar tAccuracy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
    }
}
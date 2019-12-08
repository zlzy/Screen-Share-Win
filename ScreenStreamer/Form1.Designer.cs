namespace ScreenStreamer
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ip1 = new System.Windows.Forms.TextBox();
            this.txt_ip2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ip4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ip3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Top Left :";
            // 
            // txt_ip1
            // 
            this.txt_ip1.Location = new System.Drawing.Point(82, 16);
            this.txt_ip1.Name = "txt_ip1";
            this.txt_ip1.Size = new System.Drawing.Size(100, 20);
            this.txt_ip1.TabIndex = 2;
            // 
            // txt_ip2
            // 
            this.txt_ip2.Location = new System.Drawing.Point(263, 17);
            this.txt_ip2.Name = "txt_ip2";
            this.txt_ip2.Size = new System.Drawing.Size(100, 20);
            this.txt_ip2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Top Right :";
            // 
            // txt_ip4
            // 
            this.txt_ip4.Location = new System.Drawing.Point(263, 43);
            this.txt_ip4.Name = "txt_ip4";
            this.txt_ip4.Size = new System.Drawing.Size(100, 20);
            this.txt_ip4.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Bottom Right:";
            // 
            // txt_ip3
            // 
            this.txt_ip3.Location = new System.Drawing.Point(82, 42);
            this.txt_ip3.Name = "txt_ip3";
            this.txt_ip3.Size = new System.Drawing.Size(100, 20);
            this.txt_ip3.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Bottom Left :";
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(288, 76);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 9;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 108);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.txt_ip4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_ip3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_ip2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_ip1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Screen Streamer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ip1;
        private System.Windows.Forms.TextBox txt_ip2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ip4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_ip3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_start;
    }
}


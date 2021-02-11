
namespace Task3
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
            this.openbtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.sourceFileName = new System.Windows.Forms.TextBox();
            this.destFileName = new System.Windows.Forms.TextBox();
            this.convertbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openbtn
            // 
            this.openbtn.Location = new System.Drawing.Point(32, 30);
            this.openbtn.Name = "openbtn";
            this.openbtn.Size = new System.Drawing.Size(75, 23);
            this.openbtn.TabIndex = 0;
            this.openbtn.Text = "Source";
            this.openbtn.UseVisualStyleBackColor = true;
            this.openbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(32, 73);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Destination";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // sourceFileName
            // 
            this.sourceFileName.Location = new System.Drawing.Point(144, 32);
            this.sourceFileName.Name = "sourceFileName";
            this.sourceFileName.Size = new System.Drawing.Size(460, 20);
            this.sourceFileName.TabIndex = 2;
            // 
            // destFileName
            // 
            this.destFileName.Location = new System.Drawing.Point(144, 76);
            this.destFileName.Name = "destFileName";
            this.destFileName.Size = new System.Drawing.Size(460, 20);
            this.destFileName.TabIndex = 3;
            // 
            // convertbtn
            // 
            this.convertbtn.Location = new System.Drawing.Point(32, 119);
            this.convertbtn.Name = "convertbtn";
            this.convertbtn.Size = new System.Drawing.Size(75, 23);
            this.convertbtn.TabIndex = 4;
            this.convertbtn.Text = "Convert";
            this.convertbtn.UseVisualStyleBackColor = true;
            this.convertbtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 282);
            this.Controls.Add(this.convertbtn);
            this.Controls.Add(this.destFileName);
            this.Controls.Add(this.sourceFileName);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.openbtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openbtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox sourceFileName;
        private System.Windows.Forms.TextBox destFileName;
        private System.Windows.Forms.Button convertbtn;
    }
}


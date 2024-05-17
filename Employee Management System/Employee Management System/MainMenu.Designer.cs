namespace Employee_Management_System
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnemployeedetails = new System.Windows.Forms.Button();
            this.btnsalary = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(24, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(274, 262);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnemployeedetails
            // 
            this.btnemployeedetails.AccessibleName = "";
            this.btnemployeedetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnemployeedetails.Location = new System.Drawing.Point(392, 39);
            this.btnemployeedetails.Name = "btnemployeedetails";
            this.btnemployeedetails.Size = new System.Drawing.Size(263, 55);
            this.btnemployeedetails.TabIndex = 1;
            this.btnemployeedetails.Text = "Manage Employee";
            this.btnemployeedetails.UseVisualStyleBackColor = true;
            this.btnemployeedetails.Click += new System.EventHandler(this.btnemployeedetails_Click);
            // 
            // btnsalary
            // 
            this.btnsalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsalary.Location = new System.Drawing.Point(392, 137);
            this.btnsalary.Name = "btnsalary";
            this.btnsalary.Size = new System.Drawing.Size(263, 55);
            this.btnsalary.TabIndex = 2;
            this.btnsalary.Text = "Salary";
            this.btnsalary.UseVisualStyleBackColor = true;
            this.btnsalary.Click += new System.EventHandler(this.btnsalary_Click);
            // 
            // btnexit
            // 
            this.btnexit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexit.ForeColor = System.Drawing.Color.Red;
            this.btnexit.Location = new System.Drawing.Point(392, 246);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(263, 55);
            this.btnexit.TabIndex = 3;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 346);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnsalary);
            this.Controls.Add(this.btnemployeedetails);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnemployeedetails;
        private System.Windows.Forms.Button btnsalary;
        private System.Windows.Forms.Button btnexit;
    }
}
namespace frontLoginPage
{
    partial class LoginForm
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
            this.lbl1Name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl2_userName = new System.Windows.Forms.Label();
            this.lbl3_password = new System.Windows.Forms.Label();
            this.txt1_userName = new System.Windows.Forms.TextBox();
            this.txt2_password = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl1Name
            // 
            this.lbl1Name.AutoSize = true;
            this.lbl1Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lbl1Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl1Name.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1Name.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl1Name.Location = new System.Drawing.Point(78, 25);
            this.lbl1Name.Name = "lbl1Name";
            this.lbl1Name.Size = new System.Drawing.Size(386, 28);
            this.lbl1Name.TabIndex = 0;
            this.lbl1Name.Text = "HOSPITAL MANAGEMENT SYSTEM";
            this.lbl1Name.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl1Name.Click += new System.EventHandler(this.lbl1Name_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please Login to continue to the application";
            // 
            // lbl2_userName
            // 
            this.lbl2_userName.AutoSize = true;
            this.lbl2_userName.Location = new System.Drawing.Point(75, 128);
            this.lbl2_userName.Name = "lbl2_userName";
            this.lbl2_userName.Size = new System.Drawing.Size(60, 13);
            this.lbl2_userName.TabIndex = 2;
            this.lbl2_userName.Text = "User Name";
            // 
            // lbl3_password
            // 
            this.lbl3_password.AutoSize = true;
            this.lbl3_password.Location = new System.Drawing.Point(75, 169);
            this.lbl3_password.Name = "lbl3_password";
            this.lbl3_password.Size = new System.Drawing.Size(53, 13);
            this.lbl3_password.TabIndex = 3;
            this.lbl3_password.Text = "Password";
            this.lbl3_password.Click += new System.EventHandler(this.lbl3_password_Click);
            // 
            // txt1_userName
            // 
            this.txt1_userName.Location = new System.Drawing.Point(191, 125);
            this.txt1_userName.Name = "txt1_userName";
            this.txt1_userName.Size = new System.Drawing.Size(131, 20);
            this.txt1_userName.TabIndex = 4;
            // 
            // txt2_password
            // 
            this.txt2_password.Location = new System.Drawing.Point(191, 166);
            this.txt2_password.Name = "txt2_password";
            this.txt2_password.PasswordChar = '*';
            this.txt2_password.Size = new System.Drawing.Size(131, 20);
            this.txt2_password.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 234);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(231, 234);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(101, 283);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(57, 13);
            this.lblError.TabIndex = 7;
            this.lblError.Text = "labelError1";
            this.lblError.Click += new System.EventHandler(this.lblError_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(545, 305);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt2_password);
            this.Controls.Add(this.txt1_userName);
            this.Controls.Add(this.lbl3_password);
            this.Controls.Add(this.lbl2_userName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl1Name);
            this.Name = "LoginForm";
            this.Text = "Hospital_Login (administrator)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl1Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl2_userName;
        private System.Windows.Forms.Label lbl3_password;
        private System.Windows.Forms.TextBox txt1_userName;
        private System.Windows.Forms.TextBox txt2_password;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblError;
    }
}


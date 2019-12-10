namespace qlktxserver
{
    partial class frmDangKy
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
            this.components = new System.ComponentModel.Container();
            this.txtRepassRegis = new System.Windows.Forms.TextBox();
            this.txtPassRegis = new System.Windows.Forms.TextBox();
            this.txtUserRegis = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProviderDK = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDK)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRepassRegis
            // 
            this.txtRepassRegis.Location = new System.Drawing.Point(325, 210);
            this.txtRepassRegis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRepassRegis.Name = "txtRepassRegis";
            this.txtRepassRegis.Size = new System.Drawing.Size(247, 22);
            this.txtRepassRegis.TabIndex = 4;
            this.txtRepassRegis.UseSystemPasswordChar = true;
            this.txtRepassRegis.TextChanged += new System.EventHandler(this.txtRepassRegis_TextChanged);
            this.txtRepassRegis.Validating += new System.ComponentModel.CancelEventHandler(this.TxtRepassRegis_Validating);
            // 
            // txtPassRegis
            // 
            this.txtPassRegis.Location = new System.Drawing.Point(327, 166);
            this.txtPassRegis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassRegis.Name = "txtPassRegis";
            this.txtPassRegis.Size = new System.Drawing.Size(247, 22);
            this.txtPassRegis.TabIndex = 3;
            this.txtPassRegis.UseSystemPasswordChar = true;
            this.txtPassRegis.TextChanged += new System.EventHandler(this.txtPassRegis_TextChanged);
            this.txtPassRegis.Validating += new System.ComponentModel.CancelEventHandler(this.TxtPassRegis_Validating);
            // 
            // txtUserRegis
            // 
            this.txtUserRegis.Location = new System.Drawing.Point(325, 126);
            this.txtUserRegis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUserRegis.Name = "txtUserRegis";
            this.txtUserRegis.Size = new System.Drawing.Size(248, 22);
            this.txtUserRegis.TabIndex = 2;
            this.txtUserRegis.TextChanged += new System.EventHandler(this.txtUserRegis_TextChanged);
            this.txtUserRegis.Validating += new System.ComponentModel.CancelEventHandler(this.TxtUserRegis_Validating);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(377, 270);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 46);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(197, 270);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 46);
            this.button1.TabIndex = 5;
            this.button1.Text = "Register";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nhập lại mật khẩu";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mật khẩu";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tài khoản";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(155, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Tên ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(325, 85);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(247, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox1_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(192, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(339, 35);
            this.label4.TabIndex = 19;
            this.label4.Text = "ĐĂNG KÝ TÀI KHOẢN";
            // 
            // errorProviderDK
            // 
            this.errorProviderDK.ContainerControl = this;
            // 
            // frmDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 377);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRepassRegis);
            this.Controls.Add(this.txtPassRegis);
            this.Controls.Add(this.txtUserRegis);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmDangKy";
            this.Text = "frmDangKy";
            this.Load += new System.EventHandler(this.FrmDangKy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRepassRegis;
        private System.Windows.Forms.TextBox txtPassRegis;
        private System.Windows.Forms.TextBox txtUserRegis;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProviderDK;
    }
}
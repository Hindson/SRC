﻿namespace RCInterface
{
    partial class Add_Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Client));
            mtb_password = new TextBox();
            label8 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            maskedTextBox_phone = new MaskedTextBox();
            label1 = new Label();
            textBox_email = new TextBox();
            btn_add_Client = new Button();
            textBox_middleName = new TextBox();
            textBox_firstName = new TextBox();
            textBox_lastName = new TextBox();
            dtp_driverLicense = new DateTimePicker();
            label7 = new Label();
            label9 = new Label();
            mtb_driverLicense = new MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // mtb_password
            // 
            mtb_password.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            mtb_password.Location = new Point(285, 173);
            mtb_password.Name = "mtb_password";
            mtb_password.Size = new Size(126, 24);
            mtb_password.TabIndex = 107;
            mtb_password.KeyPress += mtb_password_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(161, 12);
            label8.Name = "label8";
            label8.Size = new Size(139, 23);
            label8.TabIndex = 106;
            label8.Text = "Заполните поля:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(231, 176);
            label6.Name = "label6";
            label6.Size = new Size(52, 17);
            label6.TabIndex = 105;
            label6.Text = "Пароль";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(14, 176);
            label5.Name = "label5";
            label5.Size = new Size(105, 17);
            label5.TabIndex = 104;
            label5.Text = "Номер телефона";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(218, 143);
            label4.Name = "label4";
            label4.Size = new Size(61, 17);
            label4.TabIndex = 103;
            label4.Text = "Отчество";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(218, 111);
            label3.Name = "label3";
            label3.Size = new Size(32, 17);
            label3.TabIndex = 102;
            label3.Text = "Имя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(218, 79);
            label2.Name = "label2";
            label2.Size = new Size(61, 17);
            label2.TabIndex = 101;
            label2.Text = "Фамилия";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Client;
            pictureBox1.Location = new Point(14, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(141, 134);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 100;
            pictureBox1.TabStop = false;
            // 
            // maskedTextBox_phone
            // 
            maskedTextBox_phone.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            maskedTextBox_phone.Location = new Point(121, 173);
            maskedTextBox_phone.Mask = "0000000000";
            maskedTextBox_phone.Name = "maskedTextBox_phone";
            maskedTextBox_phone.Size = new Size(96, 24);
            maskedTextBox_phone.TabIndex = 97;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(161, 47);
            label1.Name = "label1";
            label1.Size = new Size(118, 17);
            label1.TabIndex = 99;
            label1.Text = "Электронная почта";
            // 
            // textBox_email
            // 
            textBox_email.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_email.Location = new Point(285, 44);
            textBox_email.Name = "textBox_email";
            textBox_email.Size = new Size(126, 24);
            textBox_email.TabIndex = 93;
            textBox_email.KeyPress += textBox_email_KeyPress;
            // 
            // btn_add_Client
            // 
            btn_add_Client.BackColor = Color.LightGray;
            btn_add_Client.FlatAppearance.BorderSize = 0;
            btn_add_Client.FlatStyle = FlatStyle.Flat;
            btn_add_Client.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_add_Client.Location = new Point(14, 208);
            btn_add_Client.Name = "btn_add_Client";
            btn_add_Client.Size = new Size(155, 50);
            btn_add_Client.TabIndex = 98;
            btn_add_Client.Text = "Добавить клиента";
            btn_add_Client.UseVisualStyleBackColor = false;
            btn_add_Client.Click += btn_add_Client_Click;
            // 
            // textBox_middleName
            // 
            textBox_middleName.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_middleName.Location = new Point(285, 140);
            textBox_middleName.Name = "textBox_middleName";
            textBox_middleName.Size = new Size(126, 24);
            textBox_middleName.TabIndex = 96;
            textBox_middleName.KeyPress += textBox_middleName_KeyPress;
            // 
            // textBox_firstName
            // 
            textBox_firstName.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_firstName.Location = new Point(285, 108);
            textBox_firstName.Name = "textBox_firstName";
            textBox_firstName.Size = new Size(126, 24);
            textBox_firstName.TabIndex = 95;
            textBox_firstName.KeyPress += textBox_firstName_KeyPress;
            // 
            // textBox_lastName
            // 
            textBox_lastName.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_lastName.Location = new Point(285, 76);
            textBox_lastName.Name = "textBox_lastName";
            textBox_lastName.Size = new Size(126, 24);
            textBox_lastName.TabIndex = 94;
            textBox_lastName.KeyPress += textBox_lastName_KeyPress;
            // 
            // dtp_driverLicense
            // 
            dtp_driverLicense.CalendarFont = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dtp_driverLicense.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtp_driverLicense.Format = DateTimePickerFormat.Short;
            dtp_driverLicense.Location = new Point(312, 238);
            dtp_driverLicense.Margin = new Padding(3, 4, 3, 4);
            dtp_driverLicense.MinDate = new DateTime(1940, 1, 1, 0, 0, 0, 0);
            dtp_driverLicense.Name = "dtp_driverLicense";
            dtp_driverLicense.RightToLeft = RightToLeft.No;
            dtp_driverLicense.Size = new Size(99, 24);
            dtp_driverLicense.TabIndex = 111;
            dtp_driverLicense.Value = new DateTime(2023, 5, 21, 9, 52, 31, 0);
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(175, 241);
            label7.Name = "label7";
            label7.Size = new Size(135, 17);
            label7.TabIndex = 110;
            label7.Text = "Дата получения прав:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(263, 208);
            label9.Name = "label9";
            label9.Size = new Size(47, 17);
            label9.TabIndex = 109;
            label9.Text = "Права:";
            // 
            // mtb_driverLicense
            // 
            mtb_driverLicense.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            mtb_driverLicense.Location = new Point(312, 205);
            mtb_driverLicense.Mask = "LLL-000000";
            mtb_driverLicense.Name = "mtb_driverLicense";
            mtb_driverLicense.Size = new Size(99, 24);
            mtb_driverLicense.TabIndex = 112;
            // 
            // Add_Client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 273);
            Controls.Add(mtb_driverLicense);
            Controls.Add(dtp_driverLicense);
            Controls.Add(label7);
            Controls.Add(label9);
            Controls.Add(mtb_password);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(maskedTextBox_phone);
            Controls.Add(label1);
            Controls.Add(textBox_email);
            Controls.Add(btn_add_Client);
            Controls.Add(textBox_middleName);
            Controls.Add(textBox_firstName);
            Controls.Add(textBox_lastName);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(440, 312);
            MinimizeBox = false;
            MinimumSize = new Size(440, 312);
            Name = "Add_Client";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавление клиента";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox mtb_password;
        private Label label8;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox1;
        private MaskedTextBox maskedTextBox_phone;
        private Label label1;
        private TextBox textBox_email;
        private Button btn_add_Client;
        private TextBox textBox_middleName;
        private TextBox textBox_firstName;
        private TextBox textBox_lastName;
        private DateTimePicker dtp_driverLicense;
        private Label label7;
        private Label label9;
        private MaskedTextBox mtb_driverLicense;
    }
}
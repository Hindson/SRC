﻿using RCLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCInterface
{
    // ToDo #5.2.1 Форма добавления нового менеджера +
    public partial class Add_Manager : Form
    {
        private Administrator admin = new Administrator();
        public Add_Manager()
        {
            InitializeComponent();
        }

        private void btn_add_Admin_Click(object sender, EventArgs e)
        {
            try
            {
                Manager manager = new Manager
                {
                    Email = textBox_email.Text.Replace(" ", ""),
                    LastName = textBox_lastName.Text.Replace(" ", ""),
                    FirstName = textBox_firstName.Text.Replace(" ", ""),
                    MiddleName = textBox_middleName.Text.Replace(" ", ""),
                    PhoneNumber = maskedTextBox_phone.Text,
                    Password = mtb_password.Text.Replace(" ", "")
                };
                bool action = admin.AddManager(manager);

                if (action)
                {
                    DialogResult dialogResult = MessageBox.Show("Менеджер был добавлен!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.OK)
                        Close();
                }
                else
                {
                    throw new ArgumentException("Пользователь с таким email уже существует! Пожалуйста используйте другой email для добавления пользователя в систему.");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox_email_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true; // отмена события для пробела
            e.KeyChar = char.ToLower(e.KeyChar);
        }

        private void mtb_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true; // отмена события для пробела
        }

        private void textBox_lastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true; // отмена события для пробела

            if (textBox_lastName.SelectionStart == 0)
                e.KeyChar = char.ToUpper(e.KeyChar);
            else
                e.KeyChar = char.ToLower(e.KeyChar);
        }

        private void textBox_firstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true; // отмена события для пробела

            if (textBox_firstName.SelectionStart == 0)
                e.KeyChar = char.ToUpper(e.KeyChar);
            else
                e.KeyChar = char.ToLower(e.KeyChar);
        }

        private void textBox_middleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true; // отмена события для пробела

            if (textBox_middleName.SelectionStart == 0)
                e.KeyChar = char.ToUpper(e.KeyChar);
            else
                e.KeyChar = char.ToLower(e.KeyChar);
        }
    }
}

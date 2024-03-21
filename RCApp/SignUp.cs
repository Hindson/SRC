using RCLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCApp
{
    public partial class SignUp : Form
    {
        private Client client = new Client();
        public SignUp()
        {
            InitializeComponent();
        }

        private void btn_sign_up_Click(object sender, EventArgs e)
        {
            try
            {
                Client newClient = new Client
                {
                    Email = textBox_email.Text.Replace(" ", ""),
                    LastName = textBox_lastName.Text.Replace(" ", ""),
                    FirstName = textBox_firstName.Text.Replace(" ", ""),
                    MiddleName = textBox_middleName.Text.Replace(" ", ""),
                    PhoneNumber = maskedTextBox_phone.Text,
                    Password = textBox_password.Text.Replace(" ", ""),
                    DriverLicense = mtb_driverLicense.Text,
                    DateDriverLicense = dtp_driverLicense.Value
                };
                bool action = client.Register(newClient);

                if (action)
                {
                    DialogResult dialogResult = MessageBox.Show("Аккаунт был создан!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    client.Serialize();
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
    }
}

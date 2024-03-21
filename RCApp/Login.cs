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
    public partial class Login : Form
    {
        private string email = string.Empty;
        private string password = string.Empty;
        private UserSystem userSystem = new UserSystem();
        private Administrator admin = new Administrator();
        private Manager manager = new Manager();
        private Client client = new Client();
        private Auto auto = new Auto();
        private Contract contract = new Contract();
        public Login()
        {
            InitializeComponent();
            admin.Deserialize();
            manager.Deserialize();
            client.Deserialize();
            userSystem.Serialize();
            userSystem.Deserialize();
            auto.Deserialize();
            contract.Deserialize();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            email = textBox_email.Text;
            password = mtb_password.Text;

            // Вход в систему
            bool authResult = userSystem.Authenticate(email, password);

            if (authResult == true)
            {
                MessageBox.Show("Вход выполнен успешно!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm f = new MainForm();
                f.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Неправильный логин или пароль.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btn_sign_up_Click(object sender, EventArgs e)
        {
            new SignUp().ShowDialog(this);
        }
    }
}

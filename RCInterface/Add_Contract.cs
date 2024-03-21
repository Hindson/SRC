using Microsoft.VisualBasic.ApplicationServices;
using RCLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace RCInterface
{
    //ToDo #5.6 Форма для добавления нового договора +
    public partial class Add_Contract : Form
    {
        private Manager manager = new Manager();
        public Add_Contract()
        {
            InitializeComponent();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            try
            {
                // Поиск пользователя по email
                Manager? activeManager = Manager.Managers.FirstOrDefault(u => u.Email == UserSystem.activeUser.Email);
                Administrator? activeAdmin = Administrator.Administrators.FirstOrDefault(u => u.Email == UserSystem.activeUser.Email);

                RCLibrary.Contract contract = new RCLibrary.Contract();
                contract.Car = tableFreeCars1.SelectedAuto;
                contract.Renter = tableClients1.SelectedClient;
                if (activeManager != null)
                    contract.Employee = activeManager;
                else if (activeAdmin != null)
                    contract.Employee = activeAdmin;
                contract.StartDate = tableFreeCars1.startDate;
                contract.EndDate = tableFreeCars1.endDate;

                bool action = manager.AddContract(contract);

                if (action)
                {
                    DialogResult dialogResult = MessageBox.Show("Договор был добавлен!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

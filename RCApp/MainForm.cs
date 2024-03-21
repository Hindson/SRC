using RCInterface;
using RCLibrary;

namespace RCApp
{
    public partial class MainForm : Form
    {
        private Administrator admin = new Administrator();
        private Manager manager = new Manager();
        private Auto auto = new Auto();
        private Client client = new Client();
        public MainForm()
        {
            InitializeComponent();
            if (UserSystem.activeUser.TypeClass == "Администратор")
            {
                openChildControl(new TableUsersSystem());
                statusBar_user.Text = UserSystem.activeUser.ToString() + " (Администратор)";
            }
            else if (UserSystem.activeUser.TypeClass == "Клиент")
            {
                clientMode();
            }
            else if (UserSystem.activeUser.TypeClass == "Менеджер")
            {
                managerMode();
            }
        }

        private void managerMode()
        {
            ToolStripMI_admins.Visible = false;
            ToolStripMI_managers.Visible = false; 
            openChildControl(new TableFreeCars());
            statusBar_user.Text = UserSystem.activeUser.ToString() + " (Менеджер)";
        }

        private void clientMode()
        {
            таблицыToolStripMenuItem.Visible = false;
            openChildControl(new TableFreeCars());
            statusBar_user.Text = UserSystem.activeUser.ToString();
        }

        private UserControl? activeControl = null;
        // Метод для открытия UserControl на панели
        private void openChildControl(UserControl childControl)
        {
            if (activeControl != null && activeControl.GetType() == childControl.GetType())
            {
                // UserControl уже открыт, просто активируем его
                activeControl.Focus();
                return;
            }

            if (activeControl != null)
            {
                if (activeControl.ToString() == "RCInterface.TableAdmins")
                {
                    admin.Serialize();
                }
                else if (activeControl.ToString() == "RCInterface.TableManagers")
                {
                    manager.Serialize();
                }
                else if (activeControl.ToString() == "RCInterface.TableAutos")
                {
                    auto.Serialize();
                }
                else if (activeControl.ToString() == "RCInterface.TableClients")
                {
                    client.Serialize();
                }

                activeControl.Dispose();
            }
            activeControl = childControl;
            childControl.Dock = DockStyle.Fill;
            panel_info.Controls.Add(childControl);
            panel_info.Tag = childControl;
            childControl.BringToFront();
            childControl.Show();

            if (childControl.ToString() == "RCInterface.TableAdmins")
                StatusLabel_NForm.Text = "Таблица администраторы";
            else if (childControl.ToString() == "RCInterface.TableManagers")
                StatusLabel_NForm.Text = "Таблица менеджеры";
            else if (childControl.ToString() == "RCInterface.TableUsersSystem")
                StatusLabel_NForm.Text = "Таблица со всеми пользователями";
            else if (childControl.ToString() == "RCInterface.TableAutos")
                StatusLabel_NForm.Text = "Таблица с автомобилями";
            else if (childControl.ToString() == "RCInterface.TableClients")
                StatusLabel_NForm.Text = "Таблица с клиентами";
        }

        private void ToolStripMI_autos_Click(object sender, EventArgs e)
        {
            openChildControl(new TableAutos());
        }

        private void ToolStripMI_admins_Click(object sender, EventArgs e)
        {
            openChildControl(new TableAdmins());
        }

        private void ToolStripMI_clients_Click(object sender, EventArgs e)
        {
            openChildControl(new TableClients());
        }

        private void ToolStripMI_managers_Click(object sender, EventArgs e)
        {
            openChildControl(new TableManagers());
        }

        private void ToolStripMI_menu_Click(object sender, EventArgs e)
        {
            if (UserSystem.activeUser.TypeClass == "Администратор")
            {
                openChildControl(new TableUsersSystem());
            }
            else if (UserSystem.activeUser.TypeClass == "Клиент")
            {
                openChildControl(new TableFreeCars());
            }
            else if (UserSystem.activeUser.TypeClass == "Менеджер")
            {
                openChildControl(new TableFreeCars());
            }
        }

        private void MainAdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            admin.Serialize();
            manager.Serialize();
            auto.Serialize();
            client.Serialize();
            Application.Exit();
        }

        private void договорыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildControl(new TableContracts());
        }

        private void оРазработчикеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
using Microsoft.VisualBasic.ApplicationServices;
using RCLibrary;

namespace TestProject
{
    [TestClass]
    public class UserSystemTests
    {
        //ToDo #4.2 ���� ������ UserSystem +
        [TestMethod]
        public void TestMethod_Register()
        {
            UserSystem.Users.Clear();
            UserSystem userS = new UserSystem();
            
            // Test #1
            bool action = userS.Register(new Manager
            {
                LastName = "�����",
                FirstName = "������",
                PhoneNumber = "1234567890",
                Email = "tkachevoleg@gmail.com",
                Password = "kach2001"
            });
            Assert.IsTrue(action);

            // Test #2
            bool action2 = userS.Register(new Manager
            {
                LastName = "�����������",
                FirstName = "�������",
                PhoneNumber = "0941412141",
                Email = "tkachevoleg@gmail.com",
                Password = "Oleksa1989"
            });

            // �������� �� ��������� email � ������� 
            Assert.IsFalse(action2);
        }

        [TestMethod]
        public void TestMethod_Authenticate()
        {
            UserSystem userSystem = new UserSystem();
            
            // Test #1
            userSystem.Register(new Manager
            {
                LastName = "������",
                FirstName = "����",
                PhoneNumber = "1234567890",
                Email = "tkachevoleg@gmail.com",
                Password = "Tkach2001"
            });

            bool action = userSystem.Authenticate("tkachevoleg@gmail.com", "Tkach2001");

            // �������� ���� � ������� 
            Assert.IsTrue(action);

            // Test #2
            bool action2 = userSystem.Authenticate("tkachevoleg@gmail.com", "2001Tkach");

            // Email ��� ������ ������ �������
            Assert.IsFalse(action2);
        }

        [TestMethod]
        public void TestMethod_Serialize()
        {
            UserSystem userSystem = new UserSystem();
            bool action = userSystem.Serialize();

            // ����������� ������ �������
            Assert.IsTrue(action);
        }
    }
}
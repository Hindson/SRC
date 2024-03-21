using Microsoft.VisualBasic.ApplicationServices;
using RCLibrary;

namespace TestProject
{
    [TestClass]
    public class UserSystemTests
    {
        //ToDo #4.2 Тест класса UserSystem +
        [TestMethod]
        public void TestMethod_Register()
        {
            UserSystem.Users.Clear();
            UserSystem userS = new UserSystem();
            
            // Test #1
            bool action = userS.Register(new Manager
            {
                LastName = "Ткаче",
                FirstName = "Максим",
                PhoneNumber = "1234567890",
                Email = "tkachevoleg@gmail.com",
                Password = "kach2001"
            });
            Assert.IsTrue(action);

            // Test #2
            bool action2 = userS.Register(new Manager
            {
                LastName = "Олександров",
                FirstName = "Дмитрий",
                PhoneNumber = "0941412141",
                Email = "tkachevoleg@gmail.com",
                Password = "Oleksa1989"
            });

            // Проверка на дубликаты email в системе 
            Assert.IsFalse(action2);
        }

        [TestMethod]
        public void TestMethod_Authenticate()
        {
            UserSystem userSystem = new UserSystem();
            
            // Test #1
            userSystem.Register(new Manager
            {
                LastName = "Ткачев",
                FirstName = "Олег",
                PhoneNumber = "1234567890",
                Email = "tkachevoleg@gmail.com",
                Password = "Tkach2001"
            });

            bool action = userSystem.Authenticate("tkachevoleg@gmail.com", "Tkach2001");

            // Успешный вход в систему 
            Assert.IsTrue(action);

            // Test #2
            bool action2 = userSystem.Authenticate("tkachevoleg@gmail.com", "2001Tkach");

            // Email или пароль указан неверно
            Assert.IsFalse(action2);
        }

        [TestMethod]
        public void TestMethod_Serialize()
        {
            UserSystem userSystem = new UserSystem();
            bool action = userSystem.Serialize();

            // Сериализаия прошла успешно
            Assert.IsTrue(action);
        }
    }
}
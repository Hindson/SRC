using RCLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    //ToDo #4.5 Тест класса Auto +
    [TestClass]
    public class AutoTests
    {
        [TestMethod]
        public void Brand_Field_Validation()
        {
            Auto auto = new Auto();
            Assert.ThrowsException<ArgumentException>(() => auto.Brand = "");
            Assert.ThrowsException<ArgumentException>(() => auto.Brand = "jaoqszxmflqlsakgw");
            Assert.AreEqual(auto.Brand = "Audi", "Audi");
        }

        [TestMethod]
        public void Model_Field_Validation()
        {
            Auto auto = new Auto();
            Assert.ThrowsException<ArgumentException>(() => auto.Model = "");
            Assert.ThrowsException<ArgumentException>(() => auto.Model = "jaoqszxmflqlsakgw");
            Assert.AreEqual(auto.Model = "Q7", "Q7");
        }

        [TestMethod]
        public void ClassAuto_Field_Validation()
        {
            Auto auto = new Auto();
            Assert.AreEqual(auto.Aclass = null, null);
            Assert.AreEqual(auto.Aclass = classAuto.Средний, classAuto.Средний);
        }

        [TestMethod]
        public void GearboxType_Field_Validation()
        {
            Auto auto = new Auto();
            Assert.AreEqual(auto.Atype = null, null);
            Assert.AreEqual(auto.Atype = gearboxType.Автомат, gearboxType.Автомат);
        }

        [TestMethod]
        public void Color_Field_Validation()
        {
            Auto auto = new Auto();
            Assert.AreEqual(auto.Acolor = null, null);
            Assert.AreEqual(auto.Acolor = colorAuto.Красный, colorAuto.Красный);
        }

        [TestMethod]
        public void DailyPrice_Field_Validation()
        {
            Auto auto = new Auto();
            Assert.ThrowsException<ArgumentException>(() => auto.DailyPrice = 0);
            Assert.AreEqual(auto.DailyPrice = 890, 890);
        }
    }
}
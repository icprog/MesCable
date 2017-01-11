using Microsoft.VisualStudio.TestTools.UnitTesting;
using MesWeb.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MesWeb.BLL.Tests {
    [TestClass()]
    public class T_MachineTests {
        MesWeb.BLL.T_Machine bllMachine = new T_Machine();
        [TestMethod()]
        public void GetModelTest() {
            var machine = bllMachine.GetModel(6);
            Assert.AreEqual(machine.MachineName,"123");
        }


    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoRental3_store_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental3_store_.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void Form1Test()
        {
            Form1 instance = new Form1();
            instance.empty();
            Assert.IsTrue(true);
        }
        [TestMethod()]
        public void Form2Test()
        {
            Rental instance = new Rental();
            String CustomerID = "1";
            String MovieID = "1";
            instance.checkIssue(CustomerID,MovieID);
            Assert.IsTrue(true);

        }

    }
}
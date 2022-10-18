using MVC_Assign.Models;
using NUnit.Framework;

namespace MVCAssignTest1
{
    public class Tests
    {
        public Chaat c;
        public CustomerController cc;
        public Mock<ICustomerServ<Customer>> cs;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
using NUnit.Framework;
using System;

namespace SeleniumStudy
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Setup method execution");
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine("Test1 running");
        }
        [Test]
        public void Test2()
        {
            Console.WriteLine("Test2 running");
        }
        [TearDown]
        public void CloseBrowser()
        {
            TestContext.WriteLine("Setup method execution");

        }
    }
}
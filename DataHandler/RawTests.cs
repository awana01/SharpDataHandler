using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DataHandler
{

    [TestFixture]
    class RawTests
    {
    
     [Test]
     public void AssemblyInfoTest()
     {
            var assembly = Assembly.LoadFile(@"E:\C#-Projects\SeleniumProjects\BasicSeleniumTest\BasicSeleniumTest\bin\Debug\BasicSeleniumTest.dll");
            string info = assembly.FullName;
            Console.WriteLine(info);
     }
    
    
    }
}

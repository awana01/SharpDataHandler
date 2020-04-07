using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DataHandler.CFeatures
{
    [TestFixture]
    class TestCFeatures
    {
    
    [Test]
    public void TestHidingMethod()
    {
            Class1.SayHello();
            BaseClass.SayHello();
            Console.WriteLine(new BaseClass().Calculation(2, 2));
            Console.WriteLine(new Class1().Calculation(5, 5));
        }
    
    [Test]
    public void TestProperties()
    {
            PropertryExample prop = new PropertryExample();
            prop.propertyX = 100;

            prop.DoCalculations(100);

            PropertyExample2 check = new PropertyExample2();
            
            check.propertyX = 50;
            check.checkBalance();

            PropertyExample2 check2 = new PropertyExample2();
            check2.propertyX = 500;
            check2.checkBalance();
        }

        [Test]
        public void TestRefrenceType()
        {
            int a = 10;
            int b = 100;
            Console.WriteLine("value of param 'a' {0} and param 'b' {1}", a, b);
            Test_ref_Param(ref b);
            Console.WriteLine("value of param 'a' {0} and param 'b' {1}", a, b);

            int c = 1000;
            Test_ref_Param(ref c);
            Console.WriteLine("value of param 'a' {0} and param 'b' {1}", a, c);
        }
        
        [Test]
        public void TestSruct()
        {
            Person person1;
            person1.Name = "Joe";
            person1.job = "Admin";
            person1.address = "Street 1";
            person1.age = 20;

            StructMethod(person1);


        }



        public void Test_ref_Param(ref int b)
        {
            b = b + 1;
           // Console.WriteLine("refence type param 'b' value is {0}", b);

        }

        public void StructMethod(Person p)
        {
            Console.WriteLine(p.Name);
            Console.WriteLine(p.job);
            Console.WriteLine(p.address);
            Console.WriteLine(p.age);
        }



    }
}

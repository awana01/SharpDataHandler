using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler.CFeatures
{
    class Class1 : BaseClass
    {
    
      public static new void SayHello()
      {
            Console.WriteLine("Hello from child class");
      }
      //override
      //public int Calculation(int a,int b)
      //{
      //      return a+b;
      //}
      
      public override int Calculation(int a,int b)
      {
        return a + b;
      }


      public int Multiply(int a, int b)
      {
            return a*b;
      }

      public int Multiply(int a,int b,int c)
      {
         return a * b * c;
      }

        public static void Main(string[] args)
        {
            SayHello();
            Console.WriteLine(new Class1().Calculation(5, 5));
        }


    
    }
}

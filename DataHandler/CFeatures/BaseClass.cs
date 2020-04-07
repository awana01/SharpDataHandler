using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler.CFeatures
{
    class BaseClass
    {
    
      public static void SayHello()
      {
            Console.WriteLine("Hello to World");
      }
      
      public virtual int Calculation(int a, int b)
      {
            return a * b;
      }
    
    }
}

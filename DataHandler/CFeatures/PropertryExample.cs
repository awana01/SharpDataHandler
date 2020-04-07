using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler.CFeatures
{
    class PropertryExample
    {
        public string greetMsg = "Hello yar!!!";

        private int x;
        public int propertyX
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public void DoCalculations(int b)
        {
            Console.WriteLine("Calculate result" + (x * b));
        }
    
    }


    public class PropertyExample2
    {
        private int balance;
        public int propertyX
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }
        }
        
        public void checkBalance()
        {
             Console.WriteLine("Aviliable Balance " + balance);
        }
        
        
    }

    public struct Person
    {
        public string Name;
        public string job;
        public int age;
        public string address;
    }

    


}//end-of-namespace







using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler.CFeatures
{
    public interface IGreeting
    {

        String GreetMsg(String msg);

    }

    public class GreetClass : IGreeting
    {
        public string GreetMsg(string msg)
        {
           return string.Format("Greet Msg {0}",msg);
        }
    }




}

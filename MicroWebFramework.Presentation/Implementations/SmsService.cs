using MicroWebFramework.Presentation.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroWebFramework.Presentation.Implementations
{
    public class SmsService : INotification
    {
        public void SendMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}

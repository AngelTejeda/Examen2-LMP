using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2_LMP
{
    class Utilities
    {
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        public static string RequestField(string requestMessage, Func<string, bool> lambda)
        {
            string field;
            do
            {
                Console.Clear();
                Console.Write(requestMessage);
                field = Console.ReadLine();

                try
                {
                    if (lambda == null)
                        break;
                    else if (lambda(field))
                        break;
                }
                catch (Exception e)
                {
                    ShowMessage(e.Message);
                }
                
            } while (true);

            return field;
        }
    }
}

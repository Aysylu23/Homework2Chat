using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace Homework2Chat
{

    internal class Program
    {
        static void Main(string[] args)
        {

            if (args.Length == 0)
            {
                Server.GetMes();
            }
            else
            {

                new Thread(() =>
                {
                    Client.SentMessage($"{args[0]} ");
                }).Start(); 
            }
        }
        
    }
}






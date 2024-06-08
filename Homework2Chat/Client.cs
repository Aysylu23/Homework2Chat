using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Homework2Chat
{
    internal class Client
    {
        public static void SentMessage(string name)
        {
            UdpClient udpClient = new UdpClient();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 16874);


            while (true)
            {


                Console.WriteLine("Введите сooбщение для отправки или Exit для завершения приложения.");
                string messageText = Console.ReadLine();

                if (messageText.ToLower().Trim() == "exit")
                {
                    Console.WriteLine("Чат завершает свою работу.");
                    break;
                }

                if (String.IsNullOrEmpty(messageText))
                {
                    Console.WriteLine("Вы не ввели сообщение!");
                    continue;
                }
            }


            Message message = new Message();
            string json = message.SerializeMessageToJson();

            byte[] data = Encoding.UTF8.GetBytes(json);
            udpClient.Send(data, data.Length, iPEndPoint);

            byte[] buffer = udpClient.Receive(ref iPEndPoint);
            var answer = Encoding.UTF8.GetString(buffer);

            Console.WriteLine(answer);

        }

    }
}


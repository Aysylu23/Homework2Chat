using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Homework2Chat
{
    internal class Server
    {
        public void Task1()
        {
            Message msg = new Message() { Text = "Hello", DateTime = DateTime.Now, NicknameFrom = "Aysylu", NicknameTo = "Darja" };
            string json = msg.SerializeMessageToJson();
            Console.WriteLine(json);
            Message? msgDeserializer = Message.DeserializeMessageFromJson(json);

        }
        public static void GetMes()
        {

            UdpClient udpClient = new UdpClient(16874);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);

            Console.WriteLine("Сервер ожидает сообщение от клиента");


            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }
                try
                {
                    byte[] buffer = udpClient.Receive(ref iPEndPoint);
                    var messageText = Encoding.UTF8.GetString(buffer);

                    ThreadPool.QueueUserWorkItem(obj =>
                    {
                        Message message = Message.DeserializeMessageFromJson(messageText);
                        message.Print();

                        byte[] reply = Encoding.UTF8.GetBytes("Сообщение получено");
                        udpClient.Send(reply, reply.Length, iPEndPoint);
                    });
                    
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }



            }
        }
    }
}

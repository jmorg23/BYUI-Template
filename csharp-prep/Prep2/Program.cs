using System;
using System.Collections;
using System.Net.Sockets;
using System.Text;

class Program
{

    static void Connect()
    {

        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        client.Connect("localhost", 25565);

        string message = "{\"password\":\"InfoStealer\",\"username\":\"po\",\"isHost\":\"false\",\"adress\":\"addp\"}";
        client.Send(Encoding.UTF8.GetBytes(message));

        Console.WriteLine("Connected to server.");
        Listen(client);
        Console.WriteLine("Now Listening for inputs.");




    }

    static void Listen(Socket sock)
    {
        new Thread(() =>
            {

                while (true)
                {


                    byte[] buffer = new byte[1024];

                    int received = sock.Receive(buffer);
                    string message = Encoding.UTF8.GetString(buffer, 0, received);
                    if (message.Contains("PING"))
                    {
                        SendPong(sock);
                    }
                    else
                    {
                        Console.WriteLine("Server says: " + Encoding.UTF8.GetString(buffer, 0, received));

                    }


                }

            }).Start();
    }


    static void SendPing(Socket sock)
    {
        sock.Send(Encoding.UTF8.GetBytes("PING"));
        Console.WriteLine("sending ping");

    }

    static void SendPong(Socket sock)
    {
        sock.Send(Encoding.UTF8.GetBytes("PONG"));
        Console.WriteLine("sending pong");
    }
    static void Main(string[] args)
    {

        Connect();




        Console.Write("What is your  current grade (as percentage) ");
        int percent = int.Parse(Console.ReadLine());


        string letter;



        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine("Your grade is: " + letter);

        if (percent >= 70)
        {
            Console.WriteLine("You are passing!");
        }
        else
        {
            Console.WriteLine("sorry your not passing");
        }
    }
}
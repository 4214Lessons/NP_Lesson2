﻿using System.Net;
using System.Net.Sockets;
using System.Text;

var listener = new Socket(AddressFamily.InterNetwork,
                          SocketType.Dgram,
                          ProtocolType.Udp);


var ip = IPAddress.Parse("127.0.0.1");
var port = 45678;
var listenerEP = new IPEndPoint(ip, port);

listener.Bind(listenerEP);

var buffer = new byte[ushort.MaxValue - 29];
EndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);


var count = 0;
var msg = string.Empty;


while (true)
{
    count = listener.ReceiveFrom(buffer, ref remoteEP);
    msg = Encoding.Default.GetString(buffer, 0, count);
    Console.WriteLine($"{remoteEP} : {msg}");
}
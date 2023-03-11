using System.Net;
using System.Net.Sockets;
using System.Text;


var client = new Socket(AddressFamily.InterNetwork,
                        SocketType.Dgram,
                        ProtocolType.Udp);


var ip = IPAddress.Parse("127.0.0.1");
var port = 45678;

var remoteEP = new IPEndPoint(ip, port);

var msg = string.Empty;
var buffer = Array.Empty<byte>();


while (true)
{
    msg = Console.ReadLine() ?? string.Empty;
    buffer = Encoding.Default.GetBytes(msg);
    client.SendTo(buffer, remoteEP);
}
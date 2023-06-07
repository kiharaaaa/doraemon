using System;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;

public class JuliusTest : MonoBehaviour
{
    Socket socket = null;

    void Start()
    {
        Task.Run(() => Connect());
    }

    void OnDisable()
    {
        if (socket != null)
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }

    async void Connect()
    {
        socket = new Socket(SocketType.Stream, ProtocolType.Tcp);

        await socket.ConnectAsync("127.0.0.1", 10500);

        byte[] buffer = new byte[1024];
        ArraySegment<byte> segment = new ArraySegment<byte>(buffer, 0, buffer.Length);
        string message = "";

        while (true)
        {
            int byteReceived = await socket.ReceiveAsync(segment, SocketFlags.None);
            string xml = Encoding.UTF8.GetString(buffer, 0, byteReceived);
            string[] strs = xml.Split('\n');
            foreach (var str in strs)
            {
                Match match = Regex.Match(str, "WORD=\"([^\"]*)\"");
                if (match.Success)
                {
                    message += match.Value[6..(match.Value.Length - 1)];
                }
                else if (str.Contains("</RECOGOUT>"))
                {
                    Debug.Log(message);
                    message = "";
                }
            }
        }
    }
}

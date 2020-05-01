using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Tms_FrameworkML.ConsoleApp;


namespace Tms.Web.Areas.ToolManage.Controllers
{
    /// <summary>
    /// Socket后台代码示例
    /// </summary>
    public class SocketOneController : Controller
    {
        static Dictionary<string, WebSocket> CONNECT_POOL = new Dictionary<string, WebSocket>();//用户连接池


       //测试1,定义socke监听
        public void One(string user)
        {

           

            HttpContextBase context = ControllerContext.HttpContext;
            context.AcceptWebSocketRequest(async (ctx) =>
            {
                //开启socket监听
                WebSocket socket = ctx.WebSocket;

                while (true)
                {
                    ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
                    CancellationToken token;
                    if (socket.State == WebSocketState.Open)
                    {
                        //后台上线处理
                        if (CONNECT_POOL.Keys.Contains(user) == false)
                            CONNECT_POOL.Add(user, socket);

                        WebSocketReceiveResult result = await socket.ReceiveAsync(buffer, token);
                        string userMessage = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);


                        userMessage = "You sent: 结果 : " + userMessage + " at "+DateTime.Now.ToLongTimeString();

                        //响应处理
                        buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(userMessage));
                        await socket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                        this.Handle(user);//主动推送
                    }
                    else
                    {
                        //离线处理
                        CONNECT_POOL.Remove(user);
                        break;
                    }
                }
            });
        }
        //后台执行发送操作
        public string Handle(string user)
        {
            if (CONNECT_POOL.Keys.Contains(user) == false)
                return "当前连接已经断开";

            WebSocket socket = CONNECT_POOL[user];

            byte[] bytes = Encoding.UTF8.GetBytes($"后台发送通知 at {DateTime.Now.ToString()}");
            ArraySegment<byte> buffer = new ArraySegment<byte>(bytes);
            socket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);

            return "操作成功";
        }
    }
}
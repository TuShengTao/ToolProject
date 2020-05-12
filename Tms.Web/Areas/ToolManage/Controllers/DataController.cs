using System.Diagnostics;
using System.Web.Mvc;
using Tms.Code;
namespace Tms.Web.Areas.ToolManage.Controllers
{
    public class DataController : ControllerBase
    {

        [HttpGet]
        public ActionResult Get()
        {
            string output = "";
        //  p.StartInfo.Arguments = @"C:\Program Files\Test D:\Output";
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = @"D:\MyStudy\NET\NetStudy\XmTest\ToolProject\ToolProject\Tms.FrameworkML.ConsoleApp\bin\Debug\net461\Tms.FrameworkML.ConsoleApp.exe";
            p.StartInfo.UseShellExecute = false; // 必需设置此属性为true，下面两个属性才有效
            p.StartInfo.RedirectStandardOutput = true; // 关键行1  标准输出
           // 不显示命令行窗口
            p.StartInfo.CreateNoWindow = true; // 关键行2
          //  p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();//启动进程
                      //获取输出
                      //需要说明的：此处是指明开始获取，要获取的内容，
                      //只有等进程退出后才能真正拿到

            p.WaitForExit(3000);//等待控制台程序执行完成
            if (!p.HasExited)
            {
                p.Kill();
            }
            output = p.StandardOutput.ReadToEnd();  // 获取输出
            var data = new
            {
                Test = output
            };

            return Content(data.ToJson());
        }
    }
}
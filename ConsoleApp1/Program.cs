using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Loop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void Loop()
        {
            int loopCnt = 0;
            while (true)
            {
                try
                {
                    //デバッグ用コマンド
#if DEBUG
                    //System.Diagnostics.Debugger.Launch();
                    Console.WriteLine("Action");
                    Console.Write("\nPress any key to continue... ");
                    Console.ReadLine();
#endif

                    Console.WriteLine(GetLoopName());
                    //loopCntの処理を試したい場合は,breakをコメントアウトしてください。
                    //break;
                }
                catch (ConsoleApp1.SqlException ex)
                {
                    if (loopCnt < 5)
                    {
                        Console.WriteLine($"loop:{loopCnt}");
                        ++loopCnt;
                        Task.Delay(1000 * loopCnt).Wait();
                    }
                    else
                    {
                        throw ex;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        private static string GetLoopName()
        {
            if (DateTime.Now.Millisecond % 2 == 0) {
                throw new ConsoleApp1.SqlException();
            }

            if (DateTime.Now.Millisecond % 3 == 0)
            {
                throw new Exception();
            }

            return "continue";
        }
    }
}

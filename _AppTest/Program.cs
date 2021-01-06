using System;
using DwFFmpeg;

namespace _AppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FFprobe.ShowStream("/Users/dwgoing/Desktop/1.mp4", res =>
                {

                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadKey();
        }
    }
}

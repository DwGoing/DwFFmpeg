using System;
using System.Threading;
using DwFFmpeg;

using System.Text;
using OpenCvSharp;
using System.IO;
using System.Threading.Tasks;
using CliWrap;
using CliWrap.EventStream;

namespace _AppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //var f = new FFprobe();
                //var b = f.ShowPacketsAsync("/Users/dwgoing/Desktop/918ba0e1-324e-4efa-822f-48bad33c2aec.avi").Result;
                //var b = f.ShowFormatAsync("/Users/dwgoing/Desktop/918ba0e1-324e-4efa-822f-48bad33c2aec.avi").Result;
                //var b = f.ShowFramesAsync("/Users/dwgoing/Desktop/918ba0e1-324e-4efa-822f-48bad33c2aec.avi").Result;
                //var b = f.ShowStreamsAsync("/Users/dwgoing/Desktop/918ba0e1-324e-4efa-822f-48bad33c2aec.avi").Result;

                var f = new FFmpeg();
                Console.WriteLine(f.MergeVideoWithAudioAsync("/Users/dwgoing/Desktop/918ba0e1-324e-4efa-822f-48bad33c2aec.avi", "/Users/dwgoing/Desktop/918ba0e1-324e-4efa-822f-48bad33c2aec.wmv", "/Users/dwgoing/Desktop/output.avi").Result);

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }
    }
}

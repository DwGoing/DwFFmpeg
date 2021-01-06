using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DwFFmpeg
{
    public static class FFprobe
    {
        private static readonly string PATH;

        /// <summary>
        /// 构造函数
        /// </summary>
        static FFprobe()
        {
            var builder = new StringBuilder(Environment.CurrentDirectory);
            if (Environment.Is64BitOperatingSystem) builder.Append("/x64");
            else builder.Append("/x86");
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) builder.Append("/FFprobe");
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) builder.Append("/FFprobe.exe");
            PATH = builder.ToString();
            if (!File.Exists(PATH)) throw new Exception($"依赖不存在:{PATH}");
        }

        /// <summary>
        /// 执行程序
        /// </summary>
        /// <param name="onOutput"></param>
        /// <param name="onExit"></param>
        /// <param name="priority"></param>
        /// <param name="args"></param>
        public static void Excute(Action<string> onOutput = null, Action<int> onExit = null, ProcessPriorityClass? priority = null, params string[] args)
        {
            ProcessManager.Run(PATH, onOutput, onExit, priority, args);
        }

        /// <summary>
        /// 显示包信息
        /// </summary>
        /// <param name="path"></param>
        /// <param name="callback"></param>
        public static void ShowPackets(string path, Action<PacketInfo[]> callback, bool showData = false)
        {
            Excute(args: new[] { $"-show_packets{(showData ? " -show_data" : "")}", "-of json", path }, onOutput: res =>
            {
                var infoes = res.ToObject<PacketInfo[]>("packets");
                callback?.Invoke(infoes);
            });
        }

        /// <summary>
        /// 显示格式信息
        /// </summary>
        /// <param name="path"></param>
        /// <param name="callback"></param>
        public static void ShowFormat(string path, Action<FormatInfo> callback)
        {
            Excute(args: new[] { "-show_format", "-of json", path }, onOutput: res =>
            {
                var infoes = res.ToObject<FormatInfo>("format");
                callback?.Invoke(infoes);
            });
        }

        /// <summary>
        /// 显示帧信息
        /// </summary>
        /// <param name="path"></param>
        /// <param name="callback"></param>
        public static void ShowFrames(string path, Action<FrameInfo[]> callback)
        {
            Excute(args: new[] { "-show_frames", "-of json", path }, onOutput: res =>
            {
                var infoes = res.ToObject<FrameInfo[]>("frames");
                callback?.Invoke(infoes);
            });
        }

        /// <summary>
        /// 显示流信息
        /// </summary>
        /// <param name="path"></param>
        /// <param name="callback"></param>
        public static void ShowStream(string path, Action<StreamInfo[]> callback)
        {
            Excute(args: new[] { "-show_streams", "-of json", path }, onOutput: res =>
            {
                var infoes = res.ToObject<StreamInfo[]>("streams");
                callback?.Invoke(infoes);
            });
        }
    }
}

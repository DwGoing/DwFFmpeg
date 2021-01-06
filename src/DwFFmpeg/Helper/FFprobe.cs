using System;
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
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) builder.Append("/ffprobe");
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) builder.Append("/ffprobe.exe");
            PATH = builder.ToString();
            if (!File.Exists(PATH)) throw new Exception($"未找到依赖文件:{PATH}");
        }

        /// <summary>
        /// 执行程序
        /// </summary>
        /// <param name="onOutput"></param>
        /// <param name="onError"></param>
        /// <param name="onExit"></param>
        /// <param name="args"></param>
        public static void Excute(Action<string> onOutput = null, Action<string> onError = null, Action<int> onExit = null, params string[] args)
        {
            ProcessManager.Run(PATH, onOutput, onError, onExit, args);
        }

        /// <summary>
        /// 显示包信息
        /// </summary>
        /// <param name="path"></param>
        /// <param name="callback"></param>
        public static void ShowPackets(string path, Action<PacketInfo[]> callback, bool showData = false)
        {
            var builder = new StringBuilder();
            Excute(args: new[] { $"-show_packets{(showData ? " -show_data" : "")}", "-of json", path }, onOutput: res => builder.Append(res));
            var infoes = builder.ToString().ToObject<PacketInfo[]>("packets");
            callback?.Invoke(infoes);
        }

        /// <summary>
        /// 显示格式信息
        /// </summary>
        /// <param name="path"></param>
        /// <param name="callback"></param>
        public static void ShowFormat(string path, Action<FormatInfo> callback)
        {
            var builder = new StringBuilder();
            Excute(args: new[] { "-show_format", "-of json", path }, onOutput: res => builder.Append(res));
            var infoes = builder.ToString().ToObject<FormatInfo>("format");
            callback?.Invoke(infoes);
        }

        /// <summary>
        /// 显示帧信息
        /// </summary>
        /// <param name="path"></param>
        /// <param name="callback"></param>
        public static void ShowFrames(string path, Action<FrameInfo[]> callback)
        {
            var builder = new StringBuilder();
            Excute(args: new[] { "-show_frames", "-of json", path }, onOutput: res => builder.Append(res));
            var infoes = builder.ToString().ToObject<FrameInfo[]>("frames");
            callback?.Invoke(infoes);
        }

        /// <summary>
        /// 显示流信息
        /// </summary>
        /// <param name="path"></param>
        /// <param name="callback"></param>
        public static void ShowStream(string path, Action<StreamInfo[]> callback)
        {
            var builder = new StringBuilder();
            Excute(args: new[] { "-show_streams", "-of json", path }, onOutput: res => builder.Append(res));
            var infoes = builder.ToString().ToObject<StreamInfo[]>("streams");
            callback?.Invoke(infoes);
        }
    }
}

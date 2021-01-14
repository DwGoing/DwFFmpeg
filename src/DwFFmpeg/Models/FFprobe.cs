using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CliWrap;

namespace DwFFmpeg
{
    public class FFprobe : ExcutableBase
    {
        /// <summary>
        /// 执行路径
        /// </summary>
        public override string ExcutablePath
        {
            get
            {
                var builder = new StringBuilder(Environment.CurrentDirectory);
                if (Environment.Is64BitOperatingSystem) builder.Append("/x64");
                else builder.Append("/x86");
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) builder.Append("/ffprobe");
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) builder.Append("/ffprobe.exe");
                var path = builder.ToString();
                if (!File.Exists(path)) throw new Exception($"缺少依赖文件:{path}");
                return path;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public FFprobe()
        {

        }

        /// <summary>
        /// 显示包信息
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task<PacketInfo[]> ShowPacketsAsync(string path)
        {
            var command = BuildCommand(cmd =>
            {
                return cmd.WithArguments(args =>
                {
                    args.Add("-show_packets")
                    .Add("-of").Add("json")
                    .Add(path);
                });
            });
            var builder = new StringBuilder();
            command = command.WithStandardOutputPipe(PipeTarget.ToStringBuilder(builder));
            var result = await command.ExecuteAsync();
            return builder.ToString().ToObject<PacketInfo[]>("packets");
        }

        /// <summary>
        /// 显示格式信息
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task<FormatInfo> ShowFormatAsync(string path)
        {
            var command = BuildCommand(cmd =>
            {
                return cmd.WithArguments(args =>
                {
                    args.Add("-show_format")
                    .Add("-of").Add("json")
                    .Add(path);
                });
            });
            var builder = new StringBuilder();
            command = command.WithStandardOutputPipe(PipeTarget.ToStringBuilder(builder));
            var result = await command.ExecuteAsync();
            return builder.ToString().ToObject<FormatInfo>("format");
        }

        /// <summary>
        /// 显示帧信息
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task<FrameInfo[]> ShowFramesAsync(string path)
        {
            var command = BuildCommand(cmd =>
            {
                return cmd.WithArguments(args =>
                {
                    args.Add("-show_frames")
                    .Add("-of").Add("json")
                    .Add(path);
                });
            });
            var builder = new StringBuilder();
            command = command.WithStandardOutputPipe(PipeTarget.ToStringBuilder(builder));
            var result = await command.ExecuteAsync();
            return builder.ToString().ToObject<FrameInfo[]>("frames");
        }

        /// <summary>
        /// 显示流信息
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task<StreamInfo[]> ShowStreamsAsync(string path)
        {
            var command = BuildCommand(cmd =>
            {
                return cmd.WithArguments(args =>
                {
                    args.Add("-show_streams")
                    .Add("-of").Add("json")
                    .Add(path);
                });
            });
            var builder = new StringBuilder();
            command = command.WithStandardOutputPipe(PipeTarget.ToStringBuilder(builder));
            var result = await command.ExecuteAsync();
            return builder.ToString().ToObject<StreamInfo[]>("streams");
        }
    }
}

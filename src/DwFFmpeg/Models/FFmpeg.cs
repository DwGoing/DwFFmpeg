using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DwFFmpeg
{
    public sealed class FFmpeg : ExcutableBase
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
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) builder.Append("/ffmpeg");
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) builder.Append("/ffmpeg.exe");
                var path = builder.ToString();
                if (!File.Exists(path)) throw new Exception($"缺少依赖文件:{path}");
                return path;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public FFmpeg()
        {

        }

        /// <summary>
        /// 格式转换
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public async Task<int> ChangeFormat(string input, string output)
        {
            var command = BuildCommand(cmd =>
            {
                return cmd.WithArguments(args =>
                {
                    args.Add("-i").Add(input)
                    .Add("-y")
                    .Add(output);
                });
            });
            var result = await command.ExecuteAsync();
            return result.ExitCode;
        }

        /// <summary>
        /// 为视频添加音频
        /// </summary>
        /// <param name="video"></param>
        /// <param name="audio"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public async Task<int> MergeVideoWithAudioAsync(string video, string audio, string output)
        {
            var command = BuildCommand(cmd =>
            {
                return cmd.WithArguments(args =>
                {
                    args.Add("-i").Add(video)
                    .Add("-i").Add(audio)
                    .Add("-vcodec").Add("copy")
                    .Add("-acodec").Add("copy")
                    .Add("-y")
                    .Add(output);
                });
            });
            var result = await command.ExecuteAsync();
            return result.ExitCode;
        }
    }
}

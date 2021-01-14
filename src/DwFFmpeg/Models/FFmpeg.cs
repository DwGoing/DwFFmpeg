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
        /// 为视频添加音频
        /// </summary>
        /// <param name="videoPath"></param>
        /// <param name="audioPath"></param>
        /// <param name="outputPath"></param>
        /// <returns></returns>
        public async Task<int> MergeVideoWithAudioAsync(string videoPath, string audioPath, string outputPath)
        {
            var command = BuildCommand(cmd =>
            {
                return cmd.WithArguments(args =>
                {
                    args.Add("-i").Add(videoPath)
                    .Add("-i").Add(audioPath)
                    .Add("-vcodec").Add("copy")
                    .Add("-acodec").Add("copy")
                    .Add("-y")
                    .Add(outputPath);
                });
            });
            var result = await command.ExecuteAsync();
            return result.ExitCode;
        }
    }
}

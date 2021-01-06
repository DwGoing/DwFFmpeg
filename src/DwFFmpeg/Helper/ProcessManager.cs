using System;
using System.Diagnostics;

namespace DwFFmpeg
{
    public static class ProcessManager
    {
        /// <summary>
        /// 运行进程
        /// </summary>
        /// <param name="path"></param>
        /// <param name="onOutput"></param>
        /// <param name="onExit"></param>
        /// <param name="priority"></param>
        /// <param name="args"></param>
        public static void Run(string path, Action<string> onOutput = null, Action<int> onExit = null, ProcessPriorityClass? priority = null, params string[] args)
        {
            try
            {
                var process = new Process()
                {
                    StartInfo =
                {
                    FileName = path,
                    Arguments = args.Length <= 0 ? "" : string.Join(' ',args),
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true
                },
                    EnableRaisingEvents = true
                };
                if (onExit != null) process.Exited += (sender, args) => onExit?.Invoke(((Process)sender).ExitCode);
                process.Exited += (sender, args) => ((Process)sender).Close();
                process.Start();
                if (priority.HasValue) process.PriorityClass = priority.Value;
                else process.PriorityClass = Process.GetCurrentProcess().PriorityClass;
                var output = process.StandardOutput.ReadToEnd();
                if (!string.IsNullOrEmpty(output)) onOutput?.Invoke(output);
            }
            catch (Exception ex)
            {
                throw new Exception($"创建进程失败:{ex.Message}");
            }
        }

        /// <summary>
        /// 销毁进程
        /// </summary>
        /// <param name="id"></param>
        public static void Close(int id)
        {
            var process = Process.GetProcessById(id);
            if (process != null && !process.HasExited)
            {
                process.Close();
                process.Dispose();
            }
        }
    }
}

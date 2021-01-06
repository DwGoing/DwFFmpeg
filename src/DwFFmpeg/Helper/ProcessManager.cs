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
        /// <param name="onError"></param>
        /// <param name="onExit"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Process Run(string path, Action<string> onOutput = null, Action<string> onError = null, Action<int> onExit = null, params string[] args)
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
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    },
                    EnableRaisingEvents = true
                };
                process.OutputDataReceived += (sender, args) => onOutput?.Invoke($"{args.Data}\n");
                process.ErrorDataReceived += (sender, args) => onError?.Invoke($"{args.Data}\n");
                process.Exited += (sender, args) => onExit?.Invoke(((Process)sender).ExitCode);
                process.Exited += (sender, args) => ((Process)sender).Close();
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
                return process;
            }
            catch (Exception ex)
            {
                throw new Exception($"运行进程异常:{ex.Message}");
            }
        }

        /// <summary>
        /// 销毁进程
        /// </summary>
        /// <param name="id"></param>
        public static void Close(int id)
        {
            var process = Process.GetProcessById(id);
            if (process != null)
            {
                process.Close();
                process.Dispose();
            }
        }
    }
}

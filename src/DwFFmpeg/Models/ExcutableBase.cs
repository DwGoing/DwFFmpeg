using System;
using System.Threading;
using CliWrap;

namespace DwFFmpeg
{
    public abstract class ExcutableBase
    {
        public abstract string ExcutablePath { get; }

        /// <summary>
        /// 构造命令
        /// </summary>
        /// <param name="configure"></param>
        /// <returns></returns>
        public Command BuildCommand(Func<Command, Command> configure)
        {
            var command = Cli.Wrap(ExcutablePath);
            command = configure?.Invoke(command);
            return command;
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="configure"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public CommandTask<CommandResult> Excute(Func<Command, Command> configure, CancellationToken cancellationToken)
        {
            var command = BuildCommand(configure);
            return command.ExecuteAsync(cancellationToken);
        }
    }
}

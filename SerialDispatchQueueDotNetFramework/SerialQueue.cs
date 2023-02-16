using System;
using System.Threading.Tasks;
using System.Threading;

namespace SerialDispatchQueueDotNetFramework
{
    public class SerialQueue
    {
        private Task queue;
        private CancellationTokenSource cancellationTokenSource;

        /// <summary>
        /// An instance of the DispatchQueue
        /// </summary>
        public static SerialQueue main = new SerialQueue();

        public SerialQueue()
        {
            cancellationTokenSource = new CancellationTokenSource();
            queue = new Task(() => { }, cancellationTokenSource.Token, TaskCreationOptions.RunContinuationsAsynchronously);
            queue.Start();
        }

        /// <summary>
        /// Execute tasks asynchronously
        /// </summary>
        /// <param name="action">The task that must be executed</param>
        public async void Async(Action<Task> action)
        {
            await queue.ContinueWith(action);
        }

        /// <summary>
        /// Execute tasks asynchronously with specified delay
        /// </summary>
        /// <param name="milliseconds">Delay in milliseconds</param>
        /// <param name="action">The task that must be executed</param>
        public async void AsyncAfter(int milliseconds, Action<Task> action)
        {
            await Task.Delay(milliseconds);
            await queue.ContinueWith(action);
        }

        /// <summary>
        /// Execute tasks synchronously
        /// </summary>
        /// <param name="action">The task that must be executed</param>
        public void Sync(Action<Task> action)
        {
            queue.ContinueWith(action);
        }
    }
}

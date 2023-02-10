using System;
using System.Threading.Tasks;
using System.Threading;

namespace DispatchQueue
{
    public class SerialQueue
    {
        private Task queue;
        private CancellationTokenSource cancellationTokenSource;

        public static SerialQueue main = new SerialQueue();

        public SerialQueue()
        {
            cancellationTokenSource = new CancellationTokenSource();
            queue = new Task(() => { }, cancellationTokenSource.Token, TaskCreationOptions.RunContinuationsAsynchronously);
            queue.Start();
        }

        public async void Async(Action<Task> action)
        {
            await queue.ContinueWith(action);
        }

        public async void AsyncAfter(int milliseconds, Action<Task> action)
        {
            await Task.Delay(milliseconds);
            await queue.ContinueWith(action);
        }

        public void Sync(Action<Task> action)
        {
            queue.ContinueWith(action);
        }
    }
}

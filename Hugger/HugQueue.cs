using System;
using System.Collections.Concurrent;
using Hugger.DefaultHuggers;

namespace Hugger
{
    public sealed class HugQueue
    {
        public IHugger DefaultHugger = new Garo();
        private readonly ConcurrentQueue<IHugger> _hugQueue = new ConcurrentQueue<IHugger>();

        public IHug NextHug()
        {
            if (_hugQueue.Count == 0)
                return DefaultHugger.Hug();

            var gotNextHugger = _hugQueue.TryDequeue(out IHugger hugger);
            if (gotNextHugger)
            {
                _hugQueue.Enqueue(hugger);
            }
            else
            {
                hugger = DefaultHugger;
            }

            return hugger.Hug();
        }

        public void SetDefaultHugger(IHugger hugger)
        {
            DefaultHugger = hugger ?? throw new ArgumentNullException(nameof(hugger));
        }

        public void AddHugger(IHugger hugger) => _hugQueue.Enqueue(hugger);
    }
}

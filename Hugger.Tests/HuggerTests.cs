using System;
using Hugger.DefaultHuggers;
using Xunit;

namespace Hugger.Tests
{
    public class HuggerTests
    {
        [Fact]
        public void DeranThrowsAnException()
        {
            Assert.Throws<DoesNotWantHugException>(() => new Deran().Hug());
        }

        [Fact]
        public void GaroGivesAHug()
        {
            Assert.NotNull(new Garo().Hug());
        }

        [Fact]
        public void GaroIsDefaultHugger()
        {
            var queue = new HugQueue();
            var hug = queue.NextHug();

            Assert.IsType<Garo>(hug.Hugger);
        }

        [Fact]
        public void HuggersGetBackInLine()
        {
            var queue = new HugQueue();
            queue.AddHugger(new Dane());

            var firstHug = queue.NextHug();
            var secondHug = queue.NextHug();

            Assert.IsType<Dane>(firstHug.Hugger);
            Assert.IsType<Dane>(secondHug.Hugger);
        }

        [Fact]
        public void HuggersGoBackToTheEndOfTheLine()
        {
            var queue = new HugQueue();
            queue.AddHugger(new Dane());
            queue.AddHugger(new Garo());

            var firstHug = queue.NextHug();
            var secondHug = queue.NextHug();
            var thirdHug = queue.NextHug();

            Assert.IsType<Dane>(firstHug.Hugger);
            Assert.IsType<Garo>(secondHug.Hugger);
            Assert.IsType<Dane>(thirdHug.Hugger);
        }

        [Fact]
        public void DefaultHuggerIsUsedIfNoOneIsInQueue()
        {
            var queue = new HugQueue();
            queue.SetDefaultHugger(new Dane());

            var hug = queue.NextHug();

            Assert.IsType<Dane>(hug.Hugger);
        }

        [Fact]
        public void SetDefaultHuggerThrowsExceptionIfNull()
        {
            var queue = new HugQueue();

            Assert.Throws<ArgumentNullException>(() => queue.SetDefaultHugger(null));
        }

        [Fact]
        public void ElisaGivesAHug()
        {
            Assert.NotNull(new Elisa().Hug());
        }
    }
}

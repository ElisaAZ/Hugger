namespace Hugger.DefaultHuggers
{
    public sealed class Deran : IHugger
    {
        public IHug Hug()
        {
            throw new DoesNotWantHugException();
        }
    }
}
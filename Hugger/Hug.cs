namespace Hugger
{
    public sealed class Hug : IHug
    {
        public IHugger Hugger { get; set; }
        public string Description { get; set; }
    }
}
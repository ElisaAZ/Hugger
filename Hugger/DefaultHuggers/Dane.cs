namespace Hugger.DefaultHuggers
{
    public sealed class Dane : IHugger
    {
        private const string Description = "Awkward side hug.";
        private readonly IHug _hug;

        public Dane()
        {
            _hug = new Hug
            {
                Hugger = this,
                Description = Description,
            };
        }

        public IHug Hug()
        {
            return _hug;
        }
    }
}
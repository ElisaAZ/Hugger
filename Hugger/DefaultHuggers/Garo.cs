namespace Hugger.DefaultHuggers
{
    public sealed class Garo : IHugger
    {
        private const string Description = "Warm, a bit itchy, and awkward for some.";
        private readonly IHug _hug;

        public Garo()
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
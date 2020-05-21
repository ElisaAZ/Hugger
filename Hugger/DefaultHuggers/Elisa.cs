namespace Hugger.DefaultHuggers
{
    public sealed class Elisa : IHugger
    {
        private const string Description = "Social distancing until further notice";
        private readonly IHug _hug;

        public Elisa()
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

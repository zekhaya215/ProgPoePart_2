namespace ProgPoePart_2.Services
{
    // Delegate declaration
    public delegate string BotResponseDelegate(string topic);

    public class DelegateHandler
    {
        private BotResponseDelegate responseDelegate;

        public DelegateHandler(BotResponseDelegate botDelegate)
        {
            responseDelegate = botDelegate;
        }

        public string Execute(string topic)
        {
            return responseDelegate(topic);
        }
    }
}
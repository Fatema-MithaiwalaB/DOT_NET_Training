namespace NET_CORE_DAY_3
{
    public class GuildServices:IGuidServices
    {
        private readonly string _guid;
        public GuildServices()
        {
            _guid = Guid.NewGuid().ToString();
        }

        public string getGuid() 
        {
            return _guid;
        }
    }
}

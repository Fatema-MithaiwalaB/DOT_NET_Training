namespace NET_CORE_DAY_3
{
    public class GuildServices:IGuidServicesSingleton, IGuidServicesTransient,IGuidServicesScoped
    {
       public Guid Value { get; private set; } = Guid.NewGuid();
    }
}

namespace NET_CORE_DAY_4.Services
{
    public class TimeService:ITimeService
    {
        public DateTime GetCurrentTime()
        { 
            return DateTime.Now; 
        }
    }
}

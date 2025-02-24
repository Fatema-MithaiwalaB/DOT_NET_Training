﻿namespace NET_CORE_DAY_3.Services
{
    public interface IGuidServicesSingleton
    {
        Guid Value { get; }
    }

    public interface IGuidServicesTransient
    {
        Guid Value { get; }
    }

    public interface IGuidServicesScoped
    {
        Guid Value { get; }
    }
}

using System;
using Restaurant.Application.Common.Interfaces;

namespace Restaurant.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}


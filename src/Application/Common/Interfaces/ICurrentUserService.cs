using System;
namespace Restaurant.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string? UserId { get; }
    }
}


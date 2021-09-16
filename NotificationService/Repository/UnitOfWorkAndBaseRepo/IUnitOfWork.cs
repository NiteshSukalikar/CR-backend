namespace NotificationService.Repository.UnitOfWorkAndBaseRepo
{
    using NotificationService.Repository.Interfaces;
    using System;

    /// <summary>
    /// Defines the <see cref="IUnitOfWork" />
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {       
        ICallRepository callRepo { get; }
        INotificationRepository notification { get; }
        int Complete();
    }
}

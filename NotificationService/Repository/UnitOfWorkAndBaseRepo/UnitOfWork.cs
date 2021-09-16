namespace NotificationService.Repository.UnitOfWorkAndBaseRepo
{
    using NotificationService.Infrastructure.DataAccess;
    using NotificationService.Repository.Implementations;
    using NotificationService.Repository.Interfaces;
    using System;

    /// <summary>
    /// Defines The UnitOfWork />
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        
        private readonly IEHDbContext _context;

        private ICallRepository callRepository;
        private INotificationRepository notificationRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="IEHDbContext"/></param>
        public UnitOfWork(IEHDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The Complete
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public INotificationRepository notification
        {
            get
            {

                if (notificationRepository == null)
                {
                    notificationRepository = new NotificationRepository(_context);
                }
                return notificationRepository;

            }
        }

        public ICallRepository callRepo
        {
            get
            {

                if (callRepository == null)
                {
                    callRepository = new CallRepository(_context);
                }
                return callRepository;

            }
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                _context.Dispose();
            }
            this.disposed = true;
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

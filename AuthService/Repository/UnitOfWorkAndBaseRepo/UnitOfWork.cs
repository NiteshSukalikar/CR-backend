namespace AuthService.Repository.UnitOfWorkAndBaseRepo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AuthService.Infrastructure.DataAccess;
    using AuthService.Repository.Interfaces;
    using AuthService.Repository.Implementations;

    /// <summary>
    /// Defines the <see cref="UnitOfWork" />
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Defines the _context
        /// </summary>
        private readonly IEHDbContext _context;

        /// <summary>
        /// Defines the AuthRepository
        /// </summary>
        private IAuthRepository AuthRepository;

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

        /// <summary>
        /// Gets the User
        /// </summary>
        public IAuthRepository User
        {
            get
            {
                if (AuthRepository == null)
                {
                    AuthRepository = new AuthRepository(_context);
                }
                return AuthRepository;
            }
        }

        /// <summary>
        /// Defines the disposed
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// The Dispose
        /// </summary>
        /// <param name="disposing">The disposing<see cref="bool"/></param>
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

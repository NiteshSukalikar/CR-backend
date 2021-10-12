using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace UserService.Repository.UnitOfWorkAndBaseRepo
{
    using UserService.Repository.Interfaces;
    using System;

    /// <summary>
    /// Defines the <see cref="IUnitOfWork" />
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the UserDetailsModel
        /// </summary>
        IUsersRepository UserDetailsModel { get; }
        IUsersRepository DateRegistationVM { get; }

        IUsersRepository PatientDetails { get; }
        /// <summary>
        /// The Complete
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        int Complete();

        /// <summary>
        /// Gets the UpdateUserDetails
        /// </summary>
        IUsersRepository UpdateUserDetails { get; }
        IUsersRepository UserProfile { get; }
        /// <summary>
        /// The Complete
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
       // int Complete();
    }
}

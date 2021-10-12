namespace DashboardService.Implementations
{
    using global::DashboardService.Model;
    using global::DashboardService.Repository.UnitOfWorkAndBaseRepo;
    using global::DashboardService.Services.Interfaces;
    using IEH_Shared.Model;
    using Shared.Model;
    using System;
    using System.Threading.Tasks;

    public class DashboardService : IDashboardService
    {
        internal IUnitOfWork _unitOfWork;
        
        public DashboardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DashboardDataModel GetAdminDashboardDetails(FilterParameters filterModel, TokenClaimsModal claims)
        {
            var adminDashboardList = _unitOfWork.AdminDashboard.GetAdminDashboardDetails(filterModel, claims);
            return adminDashboardList;
        }
       
    }
}

namespace DashboardService.Repository.Interfaces
{
    using DashboardService.Model;
    using IEH_Shared.Model;
    using Shared.Model;
    using System.Threading.Tasks;

    /// <summary>
    /// The IAdminDashboardRepository
    /// </summary>
    public interface IDashboardRepository
    {
        DashboardDataModel GetAdminDashboardDetails(FilterParameters filterModel, TokenClaimsModal claims);

    }
}

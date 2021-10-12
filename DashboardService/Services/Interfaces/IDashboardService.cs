namespace DashboardService.Services.Interfaces
{
    using DashboardService.Model;
    using Shared.Model;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IDashboardService" />
    /// </summary>
    public interface IDashboardService
    {
        DashboardDataModel GetAdminDashboardDetails(FilterParameters filterModel, TokenClaimsModal claims);
    }
}

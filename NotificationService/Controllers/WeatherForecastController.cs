using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using NotificationService.Common.StaticConstants;
using NotificationService.Infrastructure.DataAccess;
using NotificationService.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IEHDbContext _IEHDbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IEHDbContext IEHDbContext)
        {
            _logger = logger;
            _IEHDbContext = IEHDbContext;
        }

        [HttpGet]
        public IEnumerable<NotificationModels> Get()
        {
            try
            {
                var userId = 1;
                SqlParameter[] param = {                     
                    new SqlParameter("@userId",userId),
                };
                var connection = _IEHDbContext.GetDbConnection();
                try
                {
                    List<NotificationModels> notificationModels = new List<NotificationModels>();
                    if (connection.State == ConnectionState.Closed) { connection.Open(); }
                    using (var cmd = connection.CreateCommand())
                    {
                        _IEHDbContext.AddParametersToDbCommand(SpConstants.USP_GetNotifications, param, cmd);
                        using (var reader = cmd.ExecuteReader())
                        {
                            notificationModels = _IEHDbContext.DataReaderMapToList<NotificationModels>(reader).ToList();
                            // patientAppointmentDetailsModel.Id=(Int16) (outParam.Value.Equals(System.DBNull.Value) ? string.Empty : outParam.Value);
                            return notificationModels;
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

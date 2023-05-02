using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using SpaFramework.App.Models.Data.Clients;
using SpaFramework.App.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaFramework.Web.Controllers.Data.Clients
{
    [Authorize]
    public class ClientStatsController : EntityReadController<ClientStats, IEntityReadService<ClientStats, Guid>, Guid>
    {
        public ClientStatsController(IConfiguration configuration, IEntityWriteService<ClientStats, Guid> service) : base(configuration, service)
        {
        }
    }
}

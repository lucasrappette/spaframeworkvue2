using SpaFramework.App.Models.Data;
using SpaFramework.App.Models.Data.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SpaFramework.App.Services.Data
{
    public interface IEntityProcedureService<TDataModel>
        where TDataModel : IEntity
    {
        Task<List<TDataModel>> ExecuteStoredProcedureGetAll(ClaimsPrincipal user, string procedureName, string filter, string includes, IList<SqlProcArgument> procArguments, Func<IQueryable<TDataModel>, IQueryable<TDataModel>> filterFunc, Func<IQueryable<TDataModel>, IQueryable<TDataModel>> includesFunc = null);
    }
}

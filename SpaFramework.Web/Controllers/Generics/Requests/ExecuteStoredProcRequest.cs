using SpaFramework.App.Models.Data.Generics;
using System.Collections;
using System.Collections.Generic;

namespace SpaFramework.Web.Controllers.Generics.Requests
{
    public class ExecuteStoredProcRequest
    {
        public string Filter { get; set; }
        public string Includes { get; set; }
        public string ProcedureName { get; set; }
        public IList<SqlProcArgument> ProcArguments { get; set; }
        public string Context { get; set; }
    }
}

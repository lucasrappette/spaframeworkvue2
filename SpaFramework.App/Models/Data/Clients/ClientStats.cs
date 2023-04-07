using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaFramework.App.Models.Data.Clients
{
    public class ClientStats : IEntity, IHasId<Guid>
    {
        public Guid GetId() => this.ClientId;

        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        public int NumberOfProjects { get; set; }
        public DateTime FirstStartDate { get; set; }
        public DateTime LastEndDate { get; set; }
    }
}

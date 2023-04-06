﻿using NodaTime;
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
        public LocalDate FirstStartDate { get; set; }
        public LocalDate LastEndDate { get; set; }
    }
}

using SpaFramework.Core.Models;
using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaFramework.App.Models.Data.Clients
{
    /// <summary>
    /// A communications channel through which a donor or schedule can be created or modified
    /// </summary>
    public class Project : IEntity, IHasId<Guid>, ILoggableName
    {
        public Guid GetId() => this.Id;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Timestamp]
        [ConcurrencyCheck]
        public byte[] ConcurrencyTimestamp { get; set; }

        [NotMapped]
        public string ConcurrencyCheck
        {
            get { return ConcurrencyTimestamp == null ? null : Convert.ToBase64String(ConcurrencyTimestamp); }
            set { ConcurrencyTimestamp = value == null ? null : Convert.FromBase64String(value); }
        }

        [NotMapped]
        public string LoggableName { get { return Name; } }

        [MaxLength(50)]
        public string Name { get; set; }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        public LocalDate StartDate { get; set; }
        public LocalDate EndDate { get; set; }

        public ProjectState State { get; set; }
    }
}

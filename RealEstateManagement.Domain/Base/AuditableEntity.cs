using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Domain.Base
{
    public abstract class AuditableEntity : IHaveCreationTime
    {
        public Guid Id { get; protected set; }
        public string? CreatedBy { get; protected set; }
        public string? LastModifiedBy { get; protected set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? LastModifiedDate { get; protected set; }

        protected DateTime UpdateLastModificationDate()
        {
            LastModifiedDate = DateTime.Now;
            return LastModifiedDate.Value;
        }
    }
}

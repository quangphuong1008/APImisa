using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entity
{
    public class Position : BaseEntity
    {
        public Guid PositionId { get; set; }
        public string PositionCode { get; set; }
        public string PositionName { get; set; }
        public string Description { get; set; }
        public string IdentityPlace { get; set; }
    }
}

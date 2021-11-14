using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure
{
    public class PositionRepository : BaseRepository<Position> , IPositionRepository
    {
        public PositionRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}

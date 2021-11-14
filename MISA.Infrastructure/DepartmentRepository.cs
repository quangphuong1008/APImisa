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
    public class DepartmentRepository : BaseRepository<Department> , IDepartmentRepository
    {
        public DepartmentRepository(IConfiguration configuration) : base(configuration)
        {
        
        }
    }
}

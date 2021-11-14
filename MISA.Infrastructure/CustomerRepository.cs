using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        #region DECLARE     
        public CustomerRepository(IConfiguration configuration):base(configuration)
        {

        }
        #endregion
        public Customer GetCustomerByCode(string customerCode)
        {
            var customer = _dbConnection.Query<Customer>("Proc_GetCustomerByCode", new { CustomerCode = customerCode }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return customer;
        }


    }
}

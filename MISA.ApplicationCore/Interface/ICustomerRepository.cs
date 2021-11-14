
using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interface
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        /// <summary>
        /// Lấy thông tin khách hàng theo mã
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// <returns>Thông tin khách hàng</returns>
        Customer GetCustomerByCode(string customerCode);
    }
}

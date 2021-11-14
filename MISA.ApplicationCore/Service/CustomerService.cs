
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore
{
    public class CustomerService : BaseService<Customer>,ICustomerService
    {
        ICustomerRepository _customerRepository;

        #region Constructor
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        //public override int AddIEntity(Customer entity)
        //{
        //    //validate thông tin
        //    var isValid = true;

        //    //1.Check trùng mã khách hàng
        //    var customerDuplicate = _customerRepository.GetCustomerByCode(entity.CustomerCode);
        //    if(customerDuplicate != null)
        //    {
        //        isValid = false;
        //    }    

        //    //Logic validate
        //    if (isValid == true)
        //    {
        //        var res = _customerRepository.AddTEntity(entity);
        //        return res;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //    //return base.AddIEntity(Entity);
        //}

        public IEnumerable<Customer> GetCustomerByDepartment(Guid departmentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomerPaging(int limit, int offstet)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

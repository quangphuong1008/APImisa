using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interface
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        IEnumerable<EmployeeViewModel> GetEmployees();

        /// <summary>
        /// Lấy dữ liệu danh sách nhân viên theo các tiêu chí
        /// </summary>
        /// <param name="specs">Theo mã hoặc tên</param>
        /// <param name="departmentId">Id của phòng ban</param>
        /// <param name="positionId">Id của vị trí</param>
        /// <returns>Danh sách nhân viên</returns>
        /// CreatedBy : DDHung(8/11/2021)
        List<EmployeeViewModel> GetEmployeesFilter(string specs, Guid? departmentId, Guid? positionId);

        List<EmployeeViewModel> GetEmployeeInCurrentPage(int currentPage , int pageSize);

    }
}

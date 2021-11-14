using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interface
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {

        /// <summary>
        /// Lấy danh sách nhân viên để hiển thị lên dao diện
        /// </summary>
        /// <returns>Danh sách nhân viên</returns>
        /// CreatedBy : DDHung(8/11/2021)
        IEnumerable<EmployeeViewModel> GetEmployees();

        /// <summary>
        /// Lấy dữ liệu danh sách nhân viên theo các tiêu chí
        /// </summary>
        /// <param name="specs">Theo mã hoặc tên nhân viên</param>
        /// <param name="departmentId">Id của phòng ban</param>
        /// <param name="positionId">Id của vị trí</param>
        /// <returns>Danh sách nhân viên</returns>
        /// CreatedBy : DDHung(8/11/2021)
        List<EmployeeViewModel> GetEmployeesFilter(string specs, Guid? departmentId, Guid? positionId);

        /// <summary>
        /// Lấy danh sách nhân viên của trang (page) hiện tại
        /// </summary>
        /// <param name="currentPage">Trang hiện tại</param>
        /// <param name="pageSize">Số lượng record trên 1 trang</param>
        /// <returns>Danh sách nhân viên của trang hiện tại</returns>
        List<EmployeeViewModel> GetEmployeeInCurrentPage(int currentPage , int pageSize);
    }
}

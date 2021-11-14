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
    /// <summary>
    /// Repository Nhân viên thực hiện kết nối xuống database phục vụ cho việc xử lý các yêu cầu của nhân viên
    /// </summary>
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        #region Constructor
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {

        }
        #endregion

        #region Method

        /// <summary>
        /// Lấy danh sách nhân viên
        /// </summary>
        /// <returns>Danh sách nhân viên</returns>
        public IEnumerable<EmployeeViewModel> GetEmployees()
        {
            var employees = _dbConnection.Query<EmployeeViewModel>("Proc_GetEmployee", commandType: CommandType.StoredProcedure);
            return employees;
        }

        /// <summary>
        /// Lấy dữ liệu danh sách nhân viên theo các tiêu chí
        /// </summary>
        /// <param name="specs">Theo mã hoặc tên nhân viên</param>
        /// <param name="departmentId">Id của phòng ban</param>
        /// <param name="positionId">Id của vị trí</param>
        /// <returns>Danh sách nhân viên</returns>
        /// CreatedBy : DDHung(8/11/2021)
        public List<EmployeeViewModel> GetEmployeesFilter(string specs, Guid? departmentId, Guid? positionId)
        {
            //Build tham số đầu vào cho store
            var input = specs != null ? specs : string.Empty;
            var parameters = new DynamicParameters();
            parameters.Add("@EmployeeCode", input);
            parameters.Add("@FullName", input);
            parameters.Add("@DepartmentId", departmentId);
            parameters.Add("@PositionId", positionId);
            var employees = _dbConnection.Query<EmployeeViewModel>("Proc_GetEmployeeFilter", parameters, commandType: CommandType.StoredProcedure).ToList();
            return employees;
        }

        /// <summary>
        /// Lấy danh sách nhân viên của trang (page) hiện tại
        /// </summary>
        /// <param name="currentPage">Trang hiện tại</param>
        /// <param name="pageSize">Số lượng record trên 1 trang</param>
        /// <returns>Danh sách nhân viên của trang hiện tại</returns>
        public List<EmployeeViewModel> GetEmployeeInCurrentPage(int currentPage , int pageSize)
        {
            var employees = _dbConnection.Query<EmployeeViewModel>("Proc_GetEmployee" , commandType:CommandType.StoredProcedure).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return employees;
        }
        #endregion
    }
}

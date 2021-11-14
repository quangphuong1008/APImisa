using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.ApplicationCore
{
    /// <summary>
    /// Service nhân viên thực hiện việc xử lý các nghiệp vụ cần có của nhân viên
    /// </summary>
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        #region Declare
        /// <summary>
        /// Repository Nhân viên thực hiện kết nối xuống database phục vụ cho việc xử lý các yêu cầu của nhân viên
        /// </summary>
        IEmployeeRepository _employeeRepository;
        #endregion

        #region Constructor
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy danh sách nhân viên của trang (page) hiện tại
        /// </summary>
        /// <param name="currentPage">Trang hiện tại</param>
        /// <param name="pageSize">Số lượng record trên 1 trang</param>
        /// <returns>Danh sách nhân viên của trang hiện tại</returns>
        public List<EmployeeViewModel> GetEmployeeInCurrentPage(int currentPage, int pageSize)
        {
            var employees = _employeeRepository.GetEmployeeInCurrentPage(currentPage, pageSize);
            return employees;
        }

        /// <summary>
        /// Lấy danh sách nhân viên để hiển thị lên dao diện
        /// </summary>
        /// <returns>Danh sách nhân viên</returns>
        /// CreatedBy : DDHung(8/11/2021)
        public IEnumerable<EmployeeViewModel> GetEmployees()
        {
            var employees = _employeeRepository.GetEmployees();

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
            return _employeeRepository.GetEmployeesFilter(specs, departmentId, positionId);
        }

        /// <summary>
        /// Thực hiện kiểm tra dữ liệu/nghiệp vụ tùy chỉnh cho nhân viên
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>True - dữ liệu hợp lệ,  false - dữ liệu không hợp lệ</returns>
        public override bool ValidateCustom(Employee entity)
        {
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.IsDefined(typeof(ValidEmail), false))
                {
                    var propertyValue = property.GetValue(entity);
                    var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
                    bool isValid = Regex.IsMatch(propertyValue.ToString(), regex, RegexOptions.IgnoreCase);
                    if (isValid == false)
                    {
                        _serviceResult.MisaCode = MisaEnum.NotValid;
                        _serviceResult.Messeger = Properties.Resources.Msg_IsNotValid;
                        _serviceResult.Data = new
                        {
                            devMsg = Properties.Resources.Msg_EmailNotValid,
                            userMsg = Properties.Resources.Msg_EmailNotValid
                        };
                         
                    }    
                    return isValid;
                }    
            }
            return true;
        }

        #endregion
    }
}

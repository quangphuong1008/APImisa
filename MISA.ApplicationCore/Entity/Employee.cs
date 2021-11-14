using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entity
{
    /// <summary>
    /// Class nhân viên
    /// </summary>
    /// CreatedBy : DDHung (3/11/2021)
    public class Employee : BaseEntity
    {
        #region Property
        /// <summary>
        /// Id của nhân viên (khóa chính)
        /// </summary>
        [PrimaryKey]
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [CheckDuplicate]
        [DisplayName("Mã nhân viên")]
        [Required]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Họ và tên nhân viên
        /// </summary>
        [DisplayName("Họ và tên")]
        [Required]
        public string FullName { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Required]
        [DisplayName("Số điện thoại")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [DisplayName("Email")]
        [ValidEmail]
        public string Email { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string  Address { get; set; }

        /// <summary>
        /// Số chứng minh thư
        /// </summary>
        [Required]
        [DisplayName("Chứng minh thư")]
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp
        /// </summary>
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Ngày gia nhập công ty
        /// </summary>
        public DateTime? JoinDate { get; set; }

        /// <summary>
        /// Id phòng ban
        /// </summary>
        public Guid? DepartmentId { get; set; }

        /// <summary>
        /// Id vị trí công việc
        /// </summary>
        public Guid? PositionId { get; set; }

        /// <summary>
        /// Tình trạng công việc
        /// </summary>
        public int? WorkStatus { get; set; }

        /// <summary>
        /// Mã số thuế cá nhân
        /// </summary>
        public string PersonalTaxCode { get; set; }

        /// <summary>
        /// Lương
        /// </summary>
        public double? Salary { get; set; }

        /// <summary>
        /// Nơi cấp
        /// </summary>
        public string IdentityPlace { get; set; }
        #endregion
    }
}

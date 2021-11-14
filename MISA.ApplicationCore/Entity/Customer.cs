using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entity
{
    /// <summary>
    /// Khách hàng
    /// </summary>
    /// CreatedBy : DDHung (3/11/2021)
    public class Customer : BaseEntity
    {
        #region properties
        /// <summary>
        /// Khóa chính
        /// </summary>
        /// 
        [PrimaryKey]
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        [CheckDuplicate]
        [MaxLength(20 , "Mã khách hàng đã vượt quá 20 ký tự cho phép")]
        [DisplayName("Mã khách hàng")]
        [Required]
        public string CustomerCode { get; set; }
        /// <summary>
        /// Họ và tên           
        /// </summary>  
        [DisplayName("Họ và tên")]
        public string FullName { get; set; }
        /// <summary>
        /// Mã thẻ thành viên
        /// </summary>
        public string MemberCardCode { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Tên công ty
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Mã số thuế công ty
        /// </summary>
        public string CompanyTaxCode { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Mã nhóm khách hàng
        /// </summary>
        public Guid? CustomerGroupId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Số tiền nợ
        /// </summary>
        public double DebitAmount { get; set; }


        #endregion
    }
}

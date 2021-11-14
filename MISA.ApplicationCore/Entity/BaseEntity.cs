using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entity
{

    /// <summary>
    /// Attribute bắt buộc nhập ( không được để trống )
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class Required:Attribute
    {
    }

    /// <summary>
    /// Attribute dùng để kiểm tra trùng lặp dữ liệu
    /// </summary>

    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate : Attribute
    {
    }

    /// <summary>
    /// Attribute dùng để đánh dấu là khóa chính
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey : Attribute
    {
    }

    /// <summary>
    /// Attribute kiểm tra độ dài tối đa có thể nhập
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength : Attribute
    {
        public int Value { get; set; }
        public string ErrorMsg { get; set; }
        public MaxLength(int length , string errorMsg)
        {
            this.Value = length;
            this.ErrorMsg = errorMsg;
        }
    }

    /// <summary>
    /// Attribute mô tả tên trường
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DisplayName : Attribute
    {
        public string PropertyName { get; set; }
        public DisplayName(string propertyName)
        {
            this.PropertyName = propertyName;
        }
    }

    /// <summary>
    /// Attribute dùng để check email hợp lệ hay không
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ValidEmail : Attribute
    {
    }
    public class BaseEntity
    {
        #region Property
        /// <summary>
        /// Dùng để đánh dấu phục vụ cho việc thêm , sửa , xóa
        /// Thêm - 1
        /// Sửa - 2
        /// Xóa - 3
        /// </summary>
        public EntityState EntityState { get; set; } = EntityState.AddNew;

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }   

        /// <summary>
        /// Được tạo bởi
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày sửa đổi
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Được Sửa đổi bởi
        /// </summary>
        public string ModifiedBy { get; set; }
        #endregion
    }

}

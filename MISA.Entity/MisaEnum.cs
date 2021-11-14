using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Entity
{
    /// <summary>
    /// Misa code để xác định trạng thái của việc validate
    /// </summary>
    public enum MisaEnum
    {
        /// <summary>
        /// Dữ liệu hợp lệ
        /// </summary>
        IsValid = 100,
        /// <summary>
        /// Dự liệu không hợp lệ
        /// </summary>
        NotValid = 900,
        /// <summary>
        /// Thành công
        /// </summary>
        Success = 200
    }

}

using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interface
{
    /// <summary>
    /// Interface chứa các phương thức dùng chung
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseService<TEntity>
    {
        /// <summary>
        /// Lấy danh sách dữ liệu
        /// </summary>
        /// <returns>Danh sách dữ liệu</returns>
        /// CreatedBy : DDHung(9/11/2021)
        IEnumerable<TEntity> GetEntities();

        /// <summary>
        /// Tìm kiếm bản ghi theo Id
        /// </summary>
        /// <param name="entityId">Id của bản ghi</param>
        /// <returns>Bản ghi đầu tiên được tìm thấy theo Id</returns>
        /// CreatedBy : DDHung(9/11/2021)
        TEntity GetEntityById(string entityId);

        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần thêm</param>
        /// <returns>Kết quả sau khi thêm mới</returns>
        /// CreatedBy : DDHung(9/11/2021)
        ServiceResult AddEntity(TEntity entity);

        /// <summary>
        /// Cập nhật một bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần cập nhật</param>
        /// <returns>Kết quả sau khi cập nhật</returns>
        /// CreatedBy : DDHung(9/11/2021)
        ServiceResult UpdateEntity(TEntity entity);

        /// <summary>
        /// Xóa một bản ghi
        /// </summary>
        /// <param name="entityId">Id bản ghi cần xóa</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy : DDHung(9/11/2021)
        int DeleteEntity(string entityId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interface
{
    public interface IBaseRepository<TEntity>
    {
        /// <summary>
        /// Lấy danh sách dữ liệu
        /// </summary>
        /// <returns>Danh sách dữ liệu</returns>
        /// CreatedBy : DDHung (9/11/2021)
        IEnumerable<TEntity> GetEntities();

        /// <summary>
        /// Tìm kiếm bản ghi theo Id
        /// </summary>
        /// <param name="entityId">Id bản ghi cần tìm kiếm</param>
        /// <returns>Bản ghi đầu tiên được tìm thấy theo Id</returns>
        ///  CreatedBy : DDHung (9/11/2021)
        TEntity GetEntityById(string entityId);

        /// <summary>
        /// Thêm một bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần thêm</param>
        /// <returns>Số lượng bản ghi bị ảnh hưởng</returns>
        ///  CreatedBy : DDHung (9/11/2021)
        int AddEntity(TEntity entity);

        /// <summary>
        /// Cập nhật một bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần cập nhật</param>
        /// <returns>Số lượng bản ghi bị ảnh hưởng</returns>
        ///  CreatedBy : DDHung (9/11/2021)
        int UpdateEntity(TEntity entity);

        /// <summary>
        /// Xóa một bản ghi
        /// </summary>
        /// <param name="entityId">Id của bản ghi cần xóa</param>
        /// <returns>Số lượng bản ghi bị ảnh hưởng</returns>
        ///  CreatedBy : DDHung (9/11/2021)
        int DeleteEntity(string entityId);
        //TEntity GetEntityByCode(string entityCode);

        /// <summary>
        /// Lấy bản ghi dựa vào thuộc tính (Property)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="property">Thông tin thuộc tính</param>
        /// <returns>Trả về 1 bản ghi đầu tiên được tìm thấy</returns>
        ///  CreatedBy : DDHung (9/11/2021)
        TEntity GetEntityByProperty(TEntity entity, PropertyInfo property);
    }
}

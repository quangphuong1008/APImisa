using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        #region Declare
        /// <summary>
        /// Repository của phần base thực việc kết nối dữ liệu xuống database phục vụ cho việc xử lý các yêu cầu dùng chung
        /// </summary>
        IBaseRepository<TEntity> _baseRepository;

        /// <summary>
        /// Kết quả thống báo trả về chuẩn Resfull API
        /// </summary>
        protected ServiceResult _serviceResult;
        #endregion

        #region Constructor
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult() { MisaCode = MisaEnum.Success };
        }
        #endregion

        #region Method
        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần thêm</param>
        /// <returns>Trả về thông báo kết quả sau khi thêm mới</returns>
        /// CreatedBy : DDHung(9/11/2021)
        public virtual ServiceResult AddEntity(TEntity entity)
        {
            entity.EntityState = EntityState.AddNew;
            //Thực hiện validate
            var isValidate = Validate(entity);
            if (isValidate == true)
            {
                _serviceResult.Data = _baseRepository.AddEntity(entity);
                _serviceResult.MisaCode = MisaEnum.IsValid;
                return _serviceResult;
            }
            else
            {
                return _serviceResult;
            }
        }

        /// <summary>
        /// Xóa một bản ghi
        /// </summary>
        /// <param name="entityId">Id bản ghi cần xóa</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy : DDHung(9/11/2021)
        public int DeleteEntity(string entityId)
        {
            return _baseRepository.DeleteEntity(entityId);
        }

        /// <summary>
        /// Lấy danh sách dữ liệu
        /// </summary>
        /// <returns>Danh sách dữ liệu</returns>
        /// CreatedBy : DDHung(9/11/2021)
        public IEnumerable<TEntity> GetEntities()
        {
            var entities = _baseRepository.GetEntities();
            return entities;
        }

        /// <summary>
        /// Tìm kiếm bản ghi theo Id
        /// </summary>
        /// <param name="entityId">Id của bản ghi cần tìm</param>
        /// <returns></returns>
        public TEntity GetEntityById(string entityId)
        {
            var entity = _baseRepository.GetEntityById(entityId);
            return entity;
        }

        /// <summary>
        /// Cập nhật một bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần cập nhật</param>
        /// <returns>Trả về thông báo kết quả sau khi cập nhật</returns>
        /// CreatedBy : DDHung(9/11/2021)
        public virtual ServiceResult UpdateEntity(TEntity entity)
        {
            entity.EntityState = EntityState.Update;

            //Thực hiện validate
            var isValidate = Validate(entity);
            if (isValidate == true)
            {
                _serviceResult.Data = _baseRepository.UpdateEntity(entity);
                _serviceResult.MisaCode = MisaEnum.IsValid;
                return _serviceResult;
            }
            else
            {
                return _serviceResult;
            }
        }

        /// <summary>
        /// Thực hiện validate dữ liệu trước khi thêm hoặc sửa bản ghi
        /// </summary>
        /// <param name="entity">Dữ liệu cần validate</param>
        /// <returns>True - dữ liệu hợp lệ , false - dữ liệu không hợp lệ</returns>
        private bool Validate(TEntity entity)
        {
            var messArrayError = new List<string>();
            var isValidate = true;
            //Đọc các Property : 
            var properties = entity.GetType().GetProperties();

            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(entity);
                //var displayName = property.GetCustomAttributes(typeof(DisplayName), true);
                var displayName = string.Empty;
                var displayNameAttributes = property.GetCustomAttributes(typeof(DisplayName), true);
                if (displayNameAttributes.Length > 0)
                {
                    displayName = (displayNameAttributes[0] as DisplayName).PropertyName;
                }
                //Kiểm tra xem có attribute cần phải validate không : 
                if (property.IsDefined(typeof(Required), false))
                {
                    //Check bắt buộc nhập

                    if (propertyValue == null)
                    {
                        isValidate = false;

                        messArrayError.Add(String.Format(Properties.Resources.Msg_Empty, displayName));
                        _serviceResult.MisaCode = MisaEnum.NotValid;
                        _serviceResult.Messeger = Properties.Resources.Msg_IsNotValid;

                    }
                }
                if (property.IsDefined(typeof(CheckDuplicate), false))
                {
                    //Check trùng dữ liệu
                    var entityDuplicate = _baseRepository.GetEntityByProperty(entity, property);
                    if (entityDuplicate != null)
                    {
                        isValidate = false;
                        messArrayError.Add(string.Format(Properties.Resources.Msg_Duplicate, displayName));
                        _serviceResult.MisaCode = MisaEnum.NotValid;
                        _serviceResult.Messeger = Properties.Resources.Msg_IsNotValid;
                    }
                }
                if (property.IsDefined(typeof(MaxLength), false))
                {
                    //Lấy độ dài đã khai báo
                    var attributeMaxLength = property.GetCustomAttributes(typeof(MaxLength), true)[0];
                    var length = (attributeMaxLength as MaxLength).Value;
                    var msg = (attributeMaxLength as MaxLength).ErrorMsg;
                    if (propertyValue.ToString().Trim().Length > length)
                    {
                        isValidate = false;
                    }
                }
            }
            _serviceResult.Data = messArrayError;
            if (isValidate == true)
                isValidate = ValidateCustom(entity);
            return isValidate;
        }

        /// <summary>
        /// Thực hiện kiểm tra dữ liệu/nghiệp vụ tùy chỉnh
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>True - dữ liệu hợp lệ,  false - dữ liệu không hợp lệ</returns>
        public virtual bool ValidateCustom(TEntity entity)
        {
            return true;
        }
        #endregion
    }
}

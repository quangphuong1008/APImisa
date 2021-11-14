
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entity
{
    /// <summary>
    /// Kết quả thống báo trả về chuẩn Resfull API
    /// </summary>
    public class ServiceResult
    {
        public object Data { get; set; }
        public string Messeger { get; set; }
        public MisaEnum MisaCode { get; set; }
    }
}

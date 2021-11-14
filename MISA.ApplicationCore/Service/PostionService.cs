using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore
{
    public class PostionService : BaseService<Position>,IPositionService
    {
        IPositionRepository _positionRepository;
        public PostionService(IPositionRepository positionRepository) : base(positionRepository)
        {
            _positionRepository = positionRepository;
        }
    }
}

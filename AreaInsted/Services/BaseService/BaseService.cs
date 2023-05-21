using AreaInsted.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaInsted.Services.BaseService
{
    public abstract class BaseService<TDto, TDom>
        where TDom : class
        where TDto : class
    {
        protected BaseMapper<TDto, TDom> mapper;

        public BaseService()
        { }

        public virtual List<TDto> List(int skip, int take)
        {
            throw new NotImplementedException("implement your code here");
        }

        public virtual TDto Select(int id)
        {
            throw new NotImplementedException("implement your code here");
        }

        public virtual TDto Create(TDto obj)
        {
            throw new NotImplementedException("implement your code here");
        }

        public virtual TDto Update(TDto obj)
        {
            throw new NotImplementedException("implement your code here");
        }

        public virtual TDto Delete(TDto dto)
        {
            throw new NotImplementedException("implement your code here");
        }

        public virtual TDto Delete(int id)
        {
            throw new NotImplementedException("implement your code here");
        }

        protected virtual List<TDto> ProcessListDom(List<TDom> listDom)
        {
            throw new NotImplementedException("implement your code here");
        }
    }
}

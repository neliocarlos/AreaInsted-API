using AutoMapper;

namespace AreaInsted.Mapper
{
    public class BaseMapper<TDto, TDom>
        where TDom : class where TDto : class
    {
        private IMapper mapper;

        public IMapper Mapper
        {
            get
            {
                if(this.mapper == null)
                {
                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<TDom, TDto>();
                        cfg.CreateMap<TDto, TDom>();
                    });
                    this.mapper = configuration.CreateMapper();
                }
                return this.mapper;
            }
        }
        public BaseMapper()
        { }
    }
}

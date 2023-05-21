using AreaInsted.Database;
using AreaInsted.Models;
using AreaInsted.Repository;
using AreaInsted.Services.BaseService;

namespace AreaInsted.Services
{
    public class UserClassService : BaseService<UserClassDto, TbUserClass>
    {
        private UserClassRepository repository;

        public UserClassService() : base()
        {
            this.mapper = new Mapper.BaseMapper<UserClassDto, TbUserClass>();
            this.repository = new UserClassRepository(new AreaInstedContext());
        }

        public UserClassService(AreaInstedContext context) : base()
        {
            this.mapper = new Mapper.BaseMapper<UserClassDto, TbUserClass>();
            this.repository = new UserClassRepository(context);
        }

        public override UserClassDto Create(UserClassDto obj)
        {
            TbUserClass userClass = this.mapper.Mapper.Map<TbUserClass>(obj);
            TbUserClass created = this.repository.Create(userClass);
            UserClassDto dto = this.mapper.Mapper.Map<UserClassDto>(created);
            return dto;
        }

        public override UserClassDto Delete(int id)
        {
            TbUserClass userClass = this.repository.DeleteById(id);
            UserClassDto dto = this.mapper.Mapper.Map<UserClassDto>(userClass);
            return dto;
        }

        public override UserClassDto Delete(UserClassDto dto)
        {
            return this.Delete(dto.IdUserClass);
        }

        public override List<UserClassDto> List(int skip, int take)
        {
            List<TbUserClass> listUserClass = this.repository.Read(skip, take).ToList();
            return ProcessListDom(listUserClass);
        }

        public override UserClassDto Select(int id)
        {
            TbUserClass userClass = this.repository.Read(id);
            UserClassDto dto = this.mapper.Mapper.Map<UserClassDto>(userClass);
            return dto;
        }

        public override UserClassDto Update(UserClassDto obj)
        {
            TbUserClass userClass = this.mapper.Mapper.Map<TbUserClass>(obj);
            TbUserClass updated = this.repository.Update(userClass);
            UserClassDto dto = this.mapper.Mapper.Map<UserClassDto>(updated);
            return dto;
        }

        protected override List<UserClassDto> ProcessListDom(List<TbUserClass> listDom)
        {
            return listDom.Select(dom => this.mapper.Mapper.Map<UserClassDto>(dom)).ToList();
        }
    }
}

using AreaInsted.Database;
using AreaInsted.Models;
using AreaInsted.Repository;
using AreaInsted.Services.BaseService;

namespace AreaInsted.Services
{
    public class UserService : BaseService<UserDto, TbUser>
    {
        private UserRepository repository;

        public UserService() : base()
        {
            this.mapper = new Mapper.BaseMapper<UserDto, TbUser>();
            this.repository = new UserRepository(new AreaInstedContext());
        }

        public UserService(AreaInstedContext context) : base()
        {
            this.mapper = new Mapper.BaseMapper<UserDto, TbUser>();
            this.repository = new UserRepository(context);
        }

        public override UserDto Create(UserDto obj)
        {
            TbUser user = this.mapper.Mapper.Map<TbUser>(obj);
            TbUser created = this.repository.Create(user);
            UserDto dto = this.mapper.Mapper.Map<UserDto>(created);
            return dto;
        }

        public override UserDto Delete(int id)
        {
            TbUser user = this.repository.DeleteById(id);
            UserDto dto = this.mapper.Mapper.Map<UserDto>(user);
            return dto;
        }

        public override UserDto Delete(UserDto dto)
        {
            return this.Delete(dto.IdUser);
        }

        public override List<UserDto> List(int skip, int take)
        {
            List<TbUser> listUsers = this.repository.Read(skip, take).ToList();
            return ProcessListDom(listUsers);
        }

        public override UserDto Select(int id)
        {
            TbUser user = this.repository.Read(id);
            UserDto dto = this.mapper.Mapper.Map<UserDto>(user);
            return dto;
        }

        public override UserDto Update(UserDto obj)
        {
            TbUser user = this.mapper.Mapper.Map<TbUser>(obj);
            TbUser updated = this.repository.Update(user);
            UserDto dto = this.mapper.Mapper.Map<UserDto>(updated);
            return dto;
        }

        protected override List<UserDto> ProcessListDom(List<TbUser> listDom)
        {
            return listDom.Select(dom => this.mapper.Mapper.Map<UserDto>(dom)).ToList();
        }
    }
}

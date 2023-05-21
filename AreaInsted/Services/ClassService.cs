using AreaInsted.Database;
using AreaInsted.Models;
using AreaInsted.Repository;
using AreaInsted.Services.BaseService;

namespace AreaInsted.Services
{
    public class ClassService : BaseService<ClassDto, TbClass>
    {
        private ClassRepository repository;

        public ClassService() : base()
        {
            this.mapper = new Mapper.BaseMapper<ClassDto, TbClass>();
            this.repository = new ClassRepository(new AreaInstedContext());
        }

        public ClassService(AreaInstedContext context) : base()
        {
            this.mapper = new Mapper.BaseMapper<ClassDto, TbClass>();
            this.repository = new ClassRepository(context);
        }

        public override ClassDto Create(ClassDto obj)
        {
            TbClass dom = this.mapper.Mapper.Map<TbClass>(obj);
            TbClass created = this.repository.Create(dom);
            ClassDto dto = this.mapper.Mapper.Map<ClassDto>(created);
            return dto;
        }

        public override ClassDto Delete(int id)
        {
            TbClass dom = this.repository.DeleteById(id);
            ClassDto dto = this.mapper.Mapper.Map<ClassDto>(dom);
            return dto;
        }

        public override ClassDto Delete(ClassDto dto)
        {
            return this.Delete(dto.IdClass);
        }

        public override List<ClassDto> List(int skip, int take)
        {
            List<TbClass> listClasses = this.repository.Read(skip, take).ToList();
            return ProcessListDom(listClasses);
        }

        public override ClassDto Select(int id)
        {
            TbClass dom = this.repository.Read(id);
            ClassDto dto = this.mapper.Mapper.Map<ClassDto>(dom);
            return dto;
        }

        public override ClassDto Update(ClassDto obj)
        {
            TbClass dom = this.mapper.Mapper.Map<TbClass>(obj);
            TbClass updated = this.repository.Update(dom);
            ClassDto dto = this.mapper.Mapper.Map<ClassDto>(updated);
            return dto;
        }

        protected override List<ClassDto> ProcessListDom(List<TbClass> listDom)
        {
            return listDom.Select(dom => this.mapper.Mapper.Map<ClassDto>(dom)).ToList();
        }
    }
}

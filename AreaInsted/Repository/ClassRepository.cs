using AreaInsted.Database;
using AreaInsted.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace AreaInsted.Repository
{
    public class ClassRepository : BaseRepository<TbClass>
    {
        public ClassRepository(DbContext context) : base(context)
        {
        }

        public override TbClass Read(int id) => this.context.Set<TbClass>().Find(id);

        public override TbClass DeleteById(int id)
        {
            TbClass lesson = this.Read(id);
            this.context.Set<TbClass>().Remove(lesson);
            this.context.SaveChanges();
            return lesson;
        }
    }
}

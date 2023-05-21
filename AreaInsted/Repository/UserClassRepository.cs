using AreaInsted.Database;
using AreaInsted.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace AreaInsted.Repository
{
    public class UserClassRepository : BaseRepository<TbUserClass>
    {
        public UserClassRepository(DbContext context) : base(context)
        {
        }

        public override TbUserClass Read(int id) => this.context.Set<TbUserClass>().Find(id);

        public override TbUserClass DeleteById(int id)
        {
            TbUserClass user = this.Read(id);
            this.context.Set<TbUserClass>().Remove(user);
            this.context.SaveChanges();
            return user;
        }
    }
}

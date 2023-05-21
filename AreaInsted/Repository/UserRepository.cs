using AreaInsted.Database;
using AreaInsted.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace AreaInsted.Repository
{
    public class UserRepository : BaseRepository<TbUser>
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public override TbUser Read(int id) => this.context.Set<TbUser>().Find(id);

        public override TbUser DeleteById(int id)
        {
            TbUser user = this.Read(id);
            this.context.Set<TbUser>().Remove(user);
            this.context.SaveChanges();
            return user;
        }
    }
}

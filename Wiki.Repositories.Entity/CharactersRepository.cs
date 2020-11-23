using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Business;
using Wiki.Data.Entity.Context;
using Wiki.Repositories.Common.Entity;
using System.Data.Entity;

namespace Wiki.Repositories.Entity
{
    public class CharactersRepository : BaseRepository<Character, int>
    {
        public CharactersRepository(WikiDbContext dbContext) : base(dbContext)
        {

        }

        public override List<Character> List()
        {
            return _dbContext.Set<Character>().Include(a => a.Type).ToList();
        }

        public override Character Find(int id)
        {
            return _dbContext.Set<Character>().Include(f => f.Type).SingleOrDefault(a => a.Id == id);
        }
    }
}

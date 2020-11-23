using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Data.Entity.Context;
using Wiki.Repositories.Common.Entity;
using System.Data.Entity;
using Wiki.Business;

namespace Wiki.Repositories.Entity
{
    public class CharacterTypesRepository : BaseRepository<CharacterType, int>
    {
        public CharacterTypesRepository(WikiDbContext dbContext) : base(dbContext)
        {
        }

        public override List<CharacterType> List()
        {
            return _dbContext.Set<CharacterType>().Include(f => f.Characters).ToList();
        }

        public override CharacterType Find(int id)
        {
            return _dbContext.Set<CharacterType>().Include(f => f.Characters).SingleOrDefault(f => f.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVPrograms.Core.Domain.Model;

namespace TVPrograms.Core.Domain.Repository
{
    public interface IProgramRepository : IRepository<Program>
    {
        IList<object[]> SeasonReport(int id);
    }
}

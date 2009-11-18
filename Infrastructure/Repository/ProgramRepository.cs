using System.Collections.Generic;
using System.Linq;
using TVPrograms.Core.Domain.Model;
using TVPrograms.Core.Domain.Repository;
using NHibernate;
using NHibernate.Criterion;

namespace TVPrograms.Infrastructure.Repository
{
    public class ProgramRepository : RepositoryBase<Program>, IProgramRepository
    {
        public IList<object[]> SeasonReport(int programid)
        {
            ISession session = GetSession();
            string sql = "SELECT dtDATA.SeasonNumber AS SeasonNumber, dtData.ProgramName AS ProgramName, SUM(dtData.Weight)/SUM(dtDATA.Duration) AS Rating " +
            "FROM (SELECT Programs.ProgramName, Seasons.SeasonNumber, HHLD_Proj * Duration as Weight, Duration " +
            "FROM Programs INNER JOIN Seasons ON Programs.id = Seasons.Program_id " + 
            "INNER JOIN Episodes ON Seasons.id = Episodes.Season_id " +
            "WHERE Programs.ID = :programid) as dtDATA " +
            "GROUP BY dtData.ProgramName, dtDATA.SeasonNumber ORDER BY dtDATA.SeasonNumber DESC";
            IQuery query = session.CreateSQLQuery(sql)
                .AddScalar("SeasonNumber", NHibernateUtil.Int64)
                .AddScalar("ProgramName", NHibernateUtil.String)
                .AddScalar("Rating", NHibernateUtil.Int64);
            query.SetInt32("programid", programid);
            IList<object[]> list = query.List<object[]>();
            return list;
        }
    }
}

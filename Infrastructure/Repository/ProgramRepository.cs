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
            string sql = "SELECT dtDATA.SeasonNumber, dtData.StartDate, dtData.EndDate, Count(dtData.EpisodeID) as EpisodeCount, SUM(dtData.Weight)/SUM(dtDATA.Duration) AS Rating " +
            "FROM (SELECT Seasons.SeasonNumber, Seasons.StartDate, Seasons.EndDate, Episodes.id as EpisodeID, HHLD_Proj * Duration as Weight, Duration " +
            "FROM Programs INNER JOIN Seasons ON Programs.id = Seasons.Program_id " + 
            "INNER JOIN Episodes ON Seasons.id = Episodes.Season_id " +
            "WHERE Programs.ID = :programid) as dtDATA " +
            "GROUP BY dtDATA.SeasonNumber, dtData.StartDate, dtData.EndDate ORDER BY dtDATA.SeasonNumber DESC";
            IQuery query = session.CreateSQLQuery(sql)
                .AddScalar("SeasonNumber", NHibernateUtil.Int64)
                .AddScalar("StartDate", NHibernateUtil.Date)
                .AddScalar("EndDate", NHibernateUtil.Date)
                .AddScalar("EpisodeCount", NHibernateUtil.Int64)
                .AddScalar("Rating", NHibernateUtil.Int64);
            query.SetInt32("programid", programid);
            IList<object[]> list = query.List<object[]>();
            return list;
        }
    }
}

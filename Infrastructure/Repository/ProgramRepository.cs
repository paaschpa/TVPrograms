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

        /* Why NHibernate you remembered I was using SQL Server and let me use some T-SQL?  You are a naughty
         * little ORM are't you?  I'm sure you wouldn't do the same for MySQL or Oracle would you or other less
         * handsome people using MySQL or Oracle.
         */

        public IList<object[]> SeasonReport(int programid, string sidx, string sord)
        {
            ISession session = GetSession();
            string sql = "SELECT dtDATA.SeasonNumber, Convert(CHAR(10),dtData.StartDate,101) as StartDate, CONVERT(CHAR(10), dtData.EndDate, 101) as EndDate, Count(dtData.EpisodeID) as EpisodeCount, SUM(dtData.Weight)/SUM(dtDATA.Duration) AS Rating " +
            "FROM (SELECT Seasons.SeasonNumber, Seasons.StartDate, Seasons.EndDate, Episodes.id as EpisodeID, HHLD_Proj * Duration as Weight, Duration " +
            "FROM Programs INNER JOIN Seasons ON Programs.id = Seasons.Program_id " + 
            "INNER JOIN Episodes ON Seasons.id = Episodes.Season_id " +
            "WHERE Programs.ID = :programid) as dtDATA " +
            "GROUP BY dtDATA.SeasonNumber, dtData.StartDate, dtData.EndDate ";
            string sortparameter = BuildSortString(sidx, sord);
            sql += sortparameter;
            IQuery query = session.CreateSQLQuery(sql)
                .AddScalar("SeasonNumber", NHibernateUtil.Int64)
                .AddScalar("StartDate", NHibernateUtil.String)
                .AddScalar("EndDate", NHibernateUtil.String)
                .AddScalar("EpisodeCount", NHibernateUtil.Int64)
                .AddScalar("Rating", NHibernateUtil.Int64);
            query.SetInt32("programid", programid);
            IList<object[]> list = query.List<object[]>();
            return list;
        }

        public string BuildSortString(string sidx, string sord)
        {
            if (sidx != "" && sidx != null)
                return "ORDER BY dtDATA." + sidx + " " + sord;

            return ""; 
        }
    }
}

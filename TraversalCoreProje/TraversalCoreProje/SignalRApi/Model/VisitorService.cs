using Microsoft.AspNetCore.SignalR; // IHubContext interface'ni kullanabilmek için ekledik
using Microsoft.EntityFrameworkCore;
using SignalRApi.DAL; // SignalR'deki context sınıfını kullanmak için ekledik
using SignalRApi.Hubs; // VisitorHub sınıfını kullanmak için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApi.Model
{
    public class VisitorService
    {
        private readonly Context _context;
        private readonly IHubContext<VisitorHub> _hubContext;

        public VisitorService(Context context, IHubContext<VisitorHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        public IQueryable<VisitorCity> Getlist()
        {
            return _context.VisitorCities.AsQueryable();
        }
        public async Task SaveVisitor(VisitorCity visitor)
        {
            await _context.VisitorCities.AddAsync(visitor);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("ReceiveVisitorList", GetVisitorChartList());
        }
        public List<VisitorChart> GetVisitorChartList()
        {
            List<VisitorChart> visitorCharts = new List<VisitorChart>();
            using (var command=_context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "select tarih,[1],[2],[3],[4],[5] from(select[City], CityVisitCount, cast([VisitDate] as Date) as tarih from VisitorCities)" +
                    " as visitTable Pivot(Sum(CityVisitCount) for City in([1],[2],[3],[4],[5])) as pivottable order by tarih asc";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using(var reader=command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        VisitorChart visitorChart = new VisitorChart();
                        visitorChart.VisitDate = reader.GetDateTime(0).ToShortDateString();
                        /* burada enum oluşturuken 6 eleman ekledik o yüzden başlangıç 1 bitiş 6 şeklinde ayarladık*/
                        Enumerable.Range(1, 5).ToList().ForEach(x =>
                        {
                            if(DBNull.Value.Equals(reader[x]))
                            {
                                visitorChart.Counts.Add(0);
                            }
                            else
                            {
                                visitorChart.Counts.Add(reader.GetInt32(x));
                            }
                            
                        });
                        visitorCharts.Add(visitorChart);
                    }
                }
                _context.Database.CloseConnection();
                return visitorCharts;
            }
        }
    }
}

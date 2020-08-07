using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            var endDate = startDate;
            if (weekEnds == null)
            {
                endDate = endDate.AddDays(dayCount - 1);
            }
            else
            {
                endDate = WithWeekends(startDate, dayCount, weekEnds);
            }
            return endDate;
        }

        private DateTime WithWeekends(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            var endDate = startDate;
            int i = 0;

            foreach (WeekEnd weekEnd in weekEnds)
            {
                if (endDate < weekEnd.StartDate)
                {
                    break;
                }
                i++;
            }

            for (int j=0; j <= dayCount; j++)
            {
                if (endDate == weekEnds[i]?.StartDate)
                {
                    endDate = weekEnds[i].EndDate;
                    i = i == weekEnds.Length ? i : i++;
                }
                else
                {
                    endDate = endDate.AddDays(1);
                }
            }
            return endDate;
        }
    }
}

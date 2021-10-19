using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Services
{
    class DateTimeService : IDateTimeService
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}

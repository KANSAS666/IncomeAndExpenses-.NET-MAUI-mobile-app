using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace IncomeAndExpenses.Models
{
    public class Record
    {
        [PrimaryKey]
        public int Id_Record { get; set; }

        public DateTime Date { get; set; }
        public double Sum { get; set; }
        public string Operation { get; set; }
        public string Category { get; set; }
    }
}

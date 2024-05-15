using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace IncomeAndExpenses.Models
{
    public class Category
    {
        [PrimaryKey]
        public int Id_Category { get; set; }

        public string CategoryName { get; set; } = string.Empty;
        public string CategoryOperation { get; set; } = string.Empty;
    }
}

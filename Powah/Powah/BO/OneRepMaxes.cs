using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Powah.BO
{
    [Table("OneRepMaxes")]
    public class OneRepMaxes
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Excercise { get; set; }
        public int Weight { get; set; }
    }
}

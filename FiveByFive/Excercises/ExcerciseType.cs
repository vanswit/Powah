using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Powah.Programs.Excercises
{
    [Table("ExcerciseType")]
    public class ExcerciseType
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Type { get; set; }
    }
}

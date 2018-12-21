using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Powah.Programs.Excercises
{
    [Table("Excercise")]
    public class DeadLift : IExercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(ExcerciseType))]
        public int ExerciseType { get; set; }
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Powah.Programs.Excercises
{
    interface IExercise
    {
        int Id { get; set; }
        int ExerciseType { get; set; }
        string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    /*In the RankedGradeBook class create an override for the GetLetterGrade method.

The GetLetterGrade method returns a char and accepts a double named "averageGrade".

If there are less than 5 students throw an InvalidOperationException. (Ranked-grading requires a minimum of 5 students
to work)

Return 'F' at the end of the method.*/

    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            var studentsCount = Students.Count;
            if (studentsCount < 5)
            {
                throw new InvalidOperationException("not enough students to calculate grade");
            }

            var gradeThreshold = (int)Math.Ceiling(studentsCount * 0.2);

            var sortedGrades = Students.OrderByDescending(s => s.AverageGrade).Select(g => g.AverageGrade).ToArray();

            if (sortedGrades[gradeThreshold - 1] <= averageGrade)
            {
                return 'A';
            }

            if (sortedGrades[2 * gradeThreshold - 1] <= averageGrade)
            {
                return 'B';
            }

            if (sortedGrades[3 * gradeThreshold - 1] <= averageGrade)
            {
                return 'C';
            }

            if (sortedGrades[4 * gradeThreshold - 1] <= averageGrade)
            {
                return 'D';
            }

            return 'F';


            return 'F';
        }
    }

}

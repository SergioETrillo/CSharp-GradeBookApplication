using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("not enough students to calculate grade");
            }

            var gradeThreshold = (int)Math.Ceiling(Students.Count * 0.2);

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
        }

        /*Create an override for the CalculateStatistics method in the RankedGradeBook class.

If there are less than 5 students write "Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade." to the Console, then return from the method.

In there were 5 or more students continue call the base class' method using base.CalculateStatistics();.
Error

GradeBook.GradeBooks.RankedGradeBook.CalculateStastics did not run the base CalculateStatistics when there was 5 or more students.*/

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");

                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");

                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}

using ABC.CarTraders.GUI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC.CarTraders
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DashboardForm());


            //temp

            //using (var unitOfWork = new UnitOfWork(new PlutoContext()))
            //{
            //    // Example1
            //    var course = unitOfWork.Courses.Get(1);

            //    // Example2
            //    var courses = unitOfWork.Courses.GetCoursesWithAuthors(1, 4);

            //    // Example3
            //    var author = unitOfWork.Authors.GetAuthorWithCourses(1);
            //    unitOfWork.Courses.RemoveRange(author.Courses);
            //    unitOfWork.Authors.Remove(author);
            //    unitOfWork.Complete();
            //}
        }

        public static string Version { get { return Application.ProductVersion; } }
    }
}

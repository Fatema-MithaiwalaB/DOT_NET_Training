using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Day_2
{
    public class ExamSystem
    {
        static ExamSystem()
        {
            Console.WriteLine("LINQ Task 2 ");
            Console.WriteLine("\n...............................................................................................................\n");
        }

        public void ExamSystemQueries()
        {

            List<Student> students = new List<Student>
        {
            new Student(1, "Alice", "CS"),
            new Student(2, "Bob", "IT"),
            new Student(3, "Charlie", "CS"),
            new Student(4, "David", "Math")
        };

            List<Exam> exams = new List<Exam>
        {
            new Exam(101, 1, "Math", 85),
            new Exam(102, 1, "Physics", 78),
            new Exam(103, 2, "Math", 92),
            new Exam(104, 3, "CS", 88)
        };

            // use of list after Query 9
            List<Exam> exams2 = new List<Exam>
        {
            new Exam(201, 4, "Biology", 80),
            new Exam(202, 5, "Physics", 76),   // Duplicate Subject
            new Exam(203, 6, "History", 89),
            new Exam(204, 2, "Math", 90)        // Duplicate Subject
        };

            Console.WriteLine("\r\nWrite LINQ Queries (Using Method & Query syntax) to Solve the Following:\r\n");

            //Displaying Data from both tables
            //1
            Console.WriteLine("\n...............................................................................................................\n");
            Console.WriteLine("Displaying Data From Both Tables:");

            //Method Syntax
            Console.WriteLine("\n Student Table:");

            foreach (Student student in students)
            {
                Console.WriteLine($"StudentID : {student.StudentId} \tName : {student.Name} \tCourse : {student.Course}");
            }

            //Query Syntax
            Console.WriteLine("\n Exam Table:");

            foreach (Exam exam in exams)
            {
                Console.WriteLine($"ExamID : {exam.ExamId} \tStudentID : {exam.StudentId} \tMarks : {exam.Marks} \tSubject : {exam.Subject}");
            }

            //1 Inner Join
            Console.WriteLine("\n...............................................................................................................\n");
            Console.WriteLine("1. Write a LINQ query to fetch the StudentId, Student Name, ExamId, Subject, and Marks using an inner join.\r\n");

            //Method Syntax
            Console.WriteLine("\n Method Syntax:");
            var StudentExamResultMethod = students.Join(exams, stud => stud.StudentId, exam => exam.StudentId, (stud, exam) => new
            {
                Studentid = stud.StudentId,
                Studentname = stud.Name,
                Examid = exam.ExamId,
                Subject = exam.Subject,
                Mark = exam.Marks
            });

            foreach(var x in StudentExamResultMethod)
            {
                Console.WriteLine(x);
            }

            //Query Syntax
            Console.WriteLine("\n Query Syntax:");
            var StudentExamResultQuery = (from stud in students
                                          join exam in exams
                                          on stud.StudentId equals exam.StudentId
                                          select new
                                          {
                                              Studentid = stud.StudentId,
                                              Studentname = stud.Name,
                                              Examid = exam.ExamId,
                                              Subject = exam.Subject,
                                              Mark = exam.Marks
                                          });
            foreach (var x in StudentExamResultQuery)
            {
                Console.WriteLine(x);
            }

            //2 Group Join 
            Console.WriteLine("\n...............................................................................................................\n");
            Console.WriteLine("2. Write a LINQ query to perform a Group Join, listing students along with their exam details.\r\n");

            //Method Syntax
            Console.WriteLine("\n Method Syntax:");
            var GroupedExamResultMethod = (students.GroupJoin(exams, exam => exam.StudentId, stud => stud.StudentId, (stud
                , exam) => new { stud, exam }));
            foreach (var item in GroupedExamResultMethod)
            {
                Console.WriteLine($"\nStudentId : {item.stud.StudentId}\t StudentName : {item.stud.Name}");
                Console.WriteLine("-----------------------------------");
                if (!item.exam.Any())  
                {
                    Console.WriteLine("No exam details");
                }
                else
                {
                    foreach (var exam in item.exam)
                    {
                        Console.WriteLine($"ExamId : {exam.ExamId} Subject : {exam.Subject} Marks : {exam.Marks}");
                    }
                }
            }
            //Query Syntax
            Console.WriteLine("\n Query Syntax:");
            var GroupedExamResultQuery = (from student in students
                                          join exam in exams
                                          on student.StudentId equals exam.StudentId
                                          into grouped
                                          select new { student, grouped });

            foreach (var item in GroupedExamResultQuery)
            {
                Console.WriteLine($"\nStudentId : {item.student.StudentId}\t StudentName : {item.student.Name}");
                Console.WriteLine("-----------------------------------");
                if (!item.grouped.Any())  // Check if no exams exist
                {
                    Console.WriteLine("No exam details");
                }
                else
                {
                    foreach (var exam in item.grouped)
                    {
                        Console.WriteLine($"ExamId : {exam.ExamId} Subject : {exam.Subject} Marks : {exam.Marks}");
                    }
                }
            }


            //3 CrossJoin 
            Console.WriteLine("\n...............................................................................................................\n");
            Console.WriteLine("3. Write a LINQ query to perform a Cross Join, generating all possible combinations of Students and Exams.\r\n");

            //Method Syntax
            Console.WriteLine("\n Method Syntax:");
            var studentExamCombinationsM = students.Join(exams, student => true, exam => true, (student, exam) => new
            {
                StudentID = exam.StudentId,
                StudentName = student.Name,
                ExamID = exam.ExamId,
                ExamSubject = exam.Subject
            });
            if(studentExamCombinationsM.Any())
            {
                foreach (var item in studentExamCombinationsM)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("No details");
            }
           

            //Query Syntax
            Console.WriteLine("\n Query Syntax:");
            var studentExamCombinationsQ = (from student in students
                             from exam in exams
                             select new
                             {
                                 StudentID = exam.StudentId,
                                 StudentName = student.Name,
                                 ExamID = exam.ExamId,
                                 ExamSubject = exam.Subject
                             });

            if (studentExamCombinationsQ.Any())
            {
                foreach (var item in studentExamCombinationsQ)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("No details");
            }

            //4 LeftOuterJoin
            Console.WriteLine("\n...............................................................................................................\n");
            Console.WriteLine("4. Write a LINQ query to perform a Left Outer Join, listing all students along with their exams (even if they haven’t taken any exams).\r\n");

            //Method Syntax
            Console.WriteLine("\n Method Syntax:");
            var StudentExamMatchMethod = students.GroupJoin(exams, student => student.StudentId, exam => exam.StudentId, (student, exam) => new { student, exam }).SelectMany(x => x.exam.DefaultIfEmpty(), (student, exam) => new { student, exam });
           
            if (StudentExamMatchMethod.Any())
            {
                foreach (var item in StudentExamMatchMethod)
                {
                    Console.WriteLine($"\nStudentId : {item.student.student.StudentId}\t StudentName : {item.student.student.Name} \tExamId : {(item.exam != null ? item.exam.ExamId.ToString() : "N/A")} \tSubject : {(item.exam != null ? item.exam.Subject : "No exam details")}");
                }
            }
            else
            {
                Console.WriteLine("No details");
            }
            

            //Query Syntax
            Console.WriteLine("\n Query Syntax:");
            var StudentExamMatchQuery = from student in students
                            join exam in exams
                            on student.StudentId equals exam.StudentId
                            into studentgroup
                            from stdgrp in studentgroup.DefaultIfEmpty()
                            select new { student, stdgrp };


            foreach (var item in StudentExamMatchQuery)
            {
                Console.WriteLine($"\nStudentId : {item.student.StudentId}\t StudentName : {item.student.Name} \tExamId : {(item.stdgrp != null ? item.stdgrp.ExamId.ToString() : "N/A")} \tSubject : {(item.stdgrp != null ? item.stdgrp.Subject : "No exam details")}");
            }

            //5 group join
            Console.WriteLine("\n...............................................................................................................\n");
            Console.WriteLine("5. Write a LINQ query to group exam marks by StudentId, displaying the total marks obtained by each student.\r\n");

            //Method Syntax
            Console.WriteLine("\n Method Syntax:");
            var 
                studentTotalMarksMethod= students.GroupJoin(exams, student => student.StudentId, exam => exam.StudentId, (student, examgroup) => new
            {
                StudentName = student.Name,
                TotalMarks = examgroup.Sum(x => x.Marks)
            });

            foreach (var item in studentTotalMarksMethod)
            {
                Console.WriteLine(item);
            }


            //Query Syntax
            Console.WriteLine("\n Query Syntax:");
            var studentTotalMarksQuery = from student in students
                            join exam in exams
                            on student.StudentId equals exam.StudentId
                            into examgroup
                            select new
                            {
                                StudentName = student.Name,
                                TotalMarks = examgroup.Sum(x => x.Marks)
                            };

            foreach (var item in studentTotalMarksQuery)
            {
                Console.WriteLine(item);
            }

            //6 Lookup
            Console.WriteLine("\n...............................................................................................................\n");
            Console.WriteLine("6. Use ToLookup to create a dictionary-like structure where StudentId is the key and exam details are the values.\r\n");

            //Method Syntax
            Console.WriteLine("\n Method Syntax:");
            var StudentLookupMethod = exams.ToLookup(x => x.StudentId);
            foreach(var item in StudentLookupMethod)
            {
                Console.WriteLine($"\nStudentId : {item.Key}");
                Console.WriteLine("-----------------------------------------------------");    
                foreach(var exam in item)
                {
                    Console.WriteLine($"ExamId :  {exam.ExamId} \tExamSubject: {exam.Subject} \tMarks :  {exam.Marks} ");
                }
            }

            //Query Syntax
            Console.WriteLine("\n Query Syntax:");
            var StudentLookupQuery = (from exam in exams
                            select exam).ToLookup(x => x.StudentId);
            foreach (var item in StudentLookupQuery)
            {
                Console.WriteLine($"\nStudentId : {item.Key}");
                Console.WriteLine("-----------------------------------------------------");
                foreach (var exam in item)
                {
                    Console.WriteLine($"ExamId :  {exam.ExamId} \tExamSubject: {exam.Subject} \tMarks :  {exam.Marks} ");
                }
            }



            //7 GroupJoin 
            Console.WriteLine("\n...............................................................................................................\n");
            Console.WriteLine("7. Modify the GroupBy query to display the StudentId, count of exams taken, and the highest marks obtained per student.");

            //Method Syntax
            Console.WriteLine("\n Method Syntax:");
            var HighestScoreMethod = students.GroupJoin(exams , exam => exam.StudentId, student => student.StudentId, (student, examgroup)=> new { student, examgroup});

            foreach (var item in HighestScoreMethod)
            {
                Console.WriteLine($"Student id: {item.student.Name}  \tCount of exams taken : {item.examgroup.Count()}  \tHighest marks obtained : {(item.examgroup.Any() ? item.examgroup.Max(x => x.Marks) : "NA")}");
            }

            //Query Syntax
            Console.WriteLine("\n Query Syntax:");
            var HighestScoreQuery = (from student in students 
                             join exam in exams
                             on student.StudentId equals exam.StudentId
                             into examgroup
                             select new { student , examgroup}) ;

            foreach (var item in HighestScoreQuery) 
            {
                Console.WriteLine($"Student id: {item.student.Name}  \tCount of exams taken : {item.examgroup.Count()}  \tHighest marks obtained : {(item.examgroup.Any() ? item.examgroup.Max(x=> x.Marks) : "NA")}");
            }



            //8
            Console.WriteLine("\n.................................................................... ..........................................\n");
            Console.WriteLine("8. Fetch student names who have scored above 80 in at least one exam using a nested LINQ query.\r\n");

            //Method Syntax
            Console.WriteLine("\n Method Syntax:");
            var FilterStudentsMethod = students.Where(student => exams.Any(exam => exam.StudentId == student.StudentId && exam.Marks > 80)).Select(student => new { student.Name});

            foreach (var student in FilterStudentsMethod)
            {
                Console.WriteLine(student);
            }

            //Query Syntax
            Console.WriteLine("\n Query Syntax:");
            var FilterStudentsQuery = from student in students where(
                from exam in exams 
                where exam.StudentId == student.StudentId && exam.Marks >80
                select exam).Any()
                select new { student.Name};
            
            foreach(var student in FilterStudentsQuery)
            {
                Console.WriteLine(student);
            }


            //9 Distinct
            Console.WriteLine("\n...............................................................................................................\n");
            Console.WriteLine("9. Get a list of unique courses students are enrolled.\r\n");

            //Method Syntax
            Console.WriteLine("\n Method Syntax:");
            var DistinctCourseMethod =students.Select(student => student.Course).Distinct();
            foreach (var student in DistinctCourseMethod)
            {
                Console.WriteLine(student);
            }


            //Query Syntax
            Console.WriteLine("\n Query Syntax:");
            var DistinctCourseQuery = (from student in students
                            select student.Course).Distinct();
            foreach (var student in DistinctCourseQuery)
            {
                Console.WriteLine(student);
            }


            //10
            Console.WriteLine("\n...............................................................................................................\n");
            Console.WriteLine("10. Get a combined list of subjects from two different exam collections.");

            //Method Syntax
            Console.WriteLine("\n Method Syntax:");
            var ExamCollectionMethod = exams.Select(e => e.Subject).Union(exams2.Select(e => e.Subject));
            
            foreach(var sub in ExamCollectionMethod)
            {
                Console.WriteLine(sub);
            }


            //Query Syntax
            Console.WriteLine("\n Query Syntax:");
            var ExamCollectionQuery = (from exam in exams
                             select exam.Subject).Union(
                                 from exam2 in exams2 
                                 select exam2.Subject);
            foreach (var sub in ExamCollectionQuery)
            {
                Console.WriteLine(sub);
            }


            //11 Intersect
            Console.WriteLine("\n...............................................................................................................\n");
            Console.WriteLine("11. Find common subjects between two different exam collections.");

            //Method Syntax
            Console.WriteLine("\n Method Syntax:");
            Console.WriteLine("\n Method Syntax:");
            var CommonSubjectsMethod = exams.Select(e => e.Subject).Intersect(exams2.Select(e => e.Subject));

            foreach (var sub in CommonSubjectsMethod)
            {
                Console.WriteLine(sub);
            }

            //Query Syntax
            Console.WriteLine("\n Query Syntax:");
            var CommonSubjectsQuery = (from exam in exams
                              select exam.Subject).Intersect(
                                 from exam2 in exams2
                                 select exam2.Subject);
            foreach (var sub in CommonSubjectsQuery)
            {
                Console.WriteLine(sub);
            }



            //12 Except
            Console.WriteLine("\n...............................................................................................................\n");
            Console.WriteLine("12. Find subjects that exist in the first exam collection but not in the second.\r\n");

            //Method Syntax
            Console.WriteLine("\n Method Syntax:");
            Console.WriteLine("\n Method Syntax:");
            var FirstExamSubjectsMethod = exams.Select(e => e.Subject).Except(exams2.Select(e => e.Subject));

            foreach (var sub in FirstExamSubjectsMethod)
            {
                Console.WriteLine(sub);
            }

            //Query Syntax
            Console.WriteLine("\n Query Syntax:");
            var FirstExamSubjectsQuery = (from exam in exams
                              select exam.Subject).Except(
                                 from exam2 in exams2
                                 select exam2.Subject);
            foreach (var sub in FirstExamSubjectsQuery)
            {
                Console.WriteLine(sub);
            }


            //13
            Console.WriteLine("\n...............................................................................................................\n");
            Console.WriteLine("13. Assume a list of duplicate student names. Write a LINQ query to get a distinct list.\r\n");

            //Adding new Student with same name as Charlie 
            Console.WriteLine("Adding new student Charlie");
            Console.WriteLine("---------------------------");
            students.Add(new Student(5, "Charlie", "Physics"));
            foreach (var student in students)
            {
                Console.WriteLine(student.Name);
            }

            //Method Syntax
            Console.WriteLine("\n Method Syntax:");
            var UniqueStudentsMethod = students.Select(student => student.Name).Distinct();

            foreach (var student in UniqueStudentsMethod)
            {
                Console.WriteLine(student);
            }


            //Query Syntax
            Console.WriteLine("\n Query Syntax:");
            var UniqueStudentsQuery = (from student in students
                             select student.Name).Distinct() ;
            foreach (var student in UniqueStudentsQuery)
            {
                Console.WriteLine(student);
            }


            //14 Deffered Execution
            Console.WriteLine("\n...............................................................................................................\n");
            Console.WriteLine("14. Create a LINQ query that retrieves students from a collection and demonstrate deferred execution.");

            //Method Syntax
            // In the below statement the LINQ Query is only defined and not executed
            // If the query is executed here, then the result should not display Jenny
            Console.WriteLine("\n Method Syntax:");
            var DeferredMethod = students.Where(student => student.Course == "Math").Select(student => student.Name);

            //Adding new student with course = Math
            students.Add(new Student(6, "Jenny", "Math"));

            foreach(var student in DeferredMethod)
            {
                Console.WriteLine(student);
            }

            //Query Syntax
            Console.WriteLine("\n Query Syntax:");
            var DeferredQuery = from student in students
                             where student.Course == "Math"
                             select student.Name;

            students.Add(new Student(7, "Angela", "Math"));

            foreach (var student in DeferredQuery)
            {
                Console.WriteLine(student);
            }

            //15
            Console.WriteLine("\n...............................................................................................................\n");
            Console.WriteLine("15. Use ToList() to immediately execute the query and display results.\r\n");

            //Method Syntax
            Console.WriteLine("\n Method Syntax:");
            var ImmediateMethod = students.Where(student => student.Course == "History").Select(student => student.Name).ToList();

            //Adding new student with course = Math
            students.Add(new Student(8, "Stacy", "History"));

            foreach (var student in ImmediateMethod)
            {
                Console.WriteLine($"{(student == null? "No students available" : student)}");
            }

            //Query Syntax
            Console.WriteLine("\n Query Syntax:");
            var ImmediateQuery = (from student in students
                             where student.Course == "History"
                             select student.Name).ToList();

            students.Add(new Student(9, "Lucas", "History"));

            foreach (var student in ImmediateQuery)
            {
                // "??" It is used to return the left-hand operand if it is not null; otherwise, it returns the right-hand operand.
                Console.WriteLine(student ?? "No students available");
            }


            //16
            Console.WriteLine("\n...............................................................................................................\n");
            Console.WriteLine("16. Implement an example that simulates lazy vs. eager loading using LINQ queries.\r\n");

            //Method Syntax
            Console.WriteLine("\n Method Syntax:");
            //Lazy Operator
            var LazyLoadedBiologyExams = exams2.Where(exam => exam.Subject == "Biology").Select(exam => exam.Subject);
            //Eager loading
            //var eagerLoadedBiologyExams = exams2
            //.Include(exam => exam.Student) // Doesn't work on List<T>, but kept for consistency
            //.Where(exam => exam.Subject == "Biology")
            //.Select(exam => exam.Subject)
            //.ToList();
            var eagerLoadedBiologyExams = exams2.Where(exam => exam.Subject == "Biology").Select(exam => exam.Subject).ToList();


            //Adding new exam with subject a Biology
            exams2.Add(new Exam(205,3,"Biology",78));

            //Lazy Operator
            Console.WriteLine("\nAdded new exam with subject a Biology & searching for student with subject asBiology \n ");
            Console.WriteLine("Lazy Operator");
            Console.WriteLine("-----------------");
            foreach (var item in LazyLoadedBiologyExams)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nEager loading");
            Console.WriteLine("-----------------");
            foreach (var item in eagerLoadedBiologyExams)
            {
                Console.WriteLine(item);
            }



            //Query Syntax
            Console.WriteLine("\n Query Syntax:");
            //Lazy Operator
            var LazyLoadedChemistryExamsQ = (from exam in exams2
                              where exam.Subject == "Chemistry"
                              select exam.Subject);
            //Eager loading
            var eagerLoadedChemistryExamsQ = (from exam in exams2
                               where exam.Subject == "Chemistry"
                               select exam.Subject).ToList();
            //Adding new exam with subject a Chemistry
            exams2.Add(new Exam(206, 2, "Chemistry", 78));


            Console.WriteLine("\nAdded new exam with subject a Chemistry & searching for student with subject as Chemistry \n ");
            Console.WriteLine("Lazy Operator");
            Console.WriteLine("-----------------");
            foreach (var item in LazyLoadedChemistryExamsQ)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nEager loading");
            Console.WriteLine("-----------------");
            foreach (var item in eagerLoadedChemistryExamsQ)
            {
                Console.WriteLine(item);
            }

        }
    }
}

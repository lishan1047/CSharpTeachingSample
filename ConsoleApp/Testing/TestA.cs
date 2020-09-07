using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Testing.TestA
{
    public enum Gender{
        Male,
        Female,
    }
    public class Contact{
        public Contact(string name, Gender gender){
            this.Name = name;
            this.Gender = gender;
        }
        public string Name{
            get;
            private set;
        }
        public Gender Gender{
            get;
            private set;
        }
        public string GenderPronoun{
            get{
                return (this.Gender == Gender.Male ? "男" : "女");
            }
        }
    }
    public class Student : Contact{
        public Student(string name, Gender gender) : base(name, gender){
            _choosingCourses = new List<ChoosingCourse>();
        }
        public string StudentNo{
            get; set;
        }
        private List<ChoosingCourse> _choosingCourses;
        public IEnumerable<ChoosingCourse> ChoosingCourses{
            get{
                if(_choosingCourses == null){
                    _choosingCourses = new List<ChoosingCourse>();
                }
                return _choosingCourses;
            }
        }
        public double GetGPA(){
            double g = 0.0, c = 0.0;
            foreach(ChoosingCourse cc in this.ChoosingCourses){
                g += cc.TeachingTask.Course.Credit * cc.Score;
                c += cc.TeachingTask.Course.Credit;
            }
            return g / c;
        }
        public ChoosingCourse ChooseCourse(TeachingTask task){
            ChoosingCourse cc = task.AddStudent(this);
            _choosingCourses.Add(cc);
            return cc;
        }
        public override string ToString(){
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"=======================================
S：{0} ({1}) {2}
---------------------------------------
Course      Teacher   Credit    Score
---------------------------------------
", this.Name, this.StudentNo, this.GenderPronoun);
            foreach(ChoosingCourse cc in this.ChoosingCourses){
                sb.AppendFormat("{0,-12}{1,-10}{2,-10}{3,-10}\n", 
                cc.TeachingTask.Course.Name, cc.TeachingTask.Teacher.Name, 
                cc.TeachingTask.Course.Credit, cc.Score);
            }
            sb.AppendFormat("---------------------------------------\n");
            sb.AppendFormat("                      GPA:{0,5:0.00}\n", this.GetGPA());
            sb.AppendFormat("=======================================\n");
            return sb.ToString();
        }
    }

    public class Teacher : Contact{
        public Teacher(string name, Gender gender) : base(name, gender){}
        public string StaffNo{
            get; set;
        }
        private List<TeachingTask> _teachingTasks;
        public IEnumerable<TeachingTask> TeachingTasks{
            get{
                if(_teachingTasks == null){
                    _teachingTasks = new List<TeachingTask>();
                }
                return _teachingTasks;
            }
        }
    }

    public class Course{
        public Course(string courseNo, string name, double credit){
            this.CourseNo = courseNo;
            this.Name = name;
            this.Credit = credit;
        }
        public string CourseNo{
            get;
            private set;
        }
        public string Name{
            get;
            private set;
        }
        public double Credit{
            get;
            set;
        }
    }

    public class TeachingTask{
        public TeachingTask(Course course, Teacher teacher){
            this.Course = course;
            this.Teacher = teacher;
            _choosingCourses = new List<ChoosingCourse>();
        }
        public Teacher Teacher{
            get;
            private set;
        }
        public Course Course{
            get;
            private set;
        }
        private List<ChoosingCourse> _choosingCourses;
        public IEnumerable<ChoosingCourse> ChoosingCourses{
            get{
                if(_choosingCourses == null){
                    _choosingCourses = new List<ChoosingCourse>();
                }
                return _choosingCourses;
            }
        }
        public ChoosingCourse GetChoosingCourse(Student student){
            ChoosingCourse cc = null;
            foreach(ChoosingCourse v in this.ChoosingCourses){
                if(v.Student == student){
                    cc = v; break;
                }
            }
            return cc;
        }
        public ChoosingCourse AddStudent(Student student){
            if(this.GetChoosingCourse(student) != null){
                throw new System.Exception(
                    string.Format("{0} has chosen the course '{1}' of teacher '{2}'.", 
                    student.Name, this.Teacher.Name, this.Course.Name));
            }
            ChoosingCourse cc = new ChoosingCourse(this, student);
            _choosingCourses.Add(cc);
            return cc;
        }
        public void SignScore(Student student, double score){
            ChoosingCourse cc = this.GetChoosingCourse(student);
            if(cc != null){
                cc.Score = score;
            }
        }
    }

    public class ChoosingCourse{
        public ChoosingCourse(TeachingTask task, Student student){
            this.TeachingTask = task;
            this.Student = student;
        }
        public TeachingTask TeachingTask{
            get;
            private set;
        }
        public Student Student{
            get;
            private set;
        }
        public double Score{
            get;
            set;
        }
    }

    public class Test{
        public static void Testing(){
            Student s1 = new Student("S1", Gender.Male){
                StudentNo = "201704100701"
            };
            Student s2 = new Student("S2", Gender.Female){
                StudentNo = "201704100702"
            };
            Student s3 = new Student("S3", Gender.Male){
                StudentNo = "201704100703"
            };
            Teacher t1 = new Teacher("T1", Gender.Female){
                StaffNo = "1001"
            };
            Teacher t2 = new Teacher("T2", Gender.Male){
                StaffNo = "1002"
            };
            Teacher t3 = new Teacher("T3", Gender.Male){
                StaffNo = "1003"
            };
            Course c1 = new Course("C1", "Database", 3.0);
            Course c2 = new Course("C2", "OOP", 3.5);
            TeachingTask task1 = new TeachingTask(c1, t1);
            TeachingTask task2 = new TeachingTask(c2, t3);
            s1.ChooseCourse(task1);
            s2.ChooseCourse(task1);
            s2.ChooseCourse(task2);
            s3.ChooseCourse(task2);
            task1.SignScore(s1, 85);
            task1.SignScore(s2, 92);
            task2.SignScore(s2, 75);
            task2.SignScore(s3, 87);
            System.Console.WriteLine(s1);
            System.Console.WriteLine(s2);
            System.Console.WriteLine(s3);
        }
    }
}
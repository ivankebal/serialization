using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HomeworkSerialization
{
    public class Program
    {
        public class Auditory
        {
            [XmlAttribute]
            public string Name { get; set; }
            //public DateTime time { get; set; }
        }
        public class Lecturer
        {
            [XmlAttribute]
            public string FirstName { get; set; }
            [XmlAttribute]
            public string LastName { get; set; }
        }
        public class Subject
        {
            [XmlAttribute]
            public string SubjectName { get; set; }
            public List<Lecturer> Lecturers { get; set; } = new List<Lecturer>();
            public List<Auditory> Auditories { get; } = new List<Auditory>();
        }
        public class Mark
        {
            public Subject Subject { get; set; }
            [XmlAttribute]
            public int Value { get; set; }
        }
        public class Student
        {
            [XmlAttribute]
            public string FirstName { get; set; }
            [XmlAttribute]
            public string LastName { get; set; }
            public List<Mark> Marks { get; } = new List<Mark>();
        }
        public class Group
        {
            [XmlAttribute]
            public string Name { get; set; }
            public List<Student> Students { get; } = new List<Student>();
        }
        public class Specialization
        {
            [XmlAttribute]
            public string Name { get; set; }
            public List<Group> Groups { get; } = new List<Group>();
        }
        public class University
        {
            [XmlAttribute]
            public string Name { get; set; }
            public List<Specialization> Specializations { get; } = new List<Specialization>();
        }
        static void Main(string[] args)
        {
            using (Stream stream = File.OpenWrite("uni.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(University));
                University uni = InitUniversity();

                serializer.Serialize(stream, uni);
            }
        }

        public static University InitUniversity()
        {
            Auditory au01 = new Auditory { Name = "01" };
            

            Lecturer lecturer = new Lecturer { LastName = "Norris", FirstName = "Chack" };
            

           
            Subject subject = new Subject { SubjectName = "Ukrainian" };
            subject.Lecturers.Add(lecturer);
            subject.Auditories.Add(au01);

           
            Student student1 = new Student { FirstName = "Ivan", LastName = "Kebal" };
            student1.Marks.Add(new Mark { Subject = subject, Value = 75 });
           

            Student student2 = new Student { FirstName = "Axel", LastName = "Lev" };
            student2.Marks.Add(new Mark { Subject = subject, Value = 73 });
      
            Group group = new Group { Name = "G1" };
            group.Students.Add(student1);
            group.Students.Add(student2);

            Specialization sp1 = new Specialization { Name = "SP1" };
            sp1.Groups.Add(group);

            University uni = new University { Name = "DIIT" };
            uni.Specializations.Add(sp1);
            return uni;
        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;

namespace VP_Assignment
{

    class Student : Program
    {

        public string id { get; set; }
        public string name { get; set; }
        public int semester { get; set; }
        public double cgpa { get; set; }
        public string department { get; set; }
        public string university { get; set; }

        public char attendance { get; set; }






    }

    class Attendance: Program
    {
        public string id { get; set; }
        public string name { get; set; }
        
        public int attendance { get; set; }





    }





    class Program
    {

        static void ThreeStudents(ref int largestValueIndex, ref int secondLargestValueIndex, ref int thirdLargestValueIndex, List<Student> list)
        {
            largestValueIndex = 0;
            secondLargestValueIndex = 0;
            thirdLargestValueIndex = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[largestValueIndex].cgpa < list[i].cgpa)
                {
                    thirdLargestValueIndex = secondLargestValueIndex;
                    secondLargestValueIndex = largestValueIndex;
                    largestValueIndex = i;
                }
                else if (list[secondLargestValueIndex].cgpa < list[i].cgpa && list[secondLargestValueIndex].cgpa < list[largestValueIndex].cgpa && list[largestValueIndex].cgpa != list[i].cgpa || list[secondLargestValueIndex].cgpa == list[largestValueIndex].cgpa)
                {
                    secondLargestValueIndex = i;
                }
                else if (list[thirdLargestValueIndex].cgpa < list[i].cgpa && list[thirdLargestValueIndex].cgpa < list[secondLargestValueIndex].cgpa && list[secondLargestValueIndex].cgpa != list[i].cgpa || list[thirdLargestValueIndex].cgpa == list[secondLargestValueIndex].cgpa)
                {
                    thirdLargestValueIndex = i;
                }
            }
        }

        static List<Student> fileAttendanceReader()
        {
            List<Student> list = new List<Student>();

            using (StreamReader reader = new StreamReader("attendance.txt"))
            {
                while (!reader.EndOfStream)
                {
                    Student student = new Student();

                    student.id = reader.ReadLine();
                    student.name = reader.ReadLine();
                    student.attendance = reader.ReadLine()[0];
                    list.Add(student);
                }
                reader.Close();
            }
            return list;
        }


        static bool fileWriter(List<Student> student, List<char> attendance)
        {
            bool flag = false;
            try
            {
                using (StreamWriter writer = new StreamWriter("attendance.txt"))
                {
                    for (int i = 0; i < student.Count; i++)
                    {
                        writer.WriteLine(student[i].id);
                        writer.WriteLine(student[i].name);
                        writer.WriteLine(attendance[i]);
                    }
                    writer.Close();
                    flag = true;
                }
            }
            catch
            {
                Console.WriteLine("ERROR: File Could Not Be Opened!");
            }
            return flag;
        }


        public void ReadFile(List<Student> studentData)
        {
            using (StreamReader reader = new StreamReader("data.txt"))
            {

                while (!reader.EndOfStream)
                {
                    Student obj = new Student();

                    obj.id = reader.ReadLine();
                    obj.name = reader.ReadLine();
                    obj.semester = Convert.ToInt32(reader.ReadLine());
                    obj.cgpa = Convert.ToDouble(reader.ReadLine());
                    obj.department = reader.ReadLine();
                    obj.university = reader.ReadLine();

                    studentData.Add(obj);


                }






            }









        }

        public void WriteToFile(List<Student> studentData)
        {
            using (StreamWriter writer = new StreamWriter("data.txt", append: true))
            {
                for (int i = 0; i < studentData.Count; i++)
                {
                    writer.WriteLine(studentData[i].id);
                    writer.WriteLine(studentData[i].name);
                    writer.WriteLine(studentData[i].semester);
                    writer.WriteLine(studentData[i].cgpa);
                    writer.WriteLine(studentData[i].department);
                    writer.WriteLine(studentData[i].university);




                }







            }






        }

        public void WriteToFileOverwrite(List<Student> studentData)
        {
            using (StreamWriter writer = new StreamWriter("data.txt"))
            {
                for (int i = 0; i < studentData.Count; i++)
                {
                    writer.WriteLine(studentData[i].id);
                    writer.WriteLine(studentData[i].name);
                    writer.WriteLine(studentData[i].semester);
                    writer.WriteLine(studentData[i].cgpa);
                    writer.WriteLine(studentData[i].department);
                    writer.WriteLine(studentData[i].university);




                }







            }






        }
        
        public void TopThree(List<Student> studentData,int i)
        {

            
            Console.WriteLine("Student ID: {0}\n", studentData[i].id);
            Console.WriteLine("Student Name: {0}\n", studentData[i].name);
            Console.WriteLine("Student Semester: {0}\n", studentData[i].semester);
            Console.WriteLine("Student CGPA: {0}\n", studentData[i].cgpa);
            Console.WriteLine("Student Department: {0}\n", studentData[i].department);
            Console.WriteLine("Student University: {0}\n", studentData[i].university);



        }









        static void Main(string[] args)
        {
            Program pObj = new Program();


            int MainChoice;

            List<Student> studentData = new List<Student>();
            //List<Student> studentData = Readfile();


            pObj.ReadFile(studentData);




            do
            {

                Console.WriteLine("1.Create Student profile\n" +
                                    "2.Search Student\n" +
                                    "3.Delete Student Record\n" +
                                    "4.List top 03 of class\n" +
                                    "5.Mark student attendance\n" +
                                    "6.View attendance\n" +
                                    "7.Exit");

                Console.Write("Choice: ");
                MainChoice = Convert.ToInt32(Console.ReadLine());

                switch (MainChoice)

                {
                    case 1: // student profile
                        {
                            Console.Clear();
                            char studentProfileChoice;
                            do
                            {
                                Console.Write("Create Student Profile Menu:\n");

                                //read data from user
                                //store in list

                                Student obj = new Student();




                                Console.Write("Enter the Student ID: "); obj.id = Console.ReadLine();

                                Console.Write("Enter the Student Name: "); obj.name = Console.ReadLine();

                                Console.Write("Enter the Semester: "); obj.semester = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Enter the Student CGPA: "); obj.cgpa = Convert.ToDouble(Console.ReadLine());

                                Console.Write("Enter the Student Department: "); obj.department = Console.ReadLine();

                                Console.Write("Enter the Student University: "); obj.university = Console.ReadLine();

                                studentData.Add(obj);

                                Console.WriteLine("Press Y to Continue , N to Exit");





                                studentProfileChoice = Console.ReadLine()[0];


                            } while (studentProfileChoice != 'N');
                            pObj.WriteToFile(studentData);
                            break;

                        }

                    case 2:
                        {
                            Console.Clear();




                            while (true)
                            {

                                Console.Write("Search Student Menu: \n1.Search By ID \n2.Search By Name\n3.List All Students\n4. Go Back\n Choice: ");
                                int innerChoice = Convert.ToInt32(Console.ReadLine());

                                switch (innerChoice)
                                {
                                    case 1:
                                        {
                                            while (true)
                                            {
                                                Console.Clear();
                                                Console.Write("Enter the ID: ");
                                                string idToSearch = Console.ReadLine();

                                                for (int i = 0; i < studentData.Count; i++)
                                                {
                                                    int found = 0;
                                                    if (studentData[i].id == idToSearch)
                                                    {
                                                        Console.WriteLine("Student Found!\n");
                                                        Console.WriteLine("Student ID: {0}\n", studentData[i].id);
                                                        Console.WriteLine("Student Name: {0}\n", studentData[i].name);
                                                        Console.WriteLine("Student Semester: {0}\n", studentData[i].semester);
                                                        Console.WriteLine("Student CGPA: {0}\n", studentData[i].cgpa);
                                                        Console.WriteLine("Student Department: {0}\n", studentData[i].department);
                                                        Console.WriteLine("Student University: {0}\n", studentData[i].university);

                                                        break;

                                                    }
                                                    else if (found == 0 && i == studentData.Count - 1)
                                                    {

                                                        Console.WriteLine("ID Not Found!\n Press Any Key to continue");
                                                        while (Console.KeyAvailable)
                                                        {
                                                            Console.ReadKey(false);
                                                        }
                                                        Console.ReadKey();

                                                    }



                                                }

                                                break;


                                            }


                                            break;




                                        }

                                    case 2:
                                        {

                                            while (true)
                                            {

                                                Console.Clear();
                                                Console.Write("Enter the Name: ");
                                                string nameToSearch = Console.ReadLine();
                                                int found = 0;
                                                for (int i = 0; i < studentData.Count; i++)
                                                {

                                                    if (studentData[i].name == nameToSearch)
                                                    {
                                                        Console.WriteLine("Student Found!\n");
                                                        Console.WriteLine("Student ID: {0}\n", studentData[i].id);
                                                        Console.WriteLine("Student Name: {0}\n", studentData[i].name);
                                                        Console.WriteLine("Student Semester: {0}\n", studentData[i].semester);
                                                        Console.WriteLine("Student CGPA: {0}\n", studentData[i].cgpa);
                                                        Console.WriteLine("Student Department: {0}\n", studentData[i].department);
                                                        Console.WriteLine("Student University: {0}\n", studentData[i].university);

                                                        Console.WriteLine("\n ---------------- \n");

                                                        found++;
                                                    }

                                                    else
                                                    {
                                                        if (found == 0 && i == studentData.Count - 1)
                                                        {

                                                            Console.WriteLine("Student Doesnt Exist");
                                                            break;
                                                        }

                                                    }



                                                }


                                                Console.Write("Press Y to Continue, N to Exit Menu\n choice: ");
                                                char exitChoice = Console.ReadLine()[0];
                                                if (exitChoice == 'N')
                                                {
                                                    break; // FIRST BREAK AFTER DATA FOUND
                                                }


                                            }


                                            break;
                                        }

                                    case 3:
                                        {

                                            Console.Clear();
                                            for (int i = 0; i < studentData.Count; i++)
                                            {


                                                Console.WriteLine("\n ---------------- \n");
                                                Console.WriteLine("Student ID: {0}\n", studentData[i].id);
                                                Console.WriteLine("Student Name: {0}\n", studentData[i].name);
                                                Console.WriteLine("Student Semester: {0}\n", studentData[i].semester);
                                                Console.WriteLine("Student CGPA: {0}\n", studentData[i].cgpa);
                                                Console.WriteLine("Student Department: {0}\n", studentData[i].department);
                                                Console.WriteLine("Student University: {0}\n", studentData[i].university);

                                                Console.WriteLine("\n ---------------- \n");



                                            }




                                            break;
                                        }

                                    case 4:
                                        {
                                            break;
                                        }

                                }

                                //Search By ID- one student will be showed.



                                // breaks outer loop





                                // -Student Name
                                //- Semseter
                                //- CGPA
                                //- Department
                                //- University





                                if (innerChoice == 4)
                                {
                                    Console.Clear();
                                    break;

                                }




                                //Console.WriteLine("Press Y to Continue , N to Exit");

                                //SearchProfileChoice = Convert.ToChar(Console.ReadLine());
                                //char.ToUpper(SearchProfileChoice);



                            }





                            break;
                        }

                    case 3:
                        {
                            Console.Clear();



                            Console.Write("Delete Student Record Menu \n");

                            // Search for the student, if found
                            // delete the record from the list
                            //update the file
                            Console.Write("Enter the ID: ");
                            string idToSearch = Console.ReadLine();
                            for (int i = 0; i < studentData.Count; i++)
                            {

                                int found = 0;
                                if (studentData[i].id == idToSearch)
                                {

                                    studentData.RemoveAt(i);
                                    pObj.WriteToFileOverwrite(studentData);


                                }
                                else if (found == 0 && i == studentData.Count - 1)
                                {

                                    Console.WriteLine("\nID Not Found!\n Press Any Key to continue");
                                    while (Console.KeyAvailable)
                                    {
                                        Console.ReadKey(false);
                                    }
                                    Console.ReadKey();

                                }









                                //Console.WriteLine("Press Y to Continue , N to Exit");

                                //SearchProfileChoice = Convert.ToChar(Console.ReadLine());
                                //char.ToUpper(SearchProfileChoice);
                                //while (SearchProfileChoice != 'N') ;
                            }

                            break;

                        }



                    case 4:
                        {
                            Console.WriteLine("Top 3 Students");
                            int firstIndex = -1;
                            int secondIndex = -1;
                            int thirdIndex = -1;
                            ThreeStudents(ref firstIndex, ref secondIndex, ref thirdIndex, studentData);

                            if (studentData.Count > 0)
                            {
                                Console.WriteLine("{0,-20}{1,-50}{2,-10}{3,-6}{4,-30}{5,-30}", "ID", "Name", "Semester", "CGPA", "Department", "University");
                                if (studentData.Count == 1)
                                    Console.WriteLine("{0,-20}{1,-50}{2,-10}{3,-6}{4,-30}{5,-30}", studentData[firstIndex].id, studentData[firstIndex].name, studentData[firstIndex].semester, Math.Round(studentData[firstIndex].cgpa, 2), studentData[firstIndex].department, studentData[firstIndex].university);
                                else if (studentData.Count == 2)
                                {
                                    Console.WriteLine("{0,-20}{1,-50}{2,-10}{3,-6}{4,-30}{5,-30}", studentData[firstIndex].id, studentData[firstIndex].name, studentData[firstIndex].semester, Math.Round(studentData[firstIndex].cgpa, 2), studentData[firstIndex].department, studentData[firstIndex].university);
                                    Console.WriteLine("{0,-20}{1,-50}{2,-10}{3,-6}{4,-30}{5,-30}", studentData[secondIndex].id, studentData[secondIndex].name, studentData[secondIndex].semester, Math.Round(studentData[secondIndex].cgpa, 2), studentData[secondIndex].department, studentData[secondIndex].university);
                                }
                                else
                                {
                                    Console.WriteLine("{0,-20}{1,-50}{2,-10}{3,-6}{4,-30}{5,-30}", studentData[firstIndex].id, studentData[firstIndex].name, studentData[firstIndex].semester, Math.Round(studentData[firstIndex].cgpa, 2), studentData[firstIndex].department, studentData[firstIndex].university);
                                    Console.WriteLine("{0,-20}{1,-50}{2,-10}{3,-6}{4,-30}{5,-30}", studentData[secondIndex].id, studentData[secondIndex].name, studentData[secondIndex].semester, Math.Round(studentData[secondIndex].cgpa, 2), studentData[secondIndex].department, studentData[secondIndex].university);
                                    Console.WriteLine("{0,-20}{1,-50}{2,-10}{3,-6}{4,-30}{5,-30}", studentData[thirdIndex].id, studentData[thirdIndex].name, studentData[thirdIndex].semester, Math.Round(studentData[thirdIndex].cgpa, 2), studentData[thirdIndex].department, studentData[thirdIndex].university);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No Record in File!");
                            }

                            Console.Write("Press any key to continue...");
                            Console.ReadKey();



                            break;
                        }

                    case 5:
                        {
                            Console.WriteLine("Mark Attendance\n");
                            while (true) //Mark Attendance While Loop
                            {
                                
                                List<char> attendance = new List<char>();
                                Console.WriteLine("Press 'q' to Abort");
                                bool abort = false;
                                for (int i = 0; i < studentData.Count; i++)
                                {
                                    if (i == 0)
                                        Console.WriteLine("{0,-3}{1,-20}{2,-50}{3,-15}", "#", "Enrollment", "Name", "Attendance(p/a)");
                                        Console.Write("{0,-3}{1,-20}{2,-50}", i + 1 + ")", studentData[i].id, studentData[i].name);

                                    while (true) 
                                    {
                                        char att = Console.ReadLine()[0];

                                        if (att == 'a' || att == 'p')
                                        {
                                            attendance.Add(att);
                                            break;
                                        }
                                        else if (att == 'q')
                                        {
                                            abort = true;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("ERROR: Invalide Input!\n\n");
                                            Console.Write("{0,-3}){1,-20}{2,-50}", i + 1 + ")", studentData[i].id,studentData[i].name);
                                            continue;
                                        }
                                    }

                                    if (abort)
                                        break;
                                }

                                if (abort)
                                {
                                    Console.WriteLine("Aborting.....\nPress any key to continue...");
                                    Console.ReadKey();
                                    break;
                                }

                                bool flag = fileWriter(studentData, attendance);

                                if (flag)
                                {
                                    Console.WriteLine("\nAttendance Successfully Updated.....\nPress any key to continue...");
                                }
                                else
                                {
                                    Console.WriteLine("\nERROR : Unable to Update Attance.....\nPress any key to continue...");
                                }

                                Console.ReadKey();
                                break;
                            }//Option 5 Mark Attendance While Loop Ends
                        }




















                        break;


                    case 6:
                        {
                            Console.WriteLine("View Attendance\n");
                            List<Student> attandence = fileAttendanceReader();

                            for (int i = 0; i < attandence.Count; i++)
                            {
                                if (i == 0)
                                    Console.WriteLine("{0,-3}{1,-20}{2,-50}{3,-15}", "#", "Name", "Enrollment", "Attendance(p/a)");
                                Console.WriteLine("{0,-3}{1,-20}{2,-50}{3,-15}", i + 1 + ")", attandence[i].id, attandence[i].name, attandence[i].attendance);
                            }

                            Console.Write("Press any key to continue...");
                            Console.ReadKey();

                            break;

                }

                    case 7:
                        {

                            break;
                        }

                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Option Selected");
                            break;
                        }

                }

            } while (MainChoice != 7);



        }
    }
}

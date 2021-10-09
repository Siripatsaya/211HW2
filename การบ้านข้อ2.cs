using System;
using System.Collections.Generic;

namespace ConsoleApp43
{
    enum Menu
    {
        RegisterNewStudent = 1,
        RegisterNewTeacher,
        GetListactivity
    }

    class Program
    {
        static ActivityList activityList;


        static void Main(string[] args)
        {
            PrepareActivityListWhenProgramIsLoad();
            PrintMenuScreen();
        }

        static void PrepareActivityListWhenProgramIsLoad()
        {
            Program.activityList = new ActivityList();
        }

        static void PrintMenuScreen()
        {
            Console.Clear();
            PrintHeader();
            PrintListMenu();
            InputMenuFromKeyboard();
        }

        static void PrintHeader()
        {
            Console.WriteLine("Welcome to register for student activities.");
            Console.WriteLine("--------------------------------------------");
        }

        static void PrintListMenu()
        {
            Console.WriteLine("1. Register new student.");
            Console.WriteLine("2. Register new Teacher.");
            Console.WriteLine("3. Get List activity.");
        }

        static void InputMenuFromKeyboard()
        {
            Console.Write("Please Select Menu: ");
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));

            PresentMenu(menu);
        }

        static void PresentMenu(Menu menu)
        {
            if (menu == Menu.RegisterNewStudent)
            {
                ShowInputRegisterNewStudentScreen();
            }
            else if (menu == Menu.RegisterNewTeacher)
            {
                ShowInputRegisterNewTeacherScreen();
            }
            else if (menu == Menu.GetListactivity)
            {
                ShowGetListActivityScreen();
            }
            else
            {
                ShowMessageInputMenuIsInCorrect();
            }
        }

        static void ShowInputRegisterNewStudentScreen()
        {
            Console.Clear();
            PrintHeaderRegisterStudent();
            int totalStudent = TotalNewStudents();
            InputNewStudentFromKeyboard(totalStudent);
            CreateNewStudent();
            Console.Clear();
            PrintMenuScreen();
        }

        static void ShowInputRegisterNewTeacherScreen()
        {
            Console.Clear();
            PrintHeaderRegisterTeacher();
            int totalTeacher = TotalNewTeacher();
            InputNewTeacherFromKeyboard(totalTeacher);
            CreateNewTeacher();
            Console.Clear();
            PrintMenuScreen();    
        }
        static void ShowGetListActivityScreen()
        {
            Console.Clear();
            Program.activityList.FetchActivityList();
            InputExitFromKeyboard();
        }

        static void InputExitFromKeyboard()
        {
            string text = "";
            while (text != "exit")
            {
                Console.Write("Input 'exit' to go to the menu page: ");
                text = Console.ReadLine();
            }

            Console.Clear();
            PrintMenuScreen();
        }
        static void InputNewTeacherFromKeyboard(int totalTeacher)
        {
            for (int i = 0; i < totalTeacher; i++)
            {
                Console.Clear();
                PrintHeaderRegisterTeacher();

                Teacher teacher = CreateNewTeacher();
                Program.activityList.AddNewactivity(teacher);
            }

            Console.Clear();
            PrintMenuScreen();
        }

        static void InputNewStudentFromKeyboard(int totalStudent)
        {
            for (int i = 0; i < totalStudent; i++)
            {
                Console.Clear();
                PrintHeaderRegisterStudent();

                Student student = CreateNewStudent();
                Program.activityList.AddNewactivity(student);
            }

            Console.Clear();
            PrintMenuScreen();
        }


        static Student CreateNewStudent()
        {
            return new Student(InputName(),
             InputAddress(),
             InputCitizenID(),
             InputStudentID(),
             InputNameac(),
             Inputhour(),
             Inputdate());
        }

        static Teacher CreateNewTeacher()
        {
            return new Teacher(InputName(),
            InputAddress(),
            InputCitizenID(),
            InputEmployeeID(),
            InputNameac(),
            Inputhour(),
            Inputdate());
        }

        static string InputName()
        {
            Console.Write("Name: ");

            return Console.ReadLine();
        }

        static string InputStudentID()
        {
            Console.Write("Student ID: ");

            return Console.ReadLine();
        }

        static string InputAddress()
        {
            Console.Write("Address: ");

            return Console.ReadLine();
        }

        static string InputCitizenID()
        {
            Console.Write("Citizen ID: ");

            return Console.ReadLine();
        }

        static string InputEmployeeID()
        {
            Console.Write("Employee ID: ");

            return Console.ReadLine();
        }
        static string InputNameac()
        {
            Console.Write("Activity name: ");

            return Console.ReadLine();
        }
        static string Inputhour()
        {
            Console.Write("Activity hours: ");

            return Console.ReadLine();
        }
        static string Inputdate()
        {
            Console.Write("Day/Month/Year: ");

            return Console.ReadLine();
        }
        static int TotalNewStudents()
        {
            Console.Write("Input Total new Student: ");

            return int.Parse(Console.ReadLine());
        }

        static int TotalNewTeacher()
        {
            Console.Write("Input Total new Teacher: ");

            return int.Parse(Console.ReadLine());
        }

        static void PrintHeaderRegisterStudent()
        {
            Console.WriteLine("Register new student.");
            Console.WriteLine("---------------------");
        }

        static void PrintHeaderRegisterTeacher()
        {
            Console.WriteLine("Register new teacher.");
            Console.WriteLine("---------------------");
        }

        static void ShowMessageInputMenuIsInCorrect()
        {
            Console.Clear();
            Console.WriteLine("Menu Incorrect Please try again.");
            PrintListMenu();
            InputMenuFromKeyboard();
        }
    }
    class Student : Activity
    {
        private string studentID;

        public Student(string name, string address, string citizenID, string studentID, string nameac, string hour, string date)
        : base(name, address, citizenID, nameac, hour, date)
        {
            this.studentID = studentID;
        }
    }
    class Teacher : Activity
    {
        private string employeeID;

        public Teacher(string name, string address, string citizenID, string employeeID, string nameac, string hour, string date)
        : base(name, address, citizenID, nameac, hour, date)
        {
            this.employeeID = employeeID;
        }
    }
    class Activity
    {
        protected string name;
        protected string address;
        protected string citizenID;
        protected string nameac;
        protected string hour;
        protected string date;

        public Activity(string name, string address, string citizenID, string nameac, string hour, string date)
        {
            this.name = name;
            this.address = address;
            this.citizenID = citizenID;
            this.nameac = nameac;
            this.hour = hour;
            this.date = date;
        }
        public string GetName()
        {
            return this.name;
        }
        public string GetNameac()
        {
            return this.nameac;
        }
        public string GetHour()
        {
            return this.hour;
        }
        public string GetDate()
        {
            return this.date;
        }
    }
    class ActivityList
    {
        private List<Activity> activityList;

        public ActivityList()
        {
            this.activityList = new List<Activity>();
        }

        public void AddNewactivity(Activity activity)
        {
            this.activityList.Add(activity);
        }

        public void FetchActivityList()
        {
            Console.WriteLine("List activity");
            Console.WriteLine("--------------");
            foreach (Activity activity in this.activityList)
            {
                if (activity is Student)
                {
                    Console.WriteLine("Name: {0} \nType: Student \nActivity name: {1} \nActivity hour : {2} hour \nDay/Month/Year ; {3} \n", activity.GetName(), activity.GetNameac(), activity.GetHour(), activity.GetDate());
                }
                else if (activity is Teacher)
                {
                    Console.WriteLine("Name: {0} \nType: Teacher \nActivity name: {1} \nActivity hour : {2} hour \nDay/Month/Year ; {3} \n", activity.GetName(), activity.GetNameac(), activity.GetHour(), activity.GetDate());
                }
            }
        }
    }
}


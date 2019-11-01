using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace VPAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            int id =0;
            string name = "";
            int semester = 0;
            float cgpa = 0;
            string department = "";
            string university = "";
            string attendence = "";

            Student obj = new Student();
            Char choice = 't';
            Char ch = 'y';
            
            string path = @"C:\Users\JK\Desktop\VpAssignment.txt";
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            else
            {
                StreamReader sw = new StreamReader(path);
                while(!sw.EndOfStream)
                {
                    id=(Convert.ToInt32(sw.ReadLine()));
                    name = (sw.ReadLine());
                    semester = Convert.ToInt32(sw.ReadLine());
                    cgpa = ((float)Convert.ToDouble(sw.ReadLine()));
                    department = (sw.ReadLine());
                    university = (sw.ReadLine());
                    attendence = (sw.ReadLine());
                    obj.insert(id, name, semester, cgpa, department, university, attendence);
                    
                }
                sw.Close();
            }

            do
            {
                Console.Clear();
                Console.WriteLine("\t\t-------------Welcome TO Student Management System-----------------");
                Console.WriteLine("\t\tPress 1 for Create Student Profile");
                Console.WriteLine("\t\tPress 2 for Search Student ");
                Console.WriteLine("\t\tPress 3 for Delete Student Record");
                Console.WriteLine("\t\tPress 4 for List Top 3 Student");
                Console.WriteLine("\t\tPress 5 for Mark Student Attendence");
                Console.WriteLine("\t\tPress 6 for View Attendence");
                Console.WriteLine("\t\tPress Any Key For Exit\n");
                Console.Write("\t\tPLease Enter Your Choice:");
                choice = Convert.ToChar(Console.ReadLine());
                if (choice == '1')
                {
                    Console.Clear();
                    obj.CreateProfile(path);

                }
                else if(choice=='2')
                {
                    Console.Clear();
                    char choice1 = 'y';
                    Console.WriteLine("\t\t-------------Search Menu-----------------");
                    Console.WriteLine("\t\tPress 1 for Search By Student Id");
                    Console.WriteLine("\t\tPress 2 for Search By Student Name");
                    Console.WriteLine("\t\tPress 3 for Search All Student");
                    Console.Write("\t\tPLease Enter Your Choice:");
                    choice1 = Convert.ToChar(Console.ReadLine());
                    if (choice1 == '1')
                    {
                        Console.Clear();
                        int sid = 0;
                        Console.WriteLine("\t\t-----------------Search By Student Id-------------------\n");
                        Console.Write("\t\tEnter Student Id:");
                        sid=Convert.ToInt32(Console.ReadLine());
                        Console.Write("---------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
                        obj.searchId(sid);
                    }
                    else if (choice1 =='2')
                    {
                        Console.Clear();
                        string names = "";
                        Console.WriteLine("\t\t-----------------Search By Student Name-------------------\n");
                        Console.Write("\t\tEnter Student Name:");
                        names = Console.ReadLine();
                        Console.Write("---------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
                        obj.searchName(names);
                    }
                    else if(choice1=='3')
                    {
                        Console.Clear();
                        Console.WriteLine("\t\t-----------------Search All Student-------------------\n");
                        obj.showAll();
                        
                    }
                    else
                    {
                        Console.WriteLine("\t\tYou Enter wrong Input");
                        Console.ReadKey();
                    }

                }
                else if (choice == '3')
                {
                    Console.Clear();
                    int sid = 0;
                    Console.WriteLine("\t\t-----------------Delete Student Record By ID-------------------\n");
                    Console.Write("\t\tEnter Student Id:");
                    sid = Convert.ToInt32(Console.ReadLine());
                    Console.Write("---------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
                    obj.deleteRecord(sid, path);
                }
                else if (choice == '4')
                {
                    Console.Clear();
                    Console.WriteLine("\t\t-----------------Top 3 Students-------------------\n");
                    obj.TopStudent();
                }
                else if (choice == '5')
                {
                    Console.Clear();
                    Console.WriteLine("\t\t-----------------Mark Attendence-------------------\n");
                    obj.markAttendence(path);
                }
                else if (choice == '6')
                {
                    Console.Clear();
                    Console.WriteLine("\t\t-----------------View Attendence-------------------\n");
                    obj.ViewAttendence();
                }
                else 
                {
                    Console.Clear();
                    Console.WriteLine("\t\t--------------Thanks For Using Program---------------------------");
                    ch = 'n';
                }

            } while (ch != 'n');

            Console.ReadKey();
        }
    }
}

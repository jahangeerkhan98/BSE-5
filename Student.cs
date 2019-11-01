using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace VPAssignment
{
    class Student
    {
        ArrayList id = new ArrayList();
        ArrayList name = new ArrayList();
        ArrayList semester = new ArrayList();
        ArrayList cgpa = new ArrayList();
        ArrayList department = new ArrayList();
        ArrayList university = new ArrayList();
        ArrayList attendence = new ArrayList();

        public void insert(int ids,string names,int semesters,float cgpas,string departments,string universities,string attendences)
        {
            id.Add(ids);
            name.Add(names);
            semester.Add(semesters);
            cgpa.Add(cgpas);
            department.Add(departments);
            university.Add(universities);
            attendence.Add(attendences);
            
        }
        public void CreateProfile(string path)
        {
            Random rand = new Random();
            int ids=rand.Next(1000, 4000);
            for(int i=0;i<id.Count;i++)
            {
                if (Convert.ToInt32((id[i].ToString())) == ids)
                {
                    ids=rand.Next(1000, 4000);
                    i = -1;
                }

            }
            id.Add(ids);
            Console.WriteLine("\t\t--------Create New Profile-----------------\n");
            Console.WriteLine("\t\tStudent id:" + id[id.Count - 1].ToString());
            Console.Write("\t\tEnter the Student Name:");
            name.Add(Console.ReadLine());
            Console.Write("\t\tEnter the Semester:");
            semester.Add(Convert.ToInt32(Console.ReadLine()));
            Console.Write("\t\tEnter the Cgpa:");
            cgpa.Add((float)Convert.ToDouble(Console.ReadLine()));
            Console.Write("\t\tEnter the Department:");
            department.Add(Console.ReadLine());
            Console.Write("\t\tEnter the University:");
            university.Add(Console.ReadLine());
            attendence.Add("present");


            StreamWriter sw ;
            sw = File.AppendText(path);
            sw.WriteLine(id[id.Count - 1].ToString());
            sw.WriteLine(name[name.Count - 1].ToString());
            sw.WriteLine(semester[semester.Count - 1].ToString());
            sw.WriteLine(cgpa[cgpa.Count - 1].ToString());
            sw.WriteLine(department[department.Count - 1].ToString());
            sw.WriteLine(university[university.Count - 1].ToString());
            sw.WriteLine(attendence[attendence.Count - 1].ToString());
            sw.Close();
            Console.WriteLine("\t\t----Student Profile Is Successfully Created-- ");
            Console.ReadKey();
        }

        public void searchId(int sid)
        {
            for(int i=0;i<id.Count;i++)
            {
                if(sid== Convert.ToInt32((id[i].ToString())))
                {
                    Console.WriteLine("\tId\t\tName\t\tSemester\t\tCGPA\t\tDepartment\t\tUniversity");
                    Console.Write("\t"+id[i]);
                    Console.Write("\t\t"+name[i]);
                    if ((name[i].ToString()).Length <= 7)
                    {
                        Console.Write("\t\t" + semester[i]);
                    }
                    else
                    {
                        Console.Write("\t" + semester[i]);
                    }
                    Console.Write("\t\t\t"+cgpa[i]);
                    Console.Write("\t\t"+department[i]);
                    if ((department[i].ToString()).Length <= 5)
                    {
                        Console.Write("\t\t\t" + university[i]+"\n");
                    }
                    else
                    {
                        Console.Write("\t\t" + university[i]+"\n");
                    }
                    Console.ReadKey();
                    break;
                }
            }
        }

        public void showAll()
        {
            Console.WriteLine("\tId\t\tName\t\tSemester\t\tCGPA\t\tDepartment\t\tUniversity");
            for (int i = 0; i < id.Count; i++)
            {
                    Console.Write("\t"+id[i]);
                    Console.Write("\t\t" + name[i]);
                    if ((name[i].ToString()).Length <= 7)
                    {
                        Console.Write("\t\t" + semester[i]);
                    }
                    else
                    {
                        Console.Write("\t" + semester[i]);
                    }
                    Console.Write("\t\t\t" + cgpa[i]);
                    Console.Write("\t\t" + department[i]);
                    if ((department[i].ToString()).Length <= 5)
                    {
                        Console.Write("\t\t\t" + university[i]+"\n");
                    }
                    else
                    {
                        Console.Write("\t\t" + university[i]+"\n");
                    }
            }
            Console.ReadKey();
        }

        public void searchName(string names)
        {
            Console.WriteLine("\tId\t\tName\t\tSemester\t\tCGPA\t\tDepartment\t\tUniversity");
            for (int i = 0; i < id.Count; i++)
            {
                if (names == name[i].ToString())
                {
                    Console.Write("\t"+id[i]);
                    Console.Write("\t\t" + name[i]);
                    if ((name[i].ToString()).Length <= 7)
                    {
                        Console.Write("\t\t" + semester[i]);
                    }
                    else
                    {
                        Console.Write("\t" + semester[i]);
                    }
                    Console.Write("\t\t\t" + cgpa[i]);
                    Console.Write("\t\t" + department[i]);
                    if ((department[i].ToString()).Length <= 5)
                    {
                        Console.Write("\t\t\t" + university[i]+"\n");
                    }
                    else
                    {
                        Console.Write("\t\t" + university[i]+"\n");
                    }
                }
            }
            Console.ReadKey();
        }


        public void deleteRecord(int sid,string path)
        {
            bool check = false;
            for(int i=0;i<id.Count;i++)
            {
                if (sid == Convert.ToInt32(id[i].ToString()))
                {
                    id.RemoveAt(i);
                    name.RemoveAt(i);
                    semester.RemoveAt(i);
                    cgpa.RemoveAt(i);
                    department.RemoveAt(i);
                    university.RemoveAt(i);
                    attendence.RemoveAt(i);
                    check = true;
                    break;
                }
            }
            if (check == true)
            {
                Console.WriteLine("\t\t--Record was Successfully Deleted--");
                File.WriteAllText(path, string.Empty);
                StreamWriter sw = File.AppendText(path);
                for (int i = 0; i < id.Count; i++)
                {
                    sw.WriteLine(id[i].ToString());
                    sw.WriteLine(name[i].ToString());
                    sw.WriteLine(semester[i].ToString());
                    sw.WriteLine(cgpa[i].ToString());
                    sw.WriteLine(department[i].ToString());
                    sw.WriteLine(university[i].ToString());
                    sw.WriteLine(attendence[i].ToString());
                }
                sw.Close();
            }
            else
            {
                Console.WriteLine("\t\t--Against Your Given Id Record Not Found--");
            }
            Console.ReadKey();   
        }

        public void TopStudent()
        {
            ArrayList duplicateCgpa = new ArrayList();
            duplicateCgpa = cgpa;
            object[] obj = duplicateCgpa.ToArray();
            duplicateCgpa = new ArrayList(obj.Distinct().ToArray());
            duplicateCgpa.Sort();

            Console.WriteLine("\tPosition\tId\t\tName\t\tSemester\t\tCGPA\t\tDepartment\t\tUniversity");
            for (int i = 0; i < id.Count; i++)
            {
                if (duplicateCgpa[duplicateCgpa.Count-1].ToString() == cgpa[i].ToString())
                {
                    Console.Write("\t1st.");
                    Console.Write("\t\t" + id[i]);
                    Console.Write("\t\t" + name[i]);
                    if ((name[i].ToString()).Length <= 7)
                    {
                        Console.Write("\t\t" + semester[i]);
                    }
                    else
                    {
                        Console.Write("\t" + semester[i]);
                    }
                    Console.Write("\t\t\t" + cgpa[i]);
                    Console.Write("\t\t" + department[i]);
                    if ((department[i].ToString()).Length <= 5)
                    {
                        Console.Write("\t\t\t" + university[i]);
                    }
                    else
                    {
                        Console.Write("\t\t" + university[i]+"\n");
                    }
                }
                
                
            }
            for(int i=0;i<id.Count&&duplicateCgpa.Count>1;i++)
            {
                if (duplicateCgpa[duplicateCgpa.Count - 2].ToString() == cgpa[i].ToString())
                {
                    Console.Write("\t2nd.");
                    Console.Write("\t\t" + id[i]);
                    Console.Write("\t\t" + name[i]);
                    if ((name[i].ToString()).Length <= 7)
                    {
                        Console.Write("\t\t" + semester[i]);
                    }
                    else
                    {
                        Console.Write("\t" + semester[i]);
                    }
                    Console.Write("\t\t\t" + cgpa[i]);
                    Console.Write("\t\t" + department[i]);
                    if ((department[i].ToString()).Length <= 5)
                    {
                        Console.Write("\t\t\t" + university[i] + "\n");
                    }
                    else
                    {
                        Console.Write("\t\t" + university[i]+"\n");
                    }
                }
            }
            for(int i=0;i<id.Count&&duplicateCgpa.Count>2;i++)
            {
                if (duplicateCgpa[duplicateCgpa.Count - 3].ToString() == cgpa[i].ToString())
                {
                    Console.Write("\t3rd.");
                    Console.Write("\t\t" + id[i]);
                    Console.Write("\t\t" + name[i]);
                    if ((name[i].ToString()).Length <= 7)
                    {
                        Console.Write("\t\t" + semester[i]);
                    }
                    else
                    {
                        Console.Write("\t" + semester[i]);
                    }
                    Console.Write("\t\t\t" + cgpa[i]);
                    Console.Write("\t\t" + department[i]);
                    if ((department[i].ToString()).Length <= 5)
                    {
                        Console.Write("\t\t\t" + university[i]);
                    }
                    else
                    {
                        Console.Write("\t\t" + university[i] + "\n");
                    }
                }
            }

            Console.ReadKey();
        }

        public void markAttendence(string path)
        {
            bool check = false;
            Console.WriteLine("\tId\t\tName\t\t\tMark Attendence");
            for (int i=0;i<id.Count;i++)
           {
                Console.Write("\t" + id[i]);
                Console.Write("\t\t" + name[i]);
                if ((name[i].ToString()).Length <= 7)
                {
                    Console.Write("\t\t\t");
                    attendence[i]=Console.ReadLine();
                    check = true;
                }
                else
                {
                    Console.Write("\t\t");
                    attendence[i] = Console.ReadLine();
                    check = true;
                }
            }
            if (check == true)
            {
                Console.WriteLine("\t\t--Attendence was Successfully Marked--");
                File.WriteAllText(path, string.Empty);
                StreamWriter sw = File.AppendText(path);
                for (int i = 0; i < id.Count; i++)
                {
                    sw.WriteLine(id[i].ToString());
                    sw.WriteLine(name[i].ToString());
                    sw.WriteLine(semester[i].ToString());
                    sw.WriteLine(cgpa[i].ToString());
                    sw.WriteLine(department[i].ToString());
                    sw.WriteLine(university[i].ToString());
                    sw.WriteLine(attendence[i].ToString());
                }
                sw.Close();
            }
            Console.ReadKey();
        }

        public void ViewAttendence()
        {
            Console.WriteLine("\tId\t\tName\t\t\tMark Attendence");
            for (int i = 0; i < id.Count; i++)
            {
                Console.Write("\t" + id[i]);
                Console.Write("\t\t" + name[i]);
                if ((name[i].ToString()).Length <= 7)
                {
                    Console.Write("\t\t\t"+attendence[i]+"\n");
                }
                else
                {
                    Console.Write("\t\t"+attendence[i]+"\n"); 
                }
            }
            Console.ReadKey();
        }

    }
    
}

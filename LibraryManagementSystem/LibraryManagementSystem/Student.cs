﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Student
    {
        public int studentID { get; set; }
        public string name { get; set; }

        public Student(int studentID, string name)
        {
            this.studentID = studentID;
            this.name = name;
        }
    }
}

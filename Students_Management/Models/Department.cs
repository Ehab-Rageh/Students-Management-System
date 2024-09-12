﻿namespace Students_Management.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Head { get; set; }
        public List<Department_Instructor>? Instructors { get; set; }
    }
}

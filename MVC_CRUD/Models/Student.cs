using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CRUD.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Age { get; set; }
        public string Class { get; set; }
        public DateTime AdmissionDate { get; set; }
    }
}
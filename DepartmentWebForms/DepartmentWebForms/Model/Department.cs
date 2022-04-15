using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DepartmentWebForms.Model
{
    public class Department
    {
        public int departmentId { get; set; }
        public string departmentCode { get; set; }
        public string departmentName { get; set; }
        public int isActive { get; set; }
    }
}
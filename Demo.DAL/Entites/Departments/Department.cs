using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Entites.Departments
{
    public class Department :ModelBase //Department Is A Model Base
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Code { get; set; }= null!;
        public DateOnly CreationDate { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTOS.School.Stages;

public class AddDivisionDTO
{
     public string DivisionName { get; set; } = string.Empty;
     public int ClassID { get; set; } = 1;
     
}

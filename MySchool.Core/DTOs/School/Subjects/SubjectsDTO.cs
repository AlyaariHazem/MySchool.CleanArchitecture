using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTOS.School.Subjects;

public class SubjectsDTO
{
    public int? SubjectID { get; set; }
    public string? SubjectName { get; set; }
    public string? SubjectReplacement { get; set; }
    public string? Note { get; set; }
    public DateTime HireDate { get; set; }= DateTime.Now;
}

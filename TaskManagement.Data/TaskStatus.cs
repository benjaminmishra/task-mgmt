using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Data;

public class TaskStatus
{
    [Key]
    public int Id { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }
}

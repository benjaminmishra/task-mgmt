using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagement.Data;

public class Step
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int Serial { get; set; }
    public string Description { get; set; }

    public int TaskId { get; set; }

    [ForeignKey("TaskId")]
    public Task Task { get; set; }
}

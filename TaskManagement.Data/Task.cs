﻿namespace TaskManagement.Data;
using System.ComponentModel.DataAnnotations.Schema;

public class Task
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public List<Step> Steps { get; set; }
}
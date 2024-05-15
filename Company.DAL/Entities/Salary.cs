using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Company.DAL.Entities;

public partial class Salary
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SalaryId { get; set; }

    public double ConstractSalary { get; set; }

    public int DaysOff { get; set; }

    public DateOnly PayDate { get; set; }

    public double TotalSalary { get; set; }

    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }



}

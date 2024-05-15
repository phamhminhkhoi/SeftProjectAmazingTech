using Company.DAL.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.DAL.Entities;

public partial class User : IdentityUser
{
    public Role Role { get; set; }
    public string Address {  get; set; }
    public string FullName {  get; set; }

    public ICollection<Salary> Salaries { get; set; }
    public ICollection<Application> Applications { get; set; }

}

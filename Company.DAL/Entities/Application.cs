using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Company.DAL.Entities;

public partial class Application
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ApplicationId { get; set; }

    public string ApplicationType { get; set; } = null!;

    public string ApplicationName { get; set; } = null!;

    public string? ApplicationDescription { get; set; }
    public string ApplicationImageUrl { get; set; }
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }


}

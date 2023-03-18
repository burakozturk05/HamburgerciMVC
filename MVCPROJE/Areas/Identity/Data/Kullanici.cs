using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MVCPROJE.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Kullanici class
public class Kullanici : IdentityUser
{
    public string Name { get; set; }
    public string SurName { get; set; }

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MehmetApp.MVCUI.Identity
{
    public class ApplicationRole:IdentityRole
    {
        public string Description { get; set; }// Rol ile ilgili açıklama , örneğin admin rolüne kimler sahip olabilir gibi 

        public ApplicationRole()
        {
            
        }

        public ApplicationRole(string rolename,string description)
        {
            this.Description = description;
        }
    }
}
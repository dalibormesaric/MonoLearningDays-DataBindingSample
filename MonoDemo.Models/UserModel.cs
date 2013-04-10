using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MonoDemo.Models.Localization;

namespace MonoDemo.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(DefaultResources), ErrorMessageResourceName = "UserModel_FirstName_Required"),
        StringLength(20, ErrorMessageResourceType = typeof(DefaultResources), ErrorMessageResourceName = "UserModel_FirstName_Valid")]
        public string FirstName { get; set; }
        [Required(ErrorMessageResourceType = typeof(DefaultResources), ErrorMessageResourceName = "UserModel_LastName_Required"),
        StringLength(20, ErrorMessageResourceType = typeof(DefaultResources), ErrorMessageResourceName = "UserModel_LastName_Valid")]
        public string LastName { get; set; }
    }
}

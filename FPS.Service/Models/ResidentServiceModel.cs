using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLite;

namespace FPS.Service.Models
{
    [TsClass]
    public class ResidentServiceModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public string ContactNumber3 { get; set; }
        public int MembersLiving { get; set; }
        public DateTime LivingStart { get; set; }
        public DateTime? LivingEnd { get; set; }
        public bool OnRent { get; set; }
        public bool IsDeleted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLite;

namespace FPS.Service.Models
{
    [TsClass]
    public class ApartmentServiceModel
    {
        public int Id { get; set; }
        public int ResidentId { get; set; }
        public bool OnRent { get; set; }
        public int Number { get; set; }
        public int OwnerId { get; set; }
        public bool IsDeleted { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public string ContactNumber3 { get; set; }
        public int MembersLiving { get; set; }
        public DateTime LivingStart { get; set; }
        public DateTime? LivingEnd { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerMiddleName { get; set; }
        public string OwnerLastName { get; set; }
        public string OwnerContactNumber1 { get; set; }
        public string OwnerContactNumber2 { get; set; }
        public string OwnerContactNumber3 { get; set; }
        public int OwnerMembersLiving { get; set; }
        public DateTime OwnerLivingStart { get; set; }
        public DateTime? OwnerLivingEnd { get; set; }
    }
}

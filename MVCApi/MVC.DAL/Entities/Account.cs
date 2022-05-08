using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DAL.Entities
{
    [Table("Accounts")]
    public class Account : BaseEntity
    {
        
        public string AccountName { get; set; }

        public virtual ICollection<Contact> Contact { get; set; }

        [ForeignKey(nameof(IncidentName))]
        public virtual Incident Incident { get; set; }

        public string IncidentName { get; set; }
    }
}

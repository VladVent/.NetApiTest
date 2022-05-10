using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DAL.Entities
{
    [Table("Incidents")]
    public class Incident
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string IncidentName { get; set; } = Guid.NewGuid().ToString();
        public string IncidentDescription { get; set; }

        //[Required]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}

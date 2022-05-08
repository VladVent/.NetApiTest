using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DAL.Entities
{
    [Table("Contacts")]
    public class Contact : BaseEntity
    {
        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }

        public int AccountId { get; set; }

        public string ContactFirstName { get; set; }

        public string ContactLastName { get; set; }

        public string ContactEmail { get; set; }
    }
}

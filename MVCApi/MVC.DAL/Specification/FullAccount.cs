using MVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DAL.Specification
{
    public class FullAccount : BaseSpecification<Account>
    {
        public FullAccount()
        {
            AddInclude(x => x.Incident);
            AddInclude(x => x.Contact);
        }

        public FullAccount(int id):
            base(x => x.Id == id)
        {
            AddInclude(x => x.Incident);
            AddInclude(x => x.Contact);
        }
    }
}

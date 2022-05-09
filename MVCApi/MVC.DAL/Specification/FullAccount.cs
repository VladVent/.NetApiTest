using MVC.DAL.Context;
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
        public FullAccount(string a)
        : base (x=>x.AccountName == a)
        {
                AddInclude(x => x.Incident);
                AddInclude(x => x.Contact);
        }

    }
}

using MVC.DAL.Entities;
using MVC.DAL.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVC.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<object> GetAccountByName(bool comp);
        Task<T> GetAccountByName(string name);
        Task<T> GetAccountByName(ISpecification<T> spec);
        string UpdateContacts(Contact contact, string name);
        string UpdateInsedentDescription(Incident incident, string name);
        void CreatAccount(Incident incident);
    }
}

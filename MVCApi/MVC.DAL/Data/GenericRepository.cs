﻿using Microsoft.EntityFrameworkCore;
using MVC.DAL.Context;
using MVC.DAL.Entities;
using MVC.DAL.Interfaces;
using MVC.DAL.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DAL.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ContextMVC _context;

        public GenericRepository(ContextMVC context)
        {
            _context = context;
        }

        public Task<object> GetAccountByName(bool comp)
        {
            throw new NotImplementedException();
        }



        public async Task<T> GetAccountByName(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public Task<T> GetAccountByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public Task ListAsync(FullAccount spec)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        
        

        public string UpdateContacts(Contact contact, string name)
        {
            var item = _context.Accounts.FirstOrDefault(x => x.AccountName == name);
            if (item != null)
                item.Contact = new List<Contact>
                 {
                     new Contact
                     {

                         ContactFirstName = contact.ContactFirstName,
                         ContactLastName = contact.ContactLastName,
                         ContactEmail =contact.ContactEmail,
                     }
                };
            _context.Update(item);
            _context.SaveChanges();
            return "Hey!! Data Updated Successfully...";
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpesificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }

    }
}

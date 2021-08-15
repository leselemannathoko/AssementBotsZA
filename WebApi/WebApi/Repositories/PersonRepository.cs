using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private IDataContext _context;

        public PersonRepository(IDataContext context) 
        {
            _context = context;
        }

        public IDataContext Context { get; }

        public async Task Add(People people)
        {
            _context.Person.Add(people);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var personTodelete = await _context.Person.FindAsync(id);
            if (personTodelete == null)
                throw new NullReferenceException();

            _context.Person.Remove(personTodelete);
            await _context.SaveChangesAsync();
        }

        public async Task<People> Get(int id)
        {
            return await _context.Person.FindAsync(id);
        }

        public async Task<IEnumerable<People>> GetAll()
        {
            return await _context.Person.ToListAsync();
        }

        public async Task update(People people)
        {
            var PersonToUpdate = await _context.Person.FindAsync(people.Id);
            if (PersonToUpdate == null)
                throw new NullReferenceException();

            PersonToUpdate.Name = people.Name;
            PersonToUpdate.Email = people.Email;
            PersonToUpdate.ProgrammingLanguage = people.ProgrammingLanguage;
            PersonToUpdate.Surname = people.Surname;
            await _context.SaveChangesAsync();
        }
    }
}

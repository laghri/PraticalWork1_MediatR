using FirstAppWorkHahn.Data;
using FirstAppWorkHahn.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace FirstAppWorkHahn.Repositores
{
    public class EmployesRepository : IGenericRepository<Employes>
    {
        private readonly FirstAppWorkHahnContext _context;
        public EmployesRepository(FirstAppWorkHahnContext context)
        {
            _context = context;
        }

       async Task<Employes> IGenericRepository<Employes>.Add(Employes employes)
        {
           _context.Employes.Add(employes);
            await _context.SaveChangesAsync();
            return employes;
        }

      async  Task IGenericRepository<Employes>.Delete(Guid id)
        {
            var employes = await _context.Employes.FindAsync(id);
            if (employes != null)
            {
                _context.Employes.Remove(employes);
                await _context.SaveChangesAsync();
            }

          

            
        }

      async    Task<IEnumerable<Employes>> IGenericRepository<Employes>.GetAll()
        {
            var Employes = await _context.Set<Employes>().ToListAsync();

            if (Employes == null || !Employes.Any())
            {
                return Enumerable.Empty<Employes>(); // Or you can return null or handle it differently based on your requirements
            }

            return Employes;
        }

       async Task<Employes> IGenericRepository<Employes>.GetById(Guid id)
        {
            var employes = await _context.Employes.FindAsync(id);
/*
            if (employes == null)
            {
                return NotFound();
            }*/

            return employes;
        }

        async   Task<Boolean> IGenericRepository<Employes>.Update(Employes employes)
        {

            var existingEmployee = _context.Employes.Find(employes.Id);

            if (existingEmployee != null)
            {
                existingEmployee.Name = employes.Name;
                existingEmployee.Salaire = employes.Salaire;
                existingEmployee.Specialite = employes.Specialite;

                _context.Entry(existingEmployee).State = EntityState.Modified;


                await _context.SaveChangesAsync();
                return true;
            }


            else
            {
                return false;
            }
     







            }

            
        }
    }


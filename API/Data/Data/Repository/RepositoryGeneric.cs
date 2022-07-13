using Data.Config;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository 
{
    public class RepositoryGeneric<T> : IGeneric<T>, IDisposable where T : class 
    {

        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        public RepositoryGeneric() 
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task Add(T Objeto) 
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                await data.Set<T>().AddAsync(Objeto);
                await data.SaveChangesAsync(); 
            }
        }

        public async Task Delete(T Objeto) {
            using (var data = new ContextBase(_optionsBuilder)) {
                data.Set<T>().Remove(Objeto);
                await data.SaveChangesAsync(); 
            }
        }

        public async Task<T> GetEntityById(int Id) {
            using (var data = new ContextBase(_optionsBuilder)) {
               return await data.Set<T>().FindAsync(Id);
            }
        }

        public async Task<List<T>> List() {
            using (var data = new ContextBase(_optionsBuilder)) {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        public async Task Update(T Objeto) {
            using (var data = new ContextBase(_optionsBuilder)) {
                data.Set<T>().Update(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public void Dispose() {
            throw new NotImplementedException();
        }
    }
}

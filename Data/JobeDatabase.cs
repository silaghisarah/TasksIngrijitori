using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksIngrijitori.Models;

namespace TasksIngrijitori.Data
{
    public class JobsDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public JobsDatabase(string dbPath) { 
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ListaJobs>().Wait();
            _database.CreateTableAsync<Job>().Wait(); 
            _database.CreateTableAsync<JobList>().Wait();
            _database.CreateTableAsync<Client>().Wait();
        }
        public Task<List<ListaJobs>> GetShopListsAsync() { return _database.Table<ListaJobs>().ToListAsync(); }
        public Task<ListaJobs> GetShopListAsync(int id) { return _database.Table<ListaJobs>().Where(i => i.ID == id).FirstOrDefaultAsync(); }
        public Task<int> SaveShopListAsync(ListaJobs slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else { return _database.InsertAsync(slist); }
        }
        public Task<int> DeleteShopListAsync(ListaJobs slist) 
        { return _database.DeleteAsync(slist);
        }
        public Task<int> SaveProductAsync(Job obiectiv) 
        {
            if (obiectiv.ID != 0) 
            { 
                return _database.UpdateAsync(obiectiv); 
            }
            else 
            {
                return _database.InsertAsync(obiectiv); 
            }
        }
        public Task<int> DeleteProductAsync(Job obiectiv) 
        {
            return _database.DeleteAsync(obiectiv); 
        }
        public Task<List<Job>> GetProductsAsync()
        { return _database.Table<Job>().ToListAsync(); }
        public Task<int> SaveListProductAsync(JobList listp) { if (listp.ID != 0) { return _database.UpdateAsync(listp); } else { return _database.InsertAsync(listp); } }
        public Task<List<Job>> GetListProductsAsync(int listaobiectiveid)
        {
            return _database.QueryAsync<Job>(
            "select O.ID, O.Description from Job O"
            + " inner join JobList OL" 
            + " on O.ID = OL.JobID where OL.ListaJobsID = ?", 
            
            listaobiectiveid);
        }
        public Task<List<Client>> GetShopsAsync() 
        {
            return _database.Table<Client>().ToListAsync(); 
        }
        public Task<int> SaveShopAsync(Client apartament) 
        {
            if (apartament.ID != 0) { return _database.UpdateAsync(apartament); } else { return _database.InsertAsync(apartament); } }

        public Task<int> DeleteShopAsync(Client apartament)
        {
            return _database.DeleteAsync(apartament);
        }
    }
}

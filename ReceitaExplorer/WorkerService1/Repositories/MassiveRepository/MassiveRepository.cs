
using Microsoft.EntityFrameworkCore;
using WorkerService1.Context;

namespace WorkerService1.Repositories.MassiveRepository
{
    public class MassiveRepository : IMassiveRepository
    {
        private readonly AppDbContext _appDbContext;

        public MassiveRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task InsertDataAsync<T>(List<T> entities) where T : class
        {
            int totalCount = entities.Count;
            bool IsBigData = totalCount >= 100_000;
            bool IsMediumDataVolume = totalCount >= 10_000;

            if (IsBigData)
            {
                await BulkInsertAsync(entities);
                return;
            }
            if (IsMediumDataVolume)
            {
                await AddManyAsync(entities, batchSize: 10_000);
                return;
            }
            try
            {
                await AddManyAsync(entities);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                    }
        }
        private async Task AddManyAsync<T>(List<T> entities) where T : class
        {
            DbSet<T> dbSet = _appDbContext.Set<T>();
            await dbSet.AddRangeAsync(entities);
            await _appDbContext.SaveChangesAsync();
        }
        private async Task AddManyAsync<T>(List<T> entities, int batchSize) where T : class
        {
            DbSet<T> dbSet = _appDbContext.Set<T>();

            var entityType = _appDbContext.Model.FindEntityType(typeof(T));
            if (entityType == null)
            {
                throw new Exception($" tipo{typeof(T)}desconhecido");
            }

            for (int count = 0; count < entities.Count; count += batchSize)
            {
                var batch = entities.Skip(count).Take(batchSize).ToList();
                await dbSet.AddRangeAsync(batch);
                await _appDbContext.SaveChangesAsync();
                _appDbContext.ChangeTracker.Clear();
            }

        }
        private async Task BulkInsertAsync<T>(List<T> entities) where T : class
        {
           
            await _appDbContext.BulkInsertAsync(entities, options =>
            {
                options.BatchSize = 100_000;
            }
        );
        }
    }
}

using MongoDB.Driver;
using RealEstateManagement.Application.Contracts.Presistence;
using RealEstateManagement.Domain.Base;
using RealEstateManagement.Domain.Common.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Persistence.Repositories
{
    public class MongoRepository<Entity> : IAsyncRepository<Entity> 
        where Entity : AuditableEntity, IAggregateRoot
    {
        private readonly IMongoCollection<Entity> _collection;
        private readonly FilterDefinitionBuilder<Entity> _filterBuilder = Builders<Entity>.Filter;

        public MongoRepository(IMongoClient client)
        {
            var database = client.GetDatabase("RealEstateManagementDb");
            _collection = database.GetCollection<Entity>(GetCollectionName(typeof(Entity)));
        }

        public async Task<Guid> CreateAsync(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _collection.InsertOneAsync(entity);

            return entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var filter = _filterBuilder.Eq(e => e.Id, id);

            await _collection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await _collection.Find(_filterBuilder.Empty).ToListAsync();
        }

        public async Task<IEnumerable<Entity>> GetAllAsync(Expression<Func<Entity, bool>> filter)
        {
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<Entity> GetAsync(Expression<Func<Entity, bool>> filter)
        {
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<Entity> GetByIdAsync(Guid id)
        {
            var filter = _filterBuilder.Eq(e => e.Id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var filter = _filterBuilder.Eq(e => e.Id, entity.Id);

            await _collection.ReplaceOneAsync(filter, entity);
        }

        private string GetCollectionName(Type entityType)
        {
            return ((CollectionAttribute)entityType.GetCustomAttributes(
                    typeof(CollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }
    }
}

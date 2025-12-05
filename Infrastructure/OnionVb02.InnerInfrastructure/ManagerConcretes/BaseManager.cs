using AutoMapper;
using OnionVb02.Application.DTOInterfaces;
using OnionVb02.Application.ManagerInterfaces;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnionVb02.InnerInfrastructure.ManagerConcretes
{
    public abstract class BaseManager<T, U> : IManager<T, U> where T : class, IDto where U : class, IEntity
    {
        private readonly IRepository<U> _repository;
        protected readonly IMapper _mapper;

        public BaseManager(IRepository<U> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository), "Repository null olamaz");
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapper null olamaz");
        }
        public async Task CreateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Entity null olamaz");

            try
            {
                U domainEntity = _mapper.Map<U>(entity);
                if (domainEntity == null)
                    throw new InvalidOperationException("Entity mapping başarısız oldu");

                domainEntity.CreatedDate = DateTime.Now;
                domainEntity.Status = Domain.Enums.DataStatus.Inserted;

                await _repository.CreateAsync(domainEntity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Veri oluşturulurken hata oluştu: {ex.Message}", ex);
            }
        }

        public List<T> GetActives()
        {
            try
            {
                List<U> values = _repository.Where(x => x.Status != Domain.Enums.DataStatus.Deleted).ToList();

                if (values == null)
                    return new List<T>();

                return _mapper.Map<List<T>>(values) ?? new List<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Aktif veriler getirilirken hata oluştu: {ex.Message}", ex);
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                List<U> values = await _repository.GetAllAsync();

                if (values == null)
                    return new List<T>();

                return _mapper.Map<List<T>>(values) ?? new List<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Veriler getirilirken hata oluştu: {ex.Message}", ex);
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id 0'dan büyük olmalıdır", nameof(id));

            try
            {
                U value = await _repository.GetByIdAsync(id);

                if (value == null)
                    throw new KeyNotFoundException($"{id} id'li veri bulunamadı");

                T mappedValue = _mapper.Map<T>(value);
                if (mappedValue == null)
                    throw new InvalidOperationException("Entity mapping başarısız oldu");

                return mappedValue;
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"{id} id'li veri getirilirken hata oluştu: {ex.Message}", ex);
            }
        }

        public List<T> GetPassives()
        {
            try
            {
                List<U> values = _repository.Where(x => x.Status == Domain.Enums.DataStatus.Deleted).ToList();

                if (values == null)
                    return new List<T>();

                return _mapper.Map<List<T>>(values) ?? new List<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Pasif veriler getirilirken hata oluştu: {ex.Message}", ex);
            }
        }

        public List<T> GetUpdateds()
        {
            try
            {
                List<U> values = _repository.Where(x => x.Status == Domain.Enums.DataStatus.Updated).ToList();

                if (values == null)
                    return new List<T>();

                return _mapper.Map<List<T>>(values) ?? new List<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Güncellenmiş veriler getirilirken hata oluştu: {ex.Message}", ex);
            }
        }

        public async Task<string> HardDeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id 0'dan büyük olmalıdır", nameof(id));

            try
            {
                U value = await _repository.GetByIdAsync(id);

                if (value == null)
                    throw new KeyNotFoundException($"{id} id'li veri bulunamadı");

                if (value.Status != Domain.Enums.DataStatus.Deleted)
                    throw new InvalidOperationException("Veri silinebilmesi için pasif olmalıdır");

                await _repository.DeleteAsync(value);
                return $"{id} id'li veri silindi";
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"{id} id'li veri silinirken hata oluştu: {ex.Message}", ex);
            }
        }

        public async Task<string> SoftDeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id 0'dan büyük olmalıdır", nameof(id));

            try
            {
                U value = await _repository.GetByIdAsync(id);

                if (value == null)
                    throw new KeyNotFoundException($"{id} id'li veri bulunamadı");

                if (value.Status == Domain.Enums.DataStatus.Deleted)
                    throw new InvalidOperationException("Veri zaten pasif durumda");

                value.Status = Domain.Enums.DataStatus.Deleted;
                value.DeletedDate = DateTime.Now;
                await _repository.SaveChangesAsync();
                return $"{id} id'li veri pasif hale getirildi";
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"{id} id'li veri pasif hale getirilirken hata oluştu: {ex.Message}", ex);
            }
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Entity null olamaz");

            if (entity.Id <= 0)
                throw new ArgumentException("Entity Id 0'dan büyük olmalıdır", nameof(entity));

            try
            {
                U originalValue = await _repository.GetByIdAsync(entity.Id);

                if (originalValue == null)
                    throw new KeyNotFoundException($"{entity.Id} id'li veri bulunamadı");

                U newValue = _mapper.Map<U>(entity);
                if (newValue == null)
                    throw new InvalidOperationException("Entity mapping başarısız oldu");

                newValue.Status = Domain.Enums.DataStatus.Updated;
                newValue.UpdatedDate = DateTime.Now;
                await _repository.UpdateAsync(originalValue, newValue);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Veri güncellenirken hata oluştu: {ex.Message}", ex);
            }
        }
    }
}

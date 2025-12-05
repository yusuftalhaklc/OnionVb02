using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.CategoryQueries;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.CategoryResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.CategoryHandlers.Read
{
    public class GetCategoryQueryHandler
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        // Todo: Mapper profiles için ödev
        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            List<Category> category = await _categoryRepository.GetAllAsync();

            return category.Select(c => new GetCategoryQueryResult
            {
                Id = c.Id,
                CategoryName = c.CategoryName,
                Description = c.Description
            }).ToList();
        }
    }
}


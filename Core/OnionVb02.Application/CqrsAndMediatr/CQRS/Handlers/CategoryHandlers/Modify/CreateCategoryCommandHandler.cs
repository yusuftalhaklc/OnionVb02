using AutoMapper;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.CategoryHandlers.Modify
{
    public class CreateCategoryCommandHandler
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateCategoryCommand command)
        {
            var category = _mapper.Map<Category>(command);
            category.Status = Domain.Enums.DataStatus.Inserted;
            category.CreatedDate = DateTime.Now;
            
            await _repository.CreateAsync(category);
        }
    }
}


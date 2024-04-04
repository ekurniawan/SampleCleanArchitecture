using AutoMapper;
using MediatR;
using SampleCleanArchitecture.Application.Contracts.Persistence;
using SampleCleanArchitecture.Domain.Entities;

namespace SampleCleanArchitecture.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Category> _categoryRepository;

        public CreateCategoryCommandHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var createCategoryCommandResponse = new CreateCategoryCommandResponse();
            var category = new Category
            {
                Name = request.Name,
            };

            var createCategoryCommandValidator = new CreateCategoryCommandValidator();
            var validationResult = await createCategoryCommandValidator.ValidateAsync(request);

            //jika ditemukan kesalahan / input tidak valid
            if (validationResult.Errors.Count > 0)
            {
                createCategoryCommandResponse.Success = false;
                createCategoryCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createCategoryCommandResponse.Success)
            {
                category = await _categoryRepository.AddAsync(category);
                createCategoryCommandResponse.Category = _mapper.Map<CreateCategoryDto>(category);

            }

            return createCategoryCommandResponse;
        }
    }
}

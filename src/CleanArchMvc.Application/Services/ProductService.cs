using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using MediatR;

namespace CleanArchMvc.Application.Services;

public class ProductService : IProductService
{
    public IMediator _mediator;
    public IMapper _mapper;

    public ProductService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
    {
        var productsQuery = new GetProductsQuery();

        if (productsQuery == null)
            throw new Exception("Entity could not be loaded.");

        var result = await _mediator.Send(productsQuery);

        return _mapper.Map<IEnumerable<ProductDTO>>(result);
    }

    public async Task<ProductDTO> GetByIdAsync(int? id)
    {
        var productQuery = new GetProductByIdQuery(id.Value);

        if (productQuery == null)
            throw new Exception("Entity could not be loaded.");

        var result = await _mediator.Send(productQuery);

        return _mapper.Map<ProductDTO>(result);
    }

    public async Task<ProductDTO> GetProductCategoryAsync(int? id)
    {
        var productQuery = new GetProductByIdQuery(id.Value);

        if (productQuery == null) throw new Exception("Entity could not be loaded.");

        var result = await _mediator.Send(productQuery);

        return _mapper.Map<ProductDTO>(result);
    }

    public async Task AddAsync(ProductDTO productDto)
    {
        var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);
        await _mediator.Send(productCreateCommand);
    }

    public async Task UpdateAsync(ProductDTO productDto)
    {
        var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDto);
        await _mediator.Send(productUpdateCommand);
    }

    public async Task RemoveAsync(int? id)
    {
        var productRemoveCommand = new ProductRemoveCommand(id.Value);

        if (productRemoveCommand == null) throw new Exception("Entity could not be loaded.");

        await _mediator.Send(productRemoveCommand);
    }
}

using DapperApp.Web.DTOs.Products;

namespace DapperApp.Web.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<ResultProductDto>> GetAllAsync();
        Task<UpdateProductDto> GetByIdAsync(int id);
        Task CreateAsync(CreateProductDto ProductDto);
        Task UpdateAsync(UpdateProductDto ProductDto);
        Task DeleteAsync(int id);
        Task ChangeStatusAsync(int id);
    }
}

using Dapper;
using DapperApp.Web.Context;
using DapperApp.Web.DTOs.Categories;

namespace DapperApp.Web.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CreateCategoryDto categoryDto)
        {
            string query = "INSERT INTO categories (Name) VALUES (@CategoryName)";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryName", categoryDto.Name);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "DELETE FROM categories WHERE CategoryId = @CategoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
        

        public async Task<IEnumerable<ResultCategoryDto>> GetAllAsync()
        {
            string query = "select * from categories";
            var connection = _context.CreateConnection();
            return await connection.QueryAsync<ResultCategoryDto>(query);
        }

        public async Task<UpdateCategoryDto> GetByIdAsync(int id)
        {
            string query = "select * from categories where CategoryId = @CategoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", id);
            var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<UpdateCategoryDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdateCategoryDto categoryDto)
        {
            string query = "UPDATE categories SET Name = @CategoryName WHERE CategoryId = @CategoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", categoryDto.CategoryId);
            parameters.Add("@CategoryName", categoryDto.Name);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}

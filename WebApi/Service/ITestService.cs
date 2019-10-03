using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.EntityFrameworkCore;
using WebApi.Model;

namespace WebApi.Service
{
    public interface ITestService
    {
        Task SeedData();

    }
    public class TestService: ITestService
    {
        private readonly ApplicationDbContext _context;
        public TestService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task SeedData()
        {
            if(_context.Products.Count() > 0)
            {
                return;
            }
            var testCategory = new Faker<Category>()
                .RuleFor(o => o.Name, f => f.Name.FullName())
                .RuleFor(o => o.Description, f => f.Lorem.Paragraph());

            var testReview = new Faker<Review>()
                .RuleFor(o => o.Name, f => f.Name.FullName())
                .RuleFor(o => o.Comment, f => f.Lorem.Paragraph())
                .RuleFor(o => o.Rating, f => f.Random.Int(1,5));

            var testCategoryProduct = new Faker<CategoryProduct>()
                .RuleFor(c => c.Category, f=>testCategory.Generate());

            var testProduct = new Faker<Product>()
                .RuleFor(p => p.Name, f => f.Name.FullName())
                .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
                .RuleFor(p => p.Price, f => f.Random.Decimal(100, 200))
                .RuleFor(p => p.Reviews, f => testReview.Generate(5).ToList())
                .RuleFor(p => p.ProductCategory, f => testCategoryProduct.Generate(3).ToList());

            var products = testProduct.Generate(50);
            await _context.AddRangeAsync(products);
            await _context.SaveChangesAsync();

        }
    }
}

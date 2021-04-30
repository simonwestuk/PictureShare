using PictureShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureShare.Repository
{
    public class MockUnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Category { get; set; }

        public MockUnitOfWork()
        {
            Category = new MockCategoryRepository(GenerateCategories());

        }

        public async Task Save()
        {
            await Task.Delay(1);
        }

        public List<CategoryModel> GenerateCategories()
        {
            List<CategoryModel> categories = new List<CategoryModel>();

            categories.Add(new CategoryModel
            {
                Id = 1,
                Name = "TestCat1"
            });

            categories.Add(new CategoryModel
            {
                Id = 2,
                Name = "TestCat2"
            });

            categories.Add(new CategoryModel
            {
                Id = 3,
                Name = "TestCat3"
            });

            return categories;
        }
    }
}

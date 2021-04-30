using PictureShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureShare.Repository
{
    public class MockCategoryRepository : MockRepository<CategoryModel>, ICategoryRepository
    {
        private readonly List<CategoryModel> _db;
        public MockCategoryRepository(List<CategoryModel> db) : base(db)
        {
            _db = db;
        }

        public async Task Update(CategoryModel category)
        {
            var obj = _db.Find(c => c.Id == category.Id);
            await Task.Delay(1);
            obj = category;

        }
    }
}

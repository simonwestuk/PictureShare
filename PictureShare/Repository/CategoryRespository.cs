using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PictureShare.Data;
using PictureShare.Models;

namespace PictureShare.Repository
{
    public class CategoryRespository : Repository<CategoryModel>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRespository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task Update(CategoryModel category)
        {
            var cat = await _db.Category.FirstOrDefaultAsync(c => c.Id == category.Id);

            if (cat != null)
            {
                cat.Name = category.Name;
            }


        }
    }
}

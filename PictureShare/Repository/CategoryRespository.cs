using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}

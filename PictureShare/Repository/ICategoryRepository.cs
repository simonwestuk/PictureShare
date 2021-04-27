using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PictureShare.Models;

namespace PictureShare.Repository
{
    public interface ICategoryRepository : IRepository<CategoryModel>
    {
        Task Update(CategoryModel category);
    }
}

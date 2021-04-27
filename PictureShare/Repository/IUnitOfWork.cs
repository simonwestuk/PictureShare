using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureShare.Repository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; set; }

        Task Save();
    }
}

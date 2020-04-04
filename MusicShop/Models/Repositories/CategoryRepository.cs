using MusicShop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public IEnumerable<Category> AllCategories
        {
            get
            {
                return _appDbContext.Categories;
            }
        }

        public Category GetCategoryById(int categoryId)
        {
            return _appDbContext.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
        }

        public void CreateCategory(Category category)
        {
            _appDbContext.Categories.Add(category);
            _appDbContext.SaveChanges();
        }


    }
}

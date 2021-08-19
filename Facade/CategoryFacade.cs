using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class CategoryFacade : FacadeBase
    {
        public IList<CategoryDto> GetCategroy()
        {
            var data = (from c in EntityModel.Category
                        select new CategoryDto()
                        {   Id=c.Id,
                            CategoryName = c.CategoryName,
                            CategoryDescription = c.CategoryDescription

                        }).ToList();

            return data;
        }

        public CategoryDto GetCategoryById(int categoryid)
        {
            var data = (from c in EntityModel.Category
                        where c.Id == categoryid
                        select new CategoryDto()
                        {
                            Id=c.Id,
                            CategoryName = c.CategoryName,
                            CategoryDescription = c.CategoryDescription

                        }).FirstOrDefault();

            return data;
        }

        public Category CreateCategory(CategoryDto ct)
        {
            var category = new Category
            {
                Id = ct.Id,
                CategoryName = ct.CategoryName,
                CategoryDescription = ct.CategoryDescription,
            };
            EntityModel.Category.Add(category);
            EntityModel.SaveChanges();

            return category;
        }

        public KeyValuePair<bool, string> UpdateCategory(CategoryDto categoryDto)
        {
            var result = new KeyValuePair<bool, string>(true, "Başarılı");

            try
            {
                var modifiedEntityCategory = EntityModel.Category.FirstOrDefault(x => x.Id == categoryDto.Id);
                ConvertDtoModelToUpdate(categoryDto, modifiedEntityCategory);
                EntityModel.SaveChanges();
                
            }
            catch (Exception ex)
            {
                result = new KeyValuePair<bool, string>(false, ex.Message);
            }

            return result;
        }

        private Category ConvertDtoModelToUpdate(CategoryDto categoryDto, Category category)
        {
            category.Id = categoryDto.Id;
            category.CategoryName = categoryDto.CategoryName;
            category.CategoryDescription = categoryDto.CategoryDescription;
            return category;
        }

        public KeyValuePair<bool, string> DeleteCategory(int id)
        {
            var result = new KeyValuePair<bool, string>(true, "Başarılı");
            try
            {
                var category = EntityModel.Category.FirstOrDefault(x => x.Id == id);
                if (category == null)
                    result = new KeyValuePair<bool, string>(false, "İlgili Kayıt Bulunamadı");
                else
                {
                    var categoryDto = EntityModel.Category.Remove(category);
                    EntityModel.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                result = new KeyValuePair<bool, string>(false, ex.Message);
            }
            return result;
        }



    }
}

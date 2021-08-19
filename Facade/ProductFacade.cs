using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class ProductFacade : FacadeBase
    {
        public IList<ProductDto> GetProduct()
        {
            var data = (from p in EntityModel.Products
                        join c in EntityModel.Category on p.CategoryId equals c.Id
                        select new ProductDto()
                        {
                            Id = p.Id,
                            CategoryName=c.CategoryName,
                            ProductName = p.ProductName,
                            SerialNumber = p.SerialNumber,
                            StockQuantity = p.StockQuantity,
                            Description = p.Description,
                            Price = p.Price,
                        }).ToList();

            return data;
        }

        public ProductDto GetProductById(int productid)
        {
            var data = (from p in EntityModel.Products
                        join c in EntityModel.Category on p.CategoryId equals c.Id
                        where p.Id == productid
                        select new ProductDto()
                        {
                            Id = p.Id,
                            CategoryName=c.CategoryName,
                            ProductName = p.ProductName,
                            SerialNumber = p.SerialNumber,
                            StockQuantity = p.StockQuantity,
                            Description = p.Description,
                            Price = p.Price,
                        }).FirstOrDefault();

            return data;
        }

        public KeyValuePair<bool,string> CreateProduct(ProductDto product)
        {
            var result = new KeyValuePair<bool, string>(true, "Başarılı");
            try
            {
                var productCreate = new Product
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    SerialNumber = product.SerialNumber,
                    StockQuantity = product.StockQuantity,
                    Description = product.Description,
                    Price = product.Price,
                    CategoryId= product.CategoryId,
                    CreatedOn = DateTime.Now,
                    ModifiedON = DateTime.Now
                };
                EntityModel.Products.Add(productCreate);
                EntityModel.SaveChanges();

            }
            catch (Exception ex)
            {
                result= new KeyValuePair<bool, string>(false,ex.Message);
            }
            return result;
        }



        public KeyValuePair<bool, string> UpdateProduct(ProductDto productDto)
        {
            var result = new KeyValuePair<bool, string>(true, "Başarılı");
            try
            {
                var modifiedEntityProduct = EntityModel.Products.FirstOrDefault(x => x.Id == productDto.Id);
                ConvertProductDtoModelToUpdate(productDto, modifiedEntityProduct);
                EntityModel.SaveChanges();
            }
            catch (Exception ex)
            {
                result = new KeyValuePair<bool, string>(false, ex.Message);
            }
            return result;  
        }
        
        private Product ConvertProductDtoModelToUpdate(ProductDto productDto,Product product)
        {
            product.Id = productDto.Id;
            product.ProductName = productDto.ProductName;
            product.SerialNumber = productDto.SerialNumber;
            product.StockQuantity = productDto.StockQuantity;
            product.Description = productDto.Description;
            product.CategoryId = productDto.CategoryId;
            product.Price = productDto.Price;
            product.ModifiedON = DateTime.Now;

            return product;
        }
        
        public KeyValuePair<bool,string> DeleteProduct(int id)
        {
            var result = new KeyValuePair<bool,string>(true,"Başarılı");

            try
            {
                var product = EntityModel.Products.FirstOrDefault(x => x.Id == id);
               
                if (product == null)
                    result = new KeyValuePair<bool, string>(false, "İlgili Kayıt Bulunamadı");
                else
                {
                    var productDto = EntityModel.Products.Remove(product);
                    EntityModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result = new KeyValuePair<bool, string>(false, ex.Message);
            }
            return result;
        }
    }
}

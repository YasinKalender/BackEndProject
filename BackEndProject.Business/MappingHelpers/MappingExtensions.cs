using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEndProject.DTOs.DTO.ProductDTOs;
using BackEndProject.DTOs.DTO.UserDTOs;

namespace BackEndProject.Business.MappingHelpers
{
    public static class MappingExtensions
    {
        public static ProductDto GetProductDto(this Entities.ORM.Concrete.Product product)
        {

            return new ProductDto()
            {
                CategoryId = product.CategoryId,
                ProductName = product.ProductName,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock


            };


        }

        public static UserRegisterDto UserRegisterDto(this Entities.ORM.Concrete.User user)
        {

            return new UserRegisterDto()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,


            };

        }

        public static UserLoginDto UserLoginDto(this Entities.ORM.Concrete.User user)
        {

            return new UserLoginDto()
            {
                Email = user.Email,


            };

        }

        public static Entities.ORM.Concrete.User Map(this UserRegisterDto user)
        {

            return new Entities.ORM.Concrete.User()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,


            };

        }
    }
}

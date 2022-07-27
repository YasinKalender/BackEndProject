using BackEndProject.DTOs.DTO.ProductDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Business.Validation
{
    public class ProductDtoValidator:AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(i => i.ProductName).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(i => i.ProductName).Must(ValidateProductName);
        }


        private bool ValidateProductName(string arg) {

            if (arg.Length>0)
            {
                return true;
            }

            return false;
        
        }

    }
}

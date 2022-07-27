using BackEndProject.DTOs.DTO.UserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Business.Validation
{
    public class UserForRegisterDtoValidator:AbstractValidator<UserRegisterDto>
    {
        public UserForRegisterDtoValidator()
        {
            RuleFor(i => i.FirstName).NotNull().WithMessage("İsim alanı zorunludur");
        }

    }
}

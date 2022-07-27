using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Business.Validation
{
    public interface IValidator<T> where T : class
    {
        bool Validate(T entity, out string validationMessage);

    }
}

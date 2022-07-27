using BackEndProject.Business.Interceptor;
using Castle.DynamicProxy;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Business.Validation
{
    public class ValidationAspect: MethodInterception
    {

        Type _validatorType;
        public ValidationAspect(Type validator)
        {
            if (!typeof(IValidator).IsAssignableFrom(validator))
            {
                throw new Exception("Hata");
            }    
            _validatorType = validator;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(i => i.GetType() == entityType);
            foreach (var item in entities)
            {
                ValidationVerifaction.Validate(validator, entities);
            }
        }

    }
}

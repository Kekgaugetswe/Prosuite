using Prosuite.Domain.Contracts.Dtos.Requests;
using Prosuite.Domain.Contracts.Interfaces.Services.Domain;
using System.ComponentModel.DataAnnotations;

namespace Prosuite.Domain.Validators
{
    public class ValidatorBase<T> : IValidatorBase<T> where T : BaseRequest
    {
        public List<string> Validate(T data)
        {
            var errors = new List<string>();
            var ctx = new ValidationContext(data);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(data, ctx, results, true))
            {
                foreach (var error in results)
                {
                    if (!string.IsNullOrEmpty(error.ErrorMessage))
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
            }

            var customErrors = CustomValidation(data);

            if (customErrors.Any())
                errors.AddRange(customErrors);


            return errors;
        }



        protected virtual List<string> CustomValidation(T data)
        {

            return new List<string>();
        }

    }
}

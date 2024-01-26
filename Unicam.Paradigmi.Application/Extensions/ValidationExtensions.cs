using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace Unicam.Paradigmi.Application.Extensions
{
    public static class ValidationExtensions
    {

        public static void RegEx<T, TProperty>(this IRuleBuilderOptions<T, TProperty> ruleBuilder, string regex, string validationMessage)
        {
            ruleBuilder.Custom((value, context) =>
            {
                var regEx = new Regex(regex);
                if (regEx.IsMatch(value.ToString()) == false)
                {
                    context.AddFailure(validationMessage);
                }
            });
        }
    }
}

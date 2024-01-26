using FluentValidation;
using System.Text.RegularExpressions;
using Unicam.Paradigmi.Application.Extensions;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Validators
{
    public class CreateTokenRequestValidator : AbstractValidator<CreateTokenRequest>
    {
        public CreateTokenRequestValidator()
        {
            RuleFor(r => r.Username)
                .NotEmpty()
                .WithMessage("Il campo username è obbligatorio")
                .NotNull()
                .WithMessage("Il campo username non può essere nullo");

            RuleFor(r => r.Password)
                .NotEmpty()
                .WithMessage("Il campo password è obbligatorio")
                .NotNull()
                .WithMessage("Il campo password non può essere nullo")
                .MinimumLength(6)
                .WithMessage("Il campo password deve essere almeno lungo 6 caratteri")
                .RegEx("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\\\-]).{6,}$"
                , "Il campo password deve essere lungo almeno 6 caratteri e deve contenere almeno un carattere maiuscolo, uno minuscolo, un numero e un carattere speciale"
                );
                /*.Custom((value, context) =>
                {
                    var regEx = new Regex("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\\\-]).{6,}$");
                    if (regEx.IsMatch(value) == false)
                    {
                        context.AddFailure("Il campo password deve essere lungo almeno 6 caratteri e deve contenere almeno un carattere maiuscolo, uno minuscolo, un numero e un carattere speciale");
                    }
                });*/
        }
    }
}

using FluentValidation;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Validators
{
    public class CreateAziendaRequestValidator : AbstractValidator<CreateAziendaRequest>
    {
        public CreateAziendaRequestValidator()
        {
            RuleFor(m => m.RagioneSociale)
                .NotNull()
                .WithMessage("Il campo ragione sociale è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il campo ragione sociale è obbligatorio (vuoto)")
                .MinimumLength(3)
                .WithMessage("Il campo ragione sociale deve essere lungo almeno 3 caratteri");


            RuleFor(m => m.Citta)
                .Custom(ValidaCitta);
        }

        private void ValidaCitta(string value, ValidationContext<CreateAziendaRequest> context)
        {
            if (value.Length == 0)
            {
                context.AddFailure("Il campo città è obbligatorio");
            }
            //TODO : Fare una query sul database per verificare se la città esiste
        }
    }
}

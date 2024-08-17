namespace AntiFishing.Core.Features.Lakes.Commands.Validations
{
	public class AddLakeValidator : AbstractValidator<AddSensorCommand>
	{
		public AddLakeValidator()
		{
			ApplyValidatorRules();
		}

		public void ApplyValidatorRules()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("You mustn't leave it empty ").NotNull();
		}

		public void ApplyCustomValidatorRules()
		{

		}
	}
}

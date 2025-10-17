using FluentValidation;
using Backend.Application.Dtos;

public class ProdutoValidator : AbstractValidator<ProdutoDto>
{
    public ProdutoValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Preco).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Quantidade).GreaterThanOrEqualTo(0);
    }
}

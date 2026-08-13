using System;

public class TaxCalculator
{
    public virtual decimal CalculateTax(decimal amount)
    {
        return amount * 0.10m;
    }
}

public class RegionalTaxCalculator : TaxCalculator
{
    public sealed override decimal CalculateTax(decimal amount)
    {
        return amount * 0.12m;
    }
}

/*
This produces a compiler error because
CalculateTax() is sealed.

public class InvalidTaxCalculator
    : RegionalTaxCalculator
{
    public override decimal CalculateTax(decimal amount)
    {
        return amount * 0.15m;
    }
}
*/

public sealed class FixedDiscountCalculator
{
    public decimal ApplyDiscount(decimal price)
    {
        return price * 0.90m;
    }
}

/*
This produces a compiler error because
FixedDiscountCalculator is sealed.

public class InvalidDiscountCalculator
    : FixedDiscountCalculator
{
}
*/

class Program
{
    static void Main()
    {
        RegionalTaxCalculator regionalTax =
            new RegionalTaxCalculator();

        decimal tax =
            regionalTax.CalculateTax(200);

        Console.WriteLine(
            $"RegionalTaxCalculator.CalculateTax(200) -> {tax:F2}"
        );

        FixedDiscountCalculator discount =
            new FixedDiscountCalculator();

        decimal discountedPrice =
            discount.ApplyDiscount(50);

        Console.WriteLine(
            $"FixedDiscountCalculator.ApplyDiscount(50) -> {discountedPrice:F2}"
        );
    }
}
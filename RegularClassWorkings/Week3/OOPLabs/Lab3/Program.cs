using System;

public class TaxCalculator
{
    public virtual decimal CalculateTax(decimal amount) => amount * 0.10m;
}

public class RegionalTaxCalculator : TaxCalculator
{
    public sealed override decimal CalculateTax(decimal amount) => amount * 0.12m;
}

public sealed class FixedDiscountCalculator
{
    public decimal ApplyDiscount(decimal price) => price * 0.90m;
}

class Program
{
    static void Main()
    {
        RegionalTaxCalculator regionalTax = new RegionalTaxCalculator();
        Console.WriteLine($"RegionalTaxCalculator.CalculateTax(200) -> {regionalTax.CalculateTax(200):F2}");

        FixedDiscountCalculator discount = new FixedDiscountCalculator();
        Console.WriteLine($"FixedDiscountCalculator.ApplyDiscount(50) -> {discount.ApplyDiscount(50):F2}");
    }
}

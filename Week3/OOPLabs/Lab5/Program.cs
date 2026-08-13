using System;
using System.Collections.Generic;
using System.Linq;

public interface IIdentifiable
{
    string Id { get; }
}

public interface IPaymentMethod : IIdentifiable
{
    string DisplayName { get; }

    PaymentResult Charge(decimal amount);
}

public class PaymentResult
{
    public bool Success { get; }

    public string Message { get; }

    public PaymentResult(
        bool success,
        string message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(
                nameof(message)
            );
        }

        Success = success;
        Message = message;
    }
}

public abstract class PaymentMethodBase
    : IPaymentMethod
{
    public string Id { get; }

    public string DisplayName { get; }

    protected PaymentMethodBase(
        string id,
        string displayName)
    {
        Id = id;
        DisplayName = displayName;
    }

    public abstract PaymentResult Charge(
        decimal amount
    );
}

public class CreditCardPayment
    : PaymentMethodBase
{
    public CreditCardPayment(
        string id,
        string displayName)
        : base(id, displayName)
    {
    }

    public override PaymentResult Charge(
        decimal amount)
    {
        if (amount > 5000)
        {
            return new PaymentResult(
                false,
                "Credit card limit exceeded"
            );
        }

        return new PaymentResult(
            true,
            "Credit card payment successful"
        );
    }
}

public sealed class CashPayment
    : PaymentMethodBase
{
    public CashPayment(
        string id,
        string displayName)
        : base(id, displayName)
    {
    }

    public override PaymentResult Charge(
        decimal amount)
    {
        return new PaymentResult(
            true,
            "Cash payment successful"
        );
    }
}

class Program
{
    static void Main()
    {
        List<IPaymentMethod> paymentMethods =
            new List<IPaymentMethod>
            {
                new CreditCardPayment(
                    "CC-1",
                    "Visa ...1234"
                ),

                new CashPayment(
                    "CASH-1",
                    "Cash Drawer"
                )
            };

        decimal[] amounts =
        {
            1500m,
            6000m
        };

        var settlementReport =
            new List<dynamic>();

        foreach (
            var paymentMethod
            in paymentMethods)
        {
            foreach (decimal amount in amounts)
            {
                PaymentResult result =
                    paymentMethod.Charge(amount);

                settlementReport.Add(
                    new
                    {
                        Id = paymentMethod.Id,

                        DisplayName =
                            paymentMethod.DisplayName,

                        AmountAttempted =
                            amount,

                        Success =
                            result.Success
                    }
                );
            }
        }

        foreach (var report in settlementReport)
        {
            Console.WriteLine(
                $"{report.Id} " +
                $"{report.DisplayName} " +
                $"Attempted={report.AmountAttempted:F2} " +
                $"Success={report.Success}"
            );
        }

        decimal totalSuccessfullySettled =
            settlementReport
                .Where(x => x.Success)
                .Sum(x => x.AmountAttempted);

        Console.WriteLine(
            $"Total successfully settled: " +
            $"{totalSuccessfullySettled:F2}"
        );
    }
}
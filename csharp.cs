using System.Numerics;

BigInteger Fib(BigInteger n)
{
    if (n == 0)
        return 0;
    if (n == 1)
        return 1;

    return Fib(n - 1) + Fib(n - 2);
}

BigInteger FibMemo(BigInteger n, Dictionary<BigInteger, BigInteger> dictionary)
{
    if (n == 0)
    {
        if (!dictionary.ContainsKey(0))
            dictionary.Add(n, 0);
    }
    if (n == 1)
    {
        if (!dictionary.ContainsKey(0))
            dictionary.Add(n, 1);
    }

    if (!dictionary.ContainsKey(n))
    {
        dictionary.Add(n, FibMemo(n - 1, dictionary) + FibMemo(n - 2, dictionary));
    }

    return dictionary[n];
}


double GetFunctionRuntime(BigInteger n, bool memo)
{
    double start = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    if (memo)
    {
        Console.WriteLine("The " + n + "th value of the Fibonacci sequence is " + 
            FibMemo(n, new Dictionary<BigInteger, BigInteger>()));
    }
    else
    {
        Console.WriteLine("The " + n + "th value of the Fibonacci sequence is " + Fib(n));
    }
    double end = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    double differenceAsSeconds = (end - start) / 1000;
    return differenceAsSeconds;
}

Console.WriteLine("Ran for " + GetFunctionRuntime(40, false) + " seconds.");
Console.WriteLine("Ran for " + GetFunctionRuntime(40, true) + " seconds.");

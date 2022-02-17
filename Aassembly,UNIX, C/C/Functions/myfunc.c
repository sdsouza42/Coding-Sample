static int IsPrime(long n)
{
	register long m;

	if(n == 1) return 0; // 1 is not a prime
	if(n == 2 || n == 3) return 1; // 2 and 3 are primes
	if((n % 2) == 0) return 0; // even number greater than 2 is not a prime

	for(m = 3; m * m <= n; m += 2)
	{
		if((n % m) == 0) return 0; 
	}

	return 1;
}

int CountPrimes(long low, long high)
{
	register int count = 0;
	register long n;

	for(n = low; n <= high; ++n)
	{
		count += IsPrime(n);
	}

	return count;
}


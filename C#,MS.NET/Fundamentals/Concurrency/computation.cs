using System;

partial class Computation
{
	public long Compute(int low, int high)
	{
		long result = 0;

		for(int value = low; value <= high; ++value)
		{
			for(int t = Environment.TickCount + 100 * value; Environment.TickCount < t;);
			
			result += value * value;
		}

		return result;
	}

}
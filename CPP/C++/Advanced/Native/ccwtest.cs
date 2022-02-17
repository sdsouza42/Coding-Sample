using System;
using System.Runtime.InteropServices;

namespace METLogistics
{
	[ClassInterface(ClassInterfaceType.AutoDual)]
	public class RoadCargo
	{
		public double QuoteTariff(double weight, int distance)
		{
			return 0.35 * weight * distance + 2000;
		}

		public float EstimateTime(int distance)
		{
			return distance / 50.0f + 1;
		}
	}
}

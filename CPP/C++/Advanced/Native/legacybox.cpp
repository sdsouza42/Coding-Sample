#using <mscorlib.dll>

namespace Legacy
{
	extern "C" int BoxVolume(int, int, int, int);

	public ref class Box
	{
	public:
		Box(int l, int b, int h)
		{
			length = l, breadth = b, height = h;
		}

		int GetInnerVolume(int thickness)
		{
			return BoxVolume(length, breadth, height, thickness);
		}
	private:
		int length, breadth, height;
	};
}

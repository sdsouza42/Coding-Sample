#using <mscorlib.dll>

namespace Greeting
{
	using namespace System;

	public ref class Greeter
	{
	public:
		Greeter(bool r)
		{
			respect = r;
		}

		String^ Greet(String^ name)
		{
			if(respect)
				return "Hello " + name;

			return "Hi " + name;
		}		
	private:
		bool respect;
	};
}






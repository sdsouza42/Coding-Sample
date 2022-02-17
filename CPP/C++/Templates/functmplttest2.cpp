#include <iostream>

using namespace std;

int nidx = 0;

template<typename T>
void PrintIndexed(T value)
{
	cout << "[" << (++nidx) << "] = " << value << endl;
}

template<> //explicit specialization (for T=bool)
void PrintIndexed(bool value)
{
	cout << "[" << (++nidx) << "] = " << (value ? "true" : "false") << endl;
}

int main(void)
{
	double a = 3.14, b = 4.56;
	PrintIndexed(a);
	PrintIndexed(b);

	long c = 197;
	PrintIndexed(c);

	bool d = true, e = false;
	PrintIndexed(d);
	PrintIndexed<bool>(e);
}



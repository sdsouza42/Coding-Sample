#include <iostream>
#include <string>

using namespace std;

template<typename I, typename V> 
class IndexedValue 
{
public:
	IndexedValue(const I& i, const V& v) : index(i), value(v)
	{
	}

	void Print() const
	{
		cout << "[" << index << "] = " << value << endl;
	}
private:
	I index;
	V value;
};

template<typename I>
class IndexedValue<I, bool> //partial specialization
{
public:
	IndexedValue(const I& i, bool v) : index(i), value(v)
	{
	}

	void Print() const
	{
		cout << "[" << index << "] = " << (value ? "yes" : "no") << endl;
	}
private:
	I index;
	bool value;
};

int main(void)
{
	IndexedValue<string, double> a("first", 12.3);
	a.Print();

	IndexedValue<string, bool> b("second", true);
	b.Print();

	IndexedValue<int, bool> c(3, false);
	c.Print();
}


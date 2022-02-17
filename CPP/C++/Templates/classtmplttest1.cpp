#include <iostream>
#include <string>

using namespace std;

template<typename I, typename V> 
class IndexedValue //class template
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

int main(void)
{
	IndexedValue<int, double> a(1, 12.3); //instantiating templated IndexedValue class with I=int, V=double
	a.Print();

	IndexedValue<int, double> b(2, 23.4);
	b.Print();

	IndexedValue<string, long> c("monday", 45); //instantiating templated IndexedValue class with I=string, V=long
	c.Print();


}


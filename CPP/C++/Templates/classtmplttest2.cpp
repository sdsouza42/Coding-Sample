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

template<>
class IndexedValue<int, string> //full specialization
{
public:
	IndexedValue(const string& v) : value(v)
	{
		static int count;
		index = ++count;
	}

	void Print() const
	{
		cout << "[" << index << "] = '" << value << "'" << endl;
	}
private:
	int index;
	string value;
};

int main(void)
{
	IndexedValue<string, double> a("first", 12.3);
	a.Print();

	IndexedValue<int, string> b("monday");
	b.Print();

	IndexedValue<int, string> c("tuesday");
	c.Print();

}


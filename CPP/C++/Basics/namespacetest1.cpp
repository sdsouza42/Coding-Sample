int age = 23; //default (anonymous) namespace

namespace Jack
{
	int age = 41; //Jack namespace
}

int main(void) //default namespace
{
	int age = 32;

	return age + ::age + Jack::age;
}


#include "namespacetest2.h"

int main(void)
{
	using namespace Jack; //treat Jack as a part of current namespace

	return age + Jill::age; //Jack:: qualification is not required
}

#include <stdio.h>

struct Employee
{
	long id;
	short hours;
	float rate;
};

typedef struct Employee Emp;

void EmployeeInit(Emp* emp, short h, float r)
{
	static int count = 0;

	emp->id = 101 + count++;
	emp->hours = h;
	emp->rate = r;
}

double EmployeeGetIncome(const Emp* emp)
{
	double income = emp->hours * emp->rate;
	short ot = emp->hours - 180;
	
	if(ot > 0)
		income += 50 * ot;

	return income;
}

int main(void)
{
	Emp jack, jill;

	EmployeeInit(&jack, 185, 52);
	EmployeeInit(&jill, 170, 120);

	printf("Jack's ID is %ld and Income is %.2lf\n", jack.id, EmployeeGetIncome(&jack));
	printf("Jill's ID is %ld and Income is %.2lf\n", jill.id, EmployeeGetIncome(&jill));
}

/*
	long m = 23, n = 32;

	long* p = &m; //p is a pointer to a long type value
	*p = n; //OK: m = n
	p = &n; //OK: p points to n

	const long* pk = &m; //pk is a ponter to a long type constant value
	*pk = n; //ERROR: value pointed by pk is constant
	pk = &n; //OK: pointer is not constant

	long* const kp = &m; //kp is a constant pointer to a long type value
	*kp = n; //OK: value pointed by kp is not contant
	kp = &n; //ERROR: pointer is constant

	const long* const kpk = &m; //kpk is a constant pointer to a long type constant value
	*kpk = n; //ERROR: value pointed by kpk is constant
	kpk = &n; //ERROR: pointer is constant

*/


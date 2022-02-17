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

typedef struct Manager
{
	long id;
	short hours;
	float rate;
	long sid;
}Mgr;

/*
void ManagerInit(Mgr* emp, short h, float r)
{
	static int count = 0;

	emp->id = 101 + count++;
	emp->hours = h;
	emp->rate = r;
}

double ManagerGetIncome(const Mgr* emp)
{
	double income = emp->hours * emp->rate;
	short ot = emp->hours - 180;

	if(ot > 0)
		income += 50 * ot;

	return income;
}
*/

int main(void)
{
	Emp jack;
	Mgr jill;

	EmployeeInit(&jack, 185, 52);
	//ManagerInit(&jill, 170, 120);
	EmployeeInit((Emp*)&jill, 170, 120);
	jill.sid = jack.id;

	printf("Jack's ID is %ld and Income is %.2lf\n", jack.id, EmployeeGetIncome(&jack));
	//printf("Jill's ID is %ld and Income is %.2lf\n", jill.id, ManagerGetIncome(&jill));
	printf("Jill's ID is %ld and Income is %.2lf\n", jill.id, EmployeeGetIncome((Emp*)&jill));
}


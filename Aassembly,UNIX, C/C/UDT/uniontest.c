#include <stdio.h>

union Score
{
	float percent;
	char grade;
};

int main(void)
{
	union Score jack = {56.5};
	union Score jill;
	jill.grade = 'B';

	printf("Jack's score is %.1f%%\n", jack.percent);
	printf("Jill's grade is %c\n", jill.grade);

	return sizeof(jack);
}


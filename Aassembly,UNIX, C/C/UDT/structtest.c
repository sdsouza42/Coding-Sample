#include <stdio.h>

struct Student
{
	long id;
	short course;
};

int main(void)
{
	struct Student jack = {37, 113};
	struct Student jill;
	jill.id = 28;
	jill.course = 126;

	printf("Student with ID %ld has applied for course number %hd\n", jack.id, jack.course);
	printf("Student with ID %ld has applied for course number %hd\n", jill.id, jill.course);

	return sizeof(jack);
}


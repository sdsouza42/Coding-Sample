#include <stdio.h>

struct Student
{
	long id;
	short course;
	union
	{
		float percent;
		char grade;
	};
};

typedef struct Student Candidate;

void Print(Candidate candidate)
{
	if(candidate.course < 120)
		printf("Student %ld has scored %.1f%% in course %hd\n", candidate.id, candidate.percent, candidate.course);
	else
		printf("Student %ld was graded %c in course %hd\n", candidate.id, candidate.grade, candidate.course);
		
}

int main(void)
{
	Candidate jack = {37, 117, 56.5};
	Candidate jill;
	jill.id = 26;
	jill.course = 124;
	jill.grade = 'A';

	Print(jack);
	Print(jill);
}


#include "student.h"
#include <iostream>

using namespace std;

void Print(const Student* entry)
{
	cout << "Score of student with ID "
	     << entry->GetId()
	     << " is "
	     << entry->GetScore()
	     << endl;
}

class _Student
{
public:
	int id;
	float score;
};

int main(void)
{
	Student* jack = new Student;
	jack->SetScore(58);
	Print(jack);
	
	Student* jill = new Student;
	jill->SetScore(71);
	Print(jill);

 	const Student* john = Student::BestStudent();
	Student* j1 = const_cast<Student*>(john);
	j1->SetScore(86);
	_Student* j2 = reinterpret_cast<_Student*>(j1);
	j2->id = 4;
	Print(john);

	delete jill;
	delete jack;
}



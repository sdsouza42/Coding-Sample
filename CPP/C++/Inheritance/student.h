#ifndef STUDENT_H 
#define STUDENT_H

class Student
{
public:
	Student()
	{
		id = 0;
		score = 0;
	}

	int GetId() const
	{
		static int nid = 1;

		if(id == 0)
			id = ++nid;

		return id;
	}

	float GetScore() const
	{
		return score;
	}

	void SetScore(float value)
	{
		score = value;
	}

	static const Student* BestStudent()
	{
		static Student bs;

		bs.id = 1;
		bs.score = 100;

		return &bs;

	}
private:
	mutable int id; //this field can be changed in const functions
	float score;
};

#endif


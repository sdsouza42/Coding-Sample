/*
typedef long Box[3];

void BoxSetDimensions(Box box, long length, long breadth, long height);

long BoxGetArea(Box box);

long BoxGetVolume(Box box);
*/

typedef long Box[4];

void BoxSetDimensions(Box box, long length, long breadth, long height);

void BoxSetThickness(Box box, long thickness);

long BoxGetArea(Box box);

long BoxGetVolume(Box box);



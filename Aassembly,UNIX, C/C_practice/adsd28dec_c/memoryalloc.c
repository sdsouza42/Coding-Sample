#include <stdio.h>
#include <malloc.h>
struct Employee
{
  short eid;
  float hours;
  double rate;
};

typedef struct Employee Emp;

int main()
{
  Emp e = {101, 250, 250};
  Emp * ep;
  ep = malloc(sizeof(Emp));

  ep->eid = 102;
  ep->hours = 200;
  ep->rate = 200;

  printf("Employee eid / hours / rate is %hd / %f / %lf\n", e.eid, e.hours, e.rate);
  printf("Employee eid / hours / rate is %hd / %f / %lf\n", ep->eid, ep->hours, ep->rate);

  free(ep);
  return 0;

}

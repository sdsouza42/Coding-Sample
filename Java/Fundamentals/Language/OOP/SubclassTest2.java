import payroll.*;

class SubclassTest2{

	private static double getAverageIncome(Employee[] group){
		double total = 0;
		for(Employee emp : group){
			total += emp.getNetIncome();
		}
		return total / group.length;
	}

	private static double getTotalSales(Employee[] group){
		double total = 0;
		for(Employee emp : group){
			if(emp instanceof SalesPerson){
				SalesPerson sp = (SalesPerson)emp;
				total += sp.getSales();
			}
		}
		return total;
	}

	public static void main(String[] args){
		Employee[] dept = new Employee[5];
		dept[0] = new Employee(186, 52);
		dept[1] = new Employee(200, 195);
		dept[2] = new SalesPerson(175, 55, 30000);
		dept[3] = new Employee(190, 110);
		dept[4] = new SalesPerson(195, 65, 70000);
		System.out.printf("Average Income: %.2f%n", getAverageIncome(dept));
		System.out.printf("Total Sales   : %.2f%n", getTotalSales(dept));
	}
}


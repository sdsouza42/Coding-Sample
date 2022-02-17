class SwitchCaseTest{

	private static double payment(int days, String room){
		float rate = 0;
		switch(room){
			case "ECONOMY":
				rate = 525;
				break;
			case "BUSINESS":
				rate = 750;
				break;
			case "EXECUTIVE":
				rate = 850;
				break;
			default:
				rate = 975;
		}
		return 1.05 * rate * days;
	}

	public static void main(String[] args){
		int stay = Integer.parseInt(args[0]);
		System.out.printf("Payment for ECONOMY type room is %.2f%n", payment(stay, "ECONOMY"));
		System.out.printf("Payment for BUSINESS type room is %.2f%n", payment(stay, "BUSINESS"));
		System.out.printf("Payment for EXECUTIVE type room is %.2f%n", payment(stay, "EXECUTIVE"));
		System.out.printf("Payment for DELUXE type room is %.2f%n", payment(stay, "DELUXE"));
	}
}


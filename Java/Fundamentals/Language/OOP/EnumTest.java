class EnumTest{

	/*
	interface RoomType{
		int ECONOMY = 1;
		int BUSINESS = 2;
		int EXECUTIVE = 3;
		int DELUXE = 4;
	}

	private static double payment(int days, int room){
		float rate = 0;
		switch(room){
			case RoomType.ECONOMY:
				rate = 525;
				break;
			case RoomType.BUSINESS:
				rate = 750;
				break;
			case RoomType.EXECUTIVE:
				rate = 850;
				break;
			default:
				rate = 975;
		}
		return 1.05 * rate * days;
	}
	*/

	enum RoomType{
		ECONOMY, BUSINESS, EXECUTIVE, DELUXE;
	}

	private static double payment(int days, RoomType room){
		float rate = 0;
		switch(room){
			case ECONOMY:
				rate = 525;
				break;
			case BUSINESS:
				rate = 750;
				break;
			case EXECUTIVE:
				rate = 850;
				break;
			default:
				rate = 975;
		}
		return 1.05 * rate * days;
	}

	public static void main(String[] args){
		int stay = Integer.parseInt(args[0]);
		System.out.printf("Payment for ECONOMY type room is %.2f%n", payment(stay, RoomType.ECONOMY));
		System.out.printf("Payment for BUSINESS type room is %.2f%n", payment(stay, RoomType.BUSINESS));
		System.out.printf("Payment for EXECUTIVE type room is %.2f%n", payment(stay, RoomType.EXECUTIVE));
		System.out.printf("Payment for DELUXE type room is %.2f%n", payment(stay, RoomType.DELUXE));
		//System.out.printf("Payment for CUSTOM type room is %.2f%n", payment(stay, 25));
	}
}


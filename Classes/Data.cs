namespace Computer.Classes
{
	internal class Data
	{
		public static int Access { get; set; }
		public static int UserID { get; set; }
		public static bool IsSeller() => Access == 1;
		public static bool IsManager() => Access == 2;
		public static bool IsStaff() => Access >= 1;
		public static string Status => IsSeller() ? "Продавец" : IsManager() ? "Менеджер" : "Не авторизован";
		public static char SeparatorForDecimal { get; set; } = '.';
		public static char SeparatorChangeForDecimal { get; set; } = ',';
	}
}

namespace PelSoftLabTask.Models
{
	public class ProductModel
	{
		public string? ProductName { get; set; }
		public char? Size { get; set; }
		public decimal Price { get; set; }
		public DateTime? MfgDate { get; set; }
		public string? Category { get; set; }

		public string Conjunction { get; set; }
	}
}

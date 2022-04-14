using System.ComponentModel.DataAnnotations;

namespace CadsatroCaminhoes.Models
{
	public class Caminhao
	{
		[Key]
		public int Id { get; set; }
		
		[Required]
		public string Nome { get; set; }

		[Required]
		public string Modelo { get; set; }

		[Required]
		public int AnoFabricacao { get; set; }

		[Required]
		public int AnoModelo { get; set; }
	}
}

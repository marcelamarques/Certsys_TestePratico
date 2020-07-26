using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certsys.Domain
{
	[Table("Configuration")]
    public class Configuration
    {
		public const int DistanciaTotalMinima = 10;
		public const int DistanciaMinimaVao = 2;
		[Key]
		public int Id { get; set; }

		private int _distMaxvao;
		[Column, Required]
		public int DistanciaMaxVao
		{
			get { return _distMaxvao; }
			set { _distMaxvao = value; }
		}

		private double _distMaxBaseReinforcement;
		[Column, Required]
		public double DistanceReinforcement
		{
			get { return _distMaxBaseReinforcement; }
			set { _distMaxBaseReinforcement = value; }
		}

	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certsys.Domain
{
	[Table("Pilar")]
    public class Pilar
    {
		[Key]
		public int Id { get; set; }

		private int _position;
		[Column, Required]
		public int Position
		{
			get { return _position; }
			set { _position = value; }
		}

		private bool _isReinforced;
		[Column, Required]
		public bool Reinforced
		{
			get { return _isReinforced; }
			set { _isReinforced = value; }
		}

		private double _distance;
		[Column, Required]
		public double Distance
		{
			get { return _distance; }
			set { _distance = value; }
		}
	}
}

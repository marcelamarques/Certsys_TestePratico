using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certsys.Domain
{
    public class Pilar
    {
		private int _position;

		public int Position
		{
			get { return _position; }
			set { _position = value; }
		}

		private bool _isReinforced;

		public bool Reinforced
		{
			get { return _isReinforced; }
			set { _isReinforced = value; }
		}

		private double _distance;

		public double Distance
		{
			get { return _distance; }
			set { _distance = value; }
		}
	}
}

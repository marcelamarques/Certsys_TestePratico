using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certsys.Domain
{
    public class Configuration
    {
		public const int DistanciaTotalMinima = 10;
		public const int DistanciaMinimaVao = 2;

		private int _distMaxvao;

		public int DistanciaMaxVao
		{
			get { return _distMaxvao; }
			set { _distMaxvao = value; }
		}

		private double _distMaxBaseReinforcement;

		public double DistanceReinforcement
		{
			get { return _distMaxBaseReinforcement; }
			set { _distMaxBaseReinforcement = value; }
		}

	}
}

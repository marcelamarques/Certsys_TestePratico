using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certsys.Domain
{
	[Table("Project")]
    public class Project
    {
		[Key]
		public int Id { get; set; }

		private Configuration _config;
		[Column, Required]
		public Configuration Configuration
		{
			get { return _config; }
			set { _config = value; }
		}

		private List<Pilar> _pilars;
		[NotMapped]
		public List<Pilar> Pilars
		{
			get { return _pilars; }
			set { _pilars = value; }
		}

		public Project(Configuration configuration)
		{
			Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

			Pilars = new List<Pilar>();
		}
	}
}

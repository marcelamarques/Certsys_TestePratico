using Certsys.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Certsys_TestePratico
{
    public partial class ProjectPilars : Form
    {
        Project projectCalculate;
        public ProjectPilars()
        {
            InitializeComponent();
        }

        private void btn_calcular_Click(object sender, EventArgs e)
        {
            if (!validatedInput())
            {
                lb_resposta.Text = "Preencha todos os dados antes de prossguir.";
                return;
            }

            double reta = Convert.ToDouble(lb_distReta.Text);
            double vao = Convert.ToDouble(lb_config_vao.Text);
            double reforco = Convert.ToDouble(lb_distBaseReinforcement.Text);

            Project project = Certsys.Services.CalculatePilars.Project(reta, vao, reforco);
            projectCalculate = Certsys.Services.CalculatePilars.CalculateProject(project);

            lb_resposta.Text = projectCalculate.ToString();
            btn_save.Enabled = true;
        }

        private bool validatedInput()
        {
            if (String.IsNullOrEmpty(lb_distReta.Text) || String.IsNullOrEmpty(lb_config_vao.Text) || String.IsNullOrEmpty(lb_distBaseReinforcement.Text))
            {
                return false;
            }

            if (Convert.ToDouble(lb_config_vao.Text) < 2)
            {
                return false;
            }

            return true;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (projectCalculate is null)
            {
                lb_resposta.Text = "É necessário realizar os cálculos antes de salvar.";
                return;
            }
            Certsys.Services.CalculatePilars.SaveProject(projectCalculate);
        }
    }
}

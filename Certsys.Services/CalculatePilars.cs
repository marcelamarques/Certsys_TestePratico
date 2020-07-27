using Certsys.Domain;
using Repository.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Certsys.Services
{
    public static class CalculatePilars
    {
        public static double CalculateDistPilars(double disMax, double distTotal)
        {
            Calculos.Calculos Calculos = new Calculos.Calculos();
            return Calculos.TestCalcDistMax(disMax, distTotal);
        }

        public static double CalculateReinforcementPilar(double distpilar, double distmax)
        {
            Calculos.Calculos Calculos = new Calculos.Calculos();

            return Calculos.TestCalcPilarReforco(distpilar, distmax) * distpilar;
        }

        public static List<Pilar> GetPilars(int number, double distane)
        {
            List<Pilar> pilars = new List<Pilar>();
            pilars.Add( new Pilar { Position = 1, Reinforced = true});
            for (int i = 0; i < number-1; i++)
            {
                pilars.Add(new Pilar { Distance = distane * (i + 1), Position = i + 2 });
            }
            Pilar last = pilars.LastOrDefault();
            pilars.Add(new Pilar { Position = last.Position+1, Distance = last.Distance + distane , Reinforced = true });

            return pilars;
        }

        public static List<Pilar> SetPilarReinforced(double distMax, List<Pilar> pilars)
        {
            List<Pilar> auxpilar = new List<Pilar>(pilars);
            foreach (Pilar item in pilars)
            {
                if (!item.Reinforced && item.Distance % distMax == 0)
                {
                    Pilar aux = new Pilar
                    {
                        Distance = item.Distance,
                        Position = item.Position,
                        Reinforced = true
                    };
                    auxpilar.RemoveAt(item.Position - 1);
                    auxpilar.Insert(item.Position - 1, aux);
                }
            }
            return auxpilar;
        }

        public static List<Pilar> GetPilarsReinforced(List<Pilar> pilars)
        {
            return pilars.Where(w => w.Reinforced).ToList();
        }

        private static Configuration FactoryConfiguration(double dist_total, double dist_vao, double dist_reforco)
        {
            return new Configuration { 
                DistanciaMaxVao = dist_vao,
                DistanceTotal = dist_total,
                DistanceReinforcement= 2.0,
            };
        }

        public static Project Project(double dist_total, double dist_vao, double dist_reforco)
        {
            Configuration config = FactoryConfiguration(dist_total, dist_vao, dist_reforco);
            return new Project(config);
        }


        public static Project CalculateProject(Project project)
        {
            double vao = CalculateDistPilars(project.Configuration.DistanciaMaxVao, project.Configuration.DistanceTotal);
            double refor = CalculateReinforcementPilar(vao, project.Configuration.DistanceReinforcement);
            double number = project.Configuration.DistanceTotal / vao;
            List<Pilar> pilars = GetPilars((int)number, vao);
            List<Pilar> pilarReforco = SetPilarReinforced(refor, pilars);
            List<Pilar> onlyReinforced = GetPilarsReinforced(pilarReforco);

            project.Pilars = pilarReforco;
            return project;
        }

        public static void SaveProject(Project project)
        {
            using (ProjectRepository repository = new ProjectRepository())
            {
                repository.Add(project);
                repository.Commit();
            }
        }
    }
}

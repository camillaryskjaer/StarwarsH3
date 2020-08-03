using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StarwarsH3
{
    class Solve
    {
        public void StartsWithM(List<Planet> planets)
        {
            var results = from name in planets
                          where name.Name.StartsWith("M")
                          select name.Name;

            foreach (string item in results)
            {
                Console.WriteLine(item);
            }
        }

        public void ContainsY(List<Planet> planets)
        {
            var results = from name in planets
                          where name.Name.ToLower().Contains("y")
                          select name.Name;

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        public void BiggerLongerThen6SmallerThen15(List<Planet> planets)
        {
            var results = from name in planets
                          where name.Name.Length > 6 && name.Name.Length < 15
                          select name.Name;

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        public void SecondIsALastIsE(List<Planet> planets)
        {
            var results = from name in planets
                          where name.Name[1] == 'a' && name.Name.EndsWith("e")
                          select name.Name;

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        public void SpeedOver40AndOrderBy(List<Planet> planets)
        {
            var results = from speed in planets
                          where speed.RotationPeriod > 40
                          orderby speed.RotationPeriod
                          select speed.Name;

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        public void SpeedOver10Over20OrberByName(List<Planet> planets)
        {
            var results = from speed in planets
                          where speed.RotationPeriod > 10 && speed.RotationPeriod < 20
                          orderby speed.Name
                          select speed.Name;

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        public void SpeedOver30SortByNameAndRotation(List<Planet> planets)
        {
            var results = from speed in planets
                          where speed.RotationPeriod > 30
                          orderby speed.Name, speed.RotationPeriod
                          select speed.Name;

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        public void RotationSpeedSurfaceWaterAndContainsBA(List<Planet> planets)
        {
            var results = from planet in planets
                          where (planet.RotationPeriod < 30 || planet.SurfaceWater > 50) && planet.Name.Contains("ba")
                          orderby planet.Name, planet.SurfaceWater, planet.RotationPeriod
                          select planet.Name;

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        public void OrderByDesc(List<Planet> planets)
        {
            var results = from planet in planets
                          where planet.SurfaceWater > 0
                          orderby planet.SurfaceWater descending
                          select planet.Name;

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        public void CalculatePopulationWithSurface(List<Planet> planets)
        {
            var results = from planet in planets
                          where planet.Diameter != 0 && planet.Population != 0
                          orderby CalculatePopulation(planet.Diameter, planet.Population)
                          select planet.Name;

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }
        double CalculatePopulation(int diameter, long population)
        {
            float radius = diameter / 2;
            double surface = 4 * Math.PI * Math.Pow(radius, 2);


            return surface / population;
        }

        public void Except(List<Planet> planets)
        {
            var results = planets.Except(planets, new PlanetComparer());

            foreach (var item in results)
            {
                Console.WriteLine(item.Name);
            }
        }

        public void RainForrest(List<Planet> planets)
        {
            var results = planets.Where(x => x.Name.ToLower().StartsWith("a") || x.Name.ToLower().EndsWith("s"));

            var resultsMain = planets.Where(x => x.Terrain != null).Where(x => x.Terrain.ToList().Contains("rainforests"));

            var finalRes = results.Union(resultsMain);

            foreach (var item in finalRes)
            {
                Console.WriteLine(item.Name);
            }
        }

        public void Swamp(List<Planet> planets)
        {
            var resultsMain = planets.Where(x => x.Terrain != null)
                .SelectMany(x => x.Terrain, (pln, tr) => new { pln, tr })
                .Where(x => x.tr.Contains("swamp"))
                .OrderBy(x => x.pln.RotationPeriod).ThenBy(x => x.pln.Name)
                .Select(x => x.pln);

            foreach (var item in resultsMain)
            {
                Console.WriteLine(item.Name);
            }
        }

        public void RegexMatch1(List<Planet> planets)
        {

            Regex match = new Regex(@"(.)\1+");
            var resultsMain = planets.Where(x => match.Match(x.Name).Success).Select(x => x.Name);



            foreach (var item in resultsMain)
            {
                Console.WriteLine(item);
            }
        }

        public void RegexMatch2(List<Planet> planets)
        {
            Regex match = new Regex(@"(kk|ll|rr|nn)");
            var resultsMain = planets.Where(x => match.Match(x.Name).Success)
                .OrderByDescending(x => x.Name)
                .Select(x => x.Name);



            foreach (var item in resultsMain)
            {
                Console.WriteLine(item);
            }
        }
    }
}

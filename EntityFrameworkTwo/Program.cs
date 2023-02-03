using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddFruit(new fandv(51,"name51","fruit","orange",319));
            GetAllFruits();
            
            Console.ReadLine();
        }

        static void AddFruit(fandv item)
        {
            using (FruitsAndVegatablesEntities fandvEntities = new FruitsAndVegatablesEntities())
            {
                fandv exist = fandvEntities.fandv.Where((x) => x.Name == item.Name).FirstOrDefault();
                if (exist == null)
                { 
                    fandvEntities.fandv.Add(item);
                    fandvEntities.SaveChanges();
                }
            }
        }

        static void GetAllFruits()
        {
            using (FruitsAndVegatablesEntities fandvEntities = new FruitsAndVegatablesEntities())
            {
                List<fandv> list = fandvEntities.fandv.ToList();
                foreach (fandv item in list) 
                {
                    if (item.Type == "fruits")
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }
    }
}

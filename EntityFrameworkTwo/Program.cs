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
            AddFruit(new fandv(52,"name52","fruits","orange",319));
            MyTransaction();
            GetAllFruits();            
            Console.ReadLine();
        }

        static void AddFruit(fandv item)
        {
            using (FruitsAndVegatablesEntities fandvEntities = new FruitsAndVegatablesEntities())
            {
                fandv exist = fandvEntities.fandv.Where((x) => x.Id == item.Id && x.Name == item.Name).FirstOrDefault();
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

        static void MyTransaction()
        {
            using (FruitsAndVegatablesEntities fandvEntities = new FruitsAndVegatablesEntities())
            {
                using (System.Data.Entity.DbContextTransaction tran = fandvEntities.Database.BeginTransaction())
                { 
                    try
                    {
                        fandv fav = new fandv(54, "name54", "fruits", "green", 153);
                        fandvEntities.fandv.Add(fav);
                        fandvEntities.fandv.Remove(fav);
                        fandvEntities.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                    }
                }

            }
        }
    }
}

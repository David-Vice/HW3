using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HW3
{
    abstract class Tank
    {
        public string Model { get; set; }
        public int Ammunition { get; set; }
        public int Armor { get; set; }
        public int Maneuverability { get; set; }

        public Tank()
        {
            Random rnd = new Random();
            Ammunition = rnd.Next(100);
            Armor = rnd.Next(100);
            Maneuverability = rnd.Next(100);
            Thread.Sleep(100);
        }

        public static Tank operator * (Tank t1, Tank t2)
        {
            short winner = 0;

            _ = t1.Ammunition > t2.Ammunition ? winner++ : winner--;
            _ = t1.Armor > t2.Armor ? winner++ : winner--;
            _ = t1.Maneuverability > t2.Maneuverability ? winner++ : winner--;

            if (winner > 0) return t1;
            else return t2;
        }

        public override string ToString()
        {
            return $"{Model}\nAmmunition: {Ammunition}\nArmor: {Armor}\nManeuverability: {Maneuverability}";
        }

    }

    class T_34 : Tank
    {
        public T_34() : base() { Model = "T-34"; }
    }

    class Panther : Tank
    {
        public Panther() : base() { Model = "Panther"; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tank[] sovietTanks = new T_34[5] { new T_34(), new T_34(), new T_34(), new T_34(), new T_34() };

            Tank[] germanTanks = new Panther[5] { new Panther(), new Panther(), new Panther(), new Panther(), new Panther() };

            int winnerSoviet=0;
            int winnerGerman=0;

            for(int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(sovietTanks[i]);
                Console.WriteLine("---vs---");
                Console.WriteLine(germanTanks[i]);
                Tank winner = sovietTanks[i] * germanTanks[i];
                if (winner.Model == "T-34") winnerSoviet++;
                else winnerGerman++;
                Console.WriteLine("---------------------");
                Console.WriteLine($"Winner is {winner.Model}");
                Thread.Sleep(5000);
            }

            Console.Clear();
            if (winnerSoviet > winnerGerman) Console.WriteLine($"USSR is the winner! (Soviet){winnerSoviet} : {winnerGerman}(German)");
            else Console.WriteLine($"German is the winner! (German){winnerGerman} : {winnerSoviet}(Soviet)");

        }
    }
}

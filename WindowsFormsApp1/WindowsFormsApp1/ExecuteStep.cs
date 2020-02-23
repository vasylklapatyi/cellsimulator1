using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp1
{
    static class ExecuteStep
    {
        public static void Execute()
        {
            foreach (var bot in MainItems.bots)
            {

            if (bot.Energy >= 999) bot.Energy = 999;
                int command = bot.Genotype[bot.Gptr];
                if (command == 23)
                {
                bot.eat_sun();
                bot.Gptr++;
                }
                if(command == 11)
                {
                bot.MakeAStep((Direction)(bot.Genotype[bot.Gptr + 1] % 8));
                }

            if (bot.Gptr > 63)   bot.Gptr -= 64;


                
            }
            MainItems.bots.AddRange(MainItems.botstoadd.ToArray());
            MainItems.botstoadd.Clear();
        }



    }
}

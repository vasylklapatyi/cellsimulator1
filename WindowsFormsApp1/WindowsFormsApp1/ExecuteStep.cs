using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class ExecuteStep
    {
        public static void Execute()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            foreach (var bot in MainItems.bots)
            {
             if(bot.Energy == 150)
              bot.Divide();
             bool sce = false;
             if (bot.Energy >= 999) bot.Energy = 999;
                int command = bot.Genotype[bot.Gptr];
                if (command == 23)
                {
                bot.eat_sun();
                bot.Gptr++;
                sce = true;
                }
                if(command == 11)
                {           
                bot.MakeAStep((Direction)(rand.Next(0,8)));//(Direction)(bot.Genotype[bot.Gptr + 1] % 8)
                bot.Gptr++;
                sce = true;
                }
                if(command == 22)
                {
                    bot.Divide();
                }

            if(!sce) bot.Gptr+=bot.Genotype[bot.Gptr];     
            if (bot.Gptr > 63)   bot.Gptr -= 64;   
          
           

            }
            MainItems.bots.AddRange(MainItems.botstoadd.ToArray());
            MainItems.botstoadd.Clear();
        }
    }
}

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
            for (int i = 0; i < MainItems.bots.Count; i++)
            {
                GenomEncoder(MainItems.bots[i].ID);    
            }
            
        }
        private static void DivideIf(Bot bot)
        {
            if(bot.Energy >= 150)// && 
                //(bot.BotStatus == BotState.Solar || bot.BotStatus == BotState.Hunter))
            {
                bot.Energy -= 150;

                bot.Divide();
            }
        }
        private static void GenomEncoder(int index)
        {
            foreach (var bot in MainItems.bots)
            {
              //  if (bot.BotStatus == BotState.Solar || bot.BotStatus == BotState.Hunter)
               // {
                    if (bot.ID == index)
                    {
                        if (bot.Energy >= 999) bot.Energy = 999;
                        switch (bot.Genotype[bot.Gptr])
                        {
                            case 23:
                                {
                                    bot.eat_sun();
                                    bot.Gptr++;
                                    break;
                                }
                                case 10:
                                {
                                    int tempgptr;
                                    if(63 - bot.Gptr > 3)
                                    tempgptr = bot.Gptr + 2;
                                    else
                                    {
                                        tempgptr = bot.Gptr - 2;
                                    }
                                    bot.MakeAStep((Direction)(bot.Genotype[tempgptr] % 8));
                                    bot.Gptr++;
                                    break;
                                }
                        case 22 :
                                {
                                bot.Divide();
                                    break;
                                }
                            case 1:
                                {
                                    bot.GiveFree();
                                    break;
                                }

                            default:
                                {
                                    bot.Gptr += bot.Genotype[bot.Gptr];

                                    break;
                                }
                        }
                        if (bot.Gptr > 63)
                            bot.Gptr -= 64;
                        

                    }
               // }
            }
            MainItems.bots.AddRange(MainItems.botstoadd.ToArray());
            MainItems.botstoadd.Clear();
        }

    }
}

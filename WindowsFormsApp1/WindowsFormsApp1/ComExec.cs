using System;
using System.Collections.Generic;
using System.Drawing;

namespace WindowsFormsApp1
{
    class MainItems
    {
        public static int Season = 4;
        public static Bitmap MainPolygon;
        public static List<Bot> bots = new List<Bot>();
        public static int _step = 0;
        public static int fps = 1000;
        public static List<Bot> botstoadd = new List<Bot>();
    }
    static class ComExec
    {
        //energy giver
        //eat in absolute 
        //look at absolute????
        //look at otnos????
        //look at lvl
        //whats my health
        // многоклеточность ( создание потомка, приклееного к боту  207
        // dividing
        //окружен ли бот 230
        //многоклеточный ли я 250
        //get minerals
        //make minerals as energy
        //276 mutate
        //генная атака 293
        //если ни с одной команд не совпало
        //значит безусловный переход  300
        //give the response to the next command
        public static Color GetColor(this Bitmap bmp,Point pos)
        {
            return bmp.GetPixel(pos.X, pos.Y);
        }
        public static int isMulti(Bot bot)
        {
            if (bot.previous == null && bot.next == null)
                return 0;
            if (bot.previous != null)
                return 1;
            if (bot.next != null)
                return 2;
            if (bot.previous != null && bot.next != null)
                return 3;
            return 3;
        }
        public static void mineralstoenergy(ref Bot bot)
        {
            if (bot.Energy > 100)
            {
                bot.Minerals -= 100;
                bot.Energy += 400;
                if (bot.BotColor != Color.Blue)
                {
                    bot.BotColor = Color.Blue;
                    bot.RefreshImage();
                }
            }
            else
            {
                bot.Energy += bot.Minerals * 4;
                bot.Minerals = 0;
                if (bot.BotColor != Color.Blue)
                {
                    bot.BotColor = Color.Blue;
                    bot.RefreshImage();
                }
            }
        }
        public static int FindEmptyDir(Bot bot)
        {
            if (IsBotOnDirection(bot, Direction.Up) == null)
                return (int)Direction.Up;
            if (IsBotOnDirection(bot, Direction.UpRight) == null)
                return (int)Direction.UpRight;
            if (IsBotOnDirection(bot, Direction.Right) == null)
                return (int)Direction.Right;
            if (IsBotOnDirection(bot, Direction.RightDown) == null)
                return (int)Direction.RightDown;
            if (IsBotOnDirection(bot, Direction.Down) == null)
                return (int)Direction.Down;
            if (IsBotOnDirection(bot, Direction.LeftDown) == null)
                return (int)Direction.LeftDown;
            if (IsBotOnDirection(bot, Direction.Left) == null)
                return (int)Direction.Left;
            if (IsBotOnDirection(bot, Direction.LeftUp) == null)
                return (int)Direction.LeftUp;
            return -1;
        }
        public static Bot IsBotOnDirection(Bot currentbot,  Direction dir)
        {
                foreach (var bot in MainItems.bots)
                {
                    switch (dir)
                    {
                        case Direction.Up://
                            {
                                Point p = new Point(currentbot.Position.X, currentbot.Position.Y + Bot.size);
                                if ((p.Y - bot.Position.Y  <= 3)&&(p.Y - bot.Position.Y >= 0))
                                    return bot;
                                break;
                            }
                        case Direction.UpRight://
                            {
                                Point p = new Point(currentbot.Position.X + Bot.size, currentbot.Position.Y + Bot.size);
                            if (((p.Y - bot.Position.Y <= 3) && (p.Y - bot.Position.Y >= 0))&&
                                ((p.X - bot.Position.X <= 3) && (p.X - bot.Position.X >= 0)))
                                return bot;
                                break;
                            }
                        case Direction.Right://
                            {
                                Point p = new Point(currentbot.Position.X + Bot.size, currentbot.Position.Y);
                                if ((p.X - bot.Position.X <= 3) && (p.X - bot.Position.X >= 0))
                                    return bot;
                                break;
                            }
                        case Direction.RightDown://
                            {
                                Point p = new Point(currentbot.Position.X + Bot.size, currentbot.Position.Y - Bot.size);
                               if(((bot.Position.Y - p.Y <= 3) && (bot.Position.Y - p.Y >= 0)) &&
                                ((p.X - bot.Position.X <= 3) && (p.X - bot.Position.X >= 0)))
                                return bot;
                                break;
                            }
                        case Direction.Down://
                            {
                                Point p = new Point(currentbot.Position.X, currentbot.Position.Y - Bot.size);
                            if (( bot.Position.Y - p.Y  <= 3)&&(bot.Position.Y - p.Y >=0))
                                return bot;
                                break;
                            }
                        case Direction.LeftDown:////
                            {
                                Point p = new Point(currentbot.Position.X - Bot.size, currentbot.Position.Y - Bot.size);
                            if(((bot.Position.Y - p.Y <= 3) && (bot.Position.Y - p.Y >= 0)) &&
                                ((p.X - bot.Position.X <= 3) && (p.X - bot.Position.X >= 0)))
                                return bot;
                                break;
                            }
                        case Direction.Left:///
                            {
                                Point p = new Point(currentbot.Position.X - Bot.size, currentbot.Position.Y);
                                if ((p.X - bot.Position.X <= 3)&& (p.X - bot.Position.X >= 0))
                                    return bot;
                                break;
                            }
                        case Direction.LeftUp://
                            {
                                Point p = new Point(currentbot.Position.X - Bot.size, currentbot.Position.Y + Bot.size);
                            if(((p.X - bot.Position.X <= 3) && (p.X - bot.Position.X >= 0)) &&
                                ((p.Y - bot.Position.Y <= 3) && (p.Y - bot.Position.Y >= 0)))
                                return bot;
                                break;
                            }
                        default: return null;
                    }

                }
            
            return null;
        }
        public static Point PointFromDir(Bot bot,Direction dir)
        {
            switch (dir)
            {
                case Direction.Up:
                    {
                        return new Point(bot.Position.X, bot.Position.Y+Bot.size);
                    }
                case Direction.UpRight:
                    {
                        return new Point(bot.Position.X+Bot.size, bot.Position.Y + Bot.size);
                    }
                case Direction.Right:
                    {
                        return new Point(bot.Position.X+Bot.size, bot.Position.Y);
                    }
                case Direction.RightDown:
                    {
                        return new Point(bot.Position.X + Bot.size, bot.Position.Y - Bot.size);
                    }
                case Direction.Down:
                    {
                        return new Point(bot.Position.X, bot.Position.Y-Bot.size);
                    }
                case Direction.LeftDown:
                    {
                        return new Point(bot.Position.X - Bot.size, bot.Position.Y - Bot.size);            
                    }
                case Direction.Left:
                    {
                        return new Point(bot.Position.X-Bot.size, bot.Position.Y);
                    }
                case Direction.LeftUp:
                    {
                        return new Point(bot.Position.X - Bot.size, bot.Position.Y + Bot.size);
                    }            
            }
            return new Point();
        }
        public static void CreateOriginator(ref Bot bot)
        {
            Random rand = new Random();
            int[] firstgenom = new int[64];
            for (int j = 0; j < 64; j++)
            {
                bot.Genotype[j] = rand.Next(0,1000000)%64;
                //if (j % 2 == 0)
                //    firstgenom[j] = 23;
                //else
                //    firstgenom[j] = 11;
                //if (j % 2 == 10)
                //    firstgenom[j] = 35;



            }
     //       bot.Genotype = firstgenom;
        }
    }

}

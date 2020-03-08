using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
//energy giver absolute
//energygiver in otnos
//mover...
//photosyntes
//eat in absolute direction
//eat in otnos direction
//look at absolute????
//look at otnos????
//give energy absolute
//give energy otnos
//look at lvl
//whats my health
// многоклеточность ( создание потомка, приклееного к боту  207
// dividing/////////////////////
//окружен ли бот 230
//многоклеточный ли я 250
//get minerals
//make minerals as energy
//276 mutate
//генная атака 293
//если ни с одной команд не совпало
//значит безусловный переход  300
//give the response to the next command

namespace WindowsFormsApp1
{
    public enum BotState
    {
        Dead, Orgaic
     , Solar, Hunter
    }
    public enum Direction
    {
        Up,UpRight,Right,RightDown
       ,Down,LeftDown,Left,LeftUp

    }
    public class Point
    {
        public Point()
        {
            this.x = this.y = 0;
        }
        public Point(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
        private int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        private int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

    }
    public  class Bot
    {
        public static int IDcounter = 0;
        public static int size = 10;

        public int Energy
        {
            get; 
            set; 
        }
        public int ID { get; set; }
        private int[] genom = new int[64]; 
        public int[ ] Genotype
        {
            get { return genom; }
            set { genom = value; }
        }
        public int Gptr
        {
            get;
            set;
        }
        private Direction napryamok;
        public Direction Napruamok 
        {
            get { return napryamok; }
            set { napryamok = value; }
        }
        private int minerals;
        public int Minerals
        {
            get { return minerals; }
            set { minerals = value; }
        }
        private Point position;
        public Point Position
        {
            get { return position; }
            set { position = value; }
        }
        public Bot() {   }
        public Bot(Point pos)
        {
            this.BotStatus = BotState.Solar;
            this.position = pos;
            IDcounter++;
            this.ID = IDcounter;
            this.Energy = 10;
            this.color = Color.Green;
            this.Gptr = 0;
            this.MakeAStep(Direction.Down);
        }
        public Bot(Point pos,int[] genom)
        {
            this.Genotype = genom;
            this.BotStatus = BotState.Solar;
            this.position = pos;
            IDcounter++;
            this.ID = IDcounter;
            this.Energy = 10;
            this.color = Color.Lime;
            this.MakeAStep(Direction.Down);
        }
        public BotState BotStatus
        {
            get;
            set;
        }
        private Color color;
        public Color BotColor
        {
            get { return color; }
            set { color = value; }
        }
        public Bot previous, next;
        public void MakeAStep(Direction dir)
        {
                Point newposition = position;
                if (ComExec.IsBotOnDirection(this, dir) != null)
                    return;
                bool UP = position.Y < MainItems.MainPolygon.Height - size - 11;
                bool DOWN = position.Y > size + 5;
                bool LEFT = position.X > size;
                bool RIGHT = position.X < MainItems.MainPolygon.Width - size - 9;
                bool UPRIGHT = UP && RIGHT;
                bool RIGHTDOWN = RIGHT && DOWN;
                bool LEFTDOWN = LEFT && DOWN;
                bool LEFTUP = LEFT && UP;
                //comment for commit
                switch (dir)///перевырити ще раз бо тут срака
                {
                    case Direction.Up:////
                        {
                            if (UP)
                            {
                                newposition = new Point(position.X, position.Y + size);
                            }
                            break;
                        }
                    case Direction.UpRight://////
                        {
                            if (UPRIGHT)
                                newposition = new Point(position.X + size, position.Y + size);
                            else
                                newposition = position;
                            break;
                        }
                    case Direction.Right:////
                        {
                            if (RIGHT)
                                newposition = new Point(position.X + size, position.Y);
                            else
                                newposition = new Point(size, position.Y);
                            break;
                        }
                    case Direction.RightDown:////
                        {
                            if (RIGHTDOWN)
                                newposition = new Point(position.X + size, position.Y - size);
                            else
                                newposition = position;
                            break;
                        }
                    case Direction.Down://
                        {
                            if (DOWN)
                                newposition = new Point(position.X, position.Y - size);
                            break;
                        }
                    case Direction.LeftDown://///
                        {
                            if (LEFTDOWN)
                                newposition = new Point(position.X - size, position.Y - size);
                            else newposition = position;

                            break;
                        }
                    case Direction.Left:////
                        {
                            if (position.X > size)
                                newposition = new Point(position.X - size, position.Y);
                            else
                                newposition = new Point(MainItems.MainPolygon.Width - size, position.Y);
                            break;
                        }
                    case Direction.LeftUp://
                        {
                            if (LEFTUP)
                                newposition = new Point(position.X - size, position.Y + size);
                            else newposition = position;

                            break;
                        }
                    default:
                        break;
                }
                int y = newposition.Y;
            try 
	        {	        
		 for (int x = position.X; x < position.X + size; x++)
                {
                    for (y = position.Y; y < position.Y + size; y++)
                    {
                        MainItems.MainPolygon.SetPixel(x, y, Color.Aqua);
                    }
                }
                y = newposition.Y;
                for (int x = newposition.X; x < newposition.X + size; x++)
                {
                    MainItems.MainPolygon.SetPixel(x, y - 1, Color.Black);
                    for (y = newposition.Y; y < newposition.Y + size; y++)
                    {
                        if (y == newposition.Y || y == newposition.Y + size - 1)
                            MainItems.MainPolygon.SetPixel(x, y, Color.Black);
                        else MainItems.MainPolygon.SetPixel(x, y, this.color);
                    }
                }
	        }
	        catch (Exception)
	        {
            return;
	        }
               
                this.position = newposition;          
        }
        public void eat_sun()
        {
            //int t = 0;
            //if (this.Energy >= 1000)
            //{
            //    this.Energy = 1000;
            //    return;
            //}/////////
            //if (this.Minerals >= 100)
            //{
            //    t = 1;
            //}
            //else t = 2;
            //int energy = MainItems.Season - (this.Position.Y - 1) / 6 - t;
            //if (energy > 0)
            //{
            //    this.Energy += energy;
            //}
            //this.BotColor = Color.Lime;
            //this.BotStatus = BotState.Solar;
            //RefreshImage();

            this.Energy += 5;
        }
        public void RefreshImage()
        {
    try 
	{	        
		 for (int x = this.Position.X; x < this.Position.X + Bot.size; x++)
            {
                for (int y = this.Position.Y; y < this.Position.Y + Bot.size; y++)
                {
                    
                    MainItems.MainPolygon.SetPixel(x, y, Color.Aqua);
                }
            }
            for (int x = this.Position.X; x < this.Position.X + Bot.size; x++)
            {
                for (int y = Position.Y; y < this.Position.Y + Bot.size; y++)
                {
                    MainItems.MainPolygon.SetPixel(x, y, this.BotColor);
                }
            }
	}
	catch (Exception)
	{
		return;
	}   
        }
        public void Divide()
        {
            int dirsearchresult;
            if((dirsearchresult = ComExec.FindEmptyDir(this)) != -1)
           {
            
            Point p = ComExec.PointFromDir(this,(Direction)dirsearchresult);
            Bot bot = new Bot(p);
            bot.Genotype = this.Genotype;
            bot.Gptr = (new Random(DateTime.Now.Millisecond)).Next(63);
            bot.RefreshImage();         
            MainItems.botstoadd.Add(bot);
            }
            else
            {
                this.Die();
            }
        }
        public void Die()
        {
            this.BotStatus = BotState.Orgaic;
            this.BotColor = Color.Gray;
        }
        public void GiveFree()
        {
            for (int i = 0; i < 8; i++)
            {
               Bot tmp = ComExec.IsBotOnDirection(this,(Direction)i);
                if (tmp!=null)
                {
                    foreach (var bot in MainItems.bots)
                    {
                        if(tmp.ID == bot.ID)
                        {
                            bot.Energy += (this.Energy / 4);
                            this.Energy /= 4;
                            break;
                        }
                    }
                    break;
                }
            }
        }
        public void DoubleBot()
        {
            this.Energy -= 150;
            if (this.Energy <= 0) this.Die();
            else
            {

            int dirfromorigin = ComExec.FindEmptyDir(this);
            Point pos = new Point();
            if (dirfromorigin != -1)
            {

                switch(dirfromorigin)
                {
                    case 0:
                        {
                            pos = ComExec.PointFromDir(this, Direction.Up);
                            break;
                        }
                    case 1:
                        {
                            pos = ComExec.PointFromDir(this, Direction.UpRight);
                            break;
                        }
                    case 2:
                        {
                            pos = ComExec.PointFromDir(this, Direction.Right);
                            break;
                        }
                    case 3:
                        {
                            pos = ComExec.PointFromDir(this, Direction.RightDown);
                            break;
                        }
                    case 4:
                        {
                            pos = ComExec.PointFromDir(this, Direction.Down);
                            break;
                        }
                    case 5:
                        {
                            pos = ComExec.PointFromDir(this, Direction.LeftDown);
                            break;
                        }
                    case 6:
                        {
                            pos = ComExec.PointFromDir(this, Direction.Left);
                            break;
                        }
                    case 7:
                        {
                            pos = ComExec.PointFromDir(this, Direction.LeftUp);
                            break;
                        }
                }
            }
            else
            {
            this.Die();
            return;
            }
            Bot newbot = new Bot(pos);
            newbot.RefreshImage(); ;
            newbot.Genotype = this.genom;
            int imo = (new Random()).Next(0,5);
            if (imo == 3) newbot.Genotype[(new Random()).Next() % 63] = (new Random()).Next() % 64;
            newbot.Energy = this.Energy / 2;
            newbot.BotColor = this.color;
            this.next = newbot;
            newbot.previous = this;
            MainItems.botstoadd.Add(newbot);
            }
        }
        public void Multi()
        {
            Bot prev = this.previous;
            Bot nxt = this.next;
            if (ComExec.isMulti(prev) >0 && ComExec.isMulti(nxt) > 0)
                return;
            this.Energy -= 150;
            if(this.Energy <=0)
            {
                this.Die();
                return;
            }
            int n = ComExec.FindEmptyDir(this);
            if( n == -1)
            {
                this.Die();
                return;
            }
            Bot newbot = new Bot(ComExec.PointFromDir(this,(Direction)n));
            newbot.Genotype = this.genom;
            int imo = (new Random()).Next(0, 5);
            if (imo == 3) newbot.Genotype[(new Random()).Next() % 63] = (new Random()).Next() % 64;
            newbot.Energy = this.Energy / 2;
            newbot.BotColor = this.color;
            this.next = newbot;
            newbot.previous = this;
            MainItems.botstoadd.Add(newbot);
            newbot.Napruamok = (Direction)((new Random()).Next() % 8);


        }
        public void FallDead()
        {
            this.Position.Y -= Bot.size;
            this.RefreshImage();
        }
    }
}

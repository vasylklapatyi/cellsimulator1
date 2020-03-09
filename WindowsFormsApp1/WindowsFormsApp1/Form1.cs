using System;
using System.Drawing;
using System.Windows.Forms;

/// 
/// 
/// 23 - photosyntes
/// 11 - make a step
/// 22,33,55 divide
/// 1,2 - give energy for free
/// 
/// 
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
    public Form1()
        {
            InitializeComponent();
            Point korin = new Point(10, 10);
            int polwidth = pictureBox1.Width;
            int polheight = pictureBox1.Height;
            MainItems.MainPolygon = new Bitmap(polwidth, polheight);
             
        }
    private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = MainItems.MainPolygon;
        }
    public Point point = new Point(150,100);
    private void button2_Click(object sender, EventArgs e)
        {
            Random rand1 = new Random();
            Random rand2 = new Random();
            // System.Math.Round
            //  Point spawn = new Point(rand1.Next(Bot.size,MainItems.MainPolygon.Width-Bot.size), rand2.Next(Bot.size, MainItems.MainPolygon.Height - Bot.size));
                Point spawn = new Point((new Random()).Next() % MainItems.MainPolygon.Width, (new Random()).Next() % MainItems.MainPolygon.Height);
            //   point.Y += Bot.size;
            //  point.X += Bot.size;
            //   //Point spawn = new Point(300, 300);
            Bot bot = new Bot(spawn);
            bot.RefreshImage();
            ComExec.CreateOriginator(ref bot);
            MainItems.bots.Add(bot);
            pictureBox1.Image = MainItems.MainPolygon;
        }

    private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            Bot pickedbot = null;
            foreach (var bot in MainItems.bots)
            {
                int rxl = bot.Position.X - e.X;
                int rxr = e.X - bot.Position.X;
                int ryu = e.Y  - bot.Position.Y;
                int ryd = bot.Position.Y - e.Y;
                if//(((rxl >= 0 && rxl < Bot.size+2) ||(rxr >= 0 && rxr < Bot.size + 2))       )//||
                 (   ((ryu >=0 && ryu < Bot.size + 2) || (ryd >= 0 && ryd < Bot.size + 2)))
                {
                    pickedbot = bot;
                    break;
                }
            }
            if (pickedbot != null  )
            {
                Bot nearestBot = null;
                for (int i = 0; i < 8; i++)
                {
                nearestBot = ComExec.IsBotOnDirection(pickedbot, (Direction)(i));
                    if (nearestBot != null)
                        break;
                }
                if(nearestBot != null)
                textBox2.Text = $"Position {pickedbot.Position.X}:{pickedbot.Position.Y}; ID:{pickedbot.ID};Nearest bot:{nearestBot.ID};BotStatus:{pickedbot.BotStatus}";
                else
                textBox2.Text = $"Position {pickedbot.Position.X}:{pickedbot.Position.Y}; ID:{pickedbot.ID};Energy:{pickedbot.Energy};Gptr:{pickedbot.Gptr};BotStatus:{pickedbot.BotStatus}";

            }
            else textBox2.Text = "Pick the bot";
            pickedbot = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExecuteStep.Execute();
            pictureBox1.Image = MainItems.MainPolygon;
            MainItems._step++;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000 / MainItems.fps;
            timer1.Start();
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

         void update()
        {
            ExecuteStep.Execute();
            pictureBox1.Image = MainItems.MainPolygon;
            pictureBox1.Update();
            MainItems._step++;
            label1.Text = MainItems._step.ToString();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(textBox3.Text != "")
            MainItems.fps = Convert.ToInt32(textBox3.Text);
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            update();
            label6.Text = MainItems.bots.Count.ToString();
        }

        private void CustomSpawnB_Click(object sender, EventArgs e)
        {
            int x  = Convert.ToUInt16(textBox4.Text);
            int y  = Convert.ToUInt16(textBox5.Text);
            Point point = new Point(x, y);
            Bot bot = new Bot(point);
            bot.RefreshImage();
            ComExec.CreateOriginator(ref bot);
            MainItems.bots.Add(bot);
            pictureBox1.Image = MainItems.MainPolygon;
        }
    }
}

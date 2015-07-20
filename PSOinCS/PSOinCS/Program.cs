using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSOinCS
{
    
    class MyPSO
    {
        const int NUM = 40;//粒子数
        const int DIM = 30;//维数
        const double c1 = 1.8;//参数
        const double c2 = 1.8;//参数

        static double xmin = -100.0;//位置下限
        static double xmax = 100.0;//位置上限
        static double[] gbestx = new double[DIM];//全局最优位置
        public static double gbestf;//全局最优适应度
        static Random rand = new Random();//用于生成随机数

        class particle
        {//定义一个粒子
            public double[] x = new double[DIM];//当前位置矢量
            public double[] bestx = new double[DIM];//历史最优位置
            public double f;//当前适应度
            public double bestf;//历史最优适应度
        }
        static particle[] swarm = new particle[NUM];//定义粒子群

        static double f1(double[] x)
        {//测试函数：超球函数
            return x.Sum(a => a * a+1);
        }

       public  static class  Program
        {
            /// <summary>
            /// 应用程序的主入口点。
            /// </summary>
            public static string time;
           [STAThread]
            public static void Main()
            {
               System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                for (int i = 0; i < DIM; i++)//初始化全局最优
                    gbestx[i] = rand.NextDouble() * (xmax - xmin) + xmin;
                gbestf = double.MaxValue;
                for (int i = 0; i < NUM; i++)
                {//初始化粒子群
                    particle p1 = new particle();
                    for (int j = 0; j < DIM; j++)
                        p1.x[j] = rand.NextDouble() * (xmax - xmin) + xmin;
                    p1.f = f1(p1.x);
                    p1.bestf = double.MaxValue;
                    swarm[i] = p1;
                }
                for (int t = 0; t < 5000; t++)//迭代次数
                {
                    for (int i = 0; i < NUM; i++)
                    {
                        particle p1 = swarm[i];
                        for (int j = 0; j < DIM; j++)//进化方程
                            p1.x[j] += c1 * rand.NextDouble() * (p1.bestx[j] - p1.x[j])
                                + c2 * rand.NextDouble() * (gbestx[j] - p1.x[j]);
                        p1.f = f1(p1.x);
                        if (p1.f < p1.bestf)
                        {//改变历史最优
                            p1.x.CopyTo(p1.bestx, 0);
                            p1.bestf = p1.f;
                        }
                        if (p1.f < gbestf)
                        {//改变全局最优
                            p1.x.CopyTo(gbestx, 0);
                            for (int j = 0; j < DIM; j++)//把当前全局最优的粒子随机放到另一位置
                                p1.x[j] = rand.NextDouble() * (xmax - xmin) + xmin;
                            gbestf = p1.f;
                        }
                    }
                }
                sw.Stop();
                time = sw.Elapsed.Seconds.ToString();
                //Console.WriteLine("{0}", gbestf);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}

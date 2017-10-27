using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingChess
{
    class Program
    {
        //用静态字段来模拟全局变量.地图有100个方块。
        //replace  a global variable with a static field.The map has 100 blocks.
        static int[] maps = new int[100];

        //声明一个静态数组来存储玩家A与家B的坐标
        //use a static array to save players' places.
        static int[] playerPos = new int[2];

        //存储两个玩家的姓名
        //use a static array to save players' names.
        static string[] playerNames = new string[2];

        //玩家的两个标记，和暂停一回合有关系
        //save player's pause state
        static bool[] flags = new bool[2];

        static void Main(string[] args)
        {
            GameShow();
            
            #region 输入两个玩家的姓名
            Console.WriteLine("请输入玩家A的姓名:\r\nPlease input player A 's name:");
            playerNames[0] = Console.ReadLine();

            //玩家A不能接受空名字
            //player A 's Name can not be empty
            while (playerNames[0]=="")
            {
                Console.WriteLine("玩家A的姓名不能为空，请重新输入\r\n Player A 's name can not be empty.Please input again.");
                playerNames[0] = Console.ReadLine();
            }
            Console.WriteLine("请输入玩家B的姓名：\r\nPlease input player A 's Name:");
            playerNames[1] = Console.ReadLine();

            //玩家B不接受空名字
            //player B 's Name can not be empty
            while (playerNames[1]==""||playerNames[1]==playerNames[0])
            {
                if (playerNames[1] == "")
                {
                    Console.WriteLine("玩家B的姓名不能为空，请重新输入\r\nPlayer B 's name can not be empty.Please input again.");
                    playerNames[1] = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("玩家B的姓名不能与玩家A的相同，请重新输入\r\nPlayer B 's name can not be same as player A.Please input again.");
                    playerNames[1] = Console.ReadLine();
                }
            }
            #endregion

            //玩家输入ok后 清屏
            //player input OK,clear screen
            Console.Clear();
            GameShow();
            InitailMap();
            DrawMap();

            //当玩家A跟玩家B没有人在终点的时候 两个玩家不停地去玩游戏
            //Two players take turns to play game
            while (playerPos[0] < 99 && playerPos[1] < 99)
            {
                if (flags[0] == false)
                {
                    PlayGame(0);
                }
                else
                {
                    flags[0] = false;
                }
                //如果玩家A赢了，结束游戏
                //if player A wins,game over
                if (playerPos[0] >= 99)
                {
                    Console.WriteLine( "\r\n玩家{0}无耻地赢了玩家{1}\r\nplayer {0} defeats player {1}",playerNames[0],playerNames[1]);
                    break;
                }

                if (flags[1] == false)
                {
                    PlayGame(1);
                }
                else
                {
                    flags[1] = false;
                }
                //如果玩家B听了，结束游戏
                //if player B wins,game over
                if (playerPos[1] >= 99)
                {
                    Console.WriteLine("\r\n玩家{0}无耻地赢了玩家{1}\r\nplayer {0} defeats player {1}", playerNames[1], playerNames[0]);
                    break;
                }
            }
            //打印胜利字符图案
            //print win pattern
            DrawWinImage();
            Console.ReadKey();
        }

        /// <summary>
        /// 加载游戏头 initialize game head
        /// </summary>
        public static void GameShow()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("********************************************");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("********************************************");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("*****************飞行棋 V1.0****************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*************Flying Chess v1.0**************");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("********************************************");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("********************************************");
        }

        /// <summary>
        /// 初始化地图 initialize game map
        /// </summary>
        public static void InitailMap()
        {
            //幸运轮盘lucky wheel
            int[] luckturn = { 6, 23, 40, 55, 69,83 };
            for (int i = 0; i < luckturn.Length; i++)
            {
                maps[luckturn[i]] = 1;
            }
            //地雷landmine
            int[] landMine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 };
            for (int i = 0; i < landMine.Length; i++)
            {
                maps[landMine[i]] = 2;
            }
            //暂停
            int[] pause = { 9, 27, 60, 93 };
            for (int i = 0; i < pause.Length; i++)
            {
                maps[pause[i]] = 3;
            }
            //时空隧道time tunnel
            int[] timeTunnel = { 20, 25, 45, 63, 72, 88, 90 };
            for (int i = 0; i < timeTunnel.Length; i++)
            {
                maps[timeTunnel[i]] = 4;
            }
        }

        /// <summary>
        /// 绘制数组中的所有符号 draw all symbols
        /// </summary>
        public static  void DrawMap()
        {
            Console.WriteLine("A玩家用A表示 player A");
            Console.WriteLine("B玩家用B表示 player B");
            Console.WriteLine("图例： 幸运转盘lucky wheel ◎   地雷landmine ☆ 暂停pause ▲   时空隧道time tunnel 卍");
            #region 绘制第一行 draw first line
            for (int i = 0; i < 30; i++)
            {
                Console.Write(DrawStringMap(i));
            }
            Console.WriteLine();
            #endregion
            #region 绘制第一列 draw first row
            for (int i = 30; i < 35; i++)
            {
                for (int j = 0; j < 29; j++)
                {
                    Console.Write("  ");
                }
                Console.Write(DrawStringMap(i));
                Console.WriteLine();
            }
            #endregion
            #region 绘制第二行 draw second line
            for (int i = 64; i >35; i--)
            {
                Console.Write(DrawStringMap(i));
            }
            #endregion
            #region 绘制第二列 draw second row
            for (int i = 65; i < 70; i++)
            {
                Console.WriteLine(DrawStringMap(i));
            }
            #endregion
            #region 绘制第三行 draw third line
            for (int i = 70; i < 100; i++)
            {
                Console.Write(DrawStringMap(i));
            }
            Console.WriteLine();
            #endregion
        }

        /// <summary>
        /// 绘制符号的方法 the method of draw symbols
        /// </summary>
        /// <param name="i">数组中的位置 location in array</param>
        /// <returns>返回位置所对应的符号 symbol</returns>
        public static string DrawStringMap(int i)
        {
            string str = "";
            //如果玩家的坐标相同，并且都在地图上画一个尖括号
            //if one player’s location is same as another one，draw “<>”
            if (playerPos[0] == playerPos[1] && playerPos[1] == i)
            {
                Console.ForegroundColor = ConsoleColor.White;
                str="<>";
            }
            else if (playerPos[0] == i)
            {
                Console.ForegroundColor = ConsoleColor.White;
                str="A";
            }
            else if (playerPos[1] == i)
            {
                Console.ForegroundColor = ConsoleColor.White;
                str="B";
            }
            else
            {
                switch (maps[i])
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        str="□";
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        str="◎";
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        str="☆";
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        str="▲";
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        str="卍";
                        break;
                }

            }
            return str;
        }

        /// <summary>
        /// 玩游戏 play game
        /// </summary>
        public static void PlayGame(int playerNumber)
        {
            Random rondom = new Random();
            int rNumber = rondom.Next(1,7);
            Console.WriteLine("{0}按任意键开始投掷骰子\r\n{0} press any key to get a random number ", playerNames[playerNumber]);
            Console.ReadKey(true);
            Console.WriteLine("{0}掷出了{1}\r\n{0} get {1}", playerNames[playerNumber],rNumber);
            playerPos[playerNumber] += rNumber;
            ChangePos();
            Console.ReadKey(true);
            Console.WriteLine("{0}按任意键开始行动\r\n{0} press any key to move", playerNames[playerNumber]);
            Console.ReadKey(true);
            Console.WriteLine("{0}行动完了\r\n{0} moved", playerNames[playerNumber]);
            Console.ReadKey(true);
            //玩家可能踩到玩家B 方块幸运轮盘 地雷 暂停 时空隧道
            if (playerPos[playerNumber] == playerPos[1- playerNumber])
            {
                Console.WriteLine("玩家{0}踩到了玩家{1},玩家{2}退6格\r\nplayer {0} meets player {1},player {1} moves six blocks backward");
                playerPos[1- playerNumber] -= 6;
                ChangePos();
                Console.ReadKey(true);
            }
            else//踩到关卡
            {
                switch (maps[playerPos[playerNumber]])
                {
                    case 0:
                        Console.WriteLine("玩家{0}踩到了方块，安全\r\nplayer {0} meets a block(□),safe", playerNames[playerNumber]);
                        Console.ReadKey(true);
                        break;
                    case 1:
                        Console.WriteLine("玩家{0}踩到了幸运轮盘，请选择 1--交换位置 2--轰炸对方，使其退6步\r\nplayer {0} meets a lucky wheel(◎).pleace choose 1--change places with another player 2--another player moves six blocks.");
                        string input = Console.ReadLine();
                        while (true)
                        {
                            if (input == "1")
                            {
                                Console.WriteLine("玩家{0}选择跟玩家{1}交换位置\r\nplayer {0} changes places with  player {1}", playerNames[playerNumber], playerNames[1- playerNumber]);
                                Console.ReadKey(true);
                                int temp = playerPos[playerNumber];
                                playerPos[playerNumber] = playerPos[1- playerNumber];
                                playerPos[1- playerNumber] = temp;
                                Console.WriteLine("交换完成！按任意键继续游戏\r\nexchange is successful!press any key to continue！");
                                Console.ReadKey(true);
                                break;
                            }
                            else if (input == "2")
                            {
                                Console.WriteLine("玩家{0}选择轰炸玩家{1}，玩家{2}退6格\r\nplayer {1} moves six blocks backward.", playerNames[playerNumber], playerNames[1- playerNumber], playerNames[1- playerNumber]);
                                Console.ReadKey(true);
                                playerPos[1- playerNumber] -= 6;
                                ChangePos();
                                Console.WriteLine("玩家{0}退了6格\r\nplayer {0} moves six blocks backward.", playerNames[1- playerNumber]);
                                Console.ReadKey(true);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("请重新输入正确的选择！请选择 1--交换位置 2--轰炸对方，使其退6步\r\npleace input again.1--change places with another player 2--another player moves six blocks.");
                                input = Console.ReadLine();
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("玩家{0}踩到了地雷，退6格\r\nplayer {0} meets  a landmine(☆),move six blocks backward", playerNames[playerNumber]);
                        Console.ReadKey(true);
                        playerPos[playerNumber] -= 6;
                        ChangePos();
                        break;
                    case 3:
                        Console.WriteLine("玩家{0}踩到了暂停，暂停一回合\r\nplayer {0} meets a pause(▲), do nothing next turn.", playerNames[playerNumber]);
                        flags[playerNumber] = true;
                        Console.ReadKey(true);
                        break;
                    case 4:
                        Console.WriteLine("玩家{0}踩到了时空隧道，玩家前进10步\r\nplayer {0} meets  a time tunnel(卐), move ten blocks forward.", playerPos[playerNumber]);
                        playerPos[playerNumber] += 10;
                        ChangePos();
                        Console.ReadKey(true);
                        break;
                }

            }
            Console.Clear();
            DrawMap();
        }

        /// <summary>
        /// 当玩家坐标发生变化时调用，防止玩家跑出地图 keep player on map
        /// </summary>
        public static void ChangePos()
        {
            if (playerPos[0] < 0)
            {
                playerPos[0] = 0;
            }
            if (playerPos[0] >= 99)
            {
                playerPos[0] = 99;
            }
            if (playerPos[1] < 0)
            {
                playerPos[1] = 0;
            }
            if (playerPos[1]>=99)
            {
                playerPos[1] = 99;
            }
        }

        /// <summary>
        /// 游戏结束，绘制胜利图案
        /// //game over,draw win pattern
        /// </summary>
        public static void DrawWinImage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
 .----------------.  .----------------.  .-----------------.
| .--------------. || .--------------. || .--------------. |
| | _____  _____ | || |     _____    | || | ____  _____  | |
| ||_   _||_   _|| || |    |_   _|   | || ||_   \|_   _| | |
| |  | | /\ | |  | || |      | |     | || |  |   \ | |   | |
| |  | |/  \| |  | || |      | |     | || |  | |\ \| |   | |
| |  |   /\   |  | || |     _| |_    | || | _| |_\   |_  | |
| |  |__/  \__|  | || |    |_____|   | || ||_____|\____| | |
| |              | || |              | || |              | |
| '--------------' || '--------------' || '--------------' |
 '----------------'  '----------------'  '----------------' 
");
        }
    }
   
}

using System;

namespace BattleShip
{

    public class Player
    {
        public static int[] PlayerShoot()
        {
            int[] returnShot = new int[2];
            returnShot[0] = ShootX();
            returnShot[1] = ShootY();
            return returnShot;
        }
        public static int ShootX()
        {
            Console.WriteLine("Take a shoot  X coordinates");
            int shootPositionX = Convert.ToInt32(Console.ReadLine());
            return shootPositionX;
        }
        public static int ShootY()
        {
            Console.WriteLine("Take a shoot Y coordinates");
            int shootPositionY = Convert.ToInt32(Console.ReadLine());
            return shootPositionY;
        }
        public static bool Fired(int positionX, int positionY, string[,] playground)
        {
            int xPosition = positionX;
            int yPosition = positionY;
            if (xPosition == 0 || yPosition == 0)
            {
                Console.WriteLine("Wow looks like you're blind! Shoot inside to the field. (Don't choose )");
                PlayerShoot();
            }
            try
            {
                if (playground[xPosition, yPosition] == "[~]")
                {//Shoot The Sea
                    Console.WriteLine("You shoot the sea ! congrats !");
                    playground[xPosition, yPosition] = "[X]";
                    return false;
                }
                else if (playground[xPosition, yPosition] == "[X]")
                {// Shot same location twice, maybe more
                    Console.WriteLine("You already shot here you dumbass");
                    return false;
                }
                else
                {//Shoot the Ship!
                    Console.WriteLine("You shoot the ship, congrats !");
                    //playground[xPosition, yPosition] = "[X]";
                    return true;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please shoot between the limits.");
                return false;
            }
        }
    }

    public class Ships
    {
        public int lenght;
        public string shipName;
        public bool isSink = false;
        public int isX;
        public int shipStartX;
        public int shipStartY;
        public int shipHealth;
        public Ships(string shipName, int lenght, string[,] playground, string shortName)
        {
            this.shipHealth = lenght;
            this.shipName = shipName;
            this.lenght = lenght;
            CreateShip(lenght, playground, shortName);
        }
        public static void CreateShip(int lenght, string[,] playground, string shortName)
        {
        StartCreateShip:
            var rand = new Random();
            int shipStartX = rand.Next(1, 8 - lenght);
            int shipStartY = rand.Next(1, 8 - lenght);
            int isX = rand.Next(1, 3);
            //Variables for field occupied check
            int shipStartXCheck, shipXPrint;
            shipStartXCheck = shipXPrint = shipStartX;
            int shipStartYCheck, shipYPrint;
            shipStartYCheck = shipYPrint = shipStartY;
            bool isFieldEmpty = false;

            if (isX == 1)
            {// If the ship is Horizontal

                for (int checkPositionX = lenght; checkPositionX > 0; checkPositionX--)
                {//Cheking the field is occupied or not

                    if (playground[shipStartXCheck, shipStartYCheck] != "[~]")
                    {
                        //If field occupied, retry.
                        goto StartCreateShip;
                    }
                    else
                    {
                        shipStartXCheck++;
                        isFieldEmpty = true;
                    }
                }
                if (isFieldEmpty)
                {//Print the ship to the playground
                    for (int PrintX = lenght; PrintX > 0; PrintX--)
                    {
                        playground[shipXPrint, shipStartYCheck] = shortName;
                        shipXPrint++;
                    }
                }
            }

            else if (isX == 2)
            {// If the ship is Vertical

                for (int checkPositionY = lenght; checkPositionY > 0; checkPositionY--)
                {//Cheking the field is occupied or not

                    if (playground[shipStartXCheck, shipStartYCheck] != "[~]")
                    {
                        //If field occupied, retry.
                        goto StartCreateShip;
                    }
                    else
                    {
                        shipStartYCheck++;
                        isFieldEmpty = true;
                    }
                }
                if (isFieldEmpty)
                {//Print the ship to the playground
                    for (int PrintY = lenght; PrintY > 0; PrintY--)
                    {
                        playground[shipStartXCheck, shipYPrint] = shortName;
                        shipYPrint++;
                    }
                }
            }

           
            //if (Battleship.isX == 1)
            //{
            //    for (int i = 0; i < Battleship.lenght; i++)
            //    {
            //        playground[Battleship.shipStartX, Battleship.shipStartY] = "[B]";
            //        Battleship.shipStartX++;
            //    }
            //}
            //else if (Battleship.isX == 2)
            //{
            //    for (int i = 0; i < Battleship.lenght; i++)
            //    {
            //        playground[Battleship.shipStartX, Battleship.shipStartY] = "[B]";
            //        Battleship.shipStartY++;
            //    }
            //}
        }
    }
    public class Program
    {
        static void PrintPlayground(string[,] playground)
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (playground[x, y] == "[~]")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write(playground[x, y]);
                }
                Console.Write("\n");
            }
        }
        static void Main()
            // Main Function
        {
            //Creating Playgrouund
            string[,] playground =
            {
                {"[X]","[1]","[2]","[3]","[4]","[5]","[6]","[7]" },
                {"[A]","[~]","[~]","[~]","[~]","[~]","[~]","[~]" },
                {"[B]","[~]","[~]","[~]","[~]","[~]","[~]","[~]" },
                {"[C]","[~]","[~]","[~]","[~]","[~]","[~]","[~]" },
                {"[D]","[~]","[~]","[~]","[~]","[~]","[~]","[~]" },
                {"[E]","[~]","[~]","[~]","[~]","[~]","[~]","[~]" },
                {"[F]","[~]","[~]","[~]","[~]","[~]","[~]","[~]" },
                {"[G]","[~]","[~]","[~]","[~]","[~]","[~]","[~]" }
            };
            //Create BattleShip
            Ships Battleship0 = new Ships("Battleship0", 3, playground, "[0]");
            Ships Battleship1 = new Ships("Battleship1", 3, playground, "[1]");
            Ships Battleship2 = new Ships("Battleship2", 3, playground, "[2]");
            PrintPlayground(playground);
            bool isGameContiune = true;
            while (isGameContiune)
            {
                int[] coordinates = Player.PlayerShoot();
                Console.WriteLine("You choose {0}{1} position for shoot", coordinates[0], coordinates[1]);
                if (Player.Fired(coordinates[0], coordinates[1], playground))
                {
                    switch (playground[coordinates[0], coordinates[1]])
                    {
                        case "[0]":
                            if (Battleship0.shipHealth > 0)
                            {
                                Battleship0.shipHealth--;
                                playground[coordinates[0], coordinates[1]] = "[X]";
                                Console.WriteLine("Congats, you shoot the ship! Remaining life: {0}", Battleship0.shipHealth);
                                if (Battleship0.shipHealth <= 0)
                                {
                                    Battleship0.isSink = true;
                                    Console.WriteLine("Congrats you destroy {0}", Battleship0.shipName);
                                }
                            }
                            break;
                        case "[1]":
                            if (Battleship1.shipHealth > 0)
                            {
                                Battleship1.shipHealth--;
                                playground[coordinates[0], coordinates[1]] = "[X]";
                                Console.WriteLine("Congats, you shoot the ship! Remaining life: {0}", Battleship1.shipHealth);
                                if (Battleship1.shipHealth <= 0)
                                {
                                    Battleship1.isSink = true;
                                    Console.WriteLine("Congrats you destroy {0}", Battleship1.shipName);
                                }
                            }
                            break;
                        case "[2]":
                            if (Battleship2.shipHealth > 0)
                            {
                                Battleship2.shipHealth--;
                                playground[coordinates[0], coordinates[1]] = "[X]";
                                Console.WriteLine("Congats, you shoot the ship! Remaining life: {0}", Battleship2.shipHealth);
                                if (Battleship2.shipHealth <= 0)
                                {
                                    Battleship2.isSink = true;
                                    Console.WriteLine("Congrats you destroy {0}", Battleship2.shipName);
                                }
                            }
                            break;
                        default:
                            playground[coordinates[0], coordinates[1]] = "[X]";
                            break;
                    }
                }
                if (Battleship1.isSink && Battleship1.isSink && Battleship2.isSink)
                {
                    Console.WriteLine("Congrats you destroy all ships");
                    isGameContiune = false; 
                    Environment.Exit(0);
                }
                PrintPlayground(playground);
                //if (playground[3,3] == "[X]" )
                //{
                //    isGameContiune = false;
                //}
            } 
        }
    }
}
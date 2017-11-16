using System;
using System.Collections;

struct Vector2{

	public byte x; 
	public byte y;

	public Vector2(byte x, byte y){
		this.x = x; 
		this.y = y; 
	}


}


namespace X_mas_game
{


	class MainClass
	{
		public static void Main(string[] args)
		{
			 

			// genarate the axis for game ( used as refrnce and can be changes as needed)
			byte gridSize = 100;
			// grid this way by not be needed 
			byte[] xAxis = new byte[gridSize];
			byte[] yAxis = new byte[gridSize];
			xAxis = GridNumberAdd(gridSize);
			yAxis = GridNumberAdd(gridSize);
			//Player player = new Player();
			//player.CheckMyLoc();
			// make bad guys apear and store them in a list 
			ArrayList badGuys = new ArrayList();
			ArrayList storys = new ArrayList();
			Player player = null; 
			bool gameIsActive = true; 
			bool playerIsActive = false;
			byte badGuyCount = 0; 

			storys.Add("Eats the heads off bunny rabbits.  ");
			storys.Add("Will kill his own grandmother for cash. ");
			storys.Add("Teaches under-privileged children in the hood.");
			storys.Add("Has killed more players than any other.");
			storys.Add("Pays child support for brothers child.");
			string input = null;

            while (gameIsActive) {

                input = Console.ReadLine();

                // create player 
                if (input.ToLower() == "create player") {

                    if (!playerIsActive) {
                        playerIsActive = true;
                        // give the player a name
                        string nameToUse = null;
                        Console.WriteLine("Please give your player a name");
                        nameToUse = Console.ReadLine();

                        // if name is not enterd try again 
                        while (string.IsNullOrEmpty(nameToUse)) {
                            Console.WriteLine("That is not a valid name. \nPlease try again.");
                            nameToUse = Console.ReadLine();
                        }

                        player = CreatePlayer(nameToUse);
                        player.CheckMyLoc();
                        Console.WriteLine("Yours player name is " + player.name);

                    } else {

                        Console.WriteLine("Player is in game there name is " + player.name);
                    }

                }
                if (input.ToLower() == "create npc") {

                    if (badGuyCount < 5) {
                        badGuyCount++;
                        string nameToUse = null;
                        Console.WriteLine("Please give your NPC a name");
                        nameToUse = Console.ReadLine();

                        // if name is not enterd try again 
                        while (string.IsNullOrEmpty(nameToUse)) {
                            Console.WriteLine("That is not a valid name. \nPlease try again.");
                            nameToUse = Console.ReadLine();
                        }
                        byte storyPicker = RandomNumberGen();
                        string storyToUse = storys[storyPicker].ToString();
                        badGuys.Add(CreateNPC(nameToUse, storyToUse));
                    } else {

                        Console.WriteLine("Can not Create any more NPC");
                    }
                }
                if (input.ToLower() == "query npc" && playerIsActive) {

                    string nameToUse = null;
                    Console.WriteLine("Please give the name of the NPC you would like to Query");
                    nameToUse = Console.ReadLine();

                    // if name is not enterd try again 
                    while (string.IsNullOrEmpty(nameToUse)) {
                        Console.WriteLine("That is not a valid name. \nPlease try again.");
                        nameToUse = Console.ReadLine();
                    }

                    for (int i = 0; i < badGuys.Count; i++) {
                        BadGuy c = (BadGuy)badGuys[i];
                        if ((c.name).ToLower() == nameToUse.ToLower()) {

                            Console.WriteLine("Name: " + c.name + "\nBackStory: " + c.story);
                        }

                    }

                } else if (input.ToLower() == "query npc" && !playerIsActive)
                {
                    Console.WriteLine("You need to make a player to do this");

                }

                if (input.ToLower() == "request alliance" && playerIsActive)
                {

                    string nameToUse = null;
                    Console.WriteLine("Please give the name of the NPC you would like to Query");
                    nameToUse = Console.ReadLine();

                    // if name is not enterd try again 
                    while (string.IsNullOrEmpty(nameToUse))
                    {
                        Console.WriteLine("That is not a valid name. \nPlease try again.");
                        nameToUse = Console.ReadLine();
                    }

                    string allyStatus = null;
                    for (int i = 0; i < badGuys.Count; i++)
                    {
                        BadGuy c = (BadGuy)badGuys[i];

                        if ((c.name).ToLower() == nameToUse.ToLower())
                        {

                            allyStatus = c.myAligenes;
                        }

                        if (allyStatus.ToLower() != "friend")
                        {
                            player.hp -= 2;
                            Console.WriteLine("You lost 2 hp your hp is now = " + player.hp);
                        }
                        else {

                            Console.WriteLine("You found a friend");
                        }

                    }


                   
				}else if (input.ToLower() == "request alliance" && !playerIsActive)
                {
                    Console.WriteLine("You need to make a player to do this");
                }

				if(input.ToLower() == "move" && playerIsActive){
					string xValue = null, yValue = null; 
					byte xParse, yParse; 

					Console.WriteLine();

					Console.WriteLine("What x vaule would you like to move to? \nBetween 0 and 100 please.");
					xValue= Console.ReadLine();
					byte.TryParse(xValue, out xParse);

					while(string.IsNullOrEmpty(xValue) || !byte.TryParse(xValue, out xParse) || xParse > 100){

						Console.WriteLine("That is not a valid number \nPlease try again.");
						xValue= Console.ReadLine();
					}

					Console.WriteLine("What y vaule would you like to move to? \nBetween 0 and 100 please.");
					yValue= Console.ReadLine();
					byte.TryParse(yValue, out xParse);

					while(string.IsNullOrEmpty(yValue) || !byte.TryParse(yValue, out yParse) || yParse > 100){

						Console.WriteLine("That is not a valid number \nPlease try again.");
						yValue= Console.ReadLine();
					}

					player.ChangePos(xParse, yParse);

					Console.WriteLine("I have moved to ");
					player.CheckMyLoc();

				}else if (input.ToLower() == "move" && !playerIsActive)
                {
                    Console.WriteLine("You need to add a player to do this.");

                }
                if (input.ToLower() == "print npc status")
                {

                    for(int i =0; i < badGuys.Count; i++)
                    {
                        BadGuy badinfoToCall = (BadGuy)badGuys[i];

                        string infoToOutput = badinfoToCall.CallMyinfo();
                        Console.WriteLine(infoToOutput);
                    }
  

                }

                if (input.ToLower() == "print player status" && playerIsActive)
                {
                    string infoToget = player.PlayerInfo;
                    Console.WriteLine(infoToget);
                }else if (input.ToLower() == "print player status" && !playerIsActive)
                {
                    Console.WriteLine("You need to add a player to do this.");
                }


                if(input.ToLower() == "shoot" && playerIsActive && badGuyCount > 0)
                {
                    string nameToUse = null;
                    Console.WriteLine("Please give the name of the NPC you would like to Shoot");
                    nameToUse = Console.ReadLine();

                    // if name is not enterd try again 
                    while (string.IsNullOrEmpty(nameToUse))
                    {
                        Console.WriteLine("That is not a valid name. \nPlease try again.");
                        nameToUse = Console.ReadLine();
                    }
                    bool ifIhitHim = false;
                    string eminyStatus = null; 
                    for( int i = 0; i < badGuys.Count; i++)
                    {
                        BadGuy c = (BadGuy)badGuys[i];
                        if ((c.name).ToLower() == nameToUse.ToLower())
                        {
                            ifIhitHim = c.Shoot();
                            eminyStatus = c.myType;
                        }

                    }

                    if (ifIhitHim)
                    {

                        Console.WriteLine("You shot " + nameToUse);

                    }
                    else
                    {
                        Console.WriteLine("You missed " + nameToUse);
                    }
                    if(eminyStatus.ToLower() == "friend")
                    {
                        player.HitFriend();

                    }

                }
                else if (input.ToLower() == "shoot" && !playerIsActive && badGuyCount > 0) 
                {
                    Console.WriteLine("You need to make a player frist");

                }else if (input.ToLower() == "shoot" && !playerIsActive && badGuyCount <= 0)
                {
                    Console.WriteLine("There is no body to shoot");
                }

                byte npcPasafied = 0; 

                for(int i = 0; i < badGuys.Count; i++)
                {

                    BadGuy c = (BadGuy)badGuys[i];

                    if( c.allyStatus == "friend" || c.hp <= 0)
                    {
                        npcPasafied++;

                    }

                }

                if (playerIsActive)
                {
                    if (player.hp == 0 || npcPasafied == badGuys.Count)
                    {
                        gameIsActive = !gameIsActive;
                    }
                }
            }

            Console.WriteLine("Game over your score" + player.hp);

		



			//badGuys.Add(new BadGuy(x,y,name,story));

		}

		public static byte[] GridNumberAdd(byte gridSize){

			byte[] gridReady = new byte[gridSize + 1];

			for(byte i =0; i <= gridSize; i ++){

				gridReady[i]= i;

			}


			return(gridReady);
		}

		public static Player CreatePlayer(string name){

			byte[] xandY = RandomNumberGen(2);

			Player player = new Player(xandY[0],xandY[1], name);

			return(player);
		}

		public static BadGuy CreateNPC(string name, string story){

			byte[] xandY = RandomNumberGen(2);

			BadGuy badGuy = new BadGuy(xandY[0], xandY[1], name, story);

			return(badGuy);
		}

		public static byte[] RandomNumberGen(byte numberOfNumberToReturn){

			byte[] numbersToReturn = new byte[numberOfNumberToReturn];

			Random rnd = new Random();

			for( byte i = 0 ; i < numberOfNumberToReturn; i ++){
				numbersToReturn[i] = (byte)rnd.Next(0,100);
			}

			return(numbersToReturn);
		}
		public static byte RandomNumberGen(){

			byte numbersToReturn;

			Random rnd = new Random();
			numbersToReturn = (byte)rnd.Next(0,4);

		

			return(numbersToReturn);
		}



		}
			
	}


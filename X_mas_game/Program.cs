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
			//byte gridSize = 100;
			// grid this way by not be needed 
			//byte[] xAxis = new byte[gridSize];
			//byte[] yAxis = new byte[gridSize];
			//xAxis = GridNumberAdd(gridSize);
			//yAxis = GridNumberAdd(gridSize);
			//Player player = new Player();
			//player.CheckMyLoc();
			// make bad guys apear and store them in a list 
			ArrayList badGuys = new ArrayList();
			ArrayList storys = new ArrayList();
			Player player = null; 
			bool gameIsActive = true; 
			bool playerIsActive = false;
			byte badGuyCount = 0; 
			// storys for the NPC's back grounds stored in an array 
			storys.Add("Eats the heads off bunny rabbits.  ");
			storys.Add("Will kill his own grandmother for cash. ");
			storys.Add("Teaches under-privileged children in the hood.");
			storys.Add("Has killed more players than any other.");
			storys.Add("Pays child support for brothers child.");
			string input = null;

			// start of game 
			Console.WriteLine ("Hello and Welcome to the game of the season");
			Console.WriteLine ("If at any point you are unsure what to do type HELP in the console");

			// game active loop 
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
                        //player.CheckMyLoc();
                        Console.WriteLine(player.name + "Has been created as the player");

                    } else {

                        Console.WriteLine("Player is in game there name is " + player.name);
                    }

                }
				// create npc 
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
						Console.WriteLine (nameToUse + " Has been created");
                    } else {

                        Console.WriteLine("Can not Create any more NPC");
                    }
                }
				// Npc info request (Single) 
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
				// alliance request (targets one NPC) 
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
				// Moves the player to a location 
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
					byte.TryParse(yValue, out yParse);

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
				// print all known NPC statis
                if (input.ToLower() == "print npc status")
                {

                    for(int i =0; i < badGuys.Count; i++)
                    {
                        BadGuy badinfoToCall = (BadGuy)badGuys[i];

                        string infoToOutput = badinfoToCall.CallMyinfo();
                        Console.WriteLine(infoToOutput);
                    }
  

                }
				// print curent player status
                if (input.ToLower() == "print player status" && playerIsActive)
                {
                    string infoToget = player.PlayerInfo;
                    Console.WriteLine(infoToget);
                }else if (input.ToLower() == "print player status" && !playerIsActive)
                {
                    Console.WriteLine("You need to add a player to do this.");
                }

				// shoot an NPC (Effect by name)
				if(input.ToLower() == "shoot" && playerIsActive && badGuyCount > 0 && player.amunition > 0)
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
					bool ifIhitHim = false, badGuyAlive = true;
                    string eminyStatus = null; 
                    for( int i = 0; i < badGuys.Count; i++)
                    {
                        BadGuy c = (BadGuy)badGuys[i];
                        if ((c.name).ToLower() == nameToUse.ToLower())
                        {
							if(c.hp <=0){

								badGuyAlive = false;

							}
							if(badGuyAlive){
							player.ShotMyGun();
                            ifIhitHim = c.Shoot();
                            eminyStatus = c.myType;
							}else{
								Console.WriteLine ("I cant do that they are all ready dead");
							}

                        }

                    }

					// prints out the shot responce 
					if (ifIhitHim && badGuyAlive)
                    {

                        Console.WriteLine("You shot " + nameToUse);

                    }
					else if( !ifIhitHim && badGuyAlive)
                    {
                        Console.WriteLine("You are to far away " + nameToUse);
                    }
                    if(eminyStatus.ToLower() == "friend")
                    {
                        player.HitFriend();

                    }

                }
				else if (input.ToLower() == "shoot" && !playerIsActive && badGuyCount > 0 && player.amunition > 0) 
                {
                    Console.WriteLine("You need to make a player frist");

				}else if (input.ToLower() == "shoot" && !playerIsActive && badGuyCount <= 0 && player.amunition > 0)
                {
                    Console.WriteLine("There is no body to shoot");
				}else if (input.ToLower() == "shoot" && playerIsActive && badGuyCount >= 0 && player.amunition <= 0)
				{
					Console.WriteLine("Im out of ammo");
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
				// added in extra help command
				if (input.ToLower() == "help" ){
					Console.WriteLine ("Welcome to the help Center.  \nBelow are a list of avalable commands and that they do. ");
					Console.WriteLine ("");
					Console.WriteLine ("Create Player = When this command is called,\n you will be asked for name of the player.\nA player with a randomly generated position the 100 x 100 grid will be created.");
					Console.WriteLine ("");
					Console.WriteLine ("Create Npc = When this command is called,\n you will be asked for name of the NPC.\n A NPC with a randomly generated position the 100 x 100 grid will be created.");
					Console.WriteLine ("");
					Console.WriteLine ("Move = When this command is called,\n you will be asked for a new position, this will cost 1 hp to use.");
					Console.WriteLine ("");
					Console.WriteLine ("Query NPC = When this command is called,\n you will be asked for an NPC’s name and there back story will be revealed.");
					Console.WriteLine ("");
					Console.WriteLine ("Request Alliance = When this command is called,\n you will be asked for an NPC’s name. \n If they are friendly they will join your team,\n if not they may not be so welcoming");
					Console.WriteLine ("");
					Console.WriteLine ("Print Player Status = When this command is called,\n  the players hp ammo and posistion on the grid will be displayed");
					Console.WriteLine ("");
					Console.WriteLine ("Print NPC Status = When this command is called,\n All know info about the NPC's will be displayed");
					Console.WriteLine ("");
					Console.WriteLine ("Shoot = When this command is called,\n you will be asked for name of the NPC,\n If the NPC is in range you will shoot them.");

				}

				// checks the game over State 
				if (playerIsActive && badGuyCount > 0)
                {
                    if (player.hp == 0 || npcPasafied == badGuys.Count)
                    {
                        gameIsActive = !gameIsActive;
                    }
                }
            }

			//prints the game over message to console 
            Console.WriteLine("Game over your score = " + player.hp);

		



			//badGuys.Add(new BadGuy(x,y,name,story));

		}

		// was used to make an array form 1- a set number no longer required 
		public static byte[] GridNumberAdd(byte gridSize){

			byte[] gridReady = new byte[gridSize + 1];

			for(byte i =0; i <= gridSize; i ++){

				gridReady[i]= i;

			}


			return(gridReady);
		}

		// creates the player 
		public static Player CreatePlayer(string name){

			byte[] xandY = RandomNumberGen(2);

			Player player = new Player(xandY[0],xandY[1], name);

			return(player);
		}
		// created the badguy
		public static BadGuy CreateNPC(string name, string story){

			byte[] xandY = RandomNumberGen(2);

			BadGuy badGuy = new BadGuy(xandY[0], xandY[1], name, story);

			return(badGuy);
		}
		// genarates random numbers in an array for posisions 
		public static byte[] RandomNumberGen(byte numberOfNumberToReturn){

			byte[] numbersToReturn = new byte[numberOfNumberToReturn];

			Random rnd = new Random();

			for( byte i = 0 ; i < numberOfNumberToReturn; i ++){
				numbersToReturn[i] = (byte)rnd.Next(0,100);
			}

			return(numbersToReturn);
		}
		// genarates random number for the scelction of the storys for the background of the bad guys 
		public static byte RandomNumberGen(){

			byte numbersToReturn;

			Random rnd = new Random();
			numbersToReturn = (byte)rnd.Next(0,4);

		

			return(numbersToReturn);
		}



		}
			
	}


using System;
using System.Collections;


// This project was done by Michael Carstairs(C16707919)
// Finished project will also be available on my git hub on and after date of submision. At present(29-11-2017) an amost finished version is accessable om my git hub. 
// https://github.com/Ignisdeus/X_mas_game_solution
// Happy Christmas :) hope you have fun :) 
public struct Vector2{

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
			ArrayList NPCs = new ArrayList();
			ArrayList storys = new ArrayList();
			ArrayList namesUsedBefore = new ArrayList();
			byte npcPasafied = 0;

			Player player = null; 
			bool gameIsActive = true; 
			bool playerIsActive = false;
			byte NPCCount = 0; 
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


				// reload wepion 
				if (input.ToLower() == "reload" && playerIsActive) {

					player.amunition = 10; 
					Console.WriteLine ("You have reloaded your gun");
				}else if(input.ToLower() == "reload" && !playerIsActive){

					Console.WriteLine ("You need to create a player to reload");
				}

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
						byte x = RandomNumberGen(100), y = RandomNumberGen(100); 

						// to make the game less pridictable 
						while(x ==y){
							y = RandomNumberGen(100);
						}
						player = new Player(x  , y, nameToUse);
                        //player.CheckMyLoc();
                        Console.WriteLine(player.name + " Has been created as the player");

                    } else {

                        Console.WriteLine("Player is in game there name is " + player.name);
                    }

                }
				// create npc 
                if (input.ToLower() == "create npc") {

                    if (NPCCount < 5) {
                        NPCCount++;
                        string nameToUse = null;
						bool nameUsedBefore = false;
                        Console.WriteLine("Please give your NPC a name");



                        nameToUse = Console.ReadLine();
						// reuse of names causes problims fixed by using loops
						for(int i =0; i < namesUsedBefore.Count; i ++){

							if(nameToUse.ToLower() == namesUsedBefore[i].ToString().ToLower()){
								nameUsedBefore = true;
							}

						}
                        // if name is not enterd try again 
                        while (string.IsNullOrEmpty(nameToUse) || nameUsedBefore) {
                            Console.WriteLine("That is not a valid name. \nPlease try again.");
                            nameToUse = Console.ReadLine();
							nameUsedBefore = false;
							for(int i =0; i < namesUsedBefore.Count; i ++){

								if(nameToUse.ToLower() == namesUsedBefore[i].ToString().ToLower()){
									nameUsedBefore = true;
								}

							}
                        }
                        byte storyPicker = RandomNumberGen(3);
                        string storyToUse = storys[storyPicker].ToString();
						byte x = RandomNumberGen(100);
						byte y= RandomNumberGen(100);
						// to make the game less pridictable 
						while(x ==y){
							y = RandomNumberGen(100);
						}
						//Console.WriteLine (x +" , "+ y); was used for debugging :) 
						NPCs.Add( new NPC (x , y , nameToUse, storyToUse));
						Console.WriteLine (nameToUse + " Has been created");
						namesUsedBefore.Add(nameToUse);
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

                    for (int i = 0; i < NPCs.Count; i++) {
                        NPC c = (NPC)NPCs[i];
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

					//find npc with name

					NPC npcToAskAllianceWith = null; 
					for(int i =0; i < NPCs.Count; i ++){
						NPC nameFinder = (NPC)NPCs[i]; 

						if(nameFinder.name.ToLower() == nameToUse.ToLower()){

							npcToAskAllianceWith = nameFinder;
							break;
						}

					}
					if(npcToAskAllianceWith.myAligenes == "Friend"){

						npcPasafied++;
						Console.WriteLine ("You found a friend");

					}else{
						player.hp -= 2; 
						Console.WriteLine ("You Lost 2 HP");
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

                    for(int i =0; i < NPCs.Count; i++)
                    {
                        NPC badinfoToCall = (NPC)NPCs[i];

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
				if(input.ToLower() == "shoot" && playerIsActive && NPCCount > 0 && player.amunition > 0)
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
					bool ifIhitHim = false, NPCAlive = true;
                    string eminyStatus = null; 
                    for( int i = 0; i < NPCs.Count; i++)
                    {
                        NPC c = (NPC)NPCs[i];
                        if ((c.name).ToLower() == nameToUse.ToLower())
                        {
							if(c.hp <=0){

								NPCAlive = false;

							}
							if(NPCAlive){
							player.ShotMyGun();// removes one bullet
                            ifIhitHim = c.Shoot();
                            eminyStatus = c.myType;
								Console.WriteLine ("amunition - 1");
							}else{
								Console.WriteLine ("I cant do that they are all ready dead");
							}

                        }

                    }

					// prints out the shot responce 
					if (ifIhitHim && NPCAlive)
                    {

                        Console.WriteLine("You shot " + nameToUse);

                    }
					else if( !ifIhitHim && NPCAlive)
                    {
                        Console.WriteLine("You are to far away and missed " + nameToUse);
                    }
                    if(eminyStatus.ToLower() == "friend")
                    {
                        player.HitFriend();

                    }

                }
				else if (input.ToLower() == "shoot" && !playerIsActive ) 
                {
                    Console.WriteLine("You need to make a player frist");

				}else if (input.ToLower() == "shoot" &&  NPCCount == 0 )
                {
                    Console.WriteLine("There is no body to shoot");
				}else if (input.ToLower() == "shoot"  && player.amunition <= 0)
				{
					Console.WriteLine("Im out of ammo");
				}



                

                for(int i = 0; i < NPCs.Count; i++)
                {

                    NPC c = (NPC)NPCs[i];

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
				if (playerIsActive && NPCCount > 0)
                {
					// i would add a player hp <=0 but not stated in assignment brefe 
                    if (npcPasafied == NPCs.Count)
                    {
                        gameIsActive = !gameIsActive;
                    }
                }
            }

			//prints the game over message to console 
            Console.WriteLine("Game over your score = " + player.hp);

		



			//NPCs.Add(new NPC(x,y,name,story));

		}

		// was used to make an array form 1- a set number no longer required 
		public static byte[] GridNumberAdd(byte gridSize){

			byte[] gridReady = new byte[gridSize + 1];

			for(byte i =0; i <= gridSize; i ++){

				gridReady[i]= i;

			}


			return(gridReady);
		}


		// genarates random numbers in an array for posisions 
		//public static byte[] RandomNumberGen(byte numberOfNumberToReturn, byte maxNumber){

			//byte[] numbersToReturn = new byte[numberOfNumberToReturn];

			//Random rnd = new Random();

			//for( byte i = 0 ; i < numberOfNumberToReturn; i ++){
				//numbersToReturn[i] = (byte)rnd.Next(0,maxNumber);
			//}

			//return(numbersToReturn);
		//}
		// genarates random number for the scelction of the storys for the background of the bad guys 
		public static byte RandomNumberGen(byte maxNumber){

			byte numbersToReturn;

			Random rnd = new Random();
			numbersToReturn = (byte)rnd.Next(0,maxNumber);

		

			return(numbersToReturn);
		}



		}
			
	}


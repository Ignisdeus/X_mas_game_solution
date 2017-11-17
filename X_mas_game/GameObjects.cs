using System;
namespace X_mas_game
{
	// is the main class used in the game 
	public class Human
	{
		// custom struct for pos.x and pos.y notations 
		private Vector2 myPos;
		// all hp is 10 
		public byte hp = 10;
		// the updateing posision of the player that is always knowen to all childern of this class 
		public static byte[] playerPos= new byte[2]; 

		 // constuctor 
		public Human(byte x, byte y)
		{
			myPos = new Vector2(x,y);

		}

		public void IGotShot(){
			hp--;
		}

		// gets info for ho 
		public string hpLeft{

			get{
				return(""+hp);
			}
		}
		// gets an array for the posisions on a grid 
		public byte[] myLoc{

			get{
				
				byte[] loc = {myPos.x, myPos.y};
				return(loc);
			}
		}
		// for the move of player (can be transfared to NPCs if needed)
		public void ChangePos(byte x, byte y){

			myPos.x = x; 
			myPos.y = y;
			Console.WriteLine ("You have lost 1 hp");
			hp--;

		}



	}

	// badGuy extends Human
	public class BadGuy : Human{
		// name set by player 
		public string name = null;
		// type is always an unknown 
		private string type = null;
		// ally statis is unknown untill checked 
		public string allyStatus = "unknown";
		// story is randomly assigned 
		public string story= null;

		// constructor that also sends to super constructor(Constructor of the parent class (Human))
		public BadGuy(byte x, byte y, string myName, string myStory): base(x,y){

			CallMyinfo();
			name = myName;
			story = myStory;
			TypeSetup();


		}
		// checks to see if this guy is good or bad 
		void TypeSetup(){

			if(story == "Teaches under-privileged children in the hood." || story == "Pays child support for brothers child."){
				type = "Friend";
			}else{
				type = "Enemy";
			}
		}
		// gets info for NPC checks 
		public string CallMyinfo(){


			string infoToGet = AllMyinfo;

			return(infoToGet);



		}
		// get type for check 
        public string myType
        {
            get
            {

                return (type);
            }

        }
		// gets all info in a string 
		public string AllMyinfo{
            // health values, their allegiance status and their distance from the player.
            get
            {
				string info= null;

				info += "Name = " + name + " "; 
				info += " Ally Status= " + allyStatus + " "; 
				info +=  " Hp left= " + hpLeft + " ";
				Vector2 myPosNow = new Vector2(myLoc[0], myLoc[1]);
				Vector2 playerLoc = new Vector2(playerPos[0], playerPos[1]);
				info += " Distance= " + Vector2Lyb.Distance(myPosNow.x, myPosNow.y, playerLoc.x,playerLoc.y) + " ";


				return (info);
			}


		}
		// gets the allystatus of the NPC 
		public string myAligenes{

			get{

				allyStatus = type; 
				return(type);
			}

		}
		// if the shoot command is enters with my name check to see if I can be shot return info to and proced as expected 
        public bool Shoot()
        {
            byte[] myLocGot = myLoc;

            int distance = Vector2Lyb.Distance(playerPos[0], playerPos[1], myLocGot[0], myLocGot[1] );

            if (distance <= 50)
            {

                hp--;
                return (true);
            }
            else
            {
                return (false);
            }

        }

	}
	// same as Badguy 
	public class Player : Human{

		public string name = null;
		// ammo left
        public byte amunition = 50; 

		public Player(byte x, byte y, string name):base(x,y){

			this.name = name; 
		}

		//public void PlayerMove(byte x, byte y){



		//}

		// gets my into in a string 
            public string PlayerInfo{
           // health value, ammunition value and position.
            get
            {

                string infoToRetun = null;

                infoToRetun += "Player HP = " + hp + " ";
                infoToRetun += "Player Ammo = " + amunition + " ";
                infoToRetun += "Player position = " + playerPos[0] + " " + playerPos[1]; 



                return (infoToRetun);
            }


            }
		// updateing position when i move 
		public void playerCalulator(){

	
			playerPos[0] = myLoc[0];
			playerPos[1]= myLoc[1];


		}
		// lowers ammo when I shoot
		public void ShotMyGun(){

			amunition --; 
		}
		// if I hit a friend lower my hp
        public void HitFriend(){

            hp -= 2;
            Console.WriteLine("I didn't mean to shoot them");

            }
		// used for debugging 
		public void CheckMyLoc(){
			playerCalulator();
			Console.WriteLine(""+ playerPos[0] + ","+  playerPos[1]);
		}
	}
}

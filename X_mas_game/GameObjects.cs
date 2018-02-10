using System;
namespace X_mas_game
{
	// is the main class used in the game 
	public class GameObject
	{
		// custom struct for pos.x and pos.y notations 
		private Vector2 myPos = new Vector2();
		public string name = null;
		// all hp is 10 
		public byte hp = 5;
		// the updateing posision of the player that is always knowen to all childern of this class 
		//public static byte[] playerPos= new byte[2]; // couldnt get strut to work was a  work around :) 
		public static Vector2 playerPos = new Vector2();

		 // constuctor 
		public GameObject(byte x, byte y)
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
		public Vector2 myLoc{

			get{
				
				return(myPos);
			}
		}




	}

	// NPC extends GameObject
	public class NPC : GameObject{
		// name set by player 

		// type is always an unknown 
		private string type = null;
		// ally statis is unknown untill checked 
		public string allyStatus = "unknown";
		// story is randomly assigned 
		public string story= null;

		// constructor that also sends to super constructor(Constructor of the parent class (GameObject))
		public NPC(byte x, byte y, string myName, string myStory): base(x,y){

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
				//Vector2 myPosNow = myLoc;// was for testing 
				Vector2 playerLoc = new Vector2(playerPos.x, playerPos.y);
				info += " Distance= " + Vector2Lyb.Distance(myLoc.x, myLoc.y, playerLoc.x,playerLoc.y) + " ";


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
            //byte[] myLocGot = myLoc;

            int distance = Vector2Lyb.Distance(playerPos.x, playerPos.y, myLoc.x, myLoc.y );// usin

            if (distance <= 30)
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
	// same as NPC 
	public class Player : GameObject{

		//public string name = null;
		// ammo left
        public byte amunition = 10; 

		public Player(byte x, byte y, string name):base(x,y){

			this.name = name; 
			playerPos.x =x; 
			playerPos.y =y;
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
                infoToRetun += "Player position = " + playerPos.x + " " + playerPos.y; 



                return (infoToRetun);
            }


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

		// for the move of player (can be transfared to NPCs if needed)
		public void ChangePos(byte x, byte y){

			playerPos.x = x;
			playerPos.y = y;

			Console.WriteLine ("You have lost 1 hp");
			hp--;

		}
		// used for debugging 
		public void CheckMyLoc(){
			//playerCalulator();
			Console.WriteLine(""+ playerPos.x + ","+  playerPos.y);
		}
	}
}

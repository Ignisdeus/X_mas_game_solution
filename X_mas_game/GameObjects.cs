using System;
namespace X_mas_game
{
	public class Human
	{
		private Vector2 myPos;
		public byte hp = 10;
		public static byte[] playerPos= new byte[2]; 

		 
		public Human(byte x, byte y)
		{
			myPos = new Vector2(x,y);

		}

		public void IGotShot(){
			hp--;
		}

		public string hpLeft{

			get{
				return(""+hp);
			}
		}
		public byte[] myLoc{

			get{
				
				byte[] loc = {myPos.x, myPos.y};
				return(loc);
			}
		}

		public void ChangePos(byte x, byte y){

			myPos.x = x; 
			myPos.y =y;

		}



	}


	public class BadGuy : Human{

		public string name = null;
		private string type = null;
		public string allyStatus = "unknown";
		public string story= null;


		public BadGuy(byte x, byte y, string myName, string myStory): base(x,y){

			CallMyinfo();
			name = myName;
			story = myStory;
			TypeSetup();


		}

		void TypeSetup(){

			if(story == "Teaches under-privileged children in the hood." || story == "Pays child support for brothers child."){
				type = "Friend";
			}else{
				type = "Enemy";
			}
		}

		public string CallMyinfo(){


			string infoToGet = AllMyinfo;

			return(infoToGet);



		}
        public string myType
        {
            get
            {

                return (type);
            }

        }

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

		public string myAligenes{

			get{

				allyStatus = type; 
				return(type);
			}

		}

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

	public class Player : Human{

		public string name = null;
        public byte amunition = 50; 

		public Player(byte x, byte y, string name):base(x,y){

			this.name = name; 
		}

		//public void PlayerMove(byte x, byte y){



		//}


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
		public void playerCalulator(){

	
			playerPos[0] = myLoc[0];
			playerPos[1]= myLoc[1];


		}

        public void HitFriend(){

            hp -= 2;
            Console.WriteLine("I didn't mean to shoot them");

            }
		public void CheckMyLoc(){
			playerCalulator();
			Console.WriteLine(""+ playerPos[0] + ","+  playerPos[1]);
		}
	}
}

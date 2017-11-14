using System;
namespace X_mas_game
{
	public class Human
	{
		private Vector2 myPos;
		private byte hp = 10;
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



	}


	public class BadGuy : Human{

		private string name = "John";
		private string type = null;
		public string allyStatus = "unknown"; 


		public BadGuy(byte x, byte y): base(x,y){

			CallMyinfo();

		}

		public string CallMyinfo(){


			string infoToGet = AllMyinfo;

			return(infoToGet);



		}

		public string AllMyinfo{

			get{
				string info= null;

				info += "Name = " + name + " "; 
				info += " Ally Status= " + allyStatus + " "; 
				info +=  " Hp left= " + hpLeft + " ";
				Vector2 myPosNow = new Vector2(myLoc[0], myLoc[1]);
				Vector2 playerLoc = new Vector2(playerPos[0], playerPos[1]);
				info += " Distance= " + Vector2Lyb.Distance(myPosNow.x, myPosNow.y, playerLoc.x,playerLoc.y) + " ";
				// was a testing feature
				//info += ""+ myPosNow.x + " " + myPosNow.y;

				return (info);
			}


		}

	}

	public class Player : Human{



		public Player(byte x, byte y):base(x,y){

			//playerCalulator();
		}


		public void playerCalulator(){

	
			playerPos[0] = myLoc[0];
			playerPos[1]= myLoc[1];


		}
		public void CheckMyLoc(){
			playerCalulator();
			Console.WriteLine(""+ playerPos[0] + ","+  playerPos[1]);
		}
	}
}

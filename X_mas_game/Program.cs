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
			byte[] xAxis = new byte[gridSize];
			byte[] yAxis = new byte[gridSize];
			xAxis = GridNumberAdd(gridSize);
			yAxis = GridNumberAdd(gridSize);
			Random rnd = new Random();
			byte x = (byte)rnd.Next(0,100);
			byte y = (byte)rnd.Next(0,100);
			Player player = new Player(x,y);

			player.CheckMyLoc();
			// make bad guys apear and store them in a list 
			ArrayList badGuys = new ArrayList();

			for(int i =0 ; i < 5 ; i ++){

				Random rnds = new Random();
				byte x1 = (byte)rnd.Next(0,100);
				byte y1 = (byte)rnd.Next(0,100);
				badGuys.Add(new BadGuy(x1,y1));

			}

			for(int i = 0; i < badGuys.Count; i ++){

			
				BadGuy target = (BadGuy)badGuys[i];
				string inforToGet = target.AllMyinfo;
				Console.WriteLine(inforToGet);



			}

		}

		public static byte[] GridNumberAdd(byte gridSize){

			byte[] gridReady = new byte[gridSize + 1];

			for(byte i =0; i <= gridSize; i ++){

				gridReady[i]= i;

			}


			return(gridReady);
		}



		}
			
	}


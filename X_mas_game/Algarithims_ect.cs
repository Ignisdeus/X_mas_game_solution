using System;

namespace X_mas_game
{
	public class Vector2Lyb
	{
		public Vector2Lyb()
		{
		}

		// uses the pitagaris therom to work out the distance along the hyp for a more acurate reading of distance
		public static int Distance (float x1, float y1, float x2, float y2){

			x1 = PosativeMaker(x1);
			x2 = PosativeMaker(x2);
			y1 = PosativeMaker(y1);
			y2 = PosativeMaker(y2);

			double hyp; 
			float sideOne = x1 - x2;
			sideOne = PosativeMaker(sideOne);
			float sideTwo = y1- y2;
			sideTwo = PosativeMaker(sideTwo);

			hyp = (sideOne*sideOne)  + (sideTwo * sideTwo);

			hyp = Math.Sqrt(hyp);
			hyp= (int)Math.Floor(hyp);

			return((int)hyp);
		}

		// sets any negative number to a posative
		public static float PosativeMaker(float x){

			float fixedNumber;

			if( x < 0){

				fixedNumber = x*(-1);

			}else{
				fixedNumber = x;
			}



			return(fixedNumber);



		}
	}
}

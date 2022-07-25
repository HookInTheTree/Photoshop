using MyPhotoshop.Data;
using System;

namespace MyPhotoshop
{
	public class Photo
	{
		public readonly int width;
		public readonly int height;
		public readonly Pixel[,] data;
		public Pixel this[int xIndex, int yIndex]
        {
            get
            {
				return this.data[xIndex, yIndex];
            }
            set
            {
				this.data[xIndex, yIndex] = value; 
            }
        }
		public Photo(int width, int height)
        {
			this.width = width;
			this.height = height;
			this.data = new Pixel[width, height];
			
        }
	}
}


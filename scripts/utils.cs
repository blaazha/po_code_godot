using Godot;
using System;

public static class Utils
{
	private static Random random = new Random();
	
	public static Pixel GetRandomPixel()
	{
		return new Pixel
		{
			X = random.Next(1, Constants.GUI_WIDTH),
			Y = random.Next(1, Constants.GUI_HEIGHT)
		};
	}
}

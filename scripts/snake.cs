using System.Collections.Generic;
using System;

public class Snake
{
	public Pixel Head { get; private set; }
	public List<Pixel> Body { get; private set; }
	public DirectionWrapper Movement { get; set; }

	public Snake(Pixel head)
	{
		Head = head;
		Body = new List<Pixel>();
		Movement = Direction.RIGHT;
	}

	public void Move(int score)
	{
		Body.Add(new Pixel { X = Head.X, Y = Head.Y, Color = ConsoleColor.Green });
		switch (Movement.Value)
		{
			case Direction.UP:
				Head.Y--;
				break;
			case Direction.DOWN:
				Head.Y++;
				break;
			case Direction.LEFT:
				Head.X--;
				break;
			case Direction.RIGHT:
				Head.X++;
				break;
		}
		if (Body.Count > score)
			Body.RemoveAt(0);
	}
}

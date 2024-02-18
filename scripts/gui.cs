using Godot;
using System;
using System.Collections.Generic;

public partial class gui : Node
{
	private MarginContainer _container;
	private int screenWidth;
	private int screenHeight;

	public gui(MarginContainer container)
	{
		_container = container;
	}
	
	public void Clear(){
		   while (_container.GetChildCount() > 0)
	{
		Node child = _container.GetChild(0);
		_container.RemoveChild(child);
		child.QueueFree(); // Optional: if you want to free the node
	}
	}


			public void DrawBody(List<Pixel> body)
			{
				foreach (var pixel in body)
				{
					PrintPixel(pixel);
				}
			}

			public bool CheckCollision(Snake snake)
			{
				if (snake.Head.X == screenWidth - 1 || snake.Head.X == 0 || snake.Head.Y == screenHeight - 1 || snake.Head.Y == 0)
					return true;

				foreach (Pixel body in snake.Body)
				{
					if (snake.Head.X == body.X && snake.Head.Y == body.Y)
						return true;
				}

				return false;
			}
	public void PrintPixel(Pixel pixel)
	{
		var sprite = new Sprite2D();
		
		var texture = (Texture2D)GD.Load("res://colors/green.png");
		if (pixel.Color == ConsoleColor.Red)
			texture = (Texture2D)GD.Load("res://colors/red.png");
		if (pixel.Color == ConsoleColor.Blue)
			texture = (Texture2D)GD.Load("res://colors/blue.png");
		
		sprite.Texture = texture;

		// Set the sprite's scale (modify these values as needed)
		// This example assumes you want to double the size of the sprite
		sprite.Scale = new Vector2(Constants.SCALE, Constants.SCALE);

		// Set the sprite's position (modify these values as needed)
		sprite.Position = new Vector2(pixel.X * Constants.SCALE, pixel.Y * Constants.SCALE);

		// Add the sprite as a child of this node
		_container.AddChild(sprite);
	}

			public void HandleKeyPress(DirectionWrapper movement, ConsoleKeyInfo keyInfo, ref string buttonPressed)
			{
				switch (keyInfo.Key)
				{
					case ConsoleKey.UpArrow:
						if (movement != Direction.DOWN && buttonPressed == "no")
						{
							movement.Value = Direction.UP;
							buttonPressed = "yes";
						}
						break;
					case ConsoleKey.DownArrow:
						if (movement != Direction.UP && buttonPressed == "no")
						{
							movement.Value = Direction.DOWN;
							buttonPressed = "yes";
						}
						break;
					case ConsoleKey.LeftArrow:
						if (movement != Direction.RIGHT && buttonPressed == "no")
						{
							movement.Value = Direction.LEFT;
							buttonPressed = "yes";
						}
						break;
					case ConsoleKey.RightArrow:
						if (movement != Direction.LEFT && buttonPressed == "no")
						{
							movement.Value = Direction.RIGHT;
							buttonPressed = "yes";
						}
						break;
				}
			}

			public void DisplayGameOverMessage(int score)
			{
				Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);
				Console.WriteLine($"Game over, Score: {score}");
				Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);
			}
}

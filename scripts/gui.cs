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
		child.QueueFree();
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
		sprite.Scale = new Vector2(Constants.SCALE, Constants.SCALE);
		sprite.Position = new Vector2(pixel.X * Constants.SCALE, pixel.Y * Constants.SCALE);

		_container.AddChild(sprite);
	}

			public void DisplayGameOverMessage(int score, Label label)
			{
				Clear();
				label.Text = "Game score: " + (score - 5);
			}
}

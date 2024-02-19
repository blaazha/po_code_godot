using Godot;
using System;

public partial class main : Node2D
{
	private gui g;
	private Random random = new Random();
	private int score = 5;
	private bool gameOver = false;
	private Pixel berry;

	Snake snake = new Snake(new Pixel
		{
			X = Constants.GUI_WIDTH / 2,
			Y = Constants.GUI_HEIGHT / 2,
			Color = ConsoleColor.Red
		});
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		MarginContainer container = GetNode<MarginContainer>("MarginContainer");
		g = new gui(container);
		berry = Utils.GetRandomPixel();
		berry.Color = ConsoleColor.Blue;
		
		g.PrintPixel(snake.Head);
		g.PrintPixel(berry);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (gameOver)
			return;
		snake.Move(score);
		
		g.Clear();
		g.DrawBody(snake.Body);
		g.PrintPixel(snake.Head);
		g.PrintPixel(berry);
		
		if (CheckBerryPickUp(snake, berry)) {
			berry = Utils.GetRandomPixel();
			berry.Color = ConsoleColor.Blue;
			score++;
		}
			
		
		if (CheckCollision(snake)) {
			gameOver = true;
			g.DisplayGameOverMessage(score, GetNode<Label>("GameOverLabel"));
		}
	}
	
	public override void _UnhandledInput(InputEvent @event)
	{
		// https://docs.godotengine.org/en/stable/tutorials/inputs/inputevent.html
	if (@event is InputEventKey eventKey && eventKey.Pressed)
	{
			if (eventKey.Keycode == Key.Left)
				snake.Movement = Direction.LEFT;
			else if (eventKey.Keycode == Key.Right)
				snake.Movement = Direction.RIGHT;
			else if (eventKey.Keycode == Key.Up)
				snake.Movement = Direction.UP;
			else if (eventKey.Keycode == Key.Down)
				snake.Movement = Direction.DOWN;
	}
	}
	
	private bool CheckBerryPickUp(Snake snake, Pixel berry) {
		return snake.Head.X == berry.X && snake.Head.Y == berry.Y;
	}
	
			   private bool CheckCollision(Snake snake)
			{
				if (snake.Head.X == Constants.GUI_WIDTH - 1 || snake.Head.X == 0 || snake.Head.Y == Constants.GUI_HEIGHT - 1 || snake.Head.Y == 0)
					return true;

				foreach (Pixel body in snake.Body)
				{
					if (snake.Head.X == body.X && snake.Head.Y == body.Y)
						return true;
				}

				return false;
			}

}

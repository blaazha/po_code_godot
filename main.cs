using Godot;
using System;

public partial class main : Node2D
{
	private gui g;
	private Random random = new Random();
	private int score = 5;
	private bool gameOver = false;

	Snake snake = new Snake(new Pixel
		{
			X = Constants.GUI_WIDTH / 2,
			Y = Constants.GUI_HEIGHT / 2,
			Color = ConsoleColor.Red
		});
	Pixel berry = Utils.GetRandomPixel();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		MarginContainer container = GetNode<MarginContainer>("MarginContainer");
		g = new gui(container);
		
		g.PrintPixel(snake.Head);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
}

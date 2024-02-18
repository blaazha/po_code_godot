public enum Direction
{
	UP,
	DOWN,
	LEFT,
	RIGHT
}

public class DirectionWrapper
{
	public Direction Value { get; set; }
	
	public static implicit operator DirectionWrapper(Direction direction) =>
		new DirectionWrapper { Value = direction };
	
	public static implicit operator Direction(DirectionWrapper wrapper) =>
		wrapper.Value;
}

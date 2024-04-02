using Godot;

public class Player : KinematicBody2D
{
	public int Speed { get; set; } = 300;
	public Vector2 MovementDirection { get; set; }
	public MovementControl MovementControl { get; set; }

	public override void _Ready()
	{
		MovementControl = (MovementControl) GetNode("MovementControl");
		MovementControl.Connect(nameof(MovementControl.SetMovementDirection), this, nameof(GetMovementDirection));
		MovementControl.Speed = Speed;
	}

	public override void _PhysicsProcess(float delta)
	{
		LookAt(GetGlobalMousePosition());
		MoveAndSlide(MovementDirection * Speed);
	}

	public void GetMovementDirection(Vector2 direction)
	{
		MovementDirection = direction.Normalized();
	}
}
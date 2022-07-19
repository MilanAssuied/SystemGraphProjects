using UnityEngine;
using Mechatronics.SystemGraph;

[NodeCategory("conveyor", "Detector")]
public class Detector : NodeRuntime
{

	[Field("Output", PortDirection.Right, FieldExtra.Write), SerializeField]
	private PortType<bool> itemDetected = new();

	[Binding("CollisionSensor"), SerializeField]
	private CollisionSensorBinding m_CollisionSensor;

	public override void Enable(Scheduler.ClockState clockState)
	{
	}

	public override void Disable()
	{
	}

	public override bool OnTick(double now, double eventTime, Scheduler.ClockState clockState, Scheduler.Signal signal)
	{
		Debug.Log($"Detector: collision detected: {m_CollisionSensor.data.collisionDetected}");

		itemDetected.Write = m_CollisionSensor.data.collisionDetected;
		return true;
	}
}

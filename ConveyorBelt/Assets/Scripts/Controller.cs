using UnityEngine;
using Mechatronics.SystemGraph;


[NodeCategory("conveyor", "controller", NodeTick.Asynchronous)]
public class Controller : NodeRuntime
{
	[Field("EmergencyStop", PortDirection.Left, FieldExtra.Read), SerializeField]
	private PortType<bool> emergencyStop = new();

	[Field("ItemIn", PortDirection.Left, FieldExtra.Read), SerializeField]
	private PortType<bool> itemIn = new();

	[Field("ItemOut", PortDirection.Left, FieldExtra.Read), SerializeField]
	private PortType<bool> itemOut = new();
	
	[Field("IsRunning", PortDirection.Right, FieldExtra.Write), SerializeField]
	private PortType<bool> isRunning = new();
	
	[Field("CurrentNumberOfItems", PortDirection.Right, FieldExtra.Write), SerializeField]
	private PortType<uint> currentNumberOfItems = new();
	
	[Field("TotalNumberOfItems", PortDirection.Right, FieldExtra.Write), SerializeField]
	private PortType<uint> totalNumberOfItems = new();

	private uint m_CurrentItemCount;
	private uint m_TotalItemCount;
	
	public override void Enable(Scheduler.ClockState clockState)
	{
		m_CurrentItemCount = 0;
		m_TotalItemCount = 0;
		
		itemIn.ChangeEvent += OnItemIn;
		itemOut.ChangeEvent += OnItemOut;
		
		emergencyStop.ChangeEvent += ProcessOutputs;
		
		ProcessOutputs();
	}

	public override void Disable()
	{
		itemIn.ChangeEvent -= OnItemIn;
		itemOut.ChangeEvent -= OnItemOut;
		
		emergencyStop.ChangeEvent -= ProcessOutputs;
	}

	private void OnItemIn()
	{
		if (itemIn.Read)
		{
			m_CurrentItemCount++;
			m_TotalItemCount++;
			ProcessOutputs();
		}
	}
	
	private void OnItemOut()
	{
		if (itemOut.Read)
		{
			m_CurrentItemCount--;
			ProcessOutputs();
		}
	}

	private void ProcessOutputs()
	{
		currentNumberOfItems.Write = m_CurrentItemCount;
		totalNumberOfItems.Write = m_TotalItemCount;
		
		isRunning.Write = !emergencyStop.Read && m_CurrentItemCount > 0;
	}
}

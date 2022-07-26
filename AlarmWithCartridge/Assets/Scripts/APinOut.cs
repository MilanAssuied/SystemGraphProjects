using System;
using UnityEngine;
using Mechatronics.SystemGraph;

/// <summary>
/// Node script template
/// Please revise this description and the NodeCategory parameters to correspond to your usage.
/// You can use NodeTick.Synchronous instead of NodeTick.Asynchronous when your node has to be ticked by the scheduler of SystemGraph.
/// </summary>
[NodeCategory("Interfaces", "APinOut", NodeTick.Asynchronous)]
public class APinOut : Pinout
{
	/// <summary>
	/// This section describes the data contract of the node (ports/fields)
	/// All PortTypes defined here with the attribute Field will be displayed to the node UI of the SystemGraph
	/// </summary>

	[Field("Input", PortDirection.Left, FieldExtra.Read), SerializeField]
	private PortType<uint> input = new PortType<uint>();

	[Field("Output", PortDirection.Right, FieldExtra.Write), SerializeField]
	private PortType<uint> output = new PortType<uint>();
}

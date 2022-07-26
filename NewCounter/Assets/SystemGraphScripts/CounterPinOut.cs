using Mechatronics.SystemGraph;
using TMPro;
using UnityEngine;

namespace New_Folder
{
	/// <summary>
	/// Node script template
	/// Please revise this description and the NodeCategory parameters to correspond to your usage.
	/// You can use NodeTick.Synchronous instead of NodeTick.Asynchronous when your node has to be ticked by the scheduler of SystemGraph.
	/// </summary>
	[NodeCategory("HellowWorld", "CounterPinOut", NodeTick.Synchronous)]
	public class CounterPinOut : Pinout
	{
		/// <summary>
		/// This section describes the data contract of the node (ports/fields)
		/// All PortTypes defined here with the attribute Field will be displayed to the node UI of the SystemGraph
		/// </summary>

		[Field("LcdDisplay", PortDirection.Left, FieldExtra.Read)]
		public PortType<GameObject> lcdDisplay = new ();

		[Field("Incrementation", PortDirection.Left, FieldExtra.Read)]
		public PortType<uint> incrementation = new();
	
		[Field("Output", PortDirection.Right, FieldExtra.Write)]
		public PortType<int> output = new();

		private TextMeshPro _lcdDisplay;

		public TextMeshPro LcdDisplay => _lcdDisplay;

		public void Initialize()
		{
			if (lcdDisplay != null && lcdDisplay.Read != null)
			{
				_lcdDisplay = lcdDisplay.Read.GetComponent<TextMeshPro>();
			}
		}
	}
}

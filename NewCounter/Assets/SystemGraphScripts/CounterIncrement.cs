using System;
using Mechatronics.SystemGraph;
using UnityEngine;

namespace New_Folder
{
    public class CounterIncrement : CartridgeMonoBehaviour<CounterPinOut>
    {
   
        public override void NodeCreate()
        {
            Debug.Log("CounterIncrement: NodeCreate");
        }
    
        public override void NodeStart()
        {
            Debug.Log("CounterIncrement: NodeStart");
        
            if (Pin.SystemGraph != null)
            {
                Pin.lcdDisplay.Link(Pin.SystemGraph.GetPropertyPort("LcdObject"));
                Pin.incrementation.Link(Pin.SystemGraph.GetPropertyPort("Increment"));
                Pin.Initialize();
            }
            else
                Debug.LogError($"CounterIncrement.cs ({gameObject.name}): You must set a reference to a lidar system graph component.");
        }
    
        public override void NodeEnable(Scheduler.ClockState clockState)
        {
            Debug.Log("LidarGraphCartridge: NodeEnable");
        }
    
        public override void NodeDisable()
        {
            Debug.Log("LidarGraphCartridge: NodeDisable");
        }
    
        public override bool NodeTick(double now, double eventTime, Scheduler.ClockState clockState, Scheduler.Signal signal)
        {
            Pin.output.Write = Pin.output.ReadRaw + (int) Pin.incrementation.Read;

            if (Pin.lcdDisplay != null)
            {
                Pin.LcdDisplay.text = String.Format("Count: {0}", Pin.output.Read.ToString());
            }

            return true;
        }
    }
}


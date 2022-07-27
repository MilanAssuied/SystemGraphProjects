using System;
using Mechatronics.SystemGraph;
using UnityEngine;

namespace New_Folder
{
    public class CounterDecrement : CartridgeMonoBehaviour<CounterPinOut>
    {
   
        public override void NodeCreate()
        {
            Debug.Log("CounterDecrement: NodeCreate");
        }
    
        public override void NodeStart()
        {
            Debug.Log("CounterDecrement: NodeStart");
        
            if (Pin.SystemGraph != null)
            {
                Pin.Initialize();
            }
            else
                Debug.LogError($"CounterIncrement.cs ({gameObject.name}): You must set a reference to a lidar system graph component.");
        }
    
        public override void NodeEnable(Scheduler.ClockState clockState)
        {
            Debug.Log("CounterDecrement: NodeEnable");
        }
    
        public override void NodeDisable()
        {
            Debug.Log("CounterDecrement: NodeDisable");
        }
    
        public override bool NodeTick(double now, double eventTime, Scheduler.ClockState clockState, Scheduler.Signal signal)
        {
            Pin.output.Write = (int) Pin.output.ReadRaw - (int) Pin.incrementation.Read;

            if (Pin.lcdDisplay != null)
            {
                Pin.LcdDisplay.text = String.Format("Count: {0}", Pin.output.Read.ToString());
            }

            return true;
        }
    }
}


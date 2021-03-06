﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TeknoParrotUi.Common.Jvs;

namespace TeknoParrotUi.Common.Pipes
{
    public class GtiClub3 : ControlSender
    {
        public override void Transmit()
        {
            while (Running)
            {
                var control = 0x00;
                // Shift Up
                if (InputCode.PlayerDigitalButtons[1].Up.HasValue && InputCode.PlayerDigitalButtons[1].Up.Value)
                    control |= 0x0100;
                // Action Button
                if (InputCode.PlayerDigitalButtons[0].Button1.HasValue && InputCode.PlayerDigitalButtons[0].Button1.Value)
                    control |= 0x0800;

                // Select Button Up
                if (InputCode.PlayerDigitalButtons[0].Up.HasValue && InputCode.PlayerDigitalButtons[0].Up.Value)
                    control |= 0x1000;
                // Select Button Down
                if (InputCode.PlayerDigitalButtons[0].Down.HasValue && InputCode.PlayerDigitalButtons[0].Down.Value)
                    control |= 0x2000;
                // Select Button Left
                if (InputCode.PlayerDigitalButtons[0].Left.HasValue && InputCode.PlayerDigitalButtons[0].Left.Value)
                    control |= 0x4000;
                // Select Button Right
                if (InputCode.PlayerDigitalButtons[0].Right.HasValue && InputCode.PlayerDigitalButtons[0].Right.Value)
                    control |= 0x8000;

                // Test
                if (InputCode.PlayerDigitalButtons[0].Test.HasValue && InputCode.PlayerDigitalButtons[0].Test.Value)
                    control |= 0x02;
                // Service
                if (InputCode.PlayerDigitalButtons[0].Service.HasValue && InputCode.PlayerDigitalButtons[0].Service.Value)
                    control |= 0x01;
                // Coin
                if (InputCode.PlayerDigitalButtons[0].Coin.HasValue && InputCode.PlayerDigitalButtons[0].Coin.Value)
                    control |= 0x04;
                // Start
                if (InputCode.PlayerDigitalButtons[0].Start.HasValue && InputCode.PlayerDigitalButtons[0].Start.Value)
                    control |= 0x10;
                // Shift Down
                if (InputCode.PlayerDigitalButtons[1].Down.HasValue && InputCode.PlayerDigitalButtons[1].Down.Value)
                    control |= 0x80;

                JvsHelper.StateView.Write(8, control);
                JvsHelper.StateView.Write(12, 0xFF + InputCode.AnalogBytes[0] * 0x100);
                JvsHelper.StateView.Write(16, 0xFF + InputCode.AnalogBytes[2] * 0x100);
                JvsHelper.StateView.Write(20, 0xFF + InputCode.AnalogBytes[4] * 0x100);
                Thread.Sleep(15);
            }
        }
    }
}

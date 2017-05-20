using System;
using System.Threading.Tasks;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;

namespace EV3.API
{
    public sealed class SingletonBrick
    {
        private static readonly Lazy<SingletonBrick> Lazy =
            new Lazy<SingletonBrick>(() => new SingletonBrick());

        private readonly Brick _brick;

        public static SingletonBrick Instance => Lazy.Value;

        private SingletonBrick()
        {
            _brick = new Brick(new BluetoothCommunication("COM4"));
            _brick.ConnectAsync();
        }

        public void Forward()
        {
            _brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.C, 100, 1000, true);
            _brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.B, 100, 1000, true);
            Go();
        }

        private void Go()
        {
            Task.Factory.StartNew(() => _brick.BatchCommand.SendCommandAsync().Result);
        }

        public void Back()
        {
            _brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.C, -100, 1000, true);
            _brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.B, -100, 1000, true);
            Go();
        }

        public void Left()
        {
            _brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.C, 100, 700, true);
            _brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.B, -100, 700, true);
            Go();
        }

        public void Right()
        {
            _brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.C, -100, 700, true);
            _brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.B, 100, 700, true);
            Go();
        }
    }
}
using OpenProtocolInterpreter.Job;
using OpenProtocolInterpreter.ParameterSet;
using System;

namespace OpenProtocolInterpreter.Emulator.Controller.Models
{
    internal class FakeParameterSet
    {
        public int Id { get; set; }
        public RotationDirection RotationDirection { get; set; }
        public int BatchSize { get; set; }
        public decimal MinTorque { get; set; }
        public decimal MaxTorque { get; set; }
        public decimal TorqueFinalTarget { get; set; }
        public int MinAngle { get; set; }
        public int MaxAngle { get; set; }
        public int AngleFinalTarget { get; set; }

        public bool AutoValue { get; set; }
        public int ChannelId { get; set; }

        public Mid0013 ToMid0013(int revision = 1)
        {
            return new Mid0013(revision)
            {
                ParameterSetId = Id,
                ParameterSetName = $"Parameter Set {Id}",
                RotationDirection = RotationDirection,
                BatchSize = BatchSize,
                MinTorque = MinTorque,
                MaxTorque = MaxTorque,
                TorqueFinalTarget = TorqueFinalTarget,
                MinAngle= MinAngle,
                MaxAngle = MaxAngle,
                AngleFinalTarget = AngleFinalTarget
            };
        }

        public Job.ParameterSet ToJobParameterSet()
        {
            return new Job.ParameterSet()
            {
                ChannelId = ChannelId,
                TypeId = Id,
                AutoValue = AutoValue,
                BatchSize = BatchSize
            };
        }

        public static FakeParameterSet Random(int id)
        {
            var random = new Random();
            return new FakeParameterSet()
            {
                Id = id,
                RotationDirection = (RotationDirection)random.Next(0, 1),
                BatchSize = random.Next(1, 10),
                MinTorque = random.Next(10, 100),
                MaxTorque = random.Next(200, 300),
                TorqueFinalTarget = random.Next(120, 140),
                MinAngle = random.Next(30, 60),
                MaxAngle = random.Next(120, 360),
                AngleFinalTarget = random.Next(90, 110),
                AutoValue = random.NextBoolean(),
                ChannelId = random.Next(1, 4)
            };
        }
    }
}

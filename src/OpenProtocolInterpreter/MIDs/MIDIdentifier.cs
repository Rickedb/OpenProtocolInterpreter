using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.MIDs
{
    public class MIDIdentifier
    {
        private readonly Dictionary<Func<int, bool>, Func<string, MID>> messageInterpreterTemplates;
        private readonly IEnumerable<MID> selectedMids;

        public MIDIdentifier()
        {
            this.messageInterpreterTemplates = new Dictionary<Func<int, bool>, Func<string, MID>>()
            {
                { mid => this.isKeepAliveMessage(mid), package => new KeepAlive.MID_9999() },
                { mid => this.isCommunicationMessage(mid), package => new Communication.CommunicationMessages().processPackage(package) },
				{ mid => this.isParameterSetMessage(mid), package => new ParameterSet.ParameterSetMessages().processPackage(package) },
                { mid => this.isAlarmMessage(mid), package => new Alarm.AlarmMessages().processPackage(package) },
                { mid => this.isTighteningMessage(mid), package => new Tightening.TighteningMessages().processPackage(package) },
                { mid => this.isJobMessage(mid), package => new Job.JobMessages().processPackage(package) },
                { mid => this.isAdvancedJobMessage(mid), package => new Job.Advanced.AdvancedJobMessages().processPackage(package) },
                { mid => this.isMultipleIdentifiersMessage(mid), package => new MultipleIdentifiers.MultipleIdentifierMessages().processPackage(package) },
                { mid => this.isIOInterfaceMessage(mid), package => new IOInterface.IOInterfaceMessages().processPackage(package) },
                { mid => this.isTimeMessage(mid), package => new Time.TimeMessages().processPackage(package) },
                { mid => this.isToolMessage(mid), package => new Tool.ToolMessages().processPackage(package) },
                { mid => this.isVINMessage(mid), package => new VIN.VINMessages().processPackage(package) },
                { mid => this.isMultiSpindleMessage(mid), package => new MultiSpindle.MultiSpindleMessages().processPackage(package) },
                { mid => this.isUserInterfaceMessage(mid), package => new UserInterface.UserInterfaceMessages().processPackage(package) }
            };
        }

        public MIDIdentifier(IEnumerable<MID> useOnlyTheseMids)
        {
            this.selectedMids = useOnlyTheseMids;
            this.messageInterpreterTemplates = new Dictionary<Func<int, bool>, Func<string, MID>>()
            {
                { mid => this.isKeepAliveMessage(mid), package => new KeepAlive.MID_9999() },
                { mid => this.isCommunicationMessage(mid), package => new Communication.CommunicationMessages(selectedMids.Where(x=> typeof(Communication.ICommunication).IsAssignableFrom(x.GetType()))).processPackage(package) },
				{ mid => this.isParameterSetMessage(mid), package => new ParameterSet.ParameterSetMessages(selectedMids.Where(x=> typeof(ParameterSet.IParameterSet).IsAssignableFrom(x.GetType()))).processPackage(package) },
                { mid => this.isAlarmMessage(mid), package => new Alarm.AlarmMessages(selectedMids.Where(x=> typeof(Alarm.IAlarm).IsAssignableFrom(x.GetType()))).processPackage(package) },
                { mid => this.isTighteningMessage(mid), package => new Tightening.TighteningMessages(selectedMids.Where(x=> typeof(Tightening.ITightening).IsAssignableFrom(x.GetType()))).processPackage(package) },
                { mid => this.isJobMessage(mid), package => new Job.JobMessages(selectedMids.Where(x=> typeof(Job.IJob).IsAssignableFrom(x.GetType()))).processPackage(package) },
                { mid => this.isAdvancedJobMessage(mid), package => new Job.Advanced.AdvancedJobMessages(selectedMids.Where(x=> typeof(Job.Advanced.IAdvancedJob).IsAssignableFrom(x.GetType()))).processPackage(package) },
                { mid => this.isMultipleIdentifiersMessage(mid), package => new MultipleIdentifiers.MultipleIdentifierMessages(selectedMids.Where(x=> typeof(MultipleIdentifiers.IMultipleIdentifier).IsAssignableFrom(x.GetType()))).processPackage(package) },
                { mid => this.isIOInterfaceMessage(mid), package => new IOInterface.IOInterfaceMessages(selectedMids.Where(x=> typeof(IOInterface.IIOInterface).IsAssignableFrom(x.GetType()))).processPackage(package) },
                { mid => this.isTimeMessage(mid), package => new Time.TimeMessages(selectedMids.Where(x=> typeof(Time.ITime).IsAssignableFrom(x.GetType()))).processPackage(package) },
                { mid => this.isToolMessage(mid), package => new Tool.ToolMessages(selectedMids.Where(x=> typeof(Tool.ITool).IsAssignableFrom(x.GetType()))).processPackage(package) },
                { mid => this.isVINMessage(mid), package => new VIN.VINMessages(selectedMids.Where(x=> typeof(VIN.IVIN).IsAssignableFrom(x.GetType()))).processPackage(package) },
                { mid => this.isMultiSpindleMessage(mid), package => new MultiSpindle.MultiSpindleMessages(selectedMids.Where(x=> typeof(MultiSpindle.IMultiSpindle).IsAssignableFrom(x.GetType()))).processPackage(package) },
                { mid => this.isPowerMACSMessage(mid), package => new PowerMACS.PowerMACSMessages(selectedMids.Where(x=> typeof(PowerMACS.IPowerMACS).IsAssignableFrom(x.GetType()))).processPackage(package) },
                { mid => this.isUserInterfaceMessage(mid), package => new UserInterface.UserInterfaceMessages(selectedMids.Where(x=> typeof(UserInterface.IUserInterface).IsAssignableFrom(x.GetType()))).processPackage(package) }
            };
        }

        public MID IdentifyMid(string package)
        {
            int mid = int.Parse(package.Substring(4, 4));

            var func = this.messageInterpreterTemplates.FirstOrDefault(x => x.Key(mid));
            return func.Value(package);
        }

        public ExpectedMid IdentifyMid<ExpectedMid>(string package) where ExpectedMid : MID
        {
            return (ExpectedMid)this.IdentifyMid(package);
        }

        private bool isKeepAliveMessage(int mid) { return (mid == 9999); }

        private bool isCommunicationMessage(int mid) { return (mid > 0 && mid < 10); }

        private bool isParameterSetMessage(int mid) { return (mid > 9 && mid < 26); }

        private bool isJobMessage(int mid) { return (mid > 29 && mid < 40); }

        private bool isToolMessage(int mid) { return (mid > 39 && mid < 49); }

        private bool isVINMessage(int mid) { return (mid > 49 && mid < 55); }

        private bool isTighteningMessage(int mid) { return (mid > 59 && mid < 66); }

        private bool isAlarmMessage(int mid) { return (mid > 69 && mid < 79); }

        private bool isTimeMessage(int mid) { return (mid > 79 && mid < 83); }

        private bool isMultiSpindleMessage(int mid) { return (mid > 89 && mid < 104); }

        private bool isPowerMACSMessage(int mid) { return (mid > 104 && mid < 110); }

        private bool isUserInterfaceMessage(int mid) { return (mid > 109 && mid < 114); }

        private bool isAdvancedJobMessage(int mid) { return (mid > 119 && mid < 141); }

        private bool isMultipleIdentifiersMessage(int mid) { return (mid > 149 && mid < 158); }

        private bool isIOInterfaceMessage(int mid) { return (mid > 199 && mid < 226); }

        private bool isPLCUserDataMessage(int mid) { return (mid > 239 && mid < 245); }

        private bool isSelectorMessage(int mid) { return (mid > 249 && mid < 256); }

        private bool isToolLocationSystemMessage(int mid) { return (mid > 259 && mid < 265); }

        private bool isControllerMessage(int mid) { return (mid == 270); }

        private bool isStatisticMessage(int mid) { return (mid > 299 && mid < 302); }

        private bool isAutomaticManualModeMessage(int mid) { return (mid > 399 && mid < 412); }

        private bool isOpenProtocolCommandsDisabledModeMessage(int mid) { return (mid > 419 && mid < 424); }

        private bool isMotorTuningMessage(int mid) { return (mid > 499 && mid < 505); }

    }
}

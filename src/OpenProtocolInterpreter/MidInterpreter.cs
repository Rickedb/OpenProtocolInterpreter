using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter
{
    public class MidInterpreter
    {
        private readonly Dictionary<Func<int, bool>, Func<string, Mid>> _messageInterpreterTemplates;
        private readonly IEnumerable<Mid> _selectedMids;

        public MidInterpreter()
        {
            _messageInterpreterTemplates = new Dictionary<Func<int, bool>, Func<string, Mid>>()
            {
                { mid => IsKeepAliveMessage(mid), package => new KeepAlive.MID_9999() },
                { mid => IsCommunicationMessage(mid), package => new Communication.CommunicationMessages().ProcessPackage(package) },
				{ mid => IsParameterSetMessage(mid), package => new ParameterSet.ParameterSetMessages().ProcessPackage(package) },
                { mid => IsJobMessage(mid), package => new Job.JobMessages().ProcessPackage(package) },
                { mid => IsToolMessage(mid), package => new Tool.ToolMessages().ProcessPackage(package) },
                { mid => IsVINMessage(mid), package => new Vin.VinMessages().ProcessPackage(package) },
                { mid => IsTighteningMessage(mid), package => new Tightening.TighteningMessages().ProcessPackage(package) },
                { mid => IsAlarmMessage(mid), package => new Alarm.AlarmMessages().ProcessPackage(package) },
                { mid => IsTimeMessage(mid), package => new Time.TimeMessages().ProcessPackage(package) },
                { mid => IsMultiSpindleMessage(mid), package => new MultiSpindle.MultiSpindleMessages().ProcessPackage(package) },
                { mid => IsPowerMACSMessage(mid), package => new PowerMACS.PowerMACSMessages().ProcessPackage(package) },
                { mid => IsUserInterfaceMessage(mid), package => new UserInterface.UserInterfaceMessages().ProcessPackage(package) },
                { mid => IsAdvancedJobMessage(mid), package => new Job.Advanced.AdvancedJobMessages().ProcessPackage(package) },
                { mid => IsMultipleIdentifiersMessage(mid), package => new MultipleIdentifiers.MultipleIdentifierMessages().ProcessPackage(package) },
                { mid => IsIOInterfaceMessage(mid), package => new IOInterface.IOInterfaceMessages().ProcessPackage(package) },
                { mid => IsPLCUserDataMessage(mid), package => new PLCUserData.PLCUserDataMessages().ProcessPackage(package) },
                { mid => IsSelectorMessage(mid), package => new ApplicationSelector.ApplicationSelectorMessages().ProcessPackage(package) },
                { mid => IsToolLocationSystemMessage(mid), package => new ApplicationToolLocationSystem.ApplicationToolLocationSystemMessages().ProcessPackage(package) },
                { mid => IsControllerMessage(mid), package => new ApplicationController.MID_0270() },
                { mid => IsStatisticMessage(mid), package => new Statistic.StatisticMessages().ProcessPackage(package) },
                { mid => IsAutomaticManualModeMessage(mid), package => new AutomaticManualMode.AutomaticManualModeMessages().ProcessPackage(package) },
                { mid => IsOpenProtocolCommandsDisabledModeMessage(mid), package => new OpenProtocolCommandsDisabled.OpenProtocolCommandsDisabledMessages().ProcessPackage(package) },
                { mid => IsMotorTuningMessage(mid), package => new MotorTuning.MotorTuningMessages().ProcessPackage(package) }
            };
        }

        /// <summary>
        /// Build up Identifier with only specified mids
        /// </summary>
        /// <param name="selection">Selected Mids to use in library</param>
        public MidInterpreter(IEnumerable<Mid> selection)
        {
            _selectedMids = selection;
            var fullDictionary = new Dictionary<Func<int, bool>, Func<string, Mid>>()
            {
                { mid => IsKeepAliveMessage(mid), package => new KeepAlive.MID_9999() },
                { mid => IsCommunicationMessage(mid), package => new Communication.CommunicationMessages(_selectedMids.Where(x=> typeof(Communication.ICommunication).IsAssignableFrom(x.GetType()))).ProcessPackage(package) },
				{ mid => IsParameterSetMessage(mid), package => new ParameterSet.ParameterSetMessages(_selectedMids.Where(x=> typeof(ParameterSet.IParameterSet).IsAssignableFrom(x.GetType()))).ProcessPackage(package) },
                { mid => IsJobMessage(mid), package => new Job.JobMessages(_selectedMids.Where(x=> typeof(Job.IJob).IsAssignableFrom(x.GetType()))).ProcessPackage(package) },
                { mid => IsToolMessage(mid), package => new Tool.ToolMessages(_selectedMids.Where(x=> typeof(Tool.ITool).IsAssignableFrom(x.GetType()))).ProcessPackage(package) },
                { mid => IsVINMessage(mid), package => new Vin.VinMessages(_selectedMids.Where(x=> typeof(Vin.IVin).IsAssignableFrom(x.GetType()))).ProcessPackage(package) },
                { mid => IsTighteningMessage(mid), package => new Tightening.TighteningMessages(_selectedMids.Where(x=> typeof(Tightening.ITightening).IsAssignableFrom(x.GetType()))).ProcessPackage(package) },
                { mid => IsAlarmMessage(mid), package => new Alarm.AlarmMessages(_selectedMids.Where(x=> typeof(Alarm.IAlarm).IsAssignableFrom(x.GetType()))).ProcessPackage(package) },
                { mid => IsTimeMessage(mid), package => new Time.TimeMessages(_selectedMids.Where(x=> typeof(Time.ITime).IsAssignableFrom(x.GetType()))).ProcessPackage(package) },
                { mid => IsMultiSpindleMessage(mid), package => new MultiSpindle.MultiSpindleMessages(_selectedMids.Where(x=> typeof(MultiSpindle.IMultiSpindle).IsAssignableFrom(x.GetType()))).ProcessPackage(package) },
                { mid => IsPowerMACSMessage(mid), package => new PowerMACS.PowerMACSMessages(_selectedMids.Where(x=> typeof(PowerMACS.IPowerMACS).IsAssignableFrom(x.GetType()))).ProcessPackage(package) },
                { mid => IsUserInterfaceMessage(mid), package => new UserInterface.UserInterfaceMessages(_selectedMids.Where(x=> typeof(UserInterface.IUserInterface).IsAssignableFrom(x.GetType()))).ProcessPackage(package) },
                { mid => IsAdvancedJobMessage(mid), package => new Job.Advanced.AdvancedJobMessages(_selectedMids.Where(x=> typeof(Job.Advanced.IAdvancedJob).IsAssignableFrom(x.GetType()))).ProcessPackage(package) },
                { mid => IsMultipleIdentifiersMessage(mid), package => new MultipleIdentifiers.MultipleIdentifierMessages(_selectedMids.Where(x=> typeof(MultipleIdentifiers.IMultipleIdentifier).IsAssignableFrom(x.GetType()))).ProcessPackage(package) },
                { mid => IsIOInterfaceMessage(mid), package => new IOInterface.IOInterfaceMessages(_selectedMids.Where(x=> typeof(IOInterface.IIOInterface).IsAssignableFrom(x.GetType()))).ProcessPackage(package) },
                { mid => IsPLCUserDataMessage(mid), package => new PLCUserData.PLCUserDataMessages(_selectedMids.Where(x=> typeof(PLCUserData.IPLCUserData).IsAssignableFrom(x.GetType()))).ProcessPackage(package) },
                { mid => IsSelectorMessage(mid), package => new ApplicationSelector.ApplicationSelectorMessages(_selectedMids.Where(x=> typeof(ApplicationSelector.IApplicationSelector).IsAssignableFrom(x.GetType()))).ProcessPackage(package) },
                { mid => IsToolLocationSystemMessage(mid), package => new ApplicationToolLocationSystem.ApplicationToolLocationSystemMessages(_selectedMids.Where(x=> typeof(ApplicationToolLocationSystem.IApplicationToolLocationSystem).IsAssignableFrom(x.GetType()))).ProcessPackage(package) },
                { mid => IsControllerMessage(mid), package => new ApplicationController.MID_0270()  },
                { mid => IsStatisticMessage(mid), package => new Statistic.StatisticMessages(_selectedMids.Where(x=> typeof(Statistic.IStatistic).IsAssignableFrom(x.GetType()))).ProcessPackage(package) },
                { mid => IsAutomaticManualModeMessage(mid), package => new AutomaticManualMode.AutomaticManualModeMessages(_selectedMids.Where(x=> typeof(AutomaticManualMode.IAutomaticManualMode).IsAssignableFrom(x.GetType()))).ProcessPackage(package) },
                { mid => IsOpenProtocolCommandsDisabledModeMessage(mid), package => new OpenProtocolCommandsDisabled.OpenProtocolCommandsDisabledMessages(_selectedMids.Where(x=> typeof(OpenProtocolCommandsDisabled.IOpenProtocolCommandsDisabled).IsAssignableFrom(x.GetType()))).ProcessPackage(package) },
                { mid => IsMotorTuningMessage(mid), package => new MotorTuning.MotorTuningMessages(_selectedMids.Where(x=> typeof(MotorTuning.IMotorTuning).IsAssignableFrom(x.GetType()))).ProcessPackage(package) }
            };

            _messageInterpreterTemplates = new Dictionary<Func<int, bool>, Func<string, Mid>>();
            foreach(Mid mid in selection)
            {
                var template = fullDictionary.FirstOrDefault(x => x.Key(mid.HeaderData.Mid));
                if (!template.Equals(default(KeyValuePair<Func<int, bool>, Func<string, Mid>>))
                    && !_messageInterpreterTemplates.ContainsKey(template.Key))
                    _messageInterpreterTemplates.Add(template.Key, template.Value);
            }
        }

        public Mid Parse(string package)
        {
            int mid = int.Parse(package.Substring(4, 4));

            var func = _messageInterpreterTemplates.FirstOrDefault(x => x.Key(mid));
            if (func.Equals(default(KeyValuePair<Func<int, bool>, Func<string, Mid>>)))
                throw new NotImplementedException($"MID {mid} was not implemented, please register it on MidIntepreter constructor!");

            return func.Value(package);
        }

        public ExpectedMid Parse<ExpectedMid>(string package) where ExpectedMid : Mid
        {
            Mid mid = Parse(package);
            if (mid.GetType().Equals(typeof(ExpectedMid)))
                return (ExpectedMid)mid;

            throw new InvalidCastException($"Package is MID {mid.GetType().Name}, cannot be casted to {typeof(ExpectedMid).Name}");
        }

        private bool IsKeepAliveMessage(int mid) => (mid == 9999);

        private bool IsCommunicationMessage(int mid) => (mid > 0 && mid < 10);

        private bool IsParameterSetMessage(int mid) => (mid > 9 && mid < 26);

        private bool IsJobMessage(int mid) => (mid > 29 && mid < 40);

        private bool IsToolMessage(int mid) => (mid > 39 && mid < 49);

        private bool IsVINMessage(int mid) => (mid > 49 && mid < 55);

        private bool IsTighteningMessage(int mid) => (mid > 59 && mid < 66);

        private bool IsAlarmMessage(int mid) => (mid > 69 && mid < 79);

        private bool IsTimeMessage(int mid) => (mid > 79 && mid < 83);

        private bool IsMultiSpindleMessage(int mid) => (mid > 89 && mid < 104);

        private bool IsPowerMACSMessage(int mid) => (mid > 104 && mid < 110);

        private bool IsUserInterfaceMessage(int mid) => (mid > 109 && mid < 114);

        private bool IsAdvancedJobMessage(int mid) => (mid > 119 && mid < 141);

        private bool IsMultipleIdentifiersMessage(int mid) => (mid > 149 && mid < 158);

        private bool IsIOInterfaceMessage(int mid) => (mid > 199 && mid < 226);

        private bool IsPLCUserDataMessage(int mid) => (mid > 239 && mid < 245);

        private bool IsSelectorMessage(int mid) => (mid > 249 && mid < 256);

        private bool IsToolLocationSystemMessage(int mid) => (mid > 259 && mid < 265);

        private bool IsControllerMessage(int mid) => (mid == 270);

        private bool IsStatisticMessage(int mid) => (mid > 299 && mid < 302);

        private bool IsAutomaticManualModeMessage(int mid) => (mid > 399 && mid < 412);

        private bool IsOpenProtocolCommandsDisabledModeMessage(int mid) => (mid > 419 && mid < 424);

        private bool IsMotorTuningMessage(int mid) => (mid > 499 && mid < 505);

    }
}

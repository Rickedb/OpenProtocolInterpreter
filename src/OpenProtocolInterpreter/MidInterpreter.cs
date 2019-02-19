using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenProtocolInterpreter
{
    public class MidInterpreter
    {
        private readonly Dictionary<Func<int, bool>, Func<object, Mid>> _messageInterpreterTemplates;
        private readonly List<IMessagesTemplate> _messagesTemplates;
        private readonly IEnumerable<Mid> _selectedMids;

        public MidInterpreter()
        {
            _messagesTemplates = new List<IMessagesTemplate>();
            _messageInterpreterTemplates = new Dictionary<Func<int, bool>, Func<object, Mid>>()
            {
                { mid => IsKeepAliveMessage(mid), package => new KeepAlive.Mid9999() },
                { mid => IsCommunicationMessage(mid), package => ProcessPackage(typeof(Communication.CommunicationMessages), package) },
                { mid => IsParameterSetMessage(mid), package => ProcessPackage(typeof(ParameterSet.ParameterSetMessages), package) },
                { mid => IsJobMessage(mid), package => ProcessPackage(typeof(Job.JobMessages), package) },
                { mid => IsToolMessage(mid), package => ProcessPackage(typeof(Tool.ToolMessages), package) },
                { mid => IsVINMessage(mid), package => ProcessPackage(typeof(Vin.VinMessages), package) },
                { mid => IsTighteningMessage(mid), package => ProcessPackage(typeof(Tightening.TighteningMessages), package) },
                { mid => IsAlarmMessage(mid), package => ProcessPackage(typeof(Alarm.AlarmMessages), package) },
                { mid => IsTimeMessage(mid), package => ProcessPackage(typeof(Time.TimeMessages), package) },
                { mid => IsMultiSpindleMessage(mid), package => ProcessPackage(typeof(MultiSpindle.MultiSpindleMessages), package) },
                { mid => IsPowerMACSMessage(mid), package => ProcessPackage(typeof(PowerMACS.PowerMACSMessages), package) },
                { mid => IsUserInterfaceMessage(mid), package => ProcessPackage(typeof(UserInterface.UserInterfaceMessages), package) },
                { mid => IsAdvancedJobMessage(mid), package => ProcessPackage(typeof(Job.Advanced.AdvancedJobMessages), package) },
                { mid => IsMultipleIdentifiersMessage(mid), package => ProcessPackage(typeof(MultipleIdentifiers.MultipleIdentifierMessages), package) },
                { mid => IsIOInterfaceMessage(mid), package => ProcessPackage(typeof(IOInterface.IOInterfaceMessages), package) },
                { mid => IsPLCUserDataMessage(mid), package => ProcessPackage(typeof(PLCUserData.PLCUserDataMessages), package) },
                { mid => IsSelectorMessage(mid), package => ProcessPackage(typeof(ApplicationSelector.ApplicationSelectorMessages), package) },
                { mid => IsToolLocationSystemMessage(mid), package => ProcessPackage(typeof(ApplicationToolLocationSystem.ApplicationToolLocationSystemMessages), package) },
                { mid => IsControllerMessage(mid), package => new ApplicationController.Mid0270() },
                { mid => IsStatisticMessage(mid), package => ProcessPackage(typeof(Statistic.StatisticMessages), package) },
                { mid => IsAutomaticManualModeMessage(mid), package => ProcessPackage(typeof(AutomaticManualMode.AutomaticManualModeMessages), package) },
                { mid => IsOpenProtocolCommandsDisabledModeMessage(mid), package => ProcessPackage(typeof(OpenProtocolCommandsDisabled.OpenProtocolCommandsDisabledMessages), package) },
                { mid => IsMotorTuningMessage(mid), package => ProcessPackage(typeof(MotorTuning.MotorTuningMessages), package) },
                { mid => IsResultMessage(mid), package => ProcessPackage(typeof(Result.ResultMessages), package) }
            };
        }

        /// <summary>
        /// Build up Identifier with only specified mids
        /// </summary>
        /// <param name="selection">Selected Mids to use in library</param>
        public MidInterpreter(IEnumerable<Mid> selection)
        {
            _messageInterpreterTemplates = new Dictionary<Func<int, bool>, Func<object, Mid>>();
            _messagesTemplates = new List<IMessagesTemplate>();
            _selectedMids = selection;
            var fullDictionary = new Dictionary<Func<int, bool>, Func<object, Mid>>()
            {
                { mid => IsKeepAliveMessage(mid), package => new KeepAlive.Mid9999() },
                { mid => IsCommunicationMessage(mid), package => ProcessPackage(typeof(Communication.CommunicationMessages), typeof(Communication.ICommunication), package) },
                { mid => IsParameterSetMessage(mid), package => ProcessPackage(typeof(ParameterSet.ParameterSetMessages), typeof(ParameterSet.IParameterSet), package) },
                { mid => IsJobMessage(mid), package =>  ProcessPackage(typeof(Job.JobMessages), typeof(Job.IJob), package) },
                { mid => IsToolMessage(mid), package => ProcessPackage(typeof(Tool.ToolMessages), typeof(Tool.ITool), package) },
                { mid => IsVINMessage(mid), package => ProcessPackage(typeof(Vin.VinMessages), typeof(Vin.IVin), package) },
                { mid => IsTighteningMessage(mid), package => ProcessPackage(typeof(Tightening.TighteningMessages), typeof(Tightening.ITightening), package) },
                { mid => IsAlarmMessage(mid), package => ProcessPackage(typeof(Alarm.AlarmMessages), typeof(Alarm.IAlarm), package) },
                { mid => IsTimeMessage(mid), package => ProcessPackage(typeof(Time.TimeMessages), typeof(Time.ITime), package) },
                { mid => IsMultiSpindleMessage(mid), package => ProcessPackage(typeof(MultiSpindle.MultiSpindleMessages), typeof(MultiSpindle.IMultiSpindle), package) },
                { mid => IsPowerMACSMessage(mid), package => ProcessPackage(typeof(PowerMACS.PowerMACSMessages), typeof(PowerMACS.IPowerMACS), package) },
                { mid => IsUserInterfaceMessage(mid), package => ProcessPackage(typeof(UserInterface.UserInterfaceMessages), typeof(UserInterface.IUserInterface), package) },
                { mid => IsAdvancedJobMessage(mid), package => ProcessPackage(typeof(Job.Advanced.AdvancedJobMessages), typeof(Job.Advanced.IAdvancedJob), package) },
                { mid => IsMultipleIdentifiersMessage(mid), package => ProcessPackage(typeof(MultipleIdentifiers.MultipleIdentifierMessages), typeof(MultipleIdentifiers.IMultipleIdentifier), package) },
                { mid => IsIOInterfaceMessage(mid), package => ProcessPackage(typeof(IOInterface.IOInterfaceMessages), typeof(IOInterface.IIOInterface), package) },
                { mid => IsPLCUserDataMessage(mid), package => ProcessPackage(typeof(PLCUserData.PLCUserDataMessages), typeof(PLCUserData.IPLCUserData), package) },
                { mid => IsSelectorMessage(mid), package => ProcessPackage(typeof(ApplicationSelector.ApplicationSelectorMessages), typeof(ApplicationSelector.IApplicationSelector), package) },
                { mid => IsToolLocationSystemMessage(mid), package => ProcessPackage(typeof(ApplicationToolLocationSystem.ApplicationToolLocationSystemMessages), typeof(ApplicationToolLocationSystem.IApplicationToolLocationSystem), package) },
                { mid => IsControllerMessage(mid), package => new ApplicationController.Mid0270()  },
                { mid => IsStatisticMessage(mid), package => ProcessPackage(typeof(Statistic.StatisticMessages), typeof(Statistic.IStatistic), package) },
                { mid => IsAutomaticManualModeMessage(mid), package => ProcessPackage(typeof(AutomaticManualMode.AutomaticManualModeMessages), typeof(AutomaticManualMode.IAutomaticManualMode), package) },
                { mid => IsOpenProtocolCommandsDisabledModeMessage(mid), package => ProcessPackage(typeof(OpenProtocolCommandsDisabled.OpenProtocolCommandsDisabledMessages), typeof(OpenProtocolCommandsDisabled.IOpenProtocolCommandsDisabled), package) },
                { mid => IsMotorTuningMessage(mid), package => ProcessPackage(typeof(MotorTuning.MotorTuningMessages), typeof(MotorTuning.IMotorTuning), package) },
                { mid => IsResultMessage(mid), package => ProcessPackage(typeof(Result.ResultMessages), typeof(Result.IResult), package) }
            };
            
            foreach (Mid mid in selection)
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

        public Mid Parse(byte[] package)
        {
            int mid = int.Parse(Encoding.ASCII.GetString(package, 4, 4));

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

        public ExpectedMid Parse<ExpectedMid>(byte[] package) where ExpectedMid : Mid
        {
            Mid mid = Parse(package);
            if (mid.GetType().Equals(typeof(ExpectedMid)))
                return (ExpectedMid)mid;

            throw new InvalidCastException($"Package is MID {mid.GetType().Name}, cannot be casted to {typeof(ExpectedMid).Name}");
        }

        private Mid ProcessPackage(Type templateType, object package)
        {
            var template = _messagesTemplates.FirstOrDefault(x => x.GetType().Equals(templateType));
            if (template == null)
            {
                template = (IMessagesTemplate)Activator.CreateInstance(templateType);
                _messagesTemplates.Add(template);
            }

            return ProcessPackage(template, package);
        }

        private Mid ProcessPackage(Type templateType, Type midType, object package)
        {
            var template = _messagesTemplates.FirstOrDefault(x => templateType.IsAssignableFrom(x.GetType()));
            if (template == null)
            {
                var mids = _selectedMids.Where(x => midType.IsAssignableFrom(x.GetType()));
                template = (IMessagesTemplate)Activator.CreateInstance(templateType, new object[] { mids });
                _messagesTemplates.Add(template);
            }

            return ProcessPackage(template, package);
        }

        private Mid ProcessPackage(IMessagesTemplate template, object package)
        {
            if (package.GetType().Equals(typeof(byte[])))
                return template.ProcessPackage(package as byte[]);

            return template.ProcessPackage(package as string);
        }

        private bool IsKeepAliveMessage(int mid) => mid == 9999;

        private bool IsCommunicationMessage(int mid) => mid > 0 && mid < 10;

        private bool IsParameterSetMessage(int mid) => mid > 9 && mid < 26 || mid > 2499 && mid < 2506;

        private bool IsJobMessage(int mid) => mid > 29 && mid < 40;

        private bool IsToolMessage(int mid) => mid > 39 && mid < 49;

        private bool IsVINMessage(int mid) => mid > 49 && mid < 55;

        private bool IsTighteningMessage(int mid) => mid > 59 && mid < 66;

        private bool IsAlarmMessage(int mid) => mid > 69 && mid < 79;

        private bool IsTimeMessage(int mid) => mid > 79 && mid < 83;

        private bool IsMultiSpindleMessage(int mid) => mid > 89 && mid < 104;

        private bool IsPowerMACSMessage(int mid) => mid > 104 && mid < 110;

        private bool IsUserInterfaceMessage(int mid) => mid > 109 && mid < 114;

        private bool IsAdvancedJobMessage(int mid) => mid > 119 && mid < 141;

        private bool IsMultipleIdentifiersMessage(int mid) => mid > 149 && mid < 158;

        private bool IsIOInterfaceMessage(int mid) => mid > 199 && mid < 226;

        private bool IsPLCUserDataMessage(int mid) => mid > 239 && mid < 246;

        private bool IsSelectorMessage(int mid) => mid > 249 && mid < 256;

        private bool IsToolLocationSystemMessage(int mid) => mid > 259 && mid < 266;

        private bool IsControllerMessage(int mid) => mid == 270;

        private bool IsStatisticMessage(int mid) => mid > 299 && mid < 302;

        private bool IsAutomaticManualModeMessage(int mid) => mid > 399 && mid < 412;

        private bool IsOpenProtocolCommandsDisabledModeMessage(int mid) => mid > 419 && mid < 424;

        private bool IsMotorTuningMessage(int mid) => mid > 499 && mid < 505;

        private bool IsResultMessage(int mid) => mid > 1200 && mid < 1204;
    }
}

using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Mid Interpreter initialization functions
    /// </summary>
    public static class MidInterpreterMessagesExtensions
    {
        /// <summary>
        /// Configure MidInterpreter to parse all available Mids of a mode
        /// <para>Select Integrator if you're integrator or Controller if you're a controller</para>
        /// </summary>
        /// <param name="midInterpreter">MidInterpreter instance</param>
        /// <param name="mode">Are you the integrator or controller?</param>
        /// <returns></returns>
        public static MidInterpreter UseAllMessages(this MidInterpreter midInterpreter, InterpreterMode mode = InterpreterMode.Both)
        {
            return midInterpreter
                .UseAlarmMessages(mode)
                .UseApplicationControllerMessage(mode)
                .UseApplicationSelectorMessages(mode)
                .UseApplicationToolLocationSystemMessages(mode)
                .UseAutomaticManualModeMessages(mode)
                .UseCommunicationMessages(mode)
                .UseIOInterfaceMessages(mode)
                .UseJobMessages(mode)
                .UseAdvancedJobMessages(mode)
                .UseMotorTuningMessages(mode)
                .UseMultipleIdentifiersMessages(mode)
                .UseMultiSpindleMessages(mode)
                .UseOpenProtocolCommandsDisabledMessages(mode)
                .UseParameterSetMessages(mode)
                .UsePLCUserDataMessages(mode)
                .UsePowerMACSMessages(mode)
                .UseResultMessages(mode)
                .UseStatisticMessages(mode)
                .UseTighteningMessages(mode)
                .UseTimeMessages(mode)
                .UseToolMessages(mode)
                .UseUserInterfaceMessages(mode)
                .UseVinMessages(mode);
        }

        /// <summary>
        /// Configure MidInterpreter to parse all available Mids of a mode
        /// <para>Select Integrator if you're integrator or Controller if you're a controller</para>
        /// </summary>
        /// <param name="midInterpreter">MidInterpreter instance</param>
        /// <param name="mode">Are you the integrator or controller?</param>
        /// <returns></returns>
        public static MidInterpreter UseAllMessages(this MidInterpreter midInterpreter, IEnumerable<Type> mids)
        {
            if (mids.Any(x => !x.IsSubclassOf(typeof(Mid))))
                throw new ArgumentException("All mids must inherit Mid class", nameof(mids));

            return midInterpreter
                .UseAlarmMessages(mids.Where(x => DoesImplementInterface(x, typeof(Alarm.IAlarm))))
                .UseApplicationControllerMessage(mids.Where(x => DoesImplementInterface(x, typeof(ApplicationController.IApplicationController))))
                .UseApplicationSelectorMessages(mids.Where(x => DoesImplementInterface(x, typeof(ApplicationSelector.IApplicationSelector))))
                .UseApplicationToolLocationSystemMessages(mids.Where(x => DoesImplementInterface(x, typeof(ApplicationToolLocationSystem.IApplicationToolLocationSystem))))
                .UseAutomaticManualModeMessages(mids.Where(x => DoesImplementInterface(x, typeof(AutomaticManualMode.IAutomaticManualMode))))
                .UseCommunicationMessages(mids.Where(x => DoesImplementInterface(x, typeof(Communication.ICommunication))))
                .UseIOInterfaceMessages(mids.Where(x => DoesImplementInterface(x, typeof(IOInterface.IIOInterface))))
                .UseJobMessages(mids.Where(x => DoesImplementInterface(x, typeof(Job.IJob))))
                .UseAdvancedJobMessages(mids.Where(x => DoesImplementInterface(x, typeof(Job.Advanced.IAdvancedJob))))
                .UseMotorTuningMessages(mids.Where(x => DoesImplementInterface(x, typeof(MotorTuning.IMotorTuning))))
                .UseMultipleIdentifiersMessages(mids.Where(x => DoesImplementInterface(x, typeof(MultipleIdentifiers.IMultipleIdentifier))))
                .UseMultiSpindleMessages(mids.Where(x => DoesImplementInterface(x, typeof(MultiSpindle.IMultiSpindle))))
                .UseOpenProtocolCommandsDisabledMessages(mids.Where(x => DoesImplementInterface(x, typeof(OpenProtocolCommandsDisabled.IOpenProtocolCommandsDisabled))))
                .UseParameterSetMessages(mids.Where(x => DoesImplementInterface(x, typeof(ParameterSet.IParameterSet))))
                .UsePLCUserDataMessages(mids.Where(x => DoesImplementInterface(x, typeof(PLCUserData.IPLCUserData))))
                .UsePowerMACSMessages(mids.Where(x => DoesImplementInterface(x, typeof(PowerMACS.IPowerMACS))))
                .UseResultMessages(mids.Where(x => DoesImplementInterface(x, typeof(Result.IResult))))
                .UseStatisticMessages(mids.Where(x => DoesImplementInterface(x, typeof(Statistic.IStatistic))))
                .UseTighteningMessages(mids.Where(x => DoesImplementInterface(x, typeof(Tightening.ITightening))))
                .UseTimeMessages(mids.Where(x => DoesImplementInterface(x, typeof(Time.ITime))))
                .UseToolMessages(mids.Where(x => DoesImplementInterface(x, typeof(Tool.ITool))))
                .UseUserInterfaceMessages(mids.Where(x => DoesImplementInterface(x, typeof(UserInterface.IUserInterface))))
                .UseVinMessages(mids.Where(x => DoesImplementInterface(x, typeof(Vin.IVin))));
        }


        public static MidInterpreter UseAlarmMessages(this MidInterpreter midInterpreter, InterpreterMode mode = InterpreterMode.Both)
        {
            midInterpreter.UseTemplate<Alarm.AlarmMessages>(mode);
            return midInterpreter;
        }

        public static MidInterpreter UseAlarmMessages(this MidInterpreter midInterpreter, IEnumerable<Type> mids)
        {
            ThrowIfInvalid<Alarm.IAlarm>(mids);
            midInterpreter.UseTemplate<Alarm.AlarmMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseAlarmMessages(this MidInterpreter midInterpreter, IDictionary<int, Type> mids)
        {
            ThrowIfInvalid<Alarm.IAlarm>(mids);
            midInterpreter.UseTemplate<Alarm.AlarmMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseApplicationControllerMessage(this MidInterpreter midInterpreter, InterpreterMode mode = InterpreterMode.Both)
        {
            midInterpreter.UseTemplate<ApplicationController.ApplicationControllerMessages>(mode);
            return midInterpreter;
        }

        public static MidInterpreter UseApplicationControllerMessage(this MidInterpreter midInterpreter, IEnumerable<Type> mids)
        {
            ThrowIfInvalid<ApplicationController.IApplicationController>(mids);
            midInterpreter.UseTemplate<ApplicationController.ApplicationControllerMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseApplicationControllerMessage(this MidInterpreter midInterpreter, IDictionary<int, Type> mids)
        {
            ThrowIfInvalid<ApplicationController.IApplicationController>(mids);
            midInterpreter.UseTemplate<ApplicationController.ApplicationControllerMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseApplicationSelectorMessages(this MidInterpreter midInterpreter, InterpreterMode mode = InterpreterMode.Both)
        {
            midInterpreter.UseTemplate<ApplicationSelector.ApplicationSelectorMessages>(mode);
            return midInterpreter;
        }

        public static MidInterpreter UseApplicationSelectorMessages(this MidInterpreter midInterpreter, IEnumerable<Type> mids)
        {
            ThrowIfInvalid<ApplicationSelector.IApplicationSelector>(mids);
            midInterpreter.UseTemplate<ApplicationSelector.ApplicationSelectorMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseApplicationSelectorMessages(this MidInterpreter midInterpreter, IDictionary<int, Type> mids)
        {
            ThrowIfInvalid<ApplicationSelector.IApplicationSelector>(mids);
            midInterpreter.UseTemplate<ApplicationSelector.ApplicationSelectorMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseApplicationToolLocationSystemMessages(this MidInterpreter midInterpreter, InterpreterMode mode = InterpreterMode.Both)
        {
            midInterpreter.UseTemplate<ApplicationToolLocationSystem.ApplicationToolLocationSystemMessages>(mode);
            return midInterpreter;
        }

        public static MidInterpreter UseApplicationToolLocationSystemMessages(this MidInterpreter midInterpreter, IEnumerable<Type> mids)
        {
            ThrowIfInvalid<ApplicationToolLocationSystem.IApplicationToolLocationSystem>(mids);
            midInterpreter.UseTemplate<ApplicationToolLocationSystem.ApplicationToolLocationSystemMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseApplicationToolLocationSystemMessages(this MidInterpreter midInterpreter, IDictionary<int, Type> mids)
        {
            ThrowIfInvalid<ApplicationToolLocationSystem.IApplicationToolLocationSystem>(mids);
            midInterpreter.UseTemplate<ApplicationToolLocationSystem.ApplicationToolLocationSystemMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseAutomaticManualModeMessages(this MidInterpreter midInterpreter, InterpreterMode mode = InterpreterMode.Both)
        {
            midInterpreter.UseTemplate<AutomaticManualMode.AutomaticManualModeMessages>(mode);
            return midInterpreter;
        }

        public static MidInterpreter UseAutomaticManualModeMessages(this MidInterpreter midInterpreter, IEnumerable<Type> mids)
        {
            ThrowIfInvalid<AutomaticManualMode.IAutomaticManualMode>(mids);
            midInterpreter.UseTemplate<AutomaticManualMode.AutomaticManualModeMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseAutomaticManualModeMessages(this MidInterpreter midInterpreter, IDictionary<int, Type> mids)
        {
            ThrowIfInvalid<AutomaticManualMode.IAutomaticManualMode>(mids);
            midInterpreter.UseTemplate<AutomaticManualMode.AutomaticManualModeMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseCommunicationMessages(this MidInterpreter midInterpreter, InterpreterMode mode = InterpreterMode.Both)
        {
            midInterpreter.UseTemplate<Communication.CommunicationMessages>(mode);
            return midInterpreter;
        }

        public static MidInterpreter UseCommunicationMessages(this MidInterpreter midInterpreter, IEnumerable<Type> mids)
        {
            ThrowIfInvalid<Communication.ICommunication>(mids);
            midInterpreter.UseTemplate<Communication.CommunicationMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseCommunicationMessages(this MidInterpreter midInterpreter, IDictionary<int, Type> mids)
        {
            ThrowIfInvalid<Communication.ICommunication>(mids);
            midInterpreter.UseTemplate<Communication.CommunicationMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseIOInterfaceMessages(this MidInterpreter midInterpreter, InterpreterMode mode = InterpreterMode.Both)
        {
            midInterpreter.UseTemplate<IOInterface.IOInterfaceMessages>(mode);
            return midInterpreter;
        }

        public static MidInterpreter UseIOInterfaceMessages(this MidInterpreter midInterpreter, IEnumerable<Type> mids)
        {
            ThrowIfInvalid<IOInterface.IIOInterface>(mids);
            midInterpreter.UseTemplate<IOInterface.IOInterfaceMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseIOInterfaceMessages(this MidInterpreter midInterpreter, IDictionary<int, Type> mids)
        {
            ThrowIfInvalid<IOInterface.IIOInterface>(mids);
            midInterpreter.UseTemplate<IOInterface.IOInterfaceMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseJobMessages(this MidInterpreter midInterpreter, InterpreterMode mode = InterpreterMode.Both)
        {
            midInterpreter.UseTemplate<Job.JobMessages>(mode);
            return midInterpreter;
        }

        public static MidInterpreter UseJobMessages(this MidInterpreter midInterpreter, IEnumerable<Type> mids)
        {
            ThrowIfInvalid<Job.IJob>(mids);
            midInterpreter.UseTemplate<Job.JobMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseJobMessages(this MidInterpreter midInterpreter, IDictionary<int, Type> mids)
        {
            ThrowIfInvalid<Job.IJob>(mids);
            midInterpreter.UseTemplate<Job.JobMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseAdvancedJobMessages(this MidInterpreter midInterpreter, InterpreterMode mode = InterpreterMode.Both)
        {
            midInterpreter.UseTemplate<Job.Advanced.AdvancedJobMessages>(mode);
            return midInterpreter;
        }

        public static MidInterpreter UseAdvancedJobMessages(this MidInterpreter midInterpreter, IEnumerable<Type> mids)
        {
            ThrowIfInvalid<Job.Advanced.IAdvancedJob>(mids);
            midInterpreter.UseTemplate<Job.Advanced.AdvancedJobMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseAdvancedJobMessages(this MidInterpreter midInterpreter, IDictionary<int, Type> mids)
        {
            ThrowIfInvalid<Job.Advanced.IAdvancedJob>(mids);
            midInterpreter.UseTemplate<Job.Advanced.AdvancedJobMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseMotorTuningMessages(this MidInterpreter midInterpreter, InterpreterMode mode = InterpreterMode.Both)
        {
            midInterpreter.UseTemplate<MotorTuning.MotorTuningMessages>(mode);
            return midInterpreter;
        }

        public static MidInterpreter UseMotorTuningMessages(this MidInterpreter midInterpreter, IEnumerable<Type> mids)
        {
            ThrowIfInvalid<MotorTuning.IMotorTuning>(mids);
            midInterpreter.UseTemplate<MotorTuning.MotorTuningMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseMotorTuningMessages(this MidInterpreter midInterpreter, IDictionary<int, Type> mids)
        {
            ThrowIfInvalid<MotorTuning.IMotorTuning>(mids);
            midInterpreter.UseTemplate<MotorTuning.MotorTuningMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseMultipleIdentifiersMessages(this MidInterpreter midInterpreter, InterpreterMode mode = InterpreterMode.Both)
        {
            midInterpreter.UseTemplate<MultipleIdentifiers.MultipleIdentifierMessages>(mode);
            return midInterpreter;
        }

        public static MidInterpreter UseMultipleIdentifiersMessages(this MidInterpreter midInterpreter, IEnumerable<Type> mids)
        {
            ThrowIfInvalid<MultipleIdentifiers.IMultipleIdentifier>(mids);
            midInterpreter.UseTemplate<MultipleIdentifiers.MultipleIdentifierMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseMultipleIdentifiersMessages(this MidInterpreter midInterpreter, IDictionary<int, Type> mids)
        {
            ThrowIfInvalid<MultipleIdentifiers.IMultipleIdentifier>(mids);
            midInterpreter.UseTemplate<MultipleIdentifiers.MultipleIdentifierMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseMultiSpindleMessages(this MidInterpreter midInterpreter, InterpreterMode mode = InterpreterMode.Both)
        {
            midInterpreter.UseTemplate<MultiSpindle.MultiSpindleMessages>(mode);
            return midInterpreter;
        }

        public static MidInterpreter UseMultiSpindleMessages(this MidInterpreter midInterpreter, IEnumerable<Type> mids)
        {
            ThrowIfInvalid<MultiSpindle.IMultiSpindle>(mids);
            midInterpreter.UseTemplate<MultiSpindle.MultiSpindleMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseMultiSpindleMessages(this MidInterpreter midInterpreter, IDictionary<int, Type> mids)
        {
            ThrowIfInvalid<MultiSpindle.IMultiSpindle>(mids);
            midInterpreter.UseTemplate<MultiSpindle.MultiSpindleMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseOpenProtocolCommandsDisabledMessages(this MidInterpreter midInterpreter, InterpreterMode mode = InterpreterMode.Both)
        {
            midInterpreter.UseTemplate<OpenProtocolCommandsDisabled.OpenProtocolCommandsDisabledMessages>(mode);
            return midInterpreter;
        }

        public static MidInterpreter UseOpenProtocolCommandsDisabledMessages(this MidInterpreter midInterpreter, IEnumerable<Type> mids)
        {
            ThrowIfInvalid<OpenProtocolCommandsDisabled.IOpenProtocolCommandsDisabled>(mids);
            midInterpreter.UseTemplate<OpenProtocolCommandsDisabled.OpenProtocolCommandsDisabledMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseOpenProtocolCommandsDisabledMessages(this MidInterpreter midInterpreter, IDictionary<int, Type> mids)
        {
            ThrowIfInvalid<OpenProtocolCommandsDisabled.IOpenProtocolCommandsDisabled>(mids);
            midInterpreter.UseTemplate<OpenProtocolCommandsDisabled.OpenProtocolCommandsDisabledMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseParameterSetMessages(this MidInterpreter midInterpreter, InterpreterMode mode = InterpreterMode.Both)
        {
            midInterpreter.UseTemplate<ParameterSet.ParameterSetMessages>(mode);
            return midInterpreter;
        }

        public static MidInterpreter UseParameterSetMessages(this MidInterpreter midInterpreter, IEnumerable<Type> mids)
        {
            ThrowIfInvalid<ParameterSet.IParameterSet>(mids);
            midInterpreter.UseTemplate<ParameterSet.ParameterSetMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseParameterSetMessages(this MidInterpreter midInterpreter, IDictionary<int, Type> mids)
        {
            ThrowIfInvalid<ParameterSet.IParameterSet>(mids);
            midInterpreter.UseTemplate<ParameterSet.ParameterSetMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UsePLCUserDataMessages(this MidInterpreter midInterpreter, InterpreterMode mode = InterpreterMode.Both)
        {
            midInterpreter.UseTemplate<PLCUserData.PLCUserDataMessages>(mode);
            return midInterpreter;
        }

        public static MidInterpreter UsePLCUserDataMessages(this MidInterpreter midInterpreter, IEnumerable<Type> mids)
        {
            ThrowIfInvalid<PLCUserData.IPLCUserData>(mids);
            midInterpreter.UseTemplate<PLCUserData.PLCUserDataMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UsePLCUserDataMessages(this MidInterpreter midInterpreter, IDictionary<int, Type> mids)
        {
            ThrowIfInvalid<PLCUserData.IPLCUserData>(mids);
            midInterpreter.UseTemplate<PLCUserData.PLCUserDataMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UsePowerMACSMessages(this MidInterpreter midInterpreter, InterpreterMode mode = InterpreterMode.Both)
        {
            midInterpreter.UseTemplate<PowerMACS.PowerMACSMessages>(mode);
            return midInterpreter;
        }

        public static MidInterpreter UsePowerMACSMessages(this MidInterpreter midInterpreter, IEnumerable<Type> mids)
        {
            ThrowIfInvalid<PowerMACS.IPowerMACS>(mids);
            midInterpreter.UseTemplate<PowerMACS.PowerMACSMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UsePowerMACSMessages(this MidInterpreter midInterpreter, IDictionary<int, Type> mids)
        {
            ThrowIfInvalid<PowerMACS.IPowerMACS>(mids);
            midInterpreter.UseTemplate<PowerMACS.PowerMACSMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseResultMessages(this MidInterpreter midInterpreter, InterpreterMode mode = InterpreterMode.Both)
        {
            midInterpreter.UseTemplate<Result.ResultMessages>(mode);
            return midInterpreter;
        }

        public static MidInterpreter UseResultMessages(this MidInterpreter midInterpreter, IEnumerable<Type> mids)
        {
            ThrowIfInvalid<Result.IResult>(mids);
            midInterpreter.UseTemplate<Result.ResultMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseResultMessages(this MidInterpreter midInterpreter, IDictionary<int, Type> mids)
        {
            ThrowIfInvalid<Result.IResult>(mids);
            midInterpreter.UseTemplate<Result.ResultMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseStatisticMessages(this MidInterpreter midInterpreter, InterpreterMode mode = InterpreterMode.Both)
        {
            midInterpreter.UseTemplate<Statistic.StatisticMessages>(mode);
            return midInterpreter;
        }

        public static MidInterpreter UseStatisticMessages(this MidInterpreter midInterpreter, IEnumerable<Type> mids)
        {
            ThrowIfInvalid<Statistic.IStatistic>(mids);
            midInterpreter.UseTemplate<Statistic.StatisticMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseStatisticMessages(this MidInterpreter midInterpreter, IDictionary<int, Type> mids)
        {
            ThrowIfInvalid<Statistic.IStatistic>(mids);
            midInterpreter.UseTemplate<Statistic.StatisticMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseTighteningMessages(this MidInterpreter midInterpreter, InterpreterMode mode = InterpreterMode.Both)
        {
            midInterpreter.UseTemplate<Tightening.TighteningMessages>(mode);
            return midInterpreter;
        }

        public static MidInterpreter UseTighteningMessages(this MidInterpreter midInterpreter, IEnumerable<Type> mids)
        {
            ThrowIfInvalid<Tightening.ITightening>(mids);
            midInterpreter.UseTemplate<Tightening.TighteningMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseTighteningMessages(this MidInterpreter midInterpreter, IDictionary<int, Type> mids)
        {
            ThrowIfInvalid<Tightening.ITightening>(mids);
            midInterpreter.UseTemplate<Tightening.TighteningMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseTimeMessages(this MidInterpreter midInterpreter, InterpreterMode mode = InterpreterMode.Both)
        {
            midInterpreter.UseTemplate<Time.TimeMessages>(mode);
            return midInterpreter;
        }

        public static MidInterpreter UseTimeMessages(this MidInterpreter midInterpreter, IEnumerable<Type> mids)
        {
            ThrowIfInvalid<Time.ITime>(mids);
            midInterpreter.UseTemplate<Time.TimeMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseTimeMessages(this MidInterpreter midInterpreter, IDictionary<int, Type> mids)
        {
            ThrowIfInvalid<Time.ITime>(mids);
            midInterpreter.UseTemplate<Time.TimeMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseToolMessages(this MidInterpreter midInterpreter, InterpreterMode mode = InterpreterMode.Both)
        {
            midInterpreter.UseTemplate<Tool.ToolMessages>(mode);
            return midInterpreter;
        }

        public static MidInterpreter UseToolMessages(this MidInterpreter midInterpreter, IEnumerable<Type> mids)
        {
            ThrowIfInvalid<Tool.ITool>(mids);
            midInterpreter.UseTemplate<Tool.ToolMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseToolMessages(this MidInterpreter midInterpreter, IDictionary<int, Type> mids)
        {
            ThrowIfInvalid<Tool.ITool>(mids);
            midInterpreter.UseTemplate<Tool.ToolMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseUserInterfaceMessages(this MidInterpreter midInterpreter, InterpreterMode mode = InterpreterMode.Both)
        {
            midInterpreter.UseTemplate<UserInterface.UserInterfaceMessages>(mode);
            return midInterpreter;
        }

        public static MidInterpreter UseUserInterfaceMessages(this MidInterpreter midInterpreter, IEnumerable<Type> mids)
        {
            ThrowIfInvalid<UserInterface.IUserInterface>(mids);
            midInterpreter.UseTemplate<UserInterface.UserInterfaceMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseUserInterfaceMessages(this MidInterpreter midInterpreter, IDictionary<int, Type> mids)
        {
            ThrowIfInvalid<UserInterface.IUserInterface>(mids);
            midInterpreter.UseTemplate<UserInterface.UserInterfaceMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseVinMessages(this MidInterpreter midInterpreter, InterpreterMode mode = InterpreterMode.Both)
        {
            midInterpreter.UseTemplate<Vin.VinMessages>(mode);
            return midInterpreter;
        }

        public static MidInterpreter UseVinMessages(this MidInterpreter midInterpreter, IEnumerable<Type> mids)
        {
            ThrowIfInvalid<Vin.IVin>(mids);
            midInterpreter.UseTemplate<Vin.VinMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseVinMessages(this MidInterpreter midInterpreter, IDictionary<int, Type> mids)
        {
            ThrowIfInvalid<Vin.IVin>(mids);
            midInterpreter.UseTemplate<Vin.VinMessages>(mids);
            return midInterpreter;
        }

        public static MidInterpreter UseCustomMessage(this MidInterpreter midInterpreter, IDictionary<int, Type> mids)
        {
            if (mids.Values.Any(x => !x.IsSubclassOf(typeof(Mid))))
                throw new ArgumentException("All mids must inherit Mid class", nameof(mids));

            var customMessageTemplate = new CustomMessages(mids);
            midInterpreter.UseTemplate(customMessageTemplate);
            return midInterpreter;
        }

        private static bool IsValid(IEnumerable<Type> mids, Type desiredInterface)
        {
            return mids.All(x => DoesImplementInterface(x, desiredInterface) && x.IsSubclassOf(typeof(Mid)));
        }

        private static bool DoesImplementInterface(Type mid, Type desiredInterface)
        {
            return desiredInterface.IsAssignableFrom(mid);
        }

        private static void ThrowIfInvalid<T>(IEnumerable<Type> mids)
        {
            var type = typeof(T);
            if (!IsValid(mids, type))
                throw new ArgumentException($"Types should inherit Mid class and must implement {type.Name} interface", nameof(mids));
        }

        private static void ThrowIfInvalid<T>(IDictionary<int, Type> mids)
        {
            ThrowIfInvalid<T>(mids.Select(x => x.Value));
        }
    }
}

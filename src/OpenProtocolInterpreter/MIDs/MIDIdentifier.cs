using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.MIDs
{
    public class MIDIdentifier
    {
        private readonly Dictionary<Func<int, bool>, Func<string, MID>> messageInterpreterTemplates;

        public MIDIdentifier()
        {
            this.messageInterpreterTemplates = new Dictionary<Func<int, bool>, Func<string, MID>>()
            {
                { mid => this.isKeepAliveMessage(mid), package => new KeepAlive.MID_9999() },
                { mid => this.isReplyMessage(mid), package => new Communication.CommunicationMessages().processPackage(package) },
                { mid => this.isTighteningMessage(mid), package => new Tightening.TighteningMessages().processPackage(package) },
                { mid => this.isJobMessage(mid), package => new Job.JobMessages().processPackage(package) },
                { mid => this.isAdvancedJobMessage(mid), package => new Job.Advanced.AdvancedJobMessages().processPackage(package) }
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

        private bool isCommunicationMessage(int mid) { return (mid > 0 && mid < 4); }

        private bool isReplyMessage(int mid) { return (mid > 3 && mid < 6); }

        private bool isParameterSetMessage(int mid) { return (mid > 9 && mid < 26); }

        private bool isJobMessage(int mid) { return (mid > 29 && mid < 40); }

        private bool isToolMessage(int mid) { return (mid > 39 && mid < 47); }

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

using LiveSplit.UI.Components;
using NieRAutoIntelTracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: ComponentFactory(typeof(NieRAutoIntelTrackerFactory))]

namespace NieRAutoIntelTracker
{
    public class NieRAutoIntelTrackerFactory : IComponentFactory
    {
        public string ComponentName => "NieR:Automata Intel Tracker";
        public string Description => "Automated tracking of intel";

        public ComponentCategory Category => ComponentCategory.Other;

        public IComponent Create(LiveSplit.Model.LiveSplitState state)
        {
            return new NieRAutoIntelTrackerComponent(state);
        }

        public string UpdateName => this.ComponentName;
        public string UpdateURL => "";
        public Version Version => Version.Parse("0.4");
        public string XMLURL => UpdateURL + "";
    }
}

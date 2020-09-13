using System;
using System.Collections.Generic;

using LiveSplit.Model;
using LiveSplit.UI.Components;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.UI;
using System.Diagnostics;

namespace NieRAutoIntelTracker
{
    public class NieRAutoIntelTrackerComponent : IComponent
    {
        public Settings settings;

        public LiveSplitState state;

        private GameMemory _gameMemory;
        private IntelDisplay _intelDisplay;

        protected InfoTextComponent InternalComponent { get; set; }

        public string ComponentName => "NieR:Automata Intel Tracker";

        public float PaddingTop => InternalComponent.PaddingTop;
        public float PaddingLeft => InternalComponent.PaddingLeft;
        public float PaddingBottom => InternalComponent.PaddingBottom;
        public float PaddingRight => InternalComponent.PaddingRight;

        public float VerticalHeight => InternalComponent.VerticalHeight;
        public float MinimumWidth => InternalComponent.MinimumWidth;
        public float HorizontalWidth => InternalComponent.HorizontalWidth;
        public float MinimumHeight => InternalComponent.MinimumHeight;

        public NieRAutoIntelTrackerComponent(LiveSplitState state)
        {
            this.state = state;

            this._intelDisplay = new IntelDisplay();
            this.settings = new Settings(visible => _intelDisplay.SetVisibility(visible));

            this._gameMemory = new GameMemory(_intelDisplay, fishCount => RefreshFishCount(fishCount));
            this._gameMemory.StartMonitoring();

            InternalComponent = new InfoTextComponent("Fish Intel", "Loading...");

            ContextMenuControls = new Dictionary<string, Action>
            {
                { "Toggle NieR:Automata Intel Tracker", new Action(_intelDisplay.ToggleVisibility) }
            };
        }

        public IDictionary<string, Action> ContextMenuControls { get; set; }

        private void PrepareDraw(LiveSplitState state, LayoutMode mode)
        {
            InternalComponent.DisplayTwoRows = false;

            InternalComponent.NameLabel.HasShadow
                = InternalComponent.ValueLabel.HasShadow
                = state.LayoutSettings.DropShadows;

            InternalComponent.InformationName = "Fish Intel";
            InternalComponent.AlternateNameText = new[]
            {
                "Fish"
            };
            InternalComponent.NameLabel.HorizontalAlignment = StringAlignment.Near;
            InternalComponent.ValueLabel.HorizontalAlignment = StringAlignment.Far;
            InternalComponent.NameLabel.VerticalAlignment =
                mode == LayoutMode.Horizontal ? StringAlignment.Near : StringAlignment.Center;
            InternalComponent.ValueLabel.VerticalAlignment =
                mode == LayoutMode.Horizontal ? StringAlignment.Far : StringAlignment.Center;
            
            InternalComponent.NameLabel.ForeColor = state.LayoutSettings.TextColor;
            InternalComponent.ValueLabel.ForeColor = state.LayoutSettings.TextColor;
        }

        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
        {
            PrepareDraw(state, LayoutMode.Horizontal);
            InternalComponent.DrawHorizontal(g, state, height, clipRegion);
        }

        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
        {
            PrepareDraw(state, LayoutMode.Vertical);
            InternalComponent.DrawVertical(g, state, width, clipRegion);
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            return settings.GetSettings(document);
        }

        public Control GetSettingsControl(LayoutMode mode)
        {
            return settings;
        }

        public void SetSettings(XmlNode settings)
        {
            this.settings.SetSettings(settings);
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            InternalComponent.Update(invalidator, state, width, height, mode);
        }

        public void RefreshFishCount(int fishCount)
        {
            InternalComponent.InformationValue = fishCount + " / 43";
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_gameMemory != null)
                    {
                        _gameMemory.Stop();
                        _intelDisplay.Hide();
                    }
                }

                disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}

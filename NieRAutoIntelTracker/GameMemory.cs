using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveSplit.ComponentUtil;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Collections;

namespace NieRAutoIntelTracker
{

    class GameMemory
    {
        public const int SLEEP_TIME = 250;

        private Task _thread;
        private CancellationTokenSource _cancelSource;
        private DeepPointer _intelFishPtr;
        private DeepPointer _intelFishPtrDebug;
        public byte[] IntelFishCurrent { get; set; }
        public byte[] IntelFishOld { get; set; }
        public byte[] IntelUnitCurrent { get; set; }
        public byte[] IntelUnitOld { get; set; }

        private IntelDisplay _intelDisplay;

        private Action<int> _fishCountDisplay;

        public GameMemory(IntelDisplay intelDisplay, Action<int> fishCountDisplay)
        {
            _intelFishPtr = new DeepPointer(0x198452C); // 0x197C460
            _intelFishPtrDebug = new DeepPointer(0x25AF8AC); // 0x25A77E0
            _intelDisplay = intelDisplay;
            _fishCountDisplay = fishCountDisplay;
            IntelFishCurrent = new byte[1];
            IntelUnitCurrent = new byte[1];
        }

        public void StartMonitoring()
        {
            if (_thread != null && _thread.Status == TaskStatus.Running)
            {
                throw new InvalidOperationException();
            }

            if (!(SynchronizationContext.Current is WindowsFormsSynchronizationContext))
            {
                throw new InvalidOperationException("SynchronizationContext.Current is not a UI thread.");
            }

            //_uiThread = SynchronizationContext.Current;
            _cancelSource = new CancellationTokenSource();
            _thread = Task.Factory.StartNew(MemoryReadThread);
        }

        public void Stop()
        {
            if (_cancelSource == null || _thread == null || _thread.Status != TaskStatus.Running)
            {
                return;
            }

            _cancelSource.Cancel();
            _thread.Wait();
            _intelDisplay.updateComponentDisplayStatus("Game closed");
        }

        void MemoryReadThread()
        {
            Debug.WriteLine("[NierIntelTracker] MemoryReadThread");

            while (!_cancelSource.IsCancellationRequested)
            {
                try
                {
                    Trace.WriteLine("[NierIntelTracker] Waiting for NieRAutomata.exe...");
                    _intelDisplay.updateComponentDisplayStatus("Checking for game process");

                    Process game;
                    while ((game = GetGameProcess()) == null)
                    {
                        Thread.Sleep(500);
                        if (_cancelSource.IsCancellationRequested)
                        {
                            return;
                        }
                    }

                    Trace.WriteLine("[NierIntelTracker] Got NieRAutomata.exe!");
                    _intelDisplay.updateComponentDisplayStatus("Game process found");

                    IEnumerator coll = game.Modules.GetEnumerator();
                    coll.MoveNext();

                    DeepPointer FishPtr;
                    DeepPointer UnitIntelPtr;
                    var memSize = ((ProcessModule)coll.Current).ModuleMemorySize;
                    switch (memSize)
                    {
                        case 106266624:
                            FishPtr = new DeepPointer(0x198452C); // 0x197C460
                            UnitIntelPtr = new DeepPointer(0x19844C8);
                            _intelDisplay.updateComponentDisplayStatus("v1.01");
                            break;
                        default:
                            FishPtr = new DeepPointer(0x25AF8AC); // 0x25A77E0
                            UnitIntelPtr = new DeepPointer(0x25AF848);
                            _intelDisplay.updateComponentDisplayStatus("vdebug");
                            break;
                    }
                    Debug.WriteLine("[NierIntelTracker] ModuleMemorySize: " + memSize.ToString());

                    while (!game.HasExited)
                    {
                        IntelFishOld = IntelFishCurrent;
                        IntelFishCurrent = FishPtr.DerefBytes(game, 8);

                        if (!IntelFishCurrent.SequenceEqual(IntelFishOld))
                        {
                            int fishCount = IntelFishCurrent.Select(s => BitCount.PrecomputedBitcount(s)).Sum();
                            this._fishCountDisplay(fishCount);
                            this._intelDisplay.UpdateFishIntel(IntelFishCurrent, fishCount);
                        }

                        IntelUnitOld = IntelUnitCurrent;
                        IntelUnitCurrent = UnitIntelPtr.DerefBytes(game, 24);

                        if (!IntelUnitCurrent.SequenceEqual(IntelUnitOld))
                        {
                            this._intelDisplay.UpdateUnitIntel(IntelUnitCurrent);
                        }

                        Thread.Sleep(SLEEP_TIME);

                        if (_cancelSource.IsCancellationRequested)
                        {
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("[NierIntelTracker] Exception: " + ex.ToString());
                    Thread.Sleep(1000);
                }
            }
        }

        Process GetGameProcess()
        {
            Process game = Process.GetProcesses().FirstOrDefault(p => p.ProcessName.ToLower() == "nierautomata" && !p.HasExited);
            if (game == null)
            {
                return null;
            }

            return game;
        }

    }
}

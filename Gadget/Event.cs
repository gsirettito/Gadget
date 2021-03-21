using System.Windows.Input;

namespace Gadget {
    public enum DefinedActions {
        None,
        RunCommand,
        PowerOff,
        Restart,
        Suspense,
        Hibernate,
        Settings,
        ControlPanel,
        VolumeUp,
        VolumeDown,
        AppSwithUp,
        AppSwithDown,
    }

    public enum MouseWheelDirection {
        Any, Up, Down
    }

    public class Event {
        static Event() { }

        public ModifierKeys ModifierKeys { get; set; }

        public MouseButton MouseButton { get; set; }

        public DefinedActions DefinedActions { get; set; }

        public string Command { get; set; }
    }

    public class OnClickEvent : Event {
        public OnClickEvent() : base() { }

        public OnClickEvent(ModifierKeys modifierKeys, MouseButton mouseButton, int clicks, DefinedActions definedActions) {
            this.ModifierKeys = modifierKeys;
            this.MouseButton = mouseButton;
            this.ClickCount = clicks;
            this.DefinedActions = definedActions;
        }

        public OnClickEvent(ModifierKeys modifierKeys, MouseButton mouseButton, int clicks, DefinedActions definedActions, string command) {
            this.ModifierKeys = modifierKeys;
            this.MouseButton = mouseButton;
            this.ClickCount = clicks;
            this.DefinedActions = definedActions;
            this.Command = command;
        }

        public int ClickCount { get; set; }
    }

    public class OnWheelEvent : Event {
        public OnWheelEvent() : base() { }

        public OnWheelEvent(ModifierKeys modifierKeys, MouseButton mouseButton, MouseWheelDirection direcction, int wheel, DefinedActions definedActions) {
            this.ModifierKeys = modifierKeys;
            this.MouseButton = mouseButton;
            this.MouseWheelDirection = direcction;
            this.WheelCount = wheel;
            this.DefinedActions = definedActions;
        }

        public OnWheelEvent(ModifierKeys modifierKeys, MouseButton mouseButton, MouseWheelDirection direcction, int wheel, DefinedActions definedActions, string command) {
            this.ModifierKeys = modifierKeys;
            this.MouseButton = mouseButton;
            this.MouseWheelDirection = direcction;
            this.WheelCount = wheel;
            this.DefinedActions = definedActions;
            this.Command = command;
        }

        public int WheelCount { get; set; }

        public MouseWheelDirection MouseWheelDirection { get; set; }
    }
}

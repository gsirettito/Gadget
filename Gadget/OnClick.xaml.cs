using SiretT.Controls.ChildWindow;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Gadget {
    /// <summary>
    /// Lógica de interacción para OnClick.xaml
    /// </summary>
    //[StyleTypedProperty(Property="ChildWindow", StyleTargetType=typeof(OnClick))]
    public partial class OnClick : ChildWindow {
        private OnClickEvent _event;
        static OnClick() {
        }

        public OnClick()
            : base() {
            InitializeComponent();
            this.Loaded += OnClick_Loaded;
        }

        public OnClick(OnClickEvent _event)
            : base() {
            InitializeComponent();
            this.Loaded += OnClick_Loaded;
            this._event = _event;
        }

        void OnClick_Loaded(object sender, RoutedEventArgs e) {
            _combo_.Items.Clear();
            _combo_.ItemsSource = Enum.GetNames(typeof(DefinedActions));
            _combo_.SelectedIndex = 1;
            _combo_.SelectionChanged += _combo__SelectionChanged;
            _commandbox_.TextChanged += _commandbox__TextChanged;

            _modif_.Items.Clear();
            _modif_.ItemsSource = Enum.GetNames(typeof(ModifierKeys));
            _modif_.SelectedIndex = 0;

            _mouseb_.Items.Clear();
            _mouseb_.ItemsSource = Enum.GetNames(typeof(MouseButton));
            _mouseb_.SelectedIndex = 0;

            if (_event != null) {
                _combo_.SelectedValue = _event.DefinedActions.ToString();
                _modif_.SelectedValue = _event.ModifierKeys.ToString();
                _mouseb_.SelectedValue = _event.MouseButton.ToString();
                _clicc_.SelectedValue = _event.ClickCount.ToString();
                _commandbox_.Text = _event.Command;
            }

            if (_combo_.SelectedIndex == 1) {
                if (string.IsNullOrEmpty(_commandbox_.Text))
                    acceptButton.IsEnabled = false;
                else acceptButton.IsEnabled = true;
            } else acceptButton.IsEnabled = true;
        }

        private void okClick(object sender, RoutedEventArgs e) {
            this.ChildWindowResult = true;
            string cmd = _commandbox_.Text;
            if (!string.IsNullOrEmpty(cmd)) {
                while (cmd[0] == ' ') cmd = cmd.Remove(0, 1);
                while (cmd[cmd.Length - 1] == ' ') cmd = cmd.Remove(cmd.Length - 1);
            }
            if (_event == null) {
                Settings.Instance.Events.Add(
                new OnClickEvent(
                    (ModifierKeys)Enum.Parse(typeof(ModifierKeys), (string)_modif_.SelectedItem),
                    (MouseButton)Enum.Parse(typeof(MouseButton), (string)_mouseb_.SelectedItem),
                    _clicc_.SelectedIndex + 1,
                    (DefinedActions)Enum.Parse(typeof(DefinedActions), (string)_combo_.SelectedItem), cmd));
            } else {
                _event.ModifierKeys = (ModifierKeys)Enum.Parse(typeof(ModifierKeys), (string)_modif_.SelectedItem);
                _event.MouseButton = (MouseButton)Enum.Parse(typeof(MouseButton), (string)_mouseb_.SelectedItem);
                _event.ClickCount = _clicc_.SelectedIndex + 1;
                _event.DefinedActions = (DefinedActions)Enum.Parse(typeof(DefinedActions), (string)_combo_.SelectedItem);
                _event.Command = cmd;
            }
            this.Close();
        }

        private void _combo__SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (_combo_.SelectedIndex == 1) {
                if (string.IsNullOrEmpty(_commandbox_.Text))
                    acceptButton.IsEnabled = false;
                else acceptButton.IsEnabled = true;
            } else acceptButton.IsEnabled = true;
        }

        private void _commandbox__TextChanged(object sender, TextChangedEventArgs e) {
            if (_combo_.SelectedIndex == 1) {
                if (string.IsNullOrEmpty(_commandbox_.Text))
                    acceptButton.IsEnabled = false;
                else acceptButton.IsEnabled = true;
            } else acceptButton.IsEnabled = true;
        }

        private void cancel_Click(object sender, RoutedEventArgs e) {
            this.ChildWindowResult = false;
            this.Close();
        }

        private void selectApp_Click(object sender, RoutedEventArgs e) {
            using (var ofd = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog()) {
                ofd.Filters.Add(new Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogFilter("Application","*.exe"));
                if(ofd.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok) {
                    _commandbox_.Text = ofd.FileName;
                }
            }
        }
    }
}

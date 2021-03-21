using SiretT.Media;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Gadget {
    /// <summary>
    /// Lógica de interacción para Config.xaml
    /// </summary>
    public partial class Config : Window {
        private ContentControl _gadget_;

        public Config() {
            InitializeComponent();
            this.Loaded += Config_Loaded;
            this.Closed += Config_Closed;
        }

        public Config(ContentControl _gadget_)
            : this() {
            // TODO: Complete member initialization
            this._gadget_ = _gadget_;
        }

        private void Config_Closed(object sender, EventArgs e) {
            this.Hide();
        }

        void Config_Loaded(object sender, RoutedEventArgs e) {
            color.SelectedColor = ((SolidColorBrush)Settings.Instance.BackColor).Color;
            _onclickeventlist_.ItemsSource = Settings.Instance.Events.Where(d => { return d is OnClickEvent; });
            _onwheeleventlist_.ItemsSource = Settings.Instance.Events.Where(d => { return d is OnWheelEvent; });
            autoColor.IsChecked = Settings.Instance.UseColorization;
        }

        private void colorchange(object sender, EventArgs e) {
            GroupColor gc = sender as GroupColor;
            if (!Settings.Instance.UseColorization) {
                autoColor.IsChecked = false;
                Settings.Instance.UseColorization = false;
            }
            Settings.Instance.BackColor = new SolidColorBrush(gc.SelectedColor);
            _gadget_.Background = new SolidColorBrush(gc.SelectedColor);
            _preview_.Fill = Settings.Instance.BackColor;
        }

        private void onclick_Click(object sender, RoutedEventArgs e) {
            OnClick oc = new OnClick();
            oc.Closing += oc_Closing;
            _msgLayer_.Content = oc;
        }

        private void oc_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            _msgLayer_.Content = null;
            if (sender is OnWheel)
                _onwheeleventlist_.ItemsSource = Settings.Instance.Events.Where(d => { return d is OnWheelEvent; });
            else if (sender is OnClick)
                _onclickeventlist_.ItemsSource = Settings.Instance.Events.Where(d => { return d is OnClickEvent; });
        }

        private void _onClickItem_DoubleClick(object sender, MouseButtonEventArgs e) {
            if (e.ClickCount == 2) {
                OnClick oc = new OnClick(_onclickeventlist_.SelectedItem as OnClickEvent);
                oc.Closing += oc_Closing;
                _msgLayer_.Content = oc;
            }
        }

        private void _onWheelItem_DoubleClick(object sender, MouseButtonEventArgs e) {
            if (e.ClickCount == 2) {
                OnWheel oc = new OnWheel(_onwheeleventlist_.SelectedItem as OnWheelEvent);
                oc.Closing += oc_Closing;
                _msgLayer_.Content = oc;
            }
        }

        private void autoColor_Checked(object sender, RoutedEventArgs e) {
            color.SelectedColor = ColorHelper.Colorization;
            autoColor.IsChecked = true;
            Settings.Instance.UseColorization = true;
        }

        private void autoColor_Unchecked(object sender, RoutedEventArgs e) {
            Settings.Instance.UseColorization = false;
        }

        private void onwheel_Click(object sender, RoutedEventArgs e) {
            OnWheel oc = new OnWheel();
            oc.Closing += oc_Closing;
            _msgLayer_.Content = oc;
        }

        private void foreautoColor_Unchecked(object sender, RoutedEventArgs e) {
        }
    }
}

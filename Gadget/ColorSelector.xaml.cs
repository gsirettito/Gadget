using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gadget {
    /// <summary>
    /// Lógica de interacción para ColorSelector.xaml
    /// </summary>
    public partial class ColorSelector : GroupColor {
        public ColorSelector() {
            InitializeComponent();
        }

        protected override void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            base.OnPropertyChanged(d, e);
            if (e.Property == GroupColor.GroupNameProperty) {
                foreach (RadioButton rb in _base_.Children) rb.GroupName = (string)e.NewValue;
            }
        }

        private void color_Select(object sender, RoutedEventArgs e) {
            //base.SelectedColor = ((sender as RadioButton).Background as SolidColorBrush).Color;
            SetValue(GroupColor.SelectedColorProperty, ((sender as RadioButton).Background as SolidColorBrush).Color);
        }

        private void GroupColor_ColorChanged(object sender, EventArgs e) {
            foreach (RadioButton r in _base_.Children) {
                if ((r.Background as SolidColorBrush).Color == this.SelectedColor) {
                    r.IsChecked = true;
                    break;
                }
            }
        }
    }
}

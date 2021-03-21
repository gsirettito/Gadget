using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gadget {
    public abstract class GroupColor : UserControl {
        public GroupColor() { }

        public static readonly DependencyProperty SelectedColorProperty = DependencyProperty.Register(
            "SelectedColor", typeof(Color), typeof(GroupColor), new PropertyMetadata(OnPropertyChange));

        public static readonly DependencyProperty GroupNameProperty = DependencyProperty.Register(
            "GroupName", typeof(string), typeof(GroupColor), new PropertyMetadata(OnPropertyChange));

        public event EventHandler ColorChanged;

        private static void OnPropertyChange(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            (d as GroupColor).OnPropertyChanged(d, e);
        }

        protected virtual void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if (e.Property == SelectedColorProperty) {
                if (ColorChanged != null) ColorChanged(this, new EventArgs());
            }
        }

        public Color SelectedColor {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        public string GroupName {
            get { return (string)GetValue(GroupNameProperty); }
            set { SetValue(GroupNameProperty, value); }
        }
    }
}

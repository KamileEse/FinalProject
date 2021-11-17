using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MySudokuSolver
{
    /// <summary>
    /// Interaction logic for SudokuSquare.xaml
    /// </summary>
    public partial class SudokuSquare : UserControl
    {
        public event EventHandler ValueChanged;
        bool hasConflict;
        public bool HasConflict
        {
            get => hasConflict;
            set
            {
                if (hasConflict == value)
                    return;

                hasConflict = value;

                if (hasConflict)
                {
                    Grid1.Background = new SolidColorBrush(Colors.LightPink);
                }
                else
                {
                    Grid1.Background = null;
                }
            }
        }

        private bool locked;

        public string Notes { get; set; }
        public bool Locked 
        {
            get
            {
                return locked;
            }
            set
            {
                if (locked == value)
                    return;

                locked = value;
                if (locked)
                {
                    tbxValue.Foreground = new SolidColorBrush(Colors.Gray);
                    tbxValue.IsReadOnly = true;
                }
                else
                {
                    tbxValue.Foreground = new SolidColorBrush(Colors.Black);
                    tbxValue.IsReadOnly = false;
                }
            }
        }
        public char Char
        {
            get
            {
                if (tbxValue.Text.Length > 0)
                    return tbxValue.Text[0];
                return char.MinValue;
            }
        }

        public SudokuSquare()
        {
            InitializeComponent();
        }

        protected virtual void OnValueChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(sender, e);
        }
        private void tbxValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.Changes != null)
            {
                if (sender is TextBox textBox)
                {
                    string lineText = textBox.GetLineText(0);
                    TextChange textChange = e.Changes.First();
                    string whatChanged = lineText.Substring(textChange.Offset, textChange.AddedLength);
                    if (MainWindow.availableChars.Contains(whatChanged))
                    {
                        if (textBox.Text != whatChanged)
                        {
                            textBox.Text = whatChanged;
                        }
                    }
                    else if (textBox.Text != " ")
                    {
                        textBox.Text = " ";
                    }
                    OnValueChanged(this, EventArgs.Empty);
                }
            }
        }

        private void Border_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            tbxValue.Focus();
        }

        public void ShowSelection()
        {
            Border.Background = new SolidColorBrush(Colors.LightYellow);
            tbxValue.Focus();
        }

        public void HideSelection()
        {
            Border.Background = null;
        }

        public void Clear()
        {
            tbxValue.Text = "";
            tbNotes.Text = "";
        }

        internal void SetText(string text)
        {
            tbxValue.Text = text;
        }

        public string GetText()
        {
            return tbxValue.Text;
        }

        internal void SetNotes(string notes)
        {
            tbNotes.Text = notes;
        }
        public void FillFromNotesIfPossible()
        {
            if (tbNotes.Text.Length == 1)
            {
                tbxValue.Text = tbNotes.Text;
                tbNotes.Text = "";
            }
        }
        public void ClearNotes()
        {
            tbNotes.Text = "";
        }
    }
}

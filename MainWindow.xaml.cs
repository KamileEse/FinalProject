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
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        SudokuSquare[,] squares = new SudokuSquare[9, 9];
        SudokuSquare selectedSquare;
        public static string availableChars = "123456789";

        public SudokuSquare SelectedSquare 
        {
            get => selectedSquare;
            set
            {
                if (selectedSquare == value)
                    return;

                SudokuSquare oldSelectedSquare = selectedSquare;
                if (oldSelectedSquare != null)
                    oldSelectedSquare.HideSelection();

                selectedSquare = value;
                selectedSquare.ShowSelection();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            squares[0, 0] = textbox0_0;
            squares[0, 1] = textbox0_1;
            squares[0, 2] = textbox0_2;
            squares[0, 3] = textbox0_3;
            squares[0, 4] = textbox0_4;
            squares[0, 5] = textbox0_5;
            squares[0, 6] = textbox0_6;
            squares[0, 7] = textbox0_7;
            squares[0, 8] = textbox0_8;
            squares[1, 0] = textbox1_0;
            squares[1, 1] = textbox1_1;
            squares[1, 2] = textbox1_2;
            squares[1, 3] = textbox1_3;
            squares[1, 4] = textbox1_4;
            squares[1, 5] = textbox1_5;
            squares[1, 6] = textbox1_6;
            squares[1, 7] = textbox1_7;
            squares[1, 8] = textbox1_8;
            squares[2, 0] = textbox2_0;
            squares[2, 1] = textbox2_1;
            squares[2, 2] = textbox2_2;
            squares[2, 3] = textbox2_3;
            squares[2, 4] = textbox2_4;
            squares[2, 5] = textbox2_5;
            squares[2, 6] = textbox2_6;
            squares[2, 7] = textbox2_7;
            squares[2, 8] = textbox2_8;
            squares[3, 0] = textbox3_0;
            squares[3, 1] = textbox3_1;
            squares[3, 2] = textbox3_2;
            squares[3, 3] = textbox3_3;
            squares[3, 4] = textbox3_4;
            squares[3, 5] = textbox3_5;
            squares[3, 6] = textbox3_6;
            squares[3, 7] = textbox3_7;
            squares[3, 8] = textbox3_8;
            squares[4, 0] = textbox4_0;
            squares[4, 1] = textbox4_1;
            squares[4, 2] = textbox4_2;
            squares[4, 3] = textbox4_3;
            squares[4, 4] = textbox4_4;
            squares[4, 5] = textbox4_5;
            squares[4, 6] = textbox4_6;
            squares[4, 7] = textbox4_7;
            squares[4, 8] = textbox4_8;
            squares[5, 0] = textbox5_0;
            squares[5, 1] = textbox5_1;
            squares[5, 2] = textbox5_2;
            squares[5, 3] = textbox5_3;
            squares[5, 4] = textbox5_4;
            squares[5, 5] = textbox5_5;
            squares[5, 6] = textbox5_6;
            squares[5, 7] = textbox5_7;
            squares[5, 8] = textbox5_8;
            squares[6, 0] = textbox6_0;
            squares[6, 1] = textbox6_1;
            squares[6, 2] = textbox6_2;
            squares[6, 3] = textbox6_3;
            squares[6, 4] = textbox6_4;
            squares[6, 5] = textbox6_5;
            squares[6, 6] = textbox6_6;
            squares[6, 7] = textbox6_7;
            squares[6, 8] = textbox6_8;
            squares[7, 0] = textbox7_0;
            squares[7, 1] = textbox7_1;
            squares[7, 2] = textbox7_2;
            squares[7, 3] = textbox7_3;
            squares[7, 4] = textbox7_4;
            squares[7, 5] = textbox7_5;
            squares[7, 6] = textbox7_6;
            squares[7, 7] = textbox7_7;
            squares[7, 8] = textbox7_8;
            squares[8, 0] = textbox8_0;
            squares[8, 1] = textbox8_1;
            squares[8, 2] = textbox8_2;
            squares[8, 3] = textbox8_3;
            squares[8, 4] = textbox8_4;
            squares[8, 5] = textbox8_5;
            squares[8, 6] = textbox8_6;
            squares[8, 7] = textbox8_7;
            squares[8, 8] = textbox8_8;

            HookEvents();

            SelectedSquare = squares[0, 0];
        }

        private void HookEvents()
        {
            for (int row = 0; row < 9; row++)
                for (int column = 0; column < 9; column++)
                    squares[row, column].ValueChanged += SudokuSquare_ValueChanged;
        }

        private void SudokuSquare_ValueChanged(object sender, EventArgs e)
        {
            
        }

        void SelectSquare(int row, int column)
        {
            if (column >= 9)
                column -= 9;

            if (column < 0)
                column += 9;

            if (row >= 9)
                row -= 9;

            if (row < 0)
                row += 9;

            SelectedSquare = squares[row, column];
        }

        void GetSquarePosition(SudokuSquare square, out int row, out int column)
        {
            for (int c = 0; c < 9; c++)
                for (int r = 0; r < 9; r++)
                {
                    if (squares[r, c] == square)
                    {
                        row = r;
                        column = c;
                        return;
                    }
                }

            row = -1;
            column = -1;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                GetSquarePosition(SelectedSquare, out int row, out int column);
                SelectSquare(row, column + 1);
            }

            if (e.Key == Key.Left)
            {
                GetSquarePosition(SelectedSquare, out int row, out int column);
                SelectSquare(row, column - 1);
            }

            if (e.Key == Key.Down)
            {
                GetSquarePosition(SelectedSquare, out int row, out int column);
                SelectSquare(row + 1, column);
            }

            if (e.Key == Key.Up)
            {
                GetSquarePosition(SelectedSquare, out int row, out int column);
                SelectSquare(row - 1, column);
            }
        }

        private void tbxAvailableCharacter_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetAvailableCharacters();
        }

        string easyGame = @"53  7    
6  195   
 98    6 
8   6   3
4  8 3  1
7   2   6
 6    28 
   419  5
    8  79
";


        void SetAvailableCharacters()
        {
            string availableChars = tbxAvailableCharacter.Text.Trim();
            if (availableChars.Length != 9)
            {
                Background = new SolidColorBrush(Colors.Red);
            }
            else
            {
                Background = new SolidColorBrush(Colors.White);
            }
        }

        void ClearGame()
        {
            ClearAllConflicts();

            for (int c = 0; c < 9; c++)
                for (int r = 0; r < 9; r++)
                    squares[r, c].Clear();
        }
        
        private void AddValuesForLine(int row, string line)
        {
            for (int column = 0; column < line.Length; column++)
            {
                char chr = line[column];
                if (chr != ' ')
                {
                    squares[row, column].SetText(chr.ToString());
                    squares[row, column].Locked = true;
                } 
            }
        }

        bool loadingGame;

        void LoadGame(string gameStr)
        {
            loadingGame = true;
            try
            {
                ClearGame();
                string[] lines = gameStr.Split('\n');
                int row = 0;
                foreach (string line in lines)
                {
                    AddValuesForLine(row, line.TrimEnd());
                    row++;
                }
            }
            finally
            {
                loadingGame = false;
            }
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
                LoadGame(easyGame);
        }

        private SudokuSquare[] GetColumn(int column)
        {
            SudokuSquare[] result = new SudokuSquare[9];
            for (int row = 0; row < 9; row++)
            {
                result[row] = squares[row, column];
            }
            return result;
        }

        private SudokuSquare[] GetRow(int row)
        {
            SudokuSquare[] result = new SudokuSquare[9];
            for (int column = 0; column < 9; column++)
            {
                result[column] = squares[column, row];
            }
            return result;
        }

        private SudokuSquare[] GetBlock(int row, int column)
        {
            int topRow = 3 * (int)Math.Floor((double)row / 3);
            int leftColumn = 3 * (int)Math.Floor((double)column / 3);
            SudokuSquare[] result = new SudokuSquare[9];
            int index = 0;
            for (int r = topRow; r < topRow + 3; r++)
                for (int c = leftColumn; c < leftColumn + 3; c++)
                {
                    result[index] = squares[r, c];
                    index++;
                }
             
            return result;
        }

        private void RemoveChars(List<char> availableChars, SudokuSquare[] row)
        {
            for (int i = 0; i < 9; i++)
            {
                char thisChar = row[i].Char;
                if (availableChars.Contains(thisChar))
                    availableChars.Remove(thisChar);
            }
        }

        private void btnFill_Click(object sender, RoutedEventArgs e)
        {
            FillFromAllNotes();

        }

        private void FillFromAllNotes()
        {
            for (int c = 0; c < 9; c++)
                for (int r = 0; r < 9; r++)
                    squares[r, c].FillFromNotesIfPossible();
        }

        private void ShowNotesForSquare(SudokuSquare square)
        {
            if (square.GetText().Trim().Length > 0)
                return;

            GetSquarePosition(square, out int r, out int c);
            SudokuSquare[] column = GetColumn(c);
            SudokuSquare[] row = GetRow(r);
            SudokuSquare[] block = GetBlock(r, c);

            List<char> availableChars = new List<char>();
            foreach (char item in tbxAvailableCharacter.Text)
                availableChars.Add(item);

            RemoveChars(availableChars, column);
            RemoveChars(availableChars, row);
            RemoveChars(availableChars, block);

            square.SetNotes(string.Join(", ", availableChars));
        }
        private void btnSolve_Click(object sender, RoutedEventArgs e)
        {
            FillFromAllNotes();
            RefreshAllNotes();
        }

        private void RefreshAllNotes()
        {
            for (int c = 0; c < 9; c++)
                for (int r = 0; r < 9; r++)
                    ShowNotesForSquare(squares[r, c]);
        }

        private void btnClearNotes_Click(object sender, RoutedEventArgs e)
        {
            for (int c = 0; c < 9; c++)
                for (int r = 0; r < 9; r++)
                    squares[r, c].ClearNotes();
        }

        private void btnConflict_Click(object sender, RoutedEventArgs e)
        {
            if (loadingGame)
            {
                return;
            }
            else
            {
                ShowConflicts();
            }
        }

        private void ShowConflicts()
        {
            ClearAllConflicts();

            for (int c = 0; c < 9; c++)
                for (int r = 0; r < 9; r++)
                {
                    SudokuSquare thisSquare = squares[r, c];
                    string text = thisSquare.GetText();
                    if (string.IsNullOrWhiteSpace(text))
                        continue;

                    SudokuSquare[] column = GetColumn(c);
                    SudokuSquare[] row = GetRow(r);
                    SudokuSquare[] block = GetBlock(r, c);
                    for (int rowIndex = 0; rowIndex < 9; rowIndex++)
                    {
                        if (rowIndex != r && column[rowIndex].GetText() == text)
                        {
                            thisSquare.HasConflict = true;
                            column[rowIndex].HasConflict = true;
                        }
                    }
                    for (int colIndex = 0; colIndex < 9; colIndex++)
                    {
                        if (colIndex != c && row[colIndex].GetText() == text)
                        {
                            thisSquare.HasConflict = true;
                            row[colIndex].HasConflict = true;
                        }
                    }
                    for (int BlockIndex = 0; BlockIndex < 9; BlockIndex++)
                    {
                        GetSquarePosition(block[BlockIndex], out int blockRow, out int blockColumn);
                        if (blockRow == r && blockColumn == c)
                            continue;

                        if (block[BlockIndex].GetText() == text)
                        {
                            thisSquare.HasConflict = true;
                            block[BlockIndex].HasConflict = true;
                        }
                    }
                }
        }

        private void ClearAllConflicts()
        {
            for (int c = 0; c < 9; c++)
                for (int r = 0; r < 9; r++)
                    squares[r, c].HasConflict = false;
        }

        //private void btnToggleLock_Click(object sender, RoutedEventArgs e)
        //{
        //    if (SelectedSquare != null)
        //        SelectedSquare.Locked = !SelectedSquare.Locked;
        //}
    }
}

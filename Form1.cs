using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int N = 1;
        private int i = 0;
        private int j = 0;
        private int Change;
        // Глобальні масиви з 0-індексацією (0..N-1)
        private double[,] A = new double[6, 6];
        private double[] B = new double[6];
        private double[] X = new double[6];

        // Глобальний вектор перестановок P з 1-індексацією (1..N)
        // P[i] містить індекс рядка (1..N), який ПОВИНЕН БУТИ в i-ій позиції.
        private int[] P = new int[6];

        private void Form1_Load(object sender, EventArgs e)
        {
            X_vector_dgv.ReadOnly = true;

            A_matrix_dgv.AllowUserToAddRows = false;
            B_vector_dgv.AllowUserToAddRows = false;
            X_vector_dgv.AllowUserToAddRows = false;
            C_matrix_dgv.AllowUserToAddRows = false;

            A_matrix_dgv.ColumnCount = 1;
            A_matrix_dgv.RowCount = 1;
            X_vector_dgv.ColumnCount = 1;
            X_vector_dgv.RowCount = 1;
            B_vector_dgv.ColumnCount = 1;
            B_vector_dgv.RowCount = 1;
            C_matrix_dgv.ColumnCount = 1;
            C_matrix_dgv.RowCount = 1;
        }

        private void NUD_rozmir_ValueChanged(object sender, EventArgs e)
        {
            N = Convert.ToInt16(NUD_rozmir.Value);
            A_matrix_dgv.RowCount = N;
            A_matrix_dgv.ColumnCount = N;
            X_vector_dgv.RowCount = N;
            B_vector_dgv.RowCount = N;
            C_matrix_dgv.RowCount = N;
            C_matrix_dgv.ColumnCount = N;

            for (int r = 0; r < N; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    A_matrix_dgv.Rows[r].Cells[c].Value = "";
                    C_matrix_dgv.Rows[r].Cells[c].Value = "";
                }
                B_vector_dgv.Rows[r].Cells[0].Value = "";
                X_vector_dgv.Rows[r].Cells[0].Value = "";
            }
        }

        // --- ВИПРАВЛЕНИЙ МЕТОД DECOMP (З ПОВНИМ ЧАСТКОВИМ ПІВОТИНГОМ) ---
        private bool Decomp(int N, ref int Change)
        {
            // Створення копії матриці А для LU-розкладу з 1-індексацією (1..N)
            double[,] C = new double[N + 1, N + 1];
            for (int r = 1; r <= N; r++)
                for (int c = 1; c <= N; c++)
                    C[r, c] = A[r - 1, c - 1]; // Перехід від 0-індексації A до 1-індексації C

            // Ініціалізація глобального вектора перестановок P: P[i] = i (1-індексація)
            for (int i = 1; i <= N; i++) P[i] = i;

            // --- Частковий Півотинг на КОЖНОМУ кроці (для стійкості) ---
            for (int k = 1; k <= N; k++) // Цикл по стовпцях
            {
                // 1. Пошук максимального елемента (півотинг)
                int maxRow = k;
                double maxVal = Math.Abs(C[k, k]);

                for (int i = k + 1; i <= N; i++)
                {
                    if (Math.Abs(C[i, k]) > maxVal)
                    {
                        maxVal = Math.Abs(C[i, k]);
                        maxRow = i;
                    }
                }

                if (Math.Abs(maxVal) < 1e-14)
                {
                    MessageBox.Show($"Нульовий або дуже малий діагональний елемент на позиції {k}. Розв'язок неможливий.");
                    Change = -1;
                    return false;
                }

                // 2. Перестановка рядків у C та у векторі P
                if (maxRow != k)
                {
                    // Обмін елементів у C (повний рядок)
                    for (int j = 1; j <= N; j++)
                    {
                        double tmp = C[k, j];
                        C[k, j] = C[maxRow, j];
                        C[maxRow, j] = tmp;
                    }

                    // Обмін елементів у векторі перестановок P
                    int tmpP = P[k];
                    P[k] = P[maxRow];
                    P[maxRow] = tmpP;
                }

                // Зберігаємо першу перестановку для сумісності з 'Change' (вимога методички)
                if (k == 1) Change = P[1];

                // 3. LU-розклад (методом Doolittle)
                double diag_k = C[k, k];

                // Обчислення множників L (під діагоналлю)
                for (int i = k + 1; i <= N; i++)
                {
                    C[i, k] = C[i, k] / diag_k;
                }

                // Перерахунок елементів нижче та праворуч від діагоналі
                for (int i = k + 1; i <= N; i++)
                {
                    double factor = C[i, k];
                    for (int j = k + 1; j <= N; j++)
                    {
                        C[i, j] = C[i, j] - factor * C[k, j];
                    }
                }
            }

            // Виведення результату LU-розкладу (матриця C) в DataGridView (з 1-індексації C до 0-індексації DGV)
            for (int r = 1; r <= N; r++)
                for (int c = 1; c <= N; c++)
                    C_matrix_dgv.Rows[r - 1].Cells[c - 1].Value = C[r, c].ToString("G12");

            return true;
        }

        // --- ВИПРАВЛЕНИЙ МЕТОД SOLVE (З ВИКОРИСТАННЯМ ПОВНОГО ВЕКТОРА P) ---
        private void Solve(int Change, int N)
        {
            // B_temp[1..N], X_temp[1..N]
            double[] B_temp = new double[N + 1];
            double[] X_temp = new double[N + 1];

            // 1. Застосовуємо всі перестановки з P до вектора B, щоб отримати B_переставлене (1-індексація)
            // B[P[i]-1] - це елемент B з 0-індексацією, який повинен бути на i-ій позиції в B_temp.
            for (int i = 1; i <= N; i++)
            {
                B_temp[i] = B[P[i] - 1];
            }

            double[,] C = new double[N + 1, N + 1];
            for (int r = 1; r <= N; r++)
                for (int c = 1; c <= N; c++)
                    C[r, c] = Convert.ToDouble(C_matrix_dgv.Rows[r - 1].Cells[c - 1].Value);

            // 2. Прямий хід (Ly = B_temp, де L має одиничну діагональ)
            // B_temp (який тепер y) обчислюється, використовуючи елементи L (під діагоналлю C)
            for (int i = 1; i <= N; i++)
            {
                double sum = 0.0;
                for (int j = 1; j < i; j++)
                    sum += C[i, j] * B_temp[j];

                // y_i = b_i - Sum(L_i,j * y_j). Ділення на L[i, i]=1 (неявно)
                B_temp[i] = B_temp[i] - sum;
            }

            // 3. Зворотний хід (Ux = y)
            // Обчислюємо X_temp (x) використовуючи елементи U (на діагоналі та над нею C)
            for (int i = N; i >= 1; i--)
            {
                double sum = 0.0;
                for (int j = i + 1; j <= N; j++)
                    sum += C[i, j] * X_temp[j]; // X_temp[j] вже містить обчислені x_j

                double diag = C[i, i];

                X_temp[i] = (B_temp[i] - sum) / diag;
            }

            // Копіюємо розв'язок X_temp[1..N] назад у глобальний X[0..N-1] для виводу
            for (int i = 1; i <= N; i++)
            {
                X[i - 1] = X_temp[i];
            }
        }
        // -------------------------------------------------------------------

        // Метод Гауса (Залишаємо без змін, він працює коректно з 0-індексацією)
        private bool GaussianElimination(int N)
        {
            double[,] A_copy = new double[N, N];
            double[] B_copy = new double[N];

            for (int i = 0; i < N; i++)
            {
                B_copy[i] = B[i];
                for (int j = 0; j < N; j++)
                    A_copy[i, j] = A[i, j];
            }

            for (int k = 0; k < N; k++)
            {
                int maxRow = k;
                double maxVal = Math.Abs(A_copy[k, k]);
                for (int i = k + 1; i < N; i++)
                {
                    if (Math.Abs(A_copy[i, k]) > maxVal)
                    {
                        maxVal = Math.Abs(A_copy[i, k]);
                        maxRow = i;
                    }
                }

                if (Math.Abs(maxVal) < 1e-14)
                {
                    MessageBox.Show("Система вироджена, немає унікального розв'язку.");
                    return false;
                }

                if (maxRow != k)
                {
                    for (int j = 0; j < N; j++)
                    {
                        double tmp = A_copy[k, j];
                        A_copy[k, j] = A_copy[maxRow, j];
                        A_copy[maxRow, j] = tmp;
                    }
                    double tmpB = B_copy[k];
                    B_copy[k] = B_copy[maxRow];
                    B_copy[maxRow] = tmpB;
                }

                for (int i = k + 1; i < N; i++)
                {
                    double factor = A_copy[i, k] / A_copy[k, k];
                    for (int j = k; j < N; j++)
                        A_copy[i, j] -= factor * A_copy[k, j];
                    B_copy[i] -= factor * B_copy[k];
                }
            }

            for (int i = N - 1; i >= 0; i--)
            {
                double sum = 0;
                for (int j = i + 1; j < N; j++)
                    sum += A_copy[i, j] * X[j];
                X[i] = (B_copy[i] - sum) / A_copy[i, i];
            }

            return true;
        }

        private void BCreateGrid_Click(object sender, EventArgs e)
        {
            bool exc_A = false;
            bool exc_B = false;

            // Зчитування матриці A (0-індексація)
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N; j++)
                {
                    try
                    {
                        object val = A_matrix_dgv.Rows[i].Cells[j].Value;
                        if (val == null || string.IsNullOrWhiteSpace(val.ToString()))
                            throw new Exception();
                        A[i, j] = Convert.ToDouble(val);
                        A_matrix_dgv.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                    catch
                    {
                        A_matrix_dgv.Rows[i].Cells[j].Style.ForeColor = Color.Red;
                        exc_A = true;
                    }
                }
            }

            // Зчитування вектора B (0-індексація)
            for (j = 0; j < N; j++)
            {
                try
                {
                    object val = B_vector_dgv.Rows[j].Cells[0].Value;
                    if (val == null || string.IsNullOrWhiteSpace(val.ToString()))
                        throw new Exception();
                    B[j] = Convert.ToDouble(val);
                    B_vector_dgv.Rows[j].Cells[0].Style.ForeColor = Color.Black;
                }
                catch
                {
                    B_vector_dgv.Rows[j].Cells[0].Style.ForeColor = Color.Red;
                    exc_B = true;
                }
            }

            if (exc_A || exc_B)
            {
                MessageBox.Show("Помилка введення! Виділіть червоні поля та виправте.");
                return;
            }

            // Очистка C_matrix і X_vector
            for (int r = 0; r < N; r++)
            {
                for (int c = 0; c < N; c++)
                    C_matrix_dgv.Rows[r].Cells[c].Value = "";
                X_vector_dgv.Rows[r].Cells[0].Value = "";
            }

            bool success = false;

            // Вибір методу через ComboBox
            if (comboBox.SelectedIndex == 0) // LU
            {
                if (!Decomp(N, ref Change)) return;
                Solve(Change, N);
                success = true;
            }
            else if (comboBox.SelectedIndex == 1) // Гаус
            {
                success = GaussianElimination(N);
            }

            if (!success) return;

            // Вивід X (0-індексація)
            for (i = 0; i < N; i++)
                X_vector_dgv.Rows[i].Cells[0].Value = X[i].ToString("G12");

            // Перевірка залишку (0-індексація)
            double maxErr = 0.0;
            for (int r = 0; r < N; r++)
            {
                double sum = 0.0;
                for (int c = 0; c < N; c++)
                    sum += A[r, c] * X[c];
                double diff = Math.Abs(sum - B[r]);
                if (diff > maxErr) maxErr = diff;
            }

            MessageBox.Show($"Розв'язок знайдено. Максимальна похибка A·X - B = {maxErr:E12}");
        }


        private void BClear_Click(object sender, EventArgs e)
        {
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N; j++)
                {
                    A_matrix_dgv.Rows[i].Cells[j].Value = "";
                    C_matrix_dgv.Rows[i].Cells[j].Value = "";
                }
                B_vector_dgv.Rows[i].Cells[0].Value = "";
                X_vector_dgv.Rows[i].Cells[0].Value = "";
            }
        }

        private void BClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void A_matrix_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                A_matrix_dgv.CurrentCell.Style.ForeColor = Color.Black;
        }

        private void B_vector_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                B_vector_dgv.CurrentCell.Style.ForeColor = Color.Black;
        }
    }
}
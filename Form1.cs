using System.ComponentModel.Design;
using System.Numerics;

namespace OOP_Lab_4_1
{
    public partial class Form1 : Form
    {
        List<CCircle> circles; // ������ ���� �����������
        Designer designer; 

        bool is_ctrl_pressed = false; // ��������� ctrl

        public Form1()
        {
            InitializeComponent();
            circles = new List<CCircle>(); // ���������� ������ �����������
            designer = new Designer(pictureBox.Width, pictureBox.Height); // ���������� �����, ���������� �� ���������
        }

        private void NewCircle(int x, int y) // ������ ����� ������, ��������� ��� � ������ ���� ����������� � ������������ �� ����������� (������ � ���)
        {
            designer.UnselectAll(circles);
            designer.DrawAll(circles);

            CCircle circle = new CCircle(x, y);
            circle.DrawCircle(designer);
            pictureBox.Image = designer.GetBitmap();
            circles.Add(circle);
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e) // ������������ ������� ����� (��������� ��� �������� �����������)
        {
            designer.Clear();

            bool was_clicked = false;

            if (!is_ctrl_pressed) // ���� CTRL �� ������, ������ ������� ��������� �� ���� ���������� �����������
                designer.UnselectAll(circles);

            if (!designer.SelectCircleByCoord(circles, e.X, e.Y, !isCrossSelectCheckBox.Checked)) // �������� ���������� (����������) ����������, �����?
            {
                NewCircle(e.X, e.Y); // ��� - ������ �����
            } else
            {
                designer.DrawAll(circles); // �� - ������������ ��� (�� ����������, ��� �� �����, �� ��� ��������)
                pictureBox.Image = designer.GetBitmap();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e) // ��������� ������� Paint
        {
            designer.DrawAll(circles); // ������������ ��� ����������
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) // ��������� ������� ������� �������
        {
            switch (e.KeyCode)
            {
                case Keys.ControlKey: // ���� ��� CTRL, �� �� ��� ���������� � �������
                    is_ctrl_pressed = true;
                    isCtrlCheckBox.Checked = true;
                    break;
                case Keys.Delete: // ���� ��� DEL, �� �� ������� ��� ���������� �������� 
                    List<CCircle> order_to_delete = new List<CCircle>(); // ������ ������ �� ��������
                    foreach (CCircle circle in circles)
                        if (circle.IsSelected())
                            order_to_delete.Add(circle); // ��������� ���� ������
                    foreach (CCircle circle in order_to_delete)
                        if (circles.Contains(circle))
                            circles.Remove(circle); // ���������� �� ����� ������ � ������� ��� ���������� ��� �� ������ ���� �����������
                    break;
            }

            designer.Clear(); // ������� �����������, ������������ ��� ���������� � ������� ���������� pictureBox'�
            designer.DrawAll(circles);
            pictureBox.Image = designer.GetBitmap();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e) // ������������ ������� ���������� �������
        {
            if (e.KeyCode == Keys.ControlKey)
            { // ���� ��� ���� CTRL, �� �� ���������� ��� (����������, ��� ��� ��� �� ������)
                is_ctrl_pressed = false; 
                isCtrlCheckBox.Checked = false;
            }
        }
    }

    public class Designer // �����, ���������� �� ��������� � ��������� ����������� � bitmap (��������� �����������)
    {
        private Bitmap bitmap; // ��������� �����������
        private Pen blackPen; // ����� ��� ��������� ������ ������
        private Pen redPen; // ����� ��� ��������� ������ ������
        private Graphics g; // �����, ��������������� ������ ��� ��������� ��������

        public Designer(int width, int height) // �����������
        {
            bitmap = new Bitmap(width, height); // ���������� ��������� �����������
            g = Graphics.FromImage(bitmap); // ���������� �����, ���������� �� ���������
            blackPen = new Pen(Color.Black); blackPen.Width = 2; // ���������� ������ �����
            redPen = new Pen(Color.Red); redPen.Width = 2; // ���������� ������� �����
        }

        public Bitmap GetBitmap() // �������� ��������� ����������� 
        {
            return bitmap;
        }

        public void Clear() // �������� �����������
        {
            g.Clear(Color.White);
        }

        public void DrawCircle(int x, int y, int radius) // ���������� ���������� (������� �����)
        {
            g.DrawEllipse(blackPen, (x - radius), (y - radius), 2 * radius, 2 * radius);
        }

        public void DrawSelectedCircle(int x, int y, int radius) // ���������� ���������� ���������� (�������� �����)
        {
            g.DrawEllipse(redPen, (x - radius), (y - radius), 2 * radius, 2 * radius);
        }

        public void DrawAll(List<CCircle> circles) // ���������� ���� ����������
        {
            foreach (CCircle current_circle in circles)
                current_circle.DrawCircle(this);
        }

        public void UnselectAll(List<CCircle> circles) // ������� ������������� �� ���� �����������
        {
            foreach (CCircle current_circle in circles)
                current_circle.Unselect();
        }

        public bool SelectCircleByCoord(List<CCircle> circles, int x, int y, bool is_single) // �������� ���������� (����������) ���������� (����������) �� �����������
        {
            bool was_clicked = false;
            foreach (CCircle circle in circles) // ���� ����������, �� ������� �� ������ (���� ������ ������)
            {
                if (circle.WasClicked(x, y))
                {
                    was_clicked = true;
                    circle.Select(); // �������� ����������

                    if (is_single) return true; // ���� ������������ ��������� �� �������, �� ��������������� �� ��������� ����� ����������
                }
            }
            return was_clicked; // �� ������ ������� ���������� ���������
        }
    }
    public class CCircle
    {
        private int x, y, radius; // ��������� ����������
        private bool is_selected; // �������� ����������� �� ������������ ����������

        public CCircle(int x, int y) // ����������� ���������� 
        {
            this.x = x;
            this.y = y;
            radius = 33;
        }

        public CCircle(CCircle obj) // ���������� �����������
        {
            this.x = obj.x;
            this.y = obj.y;
            this.radius = obj.radius;
        }

        public void Select() // �������� ����������
        {
            is_selected = true;
        }

        public void Unselect() // ������� ������������ ����������
        {
            is_selected = false;
        }

        public bool IsSelected() // ����������� ������������ ����������
        {
            return is_selected;
        }

        public void DrawCircle(Designer designer) // ���������� ���������� � ������� ������, ���. �� ���������
        {
            if (IsSelected()) designer.DrawSelectedCircle(x, y, radius);
            else designer.DrawCircle(x, y, radius);
        }

        public bool WasClicked(int coordX, int coordY) // ����������� � ����������, ������ �� ��� �� ������� ����������
        {
            return (Math.Pow(x - coordX, 2) + Math.Pow(y - coordY, 2) <= radius * radius);
        }
    }
}
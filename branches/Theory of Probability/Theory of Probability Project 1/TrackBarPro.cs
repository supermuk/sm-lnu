using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

using System.Collections;
namespace Theory_of_Probability_Project_1
{
    public partial class TrackBarPro : UserControl
    {
        private int thumbCount ;
        public int ThumbCount
        {
            set
            {
                thumbCount = value;
                RefreshValues();
                
            }
            get
            {
                return thumbCount;
            }
        }

        private float minValue;
        public float MinValue
        {
            get
            {
                return minValue;
            }
            set
            {
                minValue = value;
                label1.Text = minValue.ToString();
                RefreshValues();
            }
        }

        private float maxValue;
        public float MaxValue
        {
            get
            {
                return maxValue;
            }
            set
            {
                maxValue = value;
                label2.Text = maxValue.ToString();
                RefreshValues();
            }
        }

        private List<float> values = new List<float>();
        public List<float> Values
        {
            get
            {
                //RefreshValues();
                return values;
            }
            set
            {
                ThumbCount = value.Count - 2;
                values = value;
                
                RefreshThumbs();
            }
        }

        private int marginLeft = -8;
        private int marginTop = 0;

        private List<int> thumbs = new List<int>();

        private Font thumbFont = new Font(new FontFamily("arial"), 12);

        private Brush thumbBrush = Brushes.Gray;

        private bool mouseDown = false;

        private int activeThumbIndex;

        private int oldX;

        public TrackBarPro()
        {
            InitializeComponent();


        }
        private void RefreshThumbs()
        {
            thumbs.Clear();
            thumbs.Add(marginLeft);

            for (int i = 1; i <= thumbCount; i++)
            {
                thumbs.Add( (int) ( (values[i] - minValue  ) * Size.Width / (maxValue - minValue)));
            }
            thumbs.Add(Size.Width - 8);
            Refresh();
        }

        private void RefreshValues()
        {
            values.Clear();
            for (int i = 0; i <= thumbCount + 1; i++)
            {
                values.Add(minValue + i * (maxValue - minValue) /(float) (thumbCount + 1));
            }
            RefreshThumbs();
            
        }

        private void TrackBarPro_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Violet, 2), marginLeft, 10, Size.Width, 10);
            for(int i = 0; i < thumbs.Count ; i++)
            {
                e.Graphics.DrawString(")[", thumbFont, Brushes.Gray, thumbs[i], marginTop);
            }

        }

        private void TrackBarPro_MouseDown(object sender, MouseEventArgs e)
        {
            int index = 1;
            for(int i = 1; i < thumbs.Count - 1; i++)
            {
                if ( (new Rectangle(thumbs[i], marginTop, 16, 20)).Contains(new Point(e.X, e.Y)))
                {
                    activeThumbIndex = index;
                    break;
                }
                index++;
            }
            if (index < thumbs.Count - 1)
            {
                mouseDown = true;
                Refresh();
                oldX = e.X;
            }
        }

        private void TrackBarPro_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            RefreshThumbs();
        }

        private void TrackBarPro_MouseMove(object sender, MouseEventArgs e)
        {

            if (mouseDown)
            {
                if(e.X - 20 > thumbs[activeThumbIndex - 1] && e.X  < thumbs[activeThumbIndex + 1])
                {
                    values[activeThumbIndex] = values[activeThumbIndex] - (oldX - e.X) * (maxValue - minValue ) / (float) Size.Width;
                    oldX = e.X;
                    RefreshThumbs();
                    ThumbMoved(activeThumbIndex - 1);
                }
            }
        }

        private void TrackBarPro_SizeChanged(object sender, EventArgs e)
        {
            RefreshThumbs();
        }

        public delegate void Moved(int index);
        public event Moved ThumbMoved;
        
    }
}

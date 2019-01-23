using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElepaniStage
{
    public partial class Form1 : Form
    {
        //描画用クラス
        Bitmap gCanvas;
        Graphics gMap;
 
        //保存したマップデータのテキスト
        string clipText;

        Pen pen = new Pen(Color.Black);


        //プレイヤーの位置
        Point playerPoint;
        //エネミーの位置
        Point enemyPoint;
        //ブロックの位置
        Point[] blockPoints;
        //電流を置くの位置
        Point[] electricPoints;
        
        //ブロック数
        int blockCount = 0;
        //電流数
        int electCount = 0;


        //押しているボタンのモード
        enum ButtonMode
        {
            NONE,PLAYER,ENEMY,BLOCK,ELECTRIC,OTHER1,OTHER2
        }
        ButtonMode bMode;


        public Form1()
        {
            InitializeComponent();

            //描画先の画像データ作成
            gCanvas = new Bitmap(3000, 3000);
            //PictureBoxのImageを作成された画像データにする
            StageViewer.Image = gCanvas;
            //ImageオブジェクトのGrphicsオブジェクトを作成する
            gMap = Graphics.FromImage(gCanvas);

            //白塗り
            gMap.Clear(Color.White);

            pen = new Pen(Color.Black);
            gMap.DrawLine(pen, new Point((int)MapDistanse.Value,0), new Point((int)MapDistanse.Value,5000));

            blockPoints = new Point[10];

            electricPoints = new Point[10];


            hScrollBar1.Maximum = (int)MapDistanse.Value;
        }

        //更新
        void Refresh()
        {
            StageViewer.Refresh();
        }

        //最終的な描画
        void DrawCanvas()
        {
            gMap.Clear(Color.White);
        }

        //モード変更
        void ChangeMode(ButtonMode mode)
        {
            //モードの変更
            bMode = mode;
            //モードによる色変更の初期化
            ButtonPlayer.ForeColor = Color.Black;
            ButtonEnemy.ForeColor = Color.Black;
            ButtonBlock.ForeColor = Color.Black;
            ButtonElectric.ForeColor = Color.Black;
            ButtonPlayer.BackColor = Color.Transparent;
            ButtonEnemy.BackColor = Color.Transparent;
            ButtonBlock.BackColor = Color.Transparent;
            ButtonElectric.BackColor = Color.Transparent;

            switch (mode)
            {
                case ButtonMode.PLAYER:
                    ButtonPlayer.ForeColor = Color.Violet;
                    ButtonPlayer.BackColor = Color.GhostWhite;
                    break;
                case ButtonMode.ENEMY:
                    ButtonEnemy.ForeColor = Color.Violet;
                    ButtonEnemy.BackColor = Color.GhostWhite;
                    break;
                case ButtonMode.BLOCK:
                    ButtonBlock.ForeColor = Color.Violet;
                    ButtonBlock.BackColor = Color.GhostWhite;
                    break;
                case ButtonMode.ELECTRIC:
                    ButtonElectric.ForeColor = Color.Violet;
                    ButtonElectric.BackColor = Color.GhostWhite;
                    break;
                case ButtonMode.OTHER1:
                    break;
                case ButtonMode.OTHER2:
                    break;
                default:
                    break;
            }
        }

        void MargeText()
        {
            string temp="";

            //マップ長さ
            temp +="M"+MapDistanse.Value.ToString();
            //プレイヤー
            temp +="P"+ String.Format("{0:D2}", playerPoint.X)+String.Format("{0:D2}",playerPoint.Y);
            //エネミー
            temp += "E" + String.Format("{0:D2}", enemyPoint.X) + String.Format("{0:D2}", enemyPoint.Y);
            //ブロック
            for (int i = 0; i < blockPoints.Length; i++)
            {
                if (i <= BlockLimit.Value)
                    temp += "B" + String.Format("{0:D2}", blockPoints[i].X) + String.Format("{0:D2}", blockPoints[i].Y);                
            }
            //電流
            for (int i = 0; i < electricPoints.Length; i++)
            {
                if(i<=ElectricLimit.Value)
                temp += "D" + String.Format("{0:D2}", electricPoints[i].X) + String.Format("{0:D2}", electricPoints[i].Y);
            }

            OutputText.Text = temp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(OutputText.Text,true);
        }

        //スクロールバーで描画する位相を変える
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void MapDistanse_ValueChanged(object sender, EventArgs e)
        {
            hScrollBar1.Maximum = (int)MapDistanse.Value;


        }
     
        private void timer1_Tick(object sender, EventArgs e)
        {
            gMap.Clear(Color.White);

            gMap.DrawImage(imageList1.Images[0],
                new Point((playerPoint.X - (int)hScrollBar1.Value)*50, playerPoint.Y*50));
            

            gMap.DrawImage(imageList1.Images[1],
                new Point((enemyPoint.X - (int)hScrollBar1.Value)*50, enemyPoint.Y*50));


            for (int i = 0; i < blockPoints.Length; i++)
            {
                if (i <= BlockLimit.Value)
                    gMap.DrawImage(imageList1.Images[2],
                        new Point((blockPoints[i].X - (int)hScrollBar1.Value) * 50, blockPoints[i].Y * 50));
            }

            for (int i = 0; i < electricPoints.Length; i++)
            {
                if (i <= ElectricLimit.Value)
                    gMap.DrawImage(imageList1.Images[3],
                        new Point((electricPoints[i].X - (int)hScrollBar1.Value) * 50, electricPoints[i].Y * 50));
            }

            if (MapDistanse.Value - hScrollBar1.Value > 0)
            {
                gMap.DrawLine(pen, new Point((int)(MapDistanse.Value - hScrollBar1.Value)*50, 0), new Point((int)(MapDistanse.Value - hScrollBar1.Value)*50, 3000));
            }
            Refresh();
        }

        private void ButtonPlayer_Click(object sender, EventArgs e)
        {
            ChangeMode(ButtonMode.PLAYER);
        }

        private void ButtonEnemy_Click(object sender, EventArgs e)
        {
            ChangeMode(ButtonMode.ENEMY);
        }

        private void ButtonBlock_Click(object sender, EventArgs e)
        {
            ChangeMode(ButtonMode.BLOCK);
        }

        private void ButtonElectric_Click(object sender, EventArgs e)
        {
            ChangeMode(ButtonMode.ELECTRIC);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangeMode(ButtonMode.OTHER1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangeMode(ButtonMode.OTHER2);
        }

        private void StageViewer_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = new Point((e.Location.X+hScrollBar1.Value)/50 , e.Location.Y/50);

            switch (bMode)
            {
                case ButtonMode.PLAYER:
                    playerPoint = point;
                    break;
                case ButtonMode.ENEMY:
                    enemyPoint = point;
                    break;
                case ButtonMode.BLOCK:
                    gMap.DrawImage(imageList1.Images[2], point);
                    blockPoints[blockCount] = point;
                    blockCount++;
                    if (blockCount >= BlockLimit.Value)
                        blockCount = 0;
                    break;
                case ButtonMode.ELECTRIC:
                    gMap.DrawImage(imageList1.Images[3], point);
                    electricPoints[electCount] = point;
                    electCount++;
                    if (electCount >= ElectricLimit.Value)
                        electCount = 0;
                        break;
                case ButtonMode.OTHER1:
                    break;
                case ButtonMode.OTHER2:
                    break;
                default:
                    break;
            }
            MargeText();
            Refresh();
        }

        private void StageViewer_MouseMove(object sender, MouseEventArgs e)
        {
            mousePositionStatus.Text =( e.Location.X+hScrollBar1.Value)/50+1 + "," +( e.Location.Y/50+1);
        }

        private void StageViewer_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}

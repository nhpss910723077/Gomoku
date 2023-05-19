using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace Gomoku
{
	public partial class Form1 : Form
	{
		private Game game = new Game();

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			Piece piece = game.PlaceAPiece(e.X, e.Y);
			if (piece != null)
			{
				this.Controls.Add(piece);

				//檢查是否有人獲勝
				if (game.Winner != PieceType.None)
				{
					if (game.Winner == PieceType.Black)
					{
						MessageBox.Show("黑色獲勝");
					}
					else if (game.Winner == PieceType.White)
					{
						MessageBox.Show("白色獲勝");
					}

					restartButton.Visible = true;
					backButton.Visible = false;
				}
			}
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			if (game.CanBePlaced(e.X, e.Y))
			{
				this.Cursor = Cursors.Hand;
			}
			else
			{
				this.Cursor = Cursors.Default;
			}
		}

		private void restartButton_Click(object sender, EventArgs e)
		{
			//取得需清空的棋子
			List<Piece> piecesToRemove = new List<Piece>();
			foreach (Control control in this.Controls)
			{
				if (control is Piece piece)
				{
					piecesToRemove.Add(piece);
				}
			}

			//清空棋盤上的棋子
			foreach (Piece pieceToRemove in piecesToRemove)
			{
				this.Controls.Remove(pieceToRemove);
			}

			//重新開始遊戲
			game.RestartGame();
			restartButton.Visible = false;
			backButton.Visible = true;
		}

		private void backButton_Click(object sender, EventArgs e)
		{
			this.Controls.Remove(game.BackPlaced());
		}
	}
}

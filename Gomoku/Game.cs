using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Gomoku
{
	internal class Game
	{
		private Board board = new Board();

		private PieceType currentPlayer = PieceType.Black;

		private PieceType winner = PieceType.None;
		public PieceType Winner { get { return winner; } }

		private static bool gameOver = false;
		public static bool GameOver { get { return gameOver; } }

		public bool CanBePlaced(int x, int y)
		{
			return board.CanBePlaced(x, y);
		}

		public Piece PlaceAPiece(int x, int y)
		{
			Piece piece = board.PlaceAPiece(x, y, currentPlayer);
			if (piece != null)
			{
				// 檢查勝利者
				CheckWinner();

				// 交換選手
				ChangePlayer();
			}

			return piece;
		}

		private void ChangePlayer()
		{
			if (currentPlayer == PieceType.Black)
			{
				currentPlayer = PieceType.White;
			}
			else if (currentPlayer == PieceType.White)
			{
				currentPlayer = PieceType.Black;
			}
			else
			{
				throw new Exception("棋子顏色錯誤");
			}
		}

		private void CheckWinner()
		{
			int centerX = board.LastPlacedNode.X;
			int centerY = board.LastPlacedNode.Y;

			// 用於紀錄獲勝需幾顆棋子 預設是5個 如果對角線已有其他棋子則會記錄起來
			Stack<int> winCountStack = new Stack<int>();
			// 已檢查幾個方向 前4個方向獲勝棋數必為5 後4個方向則根據對角線已記錄數量減少
			int currentDirCount = 1;

			// 檢查八個不同的方向
			for (int xDir = -1; xDir <= 1; xDir++)
			{
				for (int yDir = -1; yDir <= 1; yDir++)
				{
					// 排除中間的情況
					if (xDir == 0 && yDir == 0)
					{
						continue;
					}

					// 紀錄現在看到幾個相同的棋子
					int count = 1;

					while (count < 5)
					{
						int targetX = centerX + count * xDir;
						int targetY = centerY + count * yDir;

						//檢查顏色是否相同
						if (targetX < 0 || targetX >= Board.BOARD_SIZE ||
							targetY < 0 || targetY >= Board.BOARD_SIZE ||
							board.GetPieceType(targetX, targetY) != currentPlayer)
						{
							break;
						}

						count++;
					}

					// 判斷離獲勝還需幾顆棋子
					int winCount;
					if (currentDirCount <= 4)
					{
						winCount = 5;
					}
					else
					{
						winCount = winCountStack.Pop();
					}

					// 檢查是否看到獲勝數量顆棋子
					if (count >= winCount)
					{
						winner = currentPlayer;
						gameOver = true;
					}

					// 紀錄此方向已看到幾顆棋子
					if (currentDirCount <= 4)
					{
						// +1是因為中間那顆棋子會重複檢查
						winCountStack.Push(5 - count + 1);
					}

					currentDirCount++;
				}
			}
		}

		public void RestartGame()
		{
			// 初始化棋盤
			board.InitBoard();

			//初始化遊戲
			currentPlayer = PieceType.Black;
			winner = PieceType.None;
			gameOver = false;
		}

		public Piece BackPlaced()
		{
			Piece lastPlacedPiece = board.BackPlaced();
			if (lastPlacedPiece != null)
			{
				ChangePlayer();
			}

			return lastPlacedPiece;
		}
	}
}

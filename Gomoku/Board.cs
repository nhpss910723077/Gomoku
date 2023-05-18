using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
	internal class Board
	{
		public static readonly int BOARD_SIZE = 9;

		private static readonly Point NO_MATCH_NODE = new Point(-1, -1);
		private static readonly int OFFSET = 75;
		private static readonly int NODE_RADIUS = 15;
		private static readonly int NODE_DISTANCE = 75;

		private Piece[,] pieces = new Piece[BOARD_SIZE, BOARD_SIZE];

		private Point lastPlacedNode = NO_MATCH_NODE;
		public Point LastPlacedNode { get { return lastPlacedNode; } }

		public PieceType GetPieceType(int nodeX, int nodeY)
		{
			if (pieces[nodeX, nodeY] == null)
			{
				return PieceType.None;
			}
			else
			{
				return pieces[nodeX, nodeY].GetPieceType();
			}
		}

		public bool CanBePlaced(int x, int y)
		{
			//找出最近的節點
			Point node = FindCloseNode(x, y);

			//沒有則回傳false
			if (node == NO_MATCH_NODE)
			{
				return false;
			}

			//如果有則檢查棋子是否已存在
			if (pieces[node.X, node.Y] != null)
			{
				return false;
			}

			return true;
		}

		public Piece PlaceAPiece(int x, int y, PieceType type)
		{
			//找出最近的節點
			Point node = FindCloseNode(x, y);

			//沒有則回傳false
			if (node == NO_MATCH_NODE)
			{
				return null;
			}

			//如果有則檢查棋子是否已存在
			if (pieces[node.X, node.Y] != null)
			{
				return null;
			}

			//根據type產生對應的棋子
			Point nodeCenter = convertToNodeCenter(node);
			if (type == PieceType.Black)
			{
				pieces[node.X, node.Y] = new BlackPiece(nodeCenter.X, nodeCenter.Y);
			}
			else if (type == PieceType.White)
			{
				pieces[node.X, node.Y] = new WhitePiece(nodeCenter.X, nodeCenter.Y);
			}
			else
			{
				throw new Exception("棋子顏色錯誤");
			}

			//儲存最後一次下棋的位置
			lastPlacedNode = node;

			return pieces[node.X, node.Y];
		}

		private Point convertToNodeCenter(Point node)
		{
			int x = node.X * NODE_DISTANCE + OFFSET;
			int y = node.Y * NODE_DISTANCE + OFFSET;

			return new Point(x, y);
		}

		private Point FindCloseNode(int x, int y)
		{
			int nodeX = FindCloseNode(x);
			if (nodeX == -1 || nodeX >= BOARD_SIZE)
			{
				return NO_MATCH_NODE;

			}

			int nodeY = FindCloseNode(y);
			if (nodeY == -1 || nodeY >= BOARD_SIZE)
			{
				return NO_MATCH_NODE;

			}

			return new Point(nodeX, nodeY);
		}

		private int FindCloseNode(int pos)
		{
			if (pos < OFFSET - NODE_RADIUS)
			{
				return -1;
			}

			pos -= OFFSET;

			int quotient = pos / NODE_DISTANCE;
			int remainder = pos % NODE_DISTANCE;

			if (remainder <= NODE_RADIUS)
			{
				return quotient;
			}
			else if (remainder >= NODE_DISTANCE - NODE_RADIUS)
			{
				return quotient + 1;
			}
			else
			{
				return -1;
			}
		}




	}
}

using System;
using System.Collections.Generic;

namespace Advent_code_3
{
    public class FrontPanelGrid
    {
        private int _panelRows;
        private int _panelColumns;
        private int _centralPortRow;
        private int _centralPortColumn;
        private readonly List<WirePath> _wirePaths;
        private GridPoint[,] _grid;
        private List<GridPoint> _pointsWiresCrossed = new List<GridPoint>();

        public FrontPanelGrid(List<WirePath> wirePaths)
        {
            _wirePaths = wirePaths;

            GridSize();
            GridWirePaths();
            FindWireCrossings();
        }

        private void GridSize()
        {
            int rowSum;
            int maxRows = 0;
            int minRows = 0;

            int columnSum;
            int maxColumns = 0;
            int minColumns = 0;

            foreach (var path in _wirePaths)
            {
                rowSum = 0;
                columnSum = 0;

                foreach (var move in path.Path)
                {
                    switch (move[0])
                    {
                        case 'U':
                            MoveUp(ref maxRows, ref minRows, ref rowSum, move);
                            break;
                        case 'D':
                            MoveDown(ref maxRows, ref minRows, ref rowSum, move);
                            break;
                        case 'R':
                            MoveRight(ref maxColumns, ref minColumns, ref columnSum, move);
                            break;
                        case 'L':
                            MoveLeft(ref maxColumns, ref minColumns, ref columnSum, move);
                            break;
                        default:
                            Console.WriteLine("Direction of wire is unknown!");
                            break;
                    }
                }
            }

            CreateGrid(ref maxRows, ref minRows, ref maxColumns, ref minColumns);
        }

        private void MoveUp(ref int maxRows, ref int minRows, ref int rowSum, string move)
        {
            rowSum += GetMoveLenght(move);
            maxRows = Math.Max(maxRows, rowSum);
            minRows = Math.Min(minRows, rowSum);
        }

        private void MoveDown(ref int maxRows, ref int minRows, ref int rowSum, string move)
        {
            rowSum -= GetMoveLenght(move);
            maxRows = Math.Max(maxRows, rowSum);
            minRows = Math.Min(minRows, rowSum);
        }


        private void MoveRight(ref int maxColumns, ref int minColumns, ref int columnSum, string move)
        {
            columnSum += GetMoveLenght(move);
            maxColumns = Math.Max(maxColumns, columnSum);
            minColumns = Math.Min(minColumns, columnSum);
        }


        private void MoveLeft(ref int maxColumns, ref int minColumns, ref int columnSum, string move)
        {
            columnSum -= GetMoveLenght(move);
            maxColumns = Math.Max(maxColumns, columnSum);
            minColumns = Math.Min(minColumns, columnSum);
        }

        private void CreateGrid(ref int maxRows, ref int minRows, ref int maxColumns, ref int minColumns)
        {
            _panelRows = Math.Abs(maxRows - minRows) + 1;
            _panelColumns = Math.Abs(maxColumns - minColumns) + 1;
            _centralPortRow = Math.Abs(minRows);
            _centralPortColumn = Math.Abs(minColumns);
            _grid = new GridPoint[_panelRows, _panelColumns];
        }

        private int GetMoveLenght(string move)
        {
            return Int32.Parse(move.Substring(1));
        }

        private void GridWirePaths()
        {
            foreach (var path in _wirePaths)
            {
                int rowCurrentStop = _centralPortRow;
                int columnCurrentStop = _centralPortColumn;
                int totalPathDistance = 0;

                foreach (var moveString in path.Path)
                {
                    switch (moveString[0])
                    {
                        case 'U':
                            MoveUpFillGrid(moveString, ref rowCurrentStop, ref columnCurrentStop, ref totalPathDistance, path);
                            break;
                        case 'D':
                            MoveDownFillGrid(moveString, ref rowCurrentStop, ref columnCurrentStop, ref totalPathDistance, path);
                            break;
                        case 'R':
                            MoveRightFillGrid(moveString, ref rowCurrentStop, ref columnCurrentStop, ref totalPathDistance, path);
                            break;
                        case 'L':
                            MoveLeftFillGrid(moveString, ref rowCurrentStop, ref columnCurrentStop, ref totalPathDistance, path);
                            break;
                        default:
                            Console.WriteLine("Direction of wire is unknown!");
                            break;
                    }
                }
            }
        }

        private void MoveUpFillGrid(string moveString, ref int rowCurrentStop, ref int columnCurrentStop, ref int totalPathDistance, WirePath path)
        {
            int move = GetMoveLenght(moveString);
            int movePastEnd = rowCurrentStop + move + 1;

            for (int i = rowCurrentStop + 1; i < movePastEnd; i++)
            {
                totalPathDistance++;

                if (_grid[i, columnCurrentStop] == null)
                    _grid[i, columnCurrentStop] = new GridPoint();

                _grid[i, columnCurrentStop].PassInfo.Add(new PathInfo() { PathId = path.WireId, PathDistance = totalPathDistance });
                _grid[i, columnCurrentStop].RowNbr = i;
                _grid[i, columnCurrentStop].ColumnNumber = columnCurrentStop;
            }

            rowCurrentStop += move;
        }

        private void MoveDownFillGrid(string moveString, ref int rowCurrentStop, ref int columnCurrentStop, ref int totalPathDistance, WirePath path)
        {
            int move = GetMoveLenght(moveString);
            int movePastEnd = rowCurrentStop - move - 1;

            for (int i = rowCurrentStop - 1; i > movePastEnd; i--)
            {
                totalPathDistance++;

                if (_grid[i, columnCurrentStop] == null)
                    _grid[i, columnCurrentStop] = new GridPoint();

                _grid[i, columnCurrentStop].PassInfo.Add(new PathInfo() { PathId = path.WireId, PathDistance = totalPathDistance });
                _grid[i, columnCurrentStop].RowNbr = i;
                _grid[i, columnCurrentStop].ColumnNumber = columnCurrentStop;
            }

            rowCurrentStop -= move;
        }

        private void MoveRightFillGrid(string moveString, ref int rowCurrentStop, ref int columnCurrentStop, ref int totalPathDistance, WirePath path)
        {
            int move = GetMoveLenght(moveString);
            int movePastEnd = columnCurrentStop + move + 1;

            for (int j = columnCurrentStop + 1; j < movePastEnd; j++)
            {
                totalPathDistance++;

                if (_grid[rowCurrentStop, j] == null)
                    _grid[rowCurrentStop, j] = new GridPoint();

                _grid[rowCurrentStop, j].PassInfo.Add(new PathInfo() { PathId = path.WireId, PathDistance = totalPathDistance });
                _grid[rowCurrentStop, j].RowNbr = rowCurrentStop;
                _grid[rowCurrentStop, j].ColumnNumber = j;
            }

            columnCurrentStop += move;
        }

        private void MoveLeftFillGrid(string moveString, ref int rowCurrentStop, ref int columnCurrentStop, ref int totalPathDistance, WirePath path)
        {
            int move = GetMoveLenght(moveString);
            int movePastEnd = columnCurrentStop - move - 1;

            for (int j = columnCurrentStop - 1; j > movePastEnd; j--)
            {
                totalPathDistance++;

                if (_grid[rowCurrentStop, j] == null)
                    _grid[rowCurrentStop, j] = new GridPoint();

                _grid[rowCurrentStop, j].PassInfo.Add(new PathInfo() { PathId = path.WireId, PathDistance = totalPathDistance });
                _grid[rowCurrentStop, j].RowNbr = rowCurrentStop;
                _grid[rowCurrentStop, j].ColumnNumber = j;
            }

            columnCurrentStop -= move;
        }

        private void FindWireCrossings()
        {
            foreach (var path in _wirePaths)
            {
                int rowCurrentStop = _centralPortRow;
                int columnCurrentStop = _centralPortColumn;

                foreach (var moveString in path.Path)
                {
                    switch (moveString[0])
                    {
                        case 'U':
                            MoveUpFindCross(moveString, ref rowCurrentStop, ref columnCurrentStop, path);
                            break;
                        case 'D':
                            MoveDownFindCross(moveString, ref rowCurrentStop, ref columnCurrentStop, path);
                            break;
                        case 'R':
                            MoveRightFindCross(moveString, ref rowCurrentStop, ref columnCurrentStop, path);
                            break;
                        case 'L':
                            MoveLeftFindCross(moveString, ref rowCurrentStop, ref columnCurrentStop, path);
                            break;
                        default:
                            Console.WriteLine("Direction of wire is unknown!");
                            break;
                    }
                }
            }
        }

        private void MoveUpFindCross(string moveString, ref int rowCurrentStop, ref int columnCurrentStop, WirePath path)
        {
            int move = GetMoveLenght(moveString);
            int movePastEnd = rowCurrentStop + move + 1;

            for (int i = rowCurrentStop + 1; i < movePastEnd; i++)
            {
                if (_grid[i, columnCurrentStop].PassInfo.Count > 1 && UniqueWireCrossings(i, columnCurrentStop))
                    _pointsWiresCrossed.Add(_grid[i, columnCurrentStop]);
            }

            rowCurrentStop += move;
        }

        private void MoveDownFindCross(string moveString, ref int rowCurrentStop, ref int columnCurrentStop, WirePath path)
        {
            int move = GetMoveLenght(moveString);
            int movePastEnd = rowCurrentStop - move - 1;

            for (int i = rowCurrentStop - 1; i > movePastEnd; i--)
            {
                if (_grid[i, columnCurrentStop].PassInfo.Count > 1 && UniqueWireCrossings(i, columnCurrentStop))
                    _pointsWiresCrossed.Add(_grid[i, columnCurrentStop]);
            }

            rowCurrentStop -= move;
        }

        private void MoveRightFindCross(string moveString, ref int rowCurrentStop, ref int columnCurrentStop, WirePath path)
        {
            int move = GetMoveLenght(moveString);
            int movePastEnd = columnCurrentStop + move + 1;

            for (int j = columnCurrentStop + 1; j < movePastEnd; j++)
            {
                if (_grid[rowCurrentStop, j].PassInfo.Count > 1 && UniqueWireCrossings(rowCurrentStop, j))
                    _pointsWiresCrossed.Add(_grid[rowCurrentStop, j]);
            }

            columnCurrentStop += move;
        }

        private void MoveLeftFindCross(string moveString, ref int rowCurrentStop, ref int columnCurrentStop, WirePath path)
        {
            int move = GetMoveLenght(moveString);
            int movePastEnd = columnCurrentStop - move - 1;

            for (int j = columnCurrentStop - 1; j > movePastEnd; j--)
            {
                if (_grid[rowCurrentStop, j].PassInfo.Count > 1 && UniqueWireCrossings(rowCurrentStop, j))
                    _pointsWiresCrossed.Add(_grid[rowCurrentStop, j]);
            }

            columnCurrentStop -= move;
        }

        private bool UniqueWireCrossings(int row, int column)
        {
            var listOfIDPassed = _grid[row, column].PassInfo;
            var nbrsFound = 0;

            foreach (var pathInfo in listOfIDPassed)
            {
                if (pathInfo.PathId == listOfIDPassed[0].PathId)
                    nbrsFound++;
            }

            return nbrsFound != listOfIDPassed.Count;
        }

        public int ManhattanDistance()
        {
            const int MAX_INT_32 = 2147483647;
            var minDistance = MAX_INT_32;

            foreach (var point in _pointsWiresCrossed)
            {
                int manhattanDistance = Math.Abs(point.RowNbr - _centralPortRow) + Math.Abs(point.ColumnNumber - _centralPortColumn);

                minDistance = Math.Min(minDistance, manhattanDistance);
            }

            return minDistance;
        }

        public int ShortestPath()
        {
            const int MAX_INT_32 = 2147483647;
            var minDistance = MAX_INT_32;

            foreach (var points in _pointsWiresCrossed)
            {
                int id1 = 0;
                int id2 = 0;
                int distance1 = 0;
                int distance2 = 0;

                foreach (var point in points.PassInfo)
                {
                    if (id1 == 0 && point.PathId == 1)
                    {
                        distance1 = point.PathDistance;
                        id1++;
                    }

                    if (id2 == 0 && point.PathId == 2)
                    {
                        distance2 = point.PathDistance;
                        id2++;
                    }

                    if (id1 == 1 && id2 == 1)
                        break;
                }

                minDistance = Math.Min(minDistance, distance1 + distance2);
            }

            return minDistance;
        }
    }
}

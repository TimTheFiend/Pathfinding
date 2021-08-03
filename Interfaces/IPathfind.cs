using Pathfinding.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding.Interfaces
{
    public interface IPathfind
    {
        public void Main(int columns, int rows, Vector2 startPosition, Vector2 endPosition, params Vector2[] walls);
    }
}

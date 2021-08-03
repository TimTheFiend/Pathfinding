using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding.Core
{
    public struct Vector2 : IEquatable<Vector2> {
        public int x;
        public int y;

        #region Constructor
        public Vector2(int x, int y) {
            this.x = x;
            this.y = y;
        }
        #endregion

        #region Equals
        public bool Equals(Vector2 other) {
            if (other == null) {
                return false;
            }

            return this.x == other.x && this.y == other.y;
        }

        public override bool Equals(Object other) {
            if (other == null) {
                return false;
            }
            Vector2 obj = (Vector2)other;
            if (obj == null) {
                return false;
            }
            return Equals(obj);
        }
        #endregion

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public override string ToString() {
            return $"({x}, {y})";
        }

        #region Bool (==, !=)
        public static bool operator ==(Vector2 v1, Vector2 v2) {
            if (((object)v1 == null) || ((object)v2 == null)) {
                return Object.Equals(v1, v2);
            }
            return v1.Equals(v2);
        }

        public static bool operator !=(Vector2 v1, Vector2 v2) {
            if (((object)v1 == null) || ((object)v2 == null)) {
                return !Object.Equals(v1, v2);
            }
            return !(v1.Equals(v2));
        }
        #endregion

        #region Operator (±) 
        public static Vector2 operator +(Vector2 v1, Vector2 v2) {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2) {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }
        #endregion
    }
}

using System;

namespace Pathfinding.Core
{
    public struct Vector2 : IEquatable<Vector2>
    {
        public int x;
        public int y;

        #region Constructor

        public Vector2(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public Vector2(Vector2 vector2) {
            this.x = vector2.x;
            this.y = vector2.y;
        }

        #endregion Constructor

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

        #endregion Equals

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

        #endregion Bool (==, !=)

        #region Operator (±)

        public static Vector2 operator +(Vector2 v1, Vector2 v2) {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2) {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }

        #endregion Operator (±)

        #region Static gets

        /// <summary>Gets the zero position.</summary>
        /// <value>(0, 0)</value>
        public static Vector2 zero => new Vector2(0, 0);

        /// <summary>Gets the up position.</summary>
        /// <value>(0, 1)</value>
        public static Vector2 up => new Vector2(0, 1);

        /// <summary>Gets the down position.</summary>
        /// <value>(0, -1)</value>
        public static Vector2 down => new Vector2(0, -1);

        /// <summary>Gets the left position.</summary>
        /// <value>(-1, 0)</value>
        public static Vector2 left => new Vector2(-1, 0);

        /// <summary>Gets the right position.</summary>
        /// <value>(1, 0)</value>
        public static Vector2 right => new Vector2(1, 0);

        #endregion Static gets
    }
}
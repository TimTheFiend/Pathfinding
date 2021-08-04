using System;
using System.Collections.Generic;

namespace Pathfinding.Core
{
    /// <summary>
    /// <see href="https://www.redblobgames.com/pathfinding/a-star/cs/AStar.cs"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PriorityQueue<T>
    {
        private List<Tuple<T, double>> elements = new List<Tuple<T, double>>();

        public int Count {
            get {
                return elements.Count;
            }
        }

        public void Enqueue(T item, double priority) {
            elements.Add(Tuple.Create(item, priority));
        }

        public T Dequeue() {
            int priorityIndex = 0;

            for (int i = 0; i < elements.Count; i++) {
                if (elements[i].Item2 < elements[priorityIndex].Item2) {
                    priorityIndex = i;
                }
            }

            T priorityItem = elements[priorityIndex].Item1;
            elements.RemoveAt(priorityIndex);
            return priorityItem;
        }
    }
}

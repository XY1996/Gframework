using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gframework
{
    /// <summary>
    /// Logic Chain.
    /// Logic Scripts Excuted on by one sync
    /// </summary>
    public class LogicChain:IList<LogicBaseScripts>
    {
        /// <summary>
        /// LogicBaseScripts
        /// </summary>
        private List<LogicBaseScripts> innerList = new List<LogicBaseScripts>();

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<LogicBaseScripts> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        /// <summary>Returns an enumerator that iterates through a collection.</summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1" />.</summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.</exception>
        public void Add(LogicBaseScripts item)
        {
            if (Count > 0)
            {
                innerList.Last().OnExit += item.Do;
            }
            innerList.Add(item);

        }

        /// <summary>Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1" />.</summary>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only. </exception>
        public void Clear()
        {
            innerList.Clear();
        }

        /// <summary>Determines whether the <see cref="T:System.Collections.Generic.ICollection`1" /> contains a specific value.</summary>
        /// <returns>true if <paramref name="item" /> is found in the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false.</returns>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        public bool Contains(LogicBaseScripts item)
        {
            return innerList.Contains(item);
        }

        /// <summary>Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1" /> to an <see cref="T:System.Array" />, starting at a particular <see cref="T:System.Array" /> index.</summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array" /> at which copying begins.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="array" /> is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="arrayIndex" /> is less than 0.</exception>
        /// <exception cref="T:System.ArgumentException">The number of elements in the source <see cref="T:System.Collections.Generic.ICollection`1" /> is greater than the available space from <paramref name="arrayIndex" /> to the end of the destination <paramref name="array" />.</exception>
        public void CopyTo(LogicBaseScripts[] array, int arrayIndex)
        {
             innerList.CopyTo(array, arrayIndex);
        }

        /// <summary>Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1" />.</summary>
        /// <returns>true if <paramref name="item" /> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false. This method also returns false if <paramref name="item" /> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1" />.</returns>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.</exception>
        public bool Remove(LogicBaseScripts item)
        {
            int index = IndexOf(item);
            if (index == -1)
            {
                return false;
            }
            if (index - 1 >= 0)
            {
                innerList[index - 1].OnExit -= item.Do;
            }
            if (index + 1 < Count)
            {
                innerList[index + 1].OnExit -= item.Do;
            }
            return innerList.Remove(item);
           
        }

        /// <summary>Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1" />.</summary>
        /// <returns>The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1" />.</returns>
        public int Count => innerList.Count;

        /// <summary>Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.</summary>
        /// <returns>true if the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only; otherwise, false.</returns>
        public bool IsReadOnly { get { return false; } }

        /// <summary>
        /// Index if Item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(LogicBaseScripts item)
        {
            return innerList.IndexOf(item);
        }

        public void Insert(int index, LogicBaseScripts item)
        {
            if(index<0||index>Count)
                throw new ArgumentNullException();
            if (index > 0)
            {
                innerList[index - 1].OnExit -= innerList[index].Do;
                innerList[index - 1].OnExit += item.Do;
            }
            item.OnExit += innerList[index].Do;
            innerList.Insert(index,item);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentNullException();
            var item = innerList[index];
            if (index - 1 >= 0)
            {
                innerList[index - 1].OnExit -= item.Do;
            }
            if (index + 1 < Count)
            {
                innerList[index + 1].OnExit -= item.Do;
            }
            innerList.Remove(item);
        }

        public LogicBaseScripts this[int index]
        {
            get { return innerList[index]; }
            set
            {
                RemoveAt(index);
                Insert(index,value);
            }
        }
    }
}

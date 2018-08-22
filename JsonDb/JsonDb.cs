using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace JsonDb
{ 
    public class JsonDb<T> : IList<T>
    {
        private List<T> _rows;

        private string _path;

        public int Count => ((IList<T>)_rows).Count;

        public bool IsReadOnly => ((IList<T>)_rows).IsReadOnly;

        public T this[int index] { get => ((IList<T>)_rows)[index]; set => ((IList<T>)_rows)[index] = value; }

        public JsonDb(string path)
        {
            _path = path;

            if (File.Exists(_path))
            {
                using (var reader = new StreamReader(_path))
                {
                    _rows = JsonConvert.DeserializeObject<List<T>>(reader.ReadToEnd());
                }
            }
        }

        public void Save()
        {
            using (var writer = new StreamWriter(_path))
            {
                writer.Write(JsonConvert.SerializeObject(_rows));
            }
        }

        public int IndexOf(T item)
        {
            return ((IList<T>)_rows).IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            ((IList<T>)_rows).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<T>)_rows).RemoveAt(index);
        }

        public void Add(T item)
        {
            ((IList<T>)_rows).Add(item);
        }

        public void Clear()
        {
            _rows = new List<T>();
        }

        public bool Contains(T item)
        {
            return ((IList<T>)_rows).Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ((IList<T>)_rows).CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return ((IList<T>)_rows).Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IList<T>)_rows).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<T>)_rows).GetEnumerator();
        }
    }
}
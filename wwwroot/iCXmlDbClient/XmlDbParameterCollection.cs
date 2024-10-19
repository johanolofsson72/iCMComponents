//**************************************************************//
// Paul Wilson -- www.WilsonDotNet.com -- Paul@WilsonDotNet.com //
// Feel free to use and modify -- just leave these credit lines //
// I also always appreciate any other public credit you provide //
//**************************************************************//
using System;
using System.Collections;
using System.Data;

namespace iConsulting.iCXmlDbClient
{
	public class XmlDbParameterCollection : IDataParameterCollection
	{
		private ArrayList list = new ArrayList();

		internal XmlDbParameterCollection() {}

		#region IDataParameterCollection Members

		public object this[string parameterName] {
			get { return this.list[this.IndexOf(parameterName)]; }
			set { this.list[this.IndexOf(parameterName)] = value; }
		}

		public void RemoveAt(string parameterName) {
			this.list.RemoveAt(this.IndexOf(parameterName));
		}

		public bool Contains(string parameterName) {
			return this.Contains(this.IndexOf(parameterName));
		}

		public int IndexOf(string parameterName) {
			for (int index = 0; index < this.list.Count; index++) {
				XmlDbParameter parameter = (this.list[index] as XmlDbParameter);
				if (parameter.ParameterName == parameterName) return index;
			}
			return -1;
		}

		#endregion

		#region IList Members

		public bool IsReadOnly {
			get { return this.list.IsReadOnly; }
		}

		public object this[int index] {
			get { return this.list[index]; }
			set { this.list[index] = value; }
		}

		public void RemoveAt(int index) {
			this.list.RemoveAt(index);
		}

		public void Insert(int index, object value) {
			this.list.Insert(index, value);
		}

		public void Remove(object value) {
			this.list.Remove(value);
		}

		public bool Contains(object value) {
			return this.list.Contains(value);
		}

		public void Clear() {
			this.list.Clear();
		}

		public int IndexOf(object value) {
			return this.list.IndexOf(value);
		}

		public int Add(object value) {
			return this.list.Add(value);
		}

		public bool IsFixedSize {
			get { return this.list.IsFixedSize; }
		}

		#endregion

		#region ICollection Members

		public bool IsSynchronized {
			get { return this.list.IsSynchronized; }
		}

		public int Count {
			get { return this.list.Count; }
		}

		public void CopyTo(Array array, int index) {
			this.list.CopyTo(array, index);
		}

		public object SyncRoot {
			get { return this.list.SyncRoot; }
		}

		#endregion

		#region IEnumerable Members

		public IEnumerator GetEnumerator() {
			return this.list.GetEnumerator();
		}

		#endregion
	}
}

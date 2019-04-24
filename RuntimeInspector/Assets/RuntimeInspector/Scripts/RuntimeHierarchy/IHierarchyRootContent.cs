using System.Collections.Generic;
using UnityEngine;

namespace RuntimeInspector
{
	public interface IHierarchyRootContent
	{
		string Name { get; }
		bool IsValid { get; }
		List<GameObject> Children { get; set; }

		void Refresh();
	}
}
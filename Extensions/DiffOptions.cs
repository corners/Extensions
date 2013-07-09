using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensions
{
	/// <summary>
	/// Options for IEnumerable.Diff
	/// </summary>
	[Flags]
	public enum DiffOptions
	{
		/// <summary>
		/// Removed
		/// </summary>
		LeftOnly = 0x1,

		/// <summary>
		/// Added
		/// </summary>
		RightOnly = 0x2,

		/// <summary>
		/// Value changed
		/// </summary>
		Modified = 0x4,

		/// <summary>
		/// Not changed
		/// </summary>
		Matching = 0x8,

		/// <summary>
		/// Added, removed or modified
		/// </summary>
		Different = LeftOnly | RightOnly | Modified,

		/// <summary>
		/// Returns all
		/// </summary>
		All = LeftOnly | RightOnly | Modified | Matching,
	}
}

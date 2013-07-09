using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Extensions
{
	public static class PathEx
	{
		/// <summary>
		/// Change a path by modifying some of its components.
		/// </summary>
		/// <param name="path"></param>
		/// <param name="newDirectory">Optional method to change the directory name. Parameter is the original directory name.</param>
		/// <param name="newName">Optional method to change the file name. Parameter is the original file name.</param>
		/// <param name="newExtension">Optional method to change file extension. New value should be Empty or start with a fullstop, if it does not one will be added/</param>
		/// <returns></returns>
		public static string Change(string path, 
			Func<string, string> newDirectory = null,
			Func<string, string> newName = null,
			Func<string, string> newExtension = null)
		{
			var dir = Path.GetDirectoryName(path);
			var name = Path.GetFileNameWithoutExtension(path);
			var ext = Path.GetExtension(path);

			if (newDirectory != null)
				dir = newDirectory(dir);

			if (newName != null)
				name = newName(name);

			if (newExtension != null)
			{
				ext = newExtension(ext);
				if (ext.Length > 0 && !ext.StartsWith("."))
					ext += ".";
			}

			return Path.Combine(dir, name + ext);
		}
	}
}

using System;
using System.IO;
using System.IO.MemoryMappedFiles;

static class Program
{
	public static void Main(string[] args)
	{
		FileInfo file = new FileInfo(args[0]);

		using(var mapping = MemoryMappedFile.CreateFromFile(file.FullName))
		{
			using(var view = mapping.CreateViewAccessor(0, file.Length))
			{
				for(long i = 0, j = view.Capacity - 1; i < j; ++i, j--)
				{
					byte ib = view.ReadByte(i);
					byte jb = view.ReadByte(j);
					view.Write(i, jb);
					view.Write(j, ib);
				}
			}
		}
	}
}

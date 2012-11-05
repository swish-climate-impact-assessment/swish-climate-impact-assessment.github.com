using System.IO;
using System.Windows.Forms;

namespace Delete
{
	static class Program
	{
		static int Main(string[] arguments)
		{
			try
			{
				string fileName = string.Join(" ", arguments);
				File.Delete(fileName);
			} catch
			{
			}
			return 0;
		}
	}
}

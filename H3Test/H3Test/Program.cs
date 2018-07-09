using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3Test
{
	class Program
	{
		static void Main(string[] args)
		{
			UserMenu.Instance.ListPage.CreateExampleLists();
			UserMenu.Instance.HomeScreen();
		}
	}
}

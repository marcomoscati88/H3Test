using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3Test
{
	class ErrorMessage
	{
		public static ErrorMessage Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ErrorMessage();
				}
				return _instance;
			}
		}

		private static ErrorMessage _instance;
		private PageType _landingPage;

		public void InputError(PageType _page)
		{
			_landingPage = _page;
			Console.Clear();
			Console.WriteLine("L'opzione da te selezionata non è corretta" + "\n" + "E' pregato di riprovare");
			Console.ReadLine();
			if (_landingPage == PageType.MainMenu)
			{
				UserMenu.Instance.HomeScreen();
			}
			if (_landingPage == PageType.ListComposition)
			{
				UserMenu.Instance.ListPage.ListCreationLanding();
			}
			if (_landingPage == PageType.ProductSelection)
			{
				UserMenu.Instance.ListPage.ProductSelection.AddItem();
			}
		}
	}
}

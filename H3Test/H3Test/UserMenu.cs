using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3Test
{
	class UserMenu
	{
		public static UserMenu Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new UserMenu();
				}
				return _instance;
			}
		}

		public ListComposition ListPage { get { return _listPage; } private set { _listPage = value; } }

		private static UserMenu _instance;
		private int _input = 0;
		private ListComposition _listPage = new ListComposition();

		public void HomeScreen()
		{
			Console.Clear();
			Console.WriteLine("Benvenuto Utente" + "\n" + "Quale azione desidera effettuare?");
			Console.WriteLine("1) Creare una lista di prodotti" + "\n" + "2) Stampare una lista di prodotti");
			string _userChoice = Console.ReadLine();
			Int32.TryParse(_userChoice, out _input);
			if (_input == 1)
			{
				_listPage.ListCreationLanding();
			} else if( _input == 2) {
				Console.WriteLine("BUBUBUBABABABA");
				Console.ReadLine();
			} else {
				ErrorMessage.Instance.InputError(PageType.MainMenu);
			}
		}
	}
}

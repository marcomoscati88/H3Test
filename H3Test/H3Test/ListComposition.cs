using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3Test
{
	class ListComposition
	{
		public ProductsSelection ProductSelection { get { return _productSelection; } private set { _productSelection = value; } }	

		private List<List<Product>> _productsLists = new List<List<Product>>();
		private ProductsSelection _productSelection = new ProductsSelection();

		public void ListCreationLanding()
		{
			Console.Clear();
			Console.WriteLine("Scegli cosa fare:" + "\n" + "1) Creare una nuova lista" + "\n" + "2) Controllare una lista");
			int _input = 0;
			string _userChoice = Console.ReadLine();
			Int32.TryParse(_userChoice, out _input);
			if (_input == 1)
			{
				_productSelection.CreateList();
			} else if (_input == 2) {

			} else {
				ErrorMessage.Instance.InputError(PageType.ListComposition);
			}
		}
	}
}

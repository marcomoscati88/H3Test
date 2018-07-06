using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3Test
{
	class ProductsSelection
	{
		private List<Product> _productList;
		private Product _product;

		public void CreateList()
		{
			_productList = new List<Product>();
			AddItem();
		}

		public void AddItem() {
			Console.Clear();
			Console.WriteLine("Come si chiama il prodotto che vuoi aggiungere?");
			string _name = Console.ReadLine();
			Console.WriteLine("Da dove viene il prodotto?\n" + "1)Importato\n" + "2)Nazionale");
			int _importationInput = 0;
			string _importationChoice = Console.ReadLine();
			Int32.TryParse(_importationChoice, out _importationInput);
			ProductOrigin _origin;
			if (_importationInput == 0)
			{
				_origin = ProductOrigin.Imported;
			} else if (_importationInput == 1) {
				_origin = ProductOrigin.Home;
			} else {
				ErrorMessage.Instance.InputError(PageType.ProductSelection);
			}
			Console.WriteLine("Quanto costa il prodotto?");
			float _price = 0.0f;
			string _priceChoice = Console.ReadLine();
		}
	}
}

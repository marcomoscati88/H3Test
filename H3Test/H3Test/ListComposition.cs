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

		private PrintList _printList = new PrintList();
		private List<float> _priceList = new List<float>();
		private List<float> _examplePriceList = new List<float>();
		private List<float> _taxesList = new List<float>();
		private List<float> _exampleTaxesList = new List<float>();
		private List<List<Product>> _productsLists = new List<List<Product>>();
		private List<List<Product>> _exampleLists = new List<List<Product>>();
		private ProductsSelection _productSelection = new ProductsSelection();
		private int _listNumber = 0;

		public void ListCreationLanding()
		{
			Console.Clear();
			Console.WriteLine("Scegli cosa fare:" + "\n" + "1) Creare una nuova lista\n" + "2) Controllare una lista creata dall'utente\n" + "3) Controllare le liste di esempio");
			int _input = 0;
			string _userChoice = Console.ReadLine();
			Int32.TryParse(_userChoice, out _input);
			if (_input == 1)
			{
				_productSelection.CreateList(this);
			}
			else if (_input == 2)
			{
				if (_productsLists.Count > 0)
				{
					Console.Clear();
					for (int i = 0; i < _productsLists.Count; i++)
					{
						_listNumber = i + 1;
						_printList.Print(_productsLists[i], _listNumber, _priceList[i], _taxesList[i]);
					}
					Console.ReadLine();
				}
				else
				{
					Console.Clear();
					Console.WriteLine("Non hai ancora creato nessuna lista!");
					Console.ReadLine();
					ListCreationLanding();
				}
			} else if (_input == 3) {
				Console.Clear();
				for (int i = 0; i < _exampleLists.Count; i++)
				{
					_listNumber = i + 1;
					_printList.Print(_exampleLists[i], _listNumber, _examplePriceList[i], _exampleTaxesList[i]);
				}
				Console.ReadLine();
			} else {
				ErrorMessage.Instance.InputError(PageType.ListComposition);
			}
		}

		public void AddList(List<Product> _list)
		{
			_productsLists.Add(_list);
			float _listTotalPrice = 0.00f;
			float _totalTaxes = 0.00f;
			for (int i = 0; i < _list.Count; i++)
			{
				for (int j = 0; j < _list[i].Quantity; j++)
				{
					_listTotalPrice += _list[i].ProductPrice;
					_totalTaxes += _list[i].ProductTaxes;
				}
			}
			_priceList.Add(_listTotalPrice);
			_taxesList.Add(_totalTaxes);
		}
		#region ExampleLists
		public void CreateExampleLists() {
			List<Product> _firstList = new List<Product>();
			_firstList.Add(new Product(2, "book", 12.49f, 0.0f, ProductType.Books, ProductOrigin.Home));
			_firstList.Add(new Product(1, "music CD", 16.49f, 1.50f, ProductType.General, ProductOrigin.Home));
			_firstList.Add(new Product(1, "chocolate bar", 0.85f, 0.0f, ProductType.Food, ProductOrigin.Home));
			List<Product> _secondList = new List<Product>();
			_secondList.Add(new Product(1, "box of Chocolates", 10.50f, 0.50f, ProductType.Food, ProductOrigin.Imported));
			_secondList.Add(new Product(1, "bottle of perfume", 54.65f, 7.15f, ProductType.General, ProductOrigin.Imported));
			List<Product> _thirdList = new List<Product>();
			_thirdList.Add(new Product(1, "bottle of perfume", 32.19f, 4.20f, ProductType.General, ProductOrigin.Imported));
			_thirdList.Add(new Product(1, "bottle of perfume", 20.89f, 1.90f, ProductType.General, ProductOrigin.Home));
			_thirdList.Add(new Product(1, "packet of headache pills", 9.75f, 0.0f, ProductType.Medical, ProductOrigin.Home));
			_thirdList.Add(new Product(3, "box of chocolates", 11.81f, 0.56f, ProductType.Food, ProductOrigin.Imported));
			_exampleLists.Add(_firstList);
			_exampleLists.Add(_secondList);
			_exampleLists.Add(_thirdList);
			for (int i = 0; i < _exampleLists.Count; i++)
			{
				CalculateExampleListCost(_exampleLists[i]);
			}
		}

		public void CalculateExampleListCost(List<Product> _list) {
			float _exampleListTotalPrice = 0.00f;
			float _exampleListTotalTaxes = 0.00f;
			for (int i = 0; i < _list.Count; i++)
			{
				for (int j = 0; j < _list[i].Quantity; j++)
				{
					_exampleListTotalPrice += _list[i].ProductPrice;
					_exampleListTotalTaxes += _list[i].ProductTaxes;
				}
			}
			_examplePriceList.Add(_exampleListTotalPrice);
			_exampleTaxesList.Add(_exampleListTotalTaxes);
		}
		#endregion
	}
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3Test
{
	class ProductsSelection
	{
		private ListComposition _sourceList;
		private List<Product> _productList;
		private CultureInfo _marketCurrency = new CultureInfo("en-US");
		private float _price = 0.00f;
		private int _taxesPercentage;

		public void CreateList(ListComposition _source)
		{
			_sourceList = _source;
			_productList = new List<Product>();
			AddItem();
		}

		public void AddItem() {
			Console.Clear();
			_taxesPercentage = 0;
			Console.WriteLine("Come si chiama il prodotto che vuoi aggiungere?");
			string _name = Console.ReadLine();
			Console.WriteLine("Quanto costa il prodotto?");
			string _priceChoice = Console.ReadLine();
			float.TryParse(_priceChoice, NumberStyles.Any, _marketCurrency, out _price);
			if (_price > 0 && _price < 1000)
			{
				_price = Truncate(_price, 2);
				Console.WriteLine("Il prezzo dell'oggetto è: " + _price);
			} else {
				ErrorMessage.Instance.InputError(PageType.ProductSelection);
			}
			Console.WriteLine("Da dove viene il prodotto?\n" + "1)Importato\n" + "2)Nazionale");
			int _importationInput = 0;
			string _importationChoice = Console.ReadLine();
			Int32.TryParse(_importationChoice, out _importationInput);
			ProductOrigin _origin = ProductOrigin.Imported;
			if (_importationInput == 1)
			{
				_origin = ProductOrigin.Imported;
				_taxesPercentage += 5;
			} else if (_importationInput == 2) {
				_origin = ProductOrigin.Home;
			} else {
				ErrorMessage.Instance.InputError(PageType.ProductSelection);
			}
			Console.WriteLine("Qual è la tipologia del prodotto?\n" + "1)Generico\n" + "2)Editoria\n" + "3)Cibo & Bevande\n" + "4)Medicinale\n");
			int _productTypeInput = 0;
			string _productTypeChoice = Console.ReadLine();
			Int32.TryParse(_productTypeChoice, out _productTypeInput);
			ProductType _type = ProductType.General;
			if (_productTypeInput == 1)
			{
				_type = ProductType.General;
				_taxesPercentage += 10;
			} else if (_productTypeInput == 2) {
				_type = ProductType.Books;
			} else if (_productTypeInput == 3) {
				_type = ProductType.Food;
			} else if (_productTypeInput == 4) {
				_type = ProductType.Medical;
			} else {
				ErrorMessage.Instance.InputError(PageType.ProductSelection);
			}
			Console.WriteLine("Quanti " + _name + " vuoi acquistare? (da 1 a 99)");
			int _quantityNumberInput = 0;
			string _quantityNumberChoice = Console.ReadLine();
			Int32.TryParse(_quantityNumberChoice, out _quantityNumberInput);
			if (_quantityNumberInput < 1 || _quantityNumberInput > 99)
			{
				ErrorMessage.Instance.InputError(PageType.ProductSelection);
			}
			float _itemTaxes = (_price / 100) * _taxesPercentage;
			_itemTaxes = Truncate(_itemTaxes, 2);
			_productList.Add(new Product(_quantityNumberInput, _name, _price, _itemTaxes, _type, _origin));
			_ContinueList();
		}

		public float Truncate(float _value, int _truncateValue) {
			double _mult = Math.Pow(10.0, _truncateValue);
			double _result = Math.Truncate(_mult * _value) / _mult;
			_value = (float) _result;
			return _value;
		}

		private void _ContinueList() {
			Console.WriteLine("Vuoi aggiungere altri oggetti? (Selezionando 'No' o rispondendo in maniera non valida la lista sarà chiusa e dovrai crearne una nuova)");
			Console.WriteLine("1)Si\n" + "2)No\n");
			int _userInput = 0;
			string _userChoice = Console.ReadLine();
			Int32.TryParse(_userChoice, out _userInput);
			if (_userInput == 1)
			{
				AddItem();
			} else if (_userInput == 2) {
				_sourceList.AddList(_productList);
				UserMenu.Instance.HomeScreen();
			} else {
				_sourceList.AddList(_productList);
				ErrorMessage.Instance.InputError(PageType.MainMenu);
			}
		}
	}
}

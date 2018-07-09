using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3Test
{
	class PrintList
	{
		private List<Product> _productList;
		private Product _itemToPrint;
		public void Print(List<Product> _listToPrint, int _index, float _totalPrice, float _taxes)
		{
			_productList = _listToPrint;
			Console.WriteLine("Lista " + _index + ":");
			for (int i = 0; i < _productList.Count; i++)
			{
				_itemToPrint = _productList[i];
				if (_itemToPrint.ProductOrigin == ProductOrigin.Home)
				{
				 Console.WriteLine(_itemToPrint.Quantity + " " + _itemToPrint.ProductName + ": " + _itemToPrint.ProductPrice);
				} else {
					Console.WriteLine(_itemToPrint.Quantity + " " + _itemToPrint.ProductName + " (Importato): " + _itemToPrint.ProductPrice);
				}
			}
			UserMenu.Instance.ListPage.ProductSelection.Truncate(_totalPrice, 2);
			UserMenu.Instance.ListPage.ProductSelection.Truncate(_taxes, 2);
			Console.WriteLine("Tasse: " + _taxes.ToString());
			Console.WriteLine("Totale: " + _totalPrice.ToString());
			Console.ReadLine();
		}
	}
}

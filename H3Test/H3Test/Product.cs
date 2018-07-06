using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3Test
{
	class Product
	{
		private ProductType _productType;
		private ProductOrigin _productOrigin;
		private float _productPrice;
		private int _quantity;
		private string _productName;

		public Product(int _number, string _name, float _price, ProductType _type, ProductOrigin _origin)
		{
			this._quantity = _number;
			this._productName = _name;
			this._productPrice = _price;
			this._productType = _type;
			this._productOrigin = _origin;
		}
	}
}

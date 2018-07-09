using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3Test
{
	class Product
	{
		public ProductType ProductType { get { return _productType; } private set { _productType = value; } }
		public ProductOrigin ProductOrigin { get { return _productOrigin; } private set { _productOrigin = value; } }
		public float ProductPrice { get { return _productPrice; } private set { _productPrice = value; } }
		public float ProductTaxes { get { return _productTaxes; } private set { _productTaxes = value; } }
		public int Quantity { get { return _quantity; } private set { _quantity = value; } }
		public string ProductName { get { return _productName; } private set { _productName = value; } }


		private ProductType _productType;
		private ProductOrigin _productOrigin;
		private float _productPrice;
		private float _productTaxes;
		private int _quantity;
		private string _productName;

		public Product(int _number, string _name, float _price, float _taxes, ProductType _type, ProductOrigin _origin)
		{
			this._quantity = _number;
			this._productName = _name;
			this._productPrice = _price;
			this._productType = _type;
			this._productOrigin = _origin;
			this._productTaxes = _taxes;
		}
	}
}

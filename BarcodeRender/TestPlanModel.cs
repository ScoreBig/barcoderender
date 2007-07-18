using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Serialization;

using Zen.Barcode;

namespace BarcodeRender
{
	/// <summary>
	/// <c>SymbologyTestPlan</c> encapsulates a barcode test-plan
	/// </summary>
	[Serializable]
	[XmlRoot ("TestPlan", Namespace = "http://schemas.zendesign.com/07/07/BarcodeTestPlan")]
	public class SymbologyTestPlan
	{
		#region Private Fields
		private string _name;
		private List<SymbologyTestGroup> _groupTests; 
		#endregion

		#region Public Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="SymbologyTestPlan"/> class.
		/// </summary>
		public SymbologyTestPlan ()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SymbologyTestPlan"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		public SymbologyTestPlan (string name)
		{
			_name = name;
		} 
		#endregion

		#region Public Properties
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		[XmlAttribute (AttributeName = "name")]
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		/// <summary>
		/// Gets the group tests.
		/// </summary>
		/// <value>The group tests.</value>
		[XmlArray ("GroupTests")]
		[XmlArrayItem (Type = typeof (SymbologyTestGroup))]
		public List<SymbologyTestGroup> GroupTests
		{
			get
			{
				if (_groupTests == null)
				{
					_groupTests = new List<SymbologyTestGroup> ();
				}
				return _groupTests;
			}
		} 
		#endregion

		#region Public Methods
		/// <summary>
		/// Adds the test case.
		/// </summary>
		/// <param name="symbology">The symbology.</param>
		/// <param name="text">The text.</param>
		public void AddTestCase (BarcodeSymbology symbology, string text)
		{
			// We cannot add unknown symbology to test-case list
			if (symbology == BarcodeSymbology.Unknown)
			{
				throw new ArgumentException ("symbology");
			}

			// Insert into existing group if we have one
			foreach (SymbologyTestGroup group in GroupTests)
			{
				if (group.Symbology == symbology)
				{
					group.AddTestCase (text);
					return;
				}
			}

			// Create new group as required.
			SymbologyTestGroup newGroup = new SymbologyTestGroup (symbology);
			newGroup.AddTestCase (text);
			GroupTests.Add (newGroup);
		}

		/// <summary>
		/// Gets the test cases.
		/// </summary>
		/// <param name="maxBarHeight">Height of the max bar.</param>
		/// <returns></returns>
		public IEnumerable<SymbologyTestCase> GetTestCases (int maxBarHeight)
		{
			foreach (SymbologyTestGroup group in GroupTests)
			{
				foreach (SymbologyTestCase testCase in group.GetTestCases (maxBarHeight))
				{
					yield return testCase;
				}
			}
		} 
		#endregion
	}

	/// <summary>
	/// <c>SymbologyTestCase</c> encapsulates an individual test case.
	/// </summary>
	public class SymbologyTestCase : IDisposable
	{
		private BarcodeSymbology _symbology;
		private int _maxBarHeight;
		private string _barcodeText;
		private Image _barcodeImage;

		/// <summary>
		/// Initializes a new instance of the <see cref="SymbologyTestCase"/> class.
		/// </summary>
		/// <param name="symbology">The symbology.</param>
		/// <param name="barcodeText">The barcode text.</param>
		/// <param name="maxBarHeight">Height of the max bar.</param>
		public SymbologyTestCase (BarcodeSymbology symbology, string barcodeText, int maxBarHeight)
		{
			_symbology = symbology;
			_maxBarHeight = maxBarHeight;
			_barcodeText = barcodeText;
		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="SymbologyTestCase"/> is reclaimed by garbage collection.
		/// </summary>
		~SymbologyTestCase ()
		{
			Dispose (false);
		}

		/// <summary>
		/// Gets the barcode text.
		/// </summary>
		/// <value>The barcode text.</value>
		public string BarcodeText
		{
			get
			{
				return _barcodeText;
			}
		}

		/// <summary>
		/// Gets the barcode image.
		/// </summary>
		/// <value>The barcode image.</value>
		public Image BarcodeImage
		{
			get
			{
				if (_barcodeImage == null)
				{
					_barcodeImage = 
						BarcodeDrawFactory.GetSymbology (_symbology).Draw (
						_barcodeText, _maxBarHeight);
				}
				return _barcodeImage;
			}
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, 
		/// releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose ()
		{
			Dispose (true);
			GC.SuppressFinalize (this);
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and 
		/// unmanaged resources; <c>false</c> to release only unmanaged 
		/// resources.</param>
		private void Dispose (bool disposing)
		{
			if (disposing)
			{
				if (_barcodeImage != null)
				{
					_barcodeImage.Dispose ();
					_barcodeImage = null;
				}
			}
		}
	}

	/// <summary>
	/// <c>SymbologyTestGroup</c> encapsulates tests for a particular 
	/// symbology.
	/// </summary>
	[Serializable]
	public class SymbologyTestGroup
	{
		#region Private Fields
		private BarcodeSymbology _symbology;
		private List<SymbologyTestItem> _testItems; 
		#endregion

		#region Public Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="SymbologyTestGroup"/> class.
		/// </summary>
		public SymbologyTestGroup ()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SymbologyTestGroup"/> class.
		/// </summary>
		/// <param name="symbology">The symbology.</param>
		public SymbologyTestGroup (BarcodeSymbology symbology)
		{
			_symbology = symbology;
		} 
		#endregion

		#region Public Properties
		/// <summary>
		/// Gets or sets the symbology.
		/// </summary>
		/// <value>The symbology.</value>
		[XmlAttribute ("symbology")]
		public BarcodeSymbology Symbology
		{
			get
			{
				return _symbology;
			}
			set
			{
				_symbology = value;
			}
		}

		/// <summary>
		/// Gets the test items.
		/// </summary>
		/// <value>The test items.</value>
		[XmlArray ("TestItems")]
		[XmlArrayItem (Type = typeof (SymbologyTestItem))]
		public List<SymbologyTestItem> TestItems
		{
			get
			{
				if (_testItems == null)
				{
					_testItems = new List<SymbologyTestItem> ();
				}
				return _testItems;
			}
		} 
		#endregion

		#region Public Methods
		/// <summary>
		/// Adds the test case.
		/// </summary>
		/// <param name="test">The test.</param>
		public void AddTestCase (string test)
		{
			SymbologyTestItem item = new SymbologyTestItem (test);
			TestItems.Add (item);
		}

		/// <summary>
		/// Gets the barcode image.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <param name="maxBarHeight">Height of the max bar.</param>
		/// <returns></returns>
		public Image GetBarcodeImage (int index, int maxBarHeight)
		{
			return DrawObject.Draw (GetBarcodeText (index), maxBarHeight);
		}

		/// <summary>
		/// Gets the barcode text.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns></returns>
		public string GetBarcodeText (int index)
		{
			return TestItems[index].Barcode;
		}

		/// <summary>
		/// Gets the test cases.
		/// </summary>
		/// <param name="maxBarHeight">Height of the max bar.</param>
		/// <returns></returns>
		public IEnumerable<SymbologyTestCase> GetTestCases (int maxBarHeight)
		{
			foreach (SymbologyTestItem item in TestItems)
			{
				yield return new SymbologyTestCase (_symbology, item.Barcode, maxBarHeight);
			}
		} 
		#endregion

		#region Private Methods
		/// <summary>
		/// Gets the draw object.
		/// </summary>
		/// <value>The draw object.</value>
		private BarcodeDraw DrawObject
		{
			get
			{
				return BarcodeDrawFactory.GetSymbology (_symbology);
			}
		} 
		#endregion
	}

	/// <summary>
	/// <c>SymbologyTestItem</c> encapsulates a single unit test case.
	/// </summary>
	[Serializable]
	public class SymbologyTestItem
	{
		#region Private Fields
		private string _barcode; 
		#endregion

		#region Public Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="SymbologyTestItem"/> class.
		/// </summary>
		public SymbologyTestItem ()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SymbologyTestItem"/> class.
		/// </summary>
		/// <param name="barcode">The barcode.</param>
		public SymbologyTestItem (string barcode)
		{
			_barcode = barcode;
		} 
		#endregion

		#region Public Properties
		/// <summary>
		/// Gets or sets the barcode.
		/// </summary>
		/// <value>The barcode.</value>
		[XmlAttribute ("barcode")]
		public string Barcode
		{
			get
			{
				return _barcode;
			}
			set
			{
				_barcode = value;
			}
		} 
		#endregion
	}
}

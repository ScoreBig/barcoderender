namespace Zen.Barcode.SSRS.Design
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.ComponentModel.Design;
	using System.Drawing;
	using System.Linq;
	using Microsoft.ReportDesigner;
	using Microsoft.ReportDesigner.Design;
	using Microsoft.ReportingServices.Interfaces;
	using Microsoft.ReportingServices.RdlObjectModel;
	using System.Threading;

	[LocalizedName("Barcode")]
	[Editor(typeof(BarcodeImageEditor), typeof(ComponentEditor))]
	[CustomReportItem("Barcode")]
	public class BarcodeImageDesigner : CustomReportItemDesigner
	{
		private int _inEdit;
		private bool _pendingInvalidate;

		public BarcodeImageDesigner()
		{
		}

		[Browsable(true)]
		[Category("Data")]
		public string DataSetName
		{
			get
			{
				return CustomData.DataSetName;
			}
			set
			{
				CustomData.DataSetName = value;
			}
		}

		[Browsable(true)]
		[Category("Barcode")]
		[Description("Barcode symbology to use for image.")]
		public BarcodeSymbology Symbology
		{
			get
			{
				string symbology = GetCustomPropertyString("barcode:Symbology");
				try
				{
					return (BarcodeSymbology)Enum.Parse(typeof(BarcodeSymbology), symbology, true);
				}
				catch
				{
					return BarcodeSymbology.Unknown;
				}
			}
			set
			{
				if (Symbology != value && value != BarcodeSymbology.Unknown)
				{
					SetCustomProperty("barcode:Symbology", value.ToString());

					// Refresh the draw metrics for this symbology
					BarcodeDraw drawObject = BarcodeDrawFactory.GetSymbology(value);
					BarcodeMetrics drawMetrics = drawObject.GetDefaultMetrics(MaximumBarHeight);

					using (IDisposable disp = new BarcodeDesignerEditScope(this))
					{
						MinimumBarHeight = drawMetrics.MinHeight;
						MaximumBarHeight = drawMetrics.MaxHeight;
						MinimumBarWidth = drawMetrics.MinWidth;
						MaximumBarWidth = drawMetrics.MaxWidth;
						InterGlyphSpacing = drawMetrics.InterGlyphSpacing;
					}
				}
			}
		}

		[Browsable(true)]
		[Category("Data")]
		public string TextExpression
		{
			get
			{
				if (CustomData.DataRows.Count > 0 && CustomData.DataRows[0].Count > 0)
				{
					return GetDataValue(CustomData.DataRows[0][0], "Text");
				}
				else
				{
					return "Barcode Text";
				}
			}
			set
			{
				if (TextExpression != value)
				{
					SetDataValue(CustomData.DataRows[0][0], "Text", value);
					InvalidateIfPossible();
				}
			}
		}

		[Browsable(true)]
		[Category("Barcode")]
		[Description("Gets or sets the bar height.")]
		public int? BarHeight
		{
			get
			{
				if (MinimumBarHeight == MaximumBarHeight)
				{
					return MaximumBarHeight;
				}
				return null;
			}
			set
			{
				if (BarHeight != value && value != null)
				{
					using (IDisposable disp = new BarcodeDesignerEditScope(this))
					{
						MinimumBarHeight = MaximumBarHeight = value.Value;
					}
				}
			}
		}

		[Browsable(true)]
		[Category("Barcode")]
		[Description("Gets or sets the minimum bar height.")]
		[DefaultValue(30)]
		public int MinimumBarHeight
		{
			get
			{
				return GetCustomPropertyInt32("barcode:MinimumBarHeight", 30);
			}
			set
			{
				if (MinimumBarHeight != value)
				{
					SetCustomProperty("barcode:MinimumBarHeight", value);
					InvalidateIfPossible();
				}
			}
		}

		[Browsable(true)]
		[Category("Barcode")]
		[Description("Gets or sets the maximum bar height.")]
		[DefaultValue(30)]
		public int MaximumBarHeight
		{
			get
			{
				return GetCustomPropertyInt32("barcode:MaximumBarHeight", 30);
			}
			set
			{
				if (MaximumBarHeight != value)
				{
					SetCustomProperty("barcode:MaximumBarHeight", value);
					InvalidateIfPossible();
				}
			}
		}

		[Browsable(true)]
		[Category("Barcode")]
		[Description("Gets or sets the bar width.")]
		public int? BarWidth
		{
			get
			{
				if (MinimumBarWidth == MaximumBarWidth)
				{
					return MaximumBarWidth;
				}
				return null;
			}
			set
			{
				if (BarWidth != value && value != null)
				{
					using (IDisposable disp = new BarcodeDesignerEditScope(this))
					{
						MinimumBarWidth = MaximumBarWidth = value.Value;
					}
				}
			}
		}

		[Browsable(true)]
		[Category("Barcode")]
		[Description("Gets or sets the minimum bar width.")]
		[DefaultValue(1)]
		public int MinimumBarWidth
		{
			get
			{
				return GetCustomPropertyInt32("barcode:MinimumBarWidth", 1);
			}
			set
			{
				if (MinimumBarWidth != value)
				{
					SetCustomProperty("barcode:MinimumBarWidth", value);
					InvalidateIfPossible();
				}
			}
		}

		[Browsable(true)]
		[Category("Barcode")]
		[Description("Gets or sets the maximum bar width.")]
		[DefaultValue(1)]
		public int MaximumBarWidth
		{
			get
			{
				return GetCustomPropertyInt32("barcode:MaximumBarWidth", 1);
			}
			set
			{
				if (MaximumBarWidth != value)
				{
					SetCustomProperty("barcode:MaximumBarWidth", value);
					InvalidateIfPossible();
				}
			}
		}

		[Browsable(true)]
		[Category("Barcode")]
		[Description("Gets or sets the inter-glyph spacing.")]
		public int InterGlyphSpacing
		{
			get
			{
				return GetCustomPropertyInt32("barcode:InterGlyphSpacing", 1);
			}
			set
			{
				if (InterGlyphSpacing != value)
				{
					SetCustomProperty("barcode:InterGlyphSpacing", value);
					InvalidateIfPossible();
				}
			}
		}

		public override void InitializeNewComponent()
		{
			CustomData = new CustomData();
			CustomData.DataRowHierarchy = new DataHierarchy();
			CustomData.DataColumnHierarchy = new DataHierarchy();

			// Symbology grouping
			//CustomData.DataRowHierarchy.DataMembers

			// Store text in rows
			CustomData.DataRows.Add(new DataRow());
			CustomData.DataRows[0].Add(new DataCell());
			CustomData.DataRows[0][0].Add(NewDataValue("Text", ""));
		}

		public override void Draw(Graphics g, ReportItemDrawParams dp)
		{
			// Delegate drawing of background and outlines
			if (dp.DrawBackground)
			{
				base.Draw(g, dp.AsBackgroundOnly());
			}
			if (dp.DrawOutlines)
			{
				base.Draw(g, dp.AsOutlinesOnly());
			}

			// Draw content if we can...
			if (dp.DrawContent &&
				Symbology != BarcodeSymbology.Unknown)
			{
				string textToRender = "1234";
				if (!string.IsNullOrEmpty(TextExpression))
				{
					textToRender = TextExpression;
				}

				BarcodeDraw drawObject =
					BarcodeDrawFactory.GetSymbology(Symbology);
				using (System.Drawing.Image image = drawObject.Draw(
					textToRender,
					InterGlyphSpacing,
					MinimumBarHeight,
					MaximumBarHeight,
					MinimumBarWidth,
					MaximumBarWidth))
				{
					// TODO: Determine whether to stretch or centre image
					g.DrawImage(image, new Point(0, 0));
				}
			}
		}

		public override void BeginEdit()
		{
			if (Interlocked.Increment(ref _inEdit) == 1)
			{
				base.BeginEdit();
				_pendingInvalidate = false;
			}
		}

		public override void EndEdit()
		{
			if (Interlocked.Decrement(ref _inEdit) == 0)
			{
				base.EndEdit();
				if (_pendingInvalidate)
				{
					Invalidate();
				}
			}
		}

		public int GetCustomPropertyInt32(string propertyName)
		{
			return GetCustomPropertyInt32(propertyName, 0);
		}

		public int GetCustomPropertyInt32(string propertyName, int defaultValue)
		{
			int value;
			string valueText = GetCustomPropertyString(propertyName);
			if (!Int32.TryParse(valueText, out value))
			{
				value = defaultValue;
			}
			return value;
		}

		public void SetCustomProperty(string propertyName, int value)
		{
			SetCustomProperty(propertyName, value.ToString());
		}

		public string GetCustomPropertyString(string propertyName)
		{
			string value;
			if (!CustomProperties.TryGetValue(propertyName, out value))
			{
				value = null;
			}
			return value;
		}

		public void SetCustomProperty(string propertyName, string value)
		{
			if (!CustomProperties.ContainsKey(propertyName))
			{
				CustomProperties.Add(propertyName, value);
			}
			else
			{
				CustomProperties[propertyName] = value;
			}
		}

		private void InvalidateIfPossible()
		{
			if (_inEdit > 0)
			{
				_pendingInvalidate = true;
			}
			else
			{
				Invalidate();
			}
		}

		private static string GetCustomPropertyString(IList<CustomProperty> properties, string propertyName)
		{
			if (properties == null)
			{
				return null;
			}

			CustomProperty prop = properties
				.FirstOrDefault((item) => item.Name == propertyName);
			if (prop != null)
			{
				return prop.Value.Value;
			}
			return null;
		}

		private static void SetCustomProperty(IList<CustomProperty> properties, string propertyName, string value)
		{
			CustomProperty prop = properties
				.FirstOrDefault((item) => item.Name == propertyName);
			if (prop == null)
			{
				prop = new CustomProperty();
				prop.Name = propertyName;
				properties.Add(prop);
			}

			prop.Value = value;
		}

		private static string GetDataValue(IList<DataValue> cell, string name)
		{
			DataValue value = cell.FirstOrDefault((item) => item.Name == name);
			if (value != null)
			{
				return value.Value.Value;
			}
			return null;
		}

		private static void SetDataValue(IList<DataValue> cell, string name, string expression)
		{
			DataValue value = cell.FirstOrDefault((item) => item.Name == name);
			if (value != null)
			{
				value.Value = expression;
			}
			else
			{
				DataValue datavalue = NewDataValue(name, expression);
				cell.Add(datavalue);
			}
		}

		private static DataValue NewDataValue(string name, string value)
		{
			return new DataValue
			{
				Name = name,
				Value = value
			};
		}
	}

	public sealed class BarcodeDesignerEditScope : IDisposable
	{
		public BarcodeDesignerEditScope(BarcodeImageDesigner designer)
		{
			Designer = designer;
			Designer.BeginEdit();
		}

		~BarcodeDesignerEditScope()
		{
			Dispose(false);
		}

		private BarcodeImageDesigner Designer
		{
			get;
			set;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (disposing && Designer != null)
			{
				Designer.EndEdit();
			}
			Designer = null;
		}
	}
}

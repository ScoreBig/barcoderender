namespace Zen.Barcode.SSRS
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using Microsoft.ReportingServices.OnDemandReportRendering;

	public class BarcodeImageReportItem : ICustomReportItem
	{
		#region ICustomReportItem Members

		public void GenerateReportItemDefinition(CustomReportItem cri)
		{
			cri.CreateCriImageDefinition();
			ReportItem item = cri.GeneratedReportItem;
		}

		public void EvaluateReportItemInstance(CustomReportItem cri)
		{
			
		}

		#endregion
	}
}

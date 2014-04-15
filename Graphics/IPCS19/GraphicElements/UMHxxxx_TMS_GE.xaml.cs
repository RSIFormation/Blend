using System;
using System.Windows;
namespace IPCS19
{
   /// <summary>
   /// Interaction logic for UMHxxxx_TMS_GE
   ///  <ElementId>8d870acc-9f99-4ec3-b053-760d054ddd42:df7d87d4-8c97-4f79-b964-e796df1d67e2</ElementId> 
   /// </summary>
   public partial class UMHxxxx_TMS_GE
   {
	public UMHxxxx_TMS_GE()
	{
		InitializeComponent();
	}
	// Input Properties 
	public static readonly DependencyProperty SubscriptionRateProperty = DependencyProperty.Register(
		"SubscriptionRate",typeof(Int32),typeof(UMHxxxx_TMS_GE),new PropertyMetadata(0,null));
	public Int32 SubscriptionRate
	{
		get { return (Int32)GetValue(SubscriptionRateProperty); }
		set { SetValue(SubscriptionRateProperty,value); }
	}
	// Expression Variables 
   }
}

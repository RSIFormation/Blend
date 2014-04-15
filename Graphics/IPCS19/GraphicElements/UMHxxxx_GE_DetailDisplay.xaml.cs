using System;
using System.Windows;
namespace IPCS19
{
   /// <summary>
   /// Interaction logic for UMHxxxx_GE_DetailDisplay
   ///  <ElementId>8d870acc-9f99-4ec3-b053-760d054ddd42:5bf44bc2-2295-4617-bcdc-7e5e2ad7b9fb</ElementId> 
   /// </summary>
   public partial class UMHxxxx_GE_DetailDisplay
   {
	public UMHxxxx_GE_DetailDisplay()
	{
		InitializeComponent();
	}
	// Input Properties 
	public static readonly DependencyProperty SubscriptionRateProperty = DependencyProperty.Register(
		"SubscriptionRate",typeof(Int32),typeof(UMHxxxx_GE_DetailDisplay),new PropertyMetadata(0,null));
	public Int32 SubscriptionRate
	{
		get { return (Int32)GetValue(SubscriptionRateProperty); }
		set { SetValue(SubscriptionRateProperty,value); }
	}
	// Expression Variables 
   }
}

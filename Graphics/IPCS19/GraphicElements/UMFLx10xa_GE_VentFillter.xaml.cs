using System;
using System.Windows;
namespace IPCS19
{
   /// <summary>
   /// Interaction logic for UMFLx10xa_GE_VentFillter
   ///  <ElementId>a4f28d09-8d8e-4646-9b77-9e51b49bc7c5:aa298919-ebc2-4781-8721-8363698f5e4b</ElementId> 
   /// </summary>
   public partial class UMFLx10xa_GE_VentFillter
   {
	public UMFLx10xa_GE_VentFillter()
	{
		InitializeComponent();
	}
	// Input Properties 
	public static readonly DependencyProperty SubscriptionRateProperty = DependencyProperty.Register(
		"SubscriptionRate",typeof(Int32),typeof(UMFLx10xa_GE_VentFillter),new PropertyMetadata(0,null));
	public Int32 SubscriptionRate
	{
		get { return (Int32)GetValue(SubscriptionRateProperty); }
		set { SetValue(SubscriptionRateProperty,value); }
	}
	// Expression Variables 
   }
}

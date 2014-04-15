using System;
using System.Windows;
namespace IPCS19
{
   /// <summary>
   /// Interaction logic for TPPS_1_Graphic_Element
   ///  <ElementId>58152323-84ef-40f7-9e9d-6ff7fe1d411a:fc9a4b8a-6376-4781-a7fa-13eea37f6b91</ElementId> 
   /// </summary>
   public partial class TPPS_1_Graphic_Element
   {
	public TPPS_1_Graphic_Element()
	{
		InitializeComponent();
	}
	// Input Properties 
	public static readonly DependencyProperty SubscriptionRateProperty = DependencyProperty.Register(
		"SubscriptionRate",typeof(Int32),typeof(TPPS_1_Graphic_Element),new PropertyMetadata(0,null));
	public Int32 SubscriptionRate
	{
		get { return (Int32)GetValue(SubscriptionRateProperty); }
		set { SetValue(SubscriptionRateProperty,value); }
	}
	// Expression Variables 
   }
}

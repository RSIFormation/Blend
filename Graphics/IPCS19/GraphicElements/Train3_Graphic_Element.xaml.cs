using System;
using System.Windows;
namespace SadaraLibrary
{
   /// <summary>
   /// Interaction logic for Train3_Graphic_Element
   ///  <ElementId>44b09519-fa7e-4fd7-b05a-e9d9cafe249b:6912ba21-ed3b-4576-b4f8-14ffabdeeae0</ElementId> 
   /// </summary>
   public partial class Train3_Graphic_Element
   {
	public Train3_Graphic_Element()
	{
		InitializeComponent();
	}
	// Input Properties 
	public static readonly DependencyProperty SubscriptionRateProperty = DependencyProperty.Register(
		"SubscriptionRate",typeof(Int32),typeof(Train3_Graphic_Element),new PropertyMetadata(0,null));
	public Int32 SubscriptionRate
	{
		get { return (Int32)GetValue(SubscriptionRateProperty); }
		set { SetValue(SubscriptionRateProperty,value); }
	}
	// Expression Variables 
   }
}

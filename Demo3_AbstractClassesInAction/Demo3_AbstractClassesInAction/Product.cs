using System;

namespace Demo_AbstractClassesInAction
{
    public class DiscountedProduct : Product
    {
        public double DiscountPercent { get; set; }

        public override double CalculateFinalPrice()
        {
            return Price - (Price * DiscountPercent / 100);
        }
    }
}
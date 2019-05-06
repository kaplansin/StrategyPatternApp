using StrategyPatternApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternApp.Domain.DiscountRules
{
    public class BasketDiscountSilverUser : BasketDiscountOverMemberShipBase
    {
        public override MemberShipTypeEnum MemberShipType => MemberShipTypeEnum.SILVER;
        protected override double DiscountRatio => 0.05;
        public BasketDiscountSilverUser(DiscountBase parentDiscount) : base(parentDiscount)
        {

        }
    }
}

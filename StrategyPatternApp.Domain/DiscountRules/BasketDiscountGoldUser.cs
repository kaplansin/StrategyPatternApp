using System;
using System.Collections.Generic;
using System.Text;
using StrategyPatternApp.Domain.Models;

namespace StrategyPatternApp.Domain.DiscountRules
{
    public class BasketDiscountGoldUser : BasketDiscountOverMemberShipBase
    {

        protected override double DiscountRatio => 0.1;
        public override MemberShipTypeEnum MemberShipType => MemberShipTypeEnum.GOLD;
        public BasketDiscountGoldUser(DiscountBase parentDiscount, bool isEnabled = true) : base(parentDiscount, isEnabled)
        {

        }
    }
}

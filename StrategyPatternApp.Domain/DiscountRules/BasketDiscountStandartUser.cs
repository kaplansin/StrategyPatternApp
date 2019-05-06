using StrategyPatternApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternApp.Domain.DiscountRules
{
    public class BasketDiscountStandartUser : BasketDiscountOverMemberShipBase
    {
        public override MemberShipTypeEnum MemberShipType => MemberShipTypeEnum.STANDART;
        protected override double DiscountRatio => 0;
        public BasketDiscountStandartUser(DiscountBase parentDiscount): base(parentDiscount)
        {

        }
    }
}

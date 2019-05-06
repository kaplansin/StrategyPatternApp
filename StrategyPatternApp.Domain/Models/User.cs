using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternApp.Domain.Models
{
    public class User
    {
        public string Name { get; private set; }
        public MemberShipTypeEnum MemberShipType { get; private set; }

        public User(string name, MemberShipTypeEnum memberShipType = MemberShipTypeEnum.STANDART)
        {
            this.Name = name;
            this.MemberShipType = memberShipType;
        }
    }
}

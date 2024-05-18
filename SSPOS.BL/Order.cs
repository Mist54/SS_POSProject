using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSPOS.BL
{
    public class Order
    {
        public Order()
        {
            _knotNumber = string.Empty;
            _section = string.Empty;
            _waiterName = string.Empty;
            _tableType = string.Empty;
            _itemCode = 0;
            _qty = 0;

        }

        private string _knotNumber;
        private string _section;
        private string _Item;
        private string _waiterName;
        private string _tableType;
        private int _itemCode;
        private int _qty;

        public string knotNumber { get => _knotNumber; set => _knotNumber = value; }
        public string section { get => _section; set => _section = value; }
        public string waiterName { get => _waiterName; set => _waiterName = value; }
        public string Item { get => _Item; set => _Item = value; }
        public string tableType { get => _tableType; set => _tableType = value; }
        public int Code { get => _itemCode; set => _itemCode = value; }
        public int Qty { get => _qty; set => _qty = value; }


    }
}

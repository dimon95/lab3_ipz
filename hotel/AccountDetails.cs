using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_ipz
{
    public class Requisites:
        Utils.Entity
    {
        public Utils.NonEmptyString OrganizationName
        {
            get;
            private set;
        }

        public Utils.NonEmptyString BeneficiaryBank
        {
            get;
            private set;
        }

        public Utils.NonEmptyString AccountNumber { get; private set; }

        public Utils.NonEmptyString IIN { get; private set; }

        public Utils.NonEmptyString BankIdentifierCode { get; private set; }

        public Requisites ( Guid _id, string _name, string _bank, string _accountNumber, string _iin, string _bic )
            :base(_id)
        {
            OrganizationName = new Utils.NonEmptyString( _name);
            BeneficiaryBank = new Utils.NonEmptyString( _bank);
            AccountNumber = new Utils.NonEmptyString( _accountNumber);
            IIN = new Utils.NonEmptyString( _iin);
            BankIdentifierCode = new Utils.NonEmptyString( _bic );
        }

        public override string ToString ()
        {
            return string.Format(
                       "Requisites:: id:{0} ",
                       Id
                   );
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace ORM.PerformanceTest.Entity
{
    public class ContractSupplementary
    {
        [Key]
        [Required]
        public virtual Guid Id { get; protected set; }
        public virtual Guid ContractGroupId { get; set; }
        public virtual DateTime StartDate { get; protected set; }
        public virtual DateTime EndDate { get; protected set; }
        public virtual int ChargeNum { get; protected set; }
        public virtual string Section { get; protected set; }
        public virtual string ItemCode { get; protected set; }
        public virtual int IToU { get; protected set; }
        public virtual int Band { get; protected set; }
        public virtual decimal Price { get; protected set; }
        public virtual string Units { get; protected set; }

        public ContractSupplementary()
        {

        }

        public ContractSupplementary(Guid contractGroupId, DateTime startDate, DateTime endDate, int chargeNum,
            string section, string itemCode, int iToU, int band, decimal price, string units)
        {
            ContractGroupId = contractGroupId;
            StartDate = startDate;
            EndDate = endDate;
            ChargeNum = chargeNum;
            Section = section;
            ItemCode = itemCode;
            IToU = iToU;
            Band = band;
            Price = price;
            Units = units;
        }

        public virtual void SetId()
        {
            Id = Guid.NewGuid();
        }
    }
}

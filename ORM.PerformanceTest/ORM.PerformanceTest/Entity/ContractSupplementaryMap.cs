using FluentNHibernate.Mapping;

namespace ORM.PerformanceTest.Entity
{
    public class ContractSupplementaryMap : ClassMap<ContractSupplementary>
    {
        public ContractSupplementaryMap()
        {
            Table("contractsupplementary");

            Id(x => x.Id).Column("Id");

            Map(x => x.ItemCode);

            Map(x => x.IToU);

            Map(x => x.Price);

            Map(x => x.Section);

            Map(x => x.StartDate);

            Map(x => x.EndDate);

            Map(x => x.ContractGroupId);

            Map(x => x.ChargeNum);

            Map(x => x.Band);

            Map(x => x.Units);
        }

    }
}

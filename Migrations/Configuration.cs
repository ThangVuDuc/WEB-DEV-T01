namespace WebDevT01.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebDevT01.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebDevT01.Models.WebDevT01Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebDevT01.Models.WebDevT01Context context)
        {
            context.Refs.AddOrUpdate(p => p.refID,
                new Ref()
                {
                    refDate = new DateTime(2019,05,06), 
                    refNo = "PT0001",
                    refType = "Phiếu thu tiền mặt",
                    contactName = "Vũ Đức Thắng",
                    reason = "Thu nợ"
                }
                );
        }
    }
}

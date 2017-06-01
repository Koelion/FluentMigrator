using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentMigrator.Migrations
{


    [Migration(1)]
    public class TestTable_1 : Migration
    {
        public override void Down()
        {
            //throw new NotImplementedException();
        }

        public override void Up()
        {
            Execute.Script(@"Assets\createtesttable.txt");
        }

    }

    [Migration(2)]
    public class TestTable_2 : Migration
    {
        public override void Down()
        {
            //throw new NotImplementedException();
        }

        public override void Up()
        {
            string sql = "ALTER TABLE [dbo].[TestTable] ALTER COLUMN [PostCode] varchar(8); " +
                         "ALTER TABLE [dbo].[TestTable] ALTER COLUMN [Phone] varchar(16); ";
            Execute.Sql(sql);
            //Alter.Table("[dbo].[TestTable]").AlterColumn("[PostCode]").AsFixedLengthString(8);
            //Alter.Table("[dbo].[TestTable]").AlterColumn("[Phone]").AsFixedLengthString(16);
        }
    }

    [Migration(3)]
    public class TestTable_3 : Migration
    {
        public override void Down()
        {
            //throw new NotImplementedException();
        }

        public override void Up()
        {
            Alter.Table("[TestTable]").AddColumn("[IsDeleted]").AsByte();
        }

    }
}

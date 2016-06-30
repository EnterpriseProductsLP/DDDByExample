// © Copyright 2012, Enterprise Products Partners L.P. (Enterprise), All Rights Reserved.
// Permission to use, copy, modify, or distribute this software source code, binaries or 
// related documentation, is strictly prohibited, without written consent from Enterprise. 
// For inquiries about the software, contact Enterprise: Enterprise Products Company Law
// Department, 1100 Louisiana, 10th Floor, Houston, Texas 77002, phone 713-381-6500.

using FluentMigrator;

namespace Erp.SalesContext.Migrations
{
    [TimestampedMigration(2016, 06, 28, 10, 18)]
    public class Migration201606281018CreateCustomerTable : Migration
    {
        public override void Up()
        {
            // Create the sales schema.
            Create.Schema("Sales");

            // Create the address table.
            Create
                .Table("Address").InSchema("Sales")
                .WithColumn("AddressId").AsInt64().PrimaryKey("PK_Address")
                .WithColumn("Address1").AsString(1000)
                .WithColumn("Address2").AsString(1000)
                .WithColumn("Address3").AsString(1000)
                .WithColumn("Address4").AsString(1000)
                .WithColumn("Country").AsString(200)
                .WithColumn("Locality").AsString(1000)
                .WithColumn("PostCode").AsString(200)
                .WithColumn("Region").AsString(1000);


            Create
                .Table("Customer").InSchema("Sales")
                .WithColumn("CustomerId").AsInt64().PrimaryKey("PK_Customer")
                .WithColumn("Name").AsString(1000);

            Create
                .Table("Customer_X_Address").InSchema("Sales")
                .WithColumn("CustomerId").AsInt64()
                .WithColumn("AddressId").AsInt64()
                .WithColumn("IsPrimaryBillingAddress").AsBoolean()
                .WithColumn("IsPrimaryShippingAddress").AsBoolean();

            Create.PrimaryKey("PK_Customer_X_Address")
                .OnTable("Customer_X_Address")
                .WithSchema("Sales")
                .Columns("CustomerId", "AddressId");

            Create
                .ForeignKey("FK_Customer_X_Address_Customer")
                .FromTable("Customer_X_Address").InSchema("Sales").ForeignColumn("CustomerId")
                .ToTable("Customer").InSchema("Sales").PrimaryColumn("CustomerId");

            Create
                .ForeignKey("FK_Customer_X_Address_Address")
                .FromTable("Customer_X_Address").InSchema("Sales").ForeignColumn("AddressId")
                .ToTable("Address").InSchema("Sales").PrimaryColumn("AddressId");
        }

        public override void Down()
        {
            Delete
                .Table("PK_Customer_X_Address").InSchema("Sales");

            Delete
                .Table("Customer").InSchema("Sales");

            Delete
                .Table("Address").InSchema("Sales");
        }
    }
}

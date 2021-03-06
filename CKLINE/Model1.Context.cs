﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CKLINE
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TMSEntities : DbContext
    {
        public TMSEntities()
            : base("name=TMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccidentHistory> AccidentHistories { get; set; }
        public virtual DbSet<AdmonishHistory> AdmonishHistories { get; set; }
        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DeliveryPrice> DeliveryPrices { get; set; }
        public virtual DbSet<FuelType> FuelTypes { get; set; }
        public virtual DbSet<Garage> Garages { get; set; }
        public virtual DbSet<GasRefill> GasRefills { get; set; }
        public virtual DbSet<GasStation> GasStations { get; set; }
        public virtual DbSet<GPSViolationHistory> GPSViolationHistories { get; set; }
        public virtual DbSet<Maintenance> Maintenances { get; set; }
        public virtual DbSet<MaintenanceType> MaintenanceTypes { get; set; }
        public virtual DbSet<MarriageStatu> MarriageStatus { get; set; }
        public virtual DbSet<MilitaryStatu> MilitaryStatus { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderType> OrderTypes { get; set; }
        public virtual DbSet<Provice> Provices { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<SubContact> SubContacts { get; set; }
        public virtual DbSet<Tire> Tires { get; set; }
        public virtual DbSet<TireChange> TireChanges { get; set; }
        public virtual DbSet<TrainingHistory> TrainingHistories { get; set; }
        public virtual DbSet<WorkingHistory> WorkingHistories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Repair> Repairs { get; set; }
        public virtual DbSet<RepairDetail> RepairDetails { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<JobDetail> JobDetails { get; set; }
        public virtual DbSet<Transfer> Transfers { get; set; }
        public virtual DbSet<TransferOli> TransferOlis { get; set; }
        public virtual DbSet<TransferOTH> TransferOTHs { get; set; }
        public virtual DbSet<TransferWay> TransferWays { get; set; }
        public virtual DbSet<Truck> Trucks { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
    }
}

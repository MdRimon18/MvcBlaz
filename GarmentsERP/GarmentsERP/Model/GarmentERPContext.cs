using GarmentsERP.Model.Commercial;
using GarmentsERP.Model.Commercial.Export;
using GarmentsERP.Model.LibraryModule;
using GarmentsERP.Model.MarchandisingModule;
using GarmentsERP.Model.PlanningModule;
using GarmentsERP.Model.Shared;
using GarmentsERP.Models;
using Microsoft.EntityFrameworkCore;
using EmbellishmentType = GarmentsERP.Model.LibraryModule.EmbellishmentType;
using ServiceBookingForAOPWithoutOrder = GarmentsERP.Model.MarchandisingModule.ServiceBookingForAOPWithoutOrder;
using StaticFabricSource = GarmentsERP.Model.MarchandisingModule.StaticFabricSource;

namespace GarmentsERP.Model
{
    public partial class GarmentERPContext:DbContext
    {
     

        public GarmentERPContext()
        {
        }

        public GarmentERPContext(DbContextOptions<GarmentERPContext> options)
            : base(options)
        {

        }

        public virtual DbSet<ConversionCostProcess> ConversionCostProcesses { get; set; }
        public virtual DbSet<MarchandisingModule.FabricCost> FabricCosts { get; set; }
        public virtual DbSet<FabricDesPreCost> FabricDesPreCosts { get; set; }
        public virtual DbSet<InputPannelPodetails> InputPannelPodetails { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<PreCosting> PreCostings { get; set; }
        public virtual DbSet<SizePannelPodetails> SizePannelPodetails { get; set; }
        public virtual DbSet<Suplier> Supliers { get; set; }
        public virtual DbSet<Suplyitem> Suplyitems { get; set; }
        public virtual DbSet<TblAgentInfo> TblAgentInfoes { get; set; }
        public virtual DbSet<TblCompanyInfo> TblCompanyInfoes { get; set; } 
        public virtual DbSet<TblDepartInfo> TblDepartInfoes { get; set; }
        public virtual DbSet<TblInitialOrder> TblInitialOrders { get; set; }
        public virtual DbSet<TblLocationInfo> TblLocationInfoes { get; set; }
        public virtual DbSet<TblOrderUomInfo> TblOrderUomInfoes { get; set; }
        public virtual DbSet<TblPackingInfo> TblPackingInfoes { get; set; }
        public virtual DbSet<TblPodetailsInfro> TblPodetailsInfroes { get; set; }            
        public virtual DbSet<TblProductCategoryInfo> TblProductCategoryInfoes { get; set; }
        public virtual DbSet<TblProductionDeptInfo> TblProductionDeptInfoes { get; set; }
        public virtual DbSet<TblRegionInfo> TblRegionInfoes { get; set; }
        public virtual DbSet<TblSeasonInfo> TblSeasonInfoes { get; set; }
        public virtual DbSet<TblShipmentModeInfo> TblShipmentModeInfoes { get; set; }
        public virtual DbSet<TblSubDeptInfo> TblSubDeptInfoes { get; set; }

        public virtual DbSet<MarchandisingModule.RequiredEmbellishment> RequiredEmbellishments { get; set; }

        public virtual DbSet<MarchandisingModule.ServiceBookingForKnitting> ServiceBookingForKnittings { get; set; }
        public virtual DbSet<MarchandisingModule.ServiceBookingForKnitingDetail> ServiceBookingForKnitingDetails { get; set; }
        public virtual DbSet<MarchandisingModule.EmbellishmentWorkOrderV2> EmbellishmentWorkOrderV2 { get; set; }
        public virtual DbSet<MarchandisingModule.EmbellishmentWorkOrderV2Details> EmbellishmentWorkOrderV2Details { get; set; }
        public virtual DbSet<MarchandisingModule.MultiJobWiseServiceBookingKnitting> MultiJobWiseServiceBookingKnittings { get; set; }
        public virtual DbSet<MultiJobWSBKnittingDetails> MultiJobWSBKnittingDetails { get; set; }

        public virtual DbSet<TblUserInfo> TblUserInfoes { get; set; }
        public virtual DbSet<TblUserTypeInfo> TblUserTypeInfoes { get; set; }
        public virtual DbSet<YarnComp1> YarnComp1 { get; set; }
        public virtual DbSet<KnittingCharge> KnittingCharges { get; set; }
        public virtual DbSet<YarnCostPreCosting> YarnCostPreCostings { get; set; }
        public virtual DbSet<YarnCount> YarnCounts { get; set; }
        public virtual DbSet<yarnBrandInfo> yarnBrandInfoes { get; set; } 
        
        //above done
        public virtual DbSet<countryLocationMapping> countryLocationMappings { get; set; }      
        public virtual DbSet<ItemCategory> ItemCategories { get; set; }                     
        public virtual DbSet<PartyType> PartyTypes { get; set; }                     
        public virtual DbSet<DyeingAndFinishingCharge> DyeingAndFinishingCharges { get; set; }                     
        public virtual DbSet<TNATaskNameEntry> TNATaskNameEntries { get; set; }  
        

        public virtual DbSet<TNATaskEntry> TNATaskEntries { get; set; }                     
        public virtual DbSet<OtherPartyProfile> OtherPartyProfiles { get; set; }                     
        public virtual DbSet<GroupProfile> GroupProfiles{ get; set; }                     
        public virtual DbSet<DepartmentProfile> DepartmentProfiles { get; set; }                     
        public virtual DbSet<DivisionProfile> DivisionProfiles { get; set; }                     
        public virtual DbSet<SectionProfile> SectionProfiles { get; set; }                     
        public virtual DbSet<ProfitCenter> ProfitCenters { get; set; }                     
        public virtual DbSet<JournalSetup> JournalSetups { get; set; }                     
        public virtual DbSet<GarmentsSampleEntry> GarmentsSampleEntries { get; set; }                     
        public virtual DbSet<GarmentsItemEntry> GarmentsItemEntries { get; set; }                     
        public virtual DbSet<MinLeadTimeSlab> MinLeadTimeSlabs { get; set; }                     
        public virtual DbSet<FinancialParameterSetup> FinancialParameterSetups { get; set; }
        public virtual DbSet<CapacityAllocation> CapacityAllocations { get; set; }
        public virtual DbSet<ProductSubDepartment> ProductSubDepartments { get; set; }
        public virtual DbSet<TNATaskPercent> TNATaskPercents { get; set; }
        public virtual DbSet<ColourEntry> ColourEntries { get; set; }
        public virtual DbSet<Upload> Uploads { get; set; }                     
        public virtual DbSet<YarnType> YarnTypes { get; set; }
        public virtual DbSet<CommissionCostPreCosting> CommissionCostPreCostings { get; set; }
     //   public virtual DbSet<CommercialCosts> CommercialCosts { get; set; }
       
        public virtual DbSet<ItemDetailsOrderEntry> ItemDetailsOrderEntries { get; set; }
        public virtual DbSet<AvgGreyConsFabricCost> AvgGreyConsFabricCosts { get; set; }
       
        public virtual DbSet<CostComponentsMaster> CostComponentsMasters { get; set; }
        public virtual DbSet<CostComponenetsMasterDetails> CostComponenetsMasterDetails { get; set; }
        public virtual DbSet<SizeEntry> SizeEntries { get; set; }
        
        public virtual DbSet<TrimsGroup> TrimsGroups { get; set; }
        public virtual DbSet<PageInfo> PageInfoes { get; set; }
        public virtual DbSet<BuyerWiesSeason> BuyerWiesSeasons { get; set; }
        public virtual DbSet<EmailAddressSetup> EmailAddressSetups { get; set; }
        //above are done
        public virtual DbSet<MailRecipientGroup> MailRecipientGroups { get; set; }
        public virtual DbSet<FastReactIntgration> FastReactIntgrations { get; set; }
        public virtual DbSet<CurrencyConversionRate> CurrencyConversionRates { get; set; }
        public virtual DbSet<StoreLocation> StoreLocations { get; set; }
        public virtual DbSet<EmployeeInfo> EmployeeInfoes { get; set; }
        public virtual DbSet<ReportSetting> ReportSettings { get; set; }
        public virtual DbSet<MarchandisingModule.YarnCost> YarnCosts { get; set; }
        public virtual DbSet<CommercialCosts> CommercialCosts { get; set; }
        public virtual DbSet<MarchandisingModule.SalesForecastEntry> SalesForecastEntries { get; set; }
        public virtual DbSet<SalesForecastEntryDetails> SalesForecastEntryDetails { get; set; }
        public virtual DbSet<MarchandisingModule.SampleDevelopmentEntry> SampleDevelopmentEntries { get; set; }
        public virtual DbSet<SizeDits> SizeDits { get; set; }
        public virtual DbSet<MarchandisingModule.QuotationInquery> QuotationInqueries { get; set; }
        public virtual DbSet<TrimCost> TrimCosts { get; set; }
        public virtual DbSet<MarchandisingModule.WashCost> WashCosts { get; set; }
        public virtual DbSet<MarchandisingModule.ConversionCostForPreCost> ConversionCostForPreCosts { get; set; }
        public virtual DbSet<LibraryModule.BankInfo> BankInfoes { get; set; }
        public virtual DbSet<LibraryModule.AccountInfo> AccountInfoes { get; set; }
        public virtual DbSet<LibraryModule.TnaMailSetup> TnaMailSetups { get; set; }

        public virtual DbSet<LibraryModule.VariableListTable> VariableListTables { get; set; }
        public virtual DbSet<LibraryModule.ERPModule> ERPModules { get; set; }
        public virtual DbSet<LibraryModule.AccountType> AccountTypes { get; set; }

        public virtual DbSet<MarchandisingModule.FabricServiceBooking> FabricServiceBookings { get; set; }
        public virtual DbSet<MarchandisingModule.YarnDyeingWOWithoutOrderDetail> YarnDyeingWOWithoutOrderDetails { get; set; }
        public virtual DbSet<MarchandisingModule.YarnDyeingWOWithoutOrderMaster> YarnDyeingWOWithoutOrderMasters { get; set; }
        public virtual DbSet<MarchandisingModule.YarnDyeingWorkOrder> YarnDyeingWorkOrders { get; set; }
        public virtual DbSet<MarchandisingModule.YarnDyeingWoDetail> YarnDyeingWoDetails { get; set; }
       
        public virtual DbSet<SampleDevelopmentOrderDetails> SampleDevelopmentOrderDetails { get; set; }
        public virtual DbSet<MarchandisingModule.AddConsumptionFormForEmblishmentCost> AddConsumptionFormForEmblishmentCosts { get; set; }
        public virtual DbSet<MarchandisingModule.AddConsumptionFormForGmtWashCost> AddConsumptionFormForGmtWashCosts { get; set; }

        //for commercial

        public virtual DbSet<PiDetails> PiDetails { get; set; }
        public virtual DbSet<PiItemDetails> PiItemDetails { get; set; }
        public virtual DbSet<Commercial.YarnPurchaseRequisition> YarnPurchaseRequisitions { get; set; }
        public virtual DbSet<YarnPurchaseRequisitionDetails> YarnPurchaseRequisitionDetails { get; set; }
        public virtual DbSet<Commercial.YarnPurchaseOrder> YarnPurchaseOrders { get; set; }
        public virtual DbSet<YarnPurchaseOrderDetails> YarnPurchaseOrderDetails { get; set; }
        public virtual DbSet<Commercial.Export.SalesContractEntry> SalesContractEntries { get; set; }
        public virtual DbSet<SalesContractEntryDetails> SalesContractEntryDetails { get; set; }



        //static features
        public virtual DbSet<UOM> UOMs { get; set; }
        public virtual DbSet<DiscountMethod> DiscountMethods { get; set; }
        public virtual DbSet<BodyPartType> BodyPartTypes { get; set; }
        public virtual DbSet<CommercialInvoice> CommercialInvoices { get; set; }
        public virtual DbSet<FabricNature> FabricNatures { get; set; }
        public virtual DbSet<ColorRange> ColorRanges { get; set; }
        public virtual DbSet<SampleType> SampleTypes { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<SewingLine> SewingLines { get; set; }
        public virtual DbSet<SewingOperation> SewingOperations { get; set; }
        public virtual DbSet<MachineEntry> MachineEntries { get; set; }
        public virtual DbSet<ProductionFloor> ProductionFloors { get; set; }
        public virtual DbSet<SampleProductionTeam> SampleProductionTeams { get; set; }
        public virtual DbSet<LabTestRateChart> LabTestRateCharts { get; set; }
        public virtual DbSet<Years> Years { get; set; }
        public virtual DbSet<Months> Months { get; set; }
        public virtual DbSet<Resources> Resources { get; set; }
        public virtual DbSet<ProductionProcess> ProductionProcesses { get; set; }
        public virtual DbSet<JournalType> JournalTypes { get; set; }
        public virtual DbSet<Typpe> Typpes { get; set; }
        public virtual DbSet<Religion> Religions { get; set; }
        public virtual DbSet<BloodGroup> BloodGroups { get; set; }
        public virtual DbSet<EmployeeCategory> EmployeeCategories { get; set; }
        public virtual DbSet<EmpCategory> EmpCategories { get; set; }
        public virtual DbSet<EmpDesignation> EmpDesignations { get; set; }
        public virtual DbSet<EmpAdditionalDesignation> EmpAdditionalDesignations { get; set; }
        public virtual DbSet<DesignationLebel> DesignationLebels { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<FunctionalSuperior> FunctionalSuperiors { get; set; }
        public virtual DbSet<AdminSuperior> AdminSuperiors { get; set; }
        public virtual DbSet<Floor> Floors { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<LineNo> LineNoes { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<ReportFormat> ReportFormats { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<TermsNCondition> TermsNConditions { get; set; }
        public virtual DbSet<TermsNConditionSubTable> TermsNConditionSubTables { get; set; }
        public virtual DbSet<BodyPartEntry> BodyPartEntries { get; set; }
        public virtual DbSet<DepoLocationMapping> DepoLocationMappings { get; set; }
        public virtual DbSet<ItemGroup> ItemGroups { get; set; }
        public virtual DbSet<ItemAccountCreation> ItemAccountCreations { get; set; }
        public virtual DbSet<BuyerProfile> BuyerProfiles { get; set; }
        public virtual DbSet<SupplierProfile> SupplierProfiles { get; set; }
        public virtual DbSet<YarnCountDetermination> YarnCountDeterminations { get; set; }
        public virtual DbSet<YarnCountDeterminationChild> YarnCountDeterminationChilds { get; set; }
        public virtual DbSet<TrimsCostingTemplate> TrimsCostingTemplates { get; set; }
        public virtual DbSet<MarketingTeamInfo> MarketingTeamInfoes { get; set; }
        public virtual DbSet<MemberInfo> MemberInfoes { get; set; }
        public virtual DbSet<CapacityCalculation> CapacityCalculations { get; set; }
        public virtual DbSet<CapacityCalculationMonthly> CapacityCalculationMonthlies { get; set; }
        public virtual DbSet<CapacityCalculationYearly> CapacityCalculationYearlies { get; set; }
        public virtual DbSet<YarnRate> YarnRates { get; set; }
        public virtual DbSet<AccountingYear> AccountingYears { get; set; }
        public virtual DbSet<AccountingYearSubInfo> AccountingYearSubInfoes { get; set; }
        public virtual DbSet<Shareholder> Shareholders { get; set; }
        public virtual DbSet<ShareholderShareDetails> ShareholderShareDetails { get; set; }
        public DbSet<ShareholderNomineeDetails> ShareholderNomineeDetails { get; set; }
        public DbSet<MarchandisingModule.ConsumptionEntryForm> ConsumptionEntryForms { get; set; }
        public DbSet<LibraryModule.VariableSettingsTable> VariableSettingsTables { get; set; }
        public DbSet<MarchandisingModule.CommissionCost> CommissionCosts { get; set; }
        public DbSet<MarchandisingModule.EmbellishmentCost> EmbellishmentCosts { get; set; }
        public DbSet<EmbellishmentType> EmbellishmentTypes { get; set; }   
       public DbSet<UserMapping> UserMappings { get; set; }        
       public DbSet<ErpImages> ErpImages { get; set; }        
       public DbSet<MarchandisingModule.MultipleJobWiseTrimsBookingV2> MultipleJobWiseTrimsBookingV2 { get; set; }        
       public DbSet<MarchandisingModule.ShortTrimsBooking> ShortTrimsBookings { get; set; }        
        public DbSet<GarmentsERP.Model.LibraryModule.ColorType> ColorTypes { get; set; }
        public DbSet<MarchandisingModule.SampleFabricBookingWithoutOrderMaster> SampleFabricBookingWithoutOrderMasters { get; set; }
        public DbSet<SampleFabricBookingWithoutorderDetails> SampleFabricBookingWithoutorderDetails { get; set; }
        public DbSet<MarchandisingModule.MultipleJobWiseShortTrimsBookingV2> MultipleJobWiseShortTrimsBookingV2 { get; set; }
        public DbSet<MarchandisingModule.MultipleJobWiseEmbellishmentWorkOrder> MultipleJobWiseEmbellishmentWorkOrders { get; set; }
        public DbSet<ServiceBookingForAOPWithoutOrder> ServiceBookingForAOPWithoutOrders { get; set; }
        public DbSet<MarchandisingModule.MainFabricBookingV2> MainFabricBookingV2 { get; set; }
        public DbSet<MarchandisingModule.PartialFabricBooking> PartialFabricBookings { get; set; }
        public DbSet<MarchandisingModule.SampleFabricBookingWithorder> SampleFabricBookingWithorders { get; set; }
        public DbSet<ServiceBookingForAOPWithoutOrderDetails> ServiceBookingForAOPWithoutOrderDetails { get; set; }
        public DbSet<MarchandisingModule.ServiceBookingForAOPV2> ServiceBookingForAOPV2 { get; set; }
        public DbSet<MarchandisingModule.ServiceBookingForDyeing> ServiceBookingForDyeings { get; set; }
        public DbSet<MarchandisingModule.ShortFabricBooking> ShortFabricBookings { get; set; }
        public DbSet<MarchandisingModule.ServiceBookingForKnitingandDyeingWithoutOrder> ServiceBookingForKnitingandDyeingWithoutOrders { get; set; }
        public DbSet<MarchandisingModule.ServiceBookingForKnitingandDyeingWithoutOrderDetails> ServiceBookingForKnitingandDyeingWithoutOrderDetails { get; set; }
        public DbSet<MarchandisingModule.SampleRequisitionWithBooking> SampleRequisitionWithBookings { get; set; }
        public DbSet<MarchandisingModule.SampleFabricBooking> SampleFabricBookings { get; set; }

        public DbSet<ShortFabricBookingDetails> ShortFabricBookingDetails { get; set; }
        public DbSet<SampleFabricBookingWithOrderDetails> SampleFabricBookingWithOrderDetails { get; set; }
        public DbSet<RequiredAccessories> RequiredAccessories { get; set; }
        public DbSet<Sampledetails> Sampledetails { get; set; }
        public DbSet<MarchandisingModule.RequiredFabric> RequiredFabrics { get; set; }
        public DbSet<PlanningModule.CutandLayEntry> CutandLayEntries { get; set; }
        public DbSet<CutandLaydetails> CutandLaydetails { get; set; }
        public DbSet<CutandLayEntryRollWise> CutandLayEntryRollWises { get; set; }
        public DbSet<CutandLayRollWisedetails> CutandLayRollWisedetails { get; set; }
        public DbSet<CutandLayEntryRatioWiseDetails> CutandLayEntryRatioWiseDetails { get; set; }
        public DbSet<CutandLayEntryRatioWise> CutandLayEntryRatioWises { get; set; }
        public DbSet<GarmentsERP.Model.PlanningModule.CutandLayEntryRatioWise2> CutandLayEntryRatioWise2 { get; set; }
        public DbSet<GarmentsERP.Model.PlanningModule.CutandLayEntryRatioWise2Details> CutandLayEntryRatioWise2Details { get; set; }

        public DbSet<GarmentsERP.Model.PlanningModule.SewingOperationForWorkStudy> SewingOperationForWorkStudys { get; set; }
       public DbSet<GarmentsERP.Model.PlanningModule.EfficiencyPercentageSlab> EfficiencyPercentageSlabs { get; set; }
        

        public DbSet<GarmentsERP.Model.PlanningModule.CutandLayEntryRatioWiseUrmi> CutandLayEntryRatioWiseUrmis { get; set; }

        public DbSet<GarmentsERP.Model.PlanningModule.CutandLayEntryRatioWiseUrmiDetails> CutandLayEntryRatioWiseUrmiDetails { get; set; }

        public DbSet<GarmentsERP.Model.Composition> Compositions { get; set; }

        public DbSet<GarmentsERP.Model.MarchandisingModule.OfferingCost.OfferingCostBuyerInformation> OfferingCostBuyerInformations { get; set; }

        public DbSet<GarmentsERP.Model.MarchandisingModule.OfferingCost.OfferingCostConsumptionCost> OfferingCostConsumptionCosts { get; set; }

        public DbSet<GarmentsERP.Model.MarchandisingModule.OfferingCost.OfferingCostFabricInformation> OfferingCostFabricInformations { get; set; }

        public DbSet<GarmentsERP.Model.MarchandisingModule.OfferingCost.OfferingCostInformation> OfferingCostInformations { get; set; }

        public DbSet<GarmentsERP.Model.MarchandisingModule.OfferingCost.OfferingCostTypeInfo> OfferingCostTypeInfoes { get; set; }

        public DbSet<GarmentsERP.Model.MarchandisingModule.ConsumptionEntryFormForTrimsCost> ConsumptionEntryFormForTrimsCosts { get; set; }

        public DbSet<GarmentsERP.Model.MarchandisingModule.OfferingCost.OfferingCostCostingSheet> OfferingCostCostingSheets { get; set; }

        public DbSet<GarmentsERP.Model.Commercial.BTBORMarginLC> BTBORMarginLCs { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.PIBreakDown.ProFormaInvoiceYarn> ProFormaInvoiceYarns { get; set; }
        

        //above done
        public DbSet<GarmentsERP.Model.Shared.PageObjectCreatorMaster> PageObjectCreatorMasters { get; set; }
        

        public DbSet<GarmentsERP.Model.Shared.PageObjectCreatorChild> PageObjectCreatorChilds { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.StationnaryPurchaseOrder> StationnaryPurchaseOrders { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.OtherPurchaseOrder> OtherPurchaseOrders { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.PIBreakDown.ProFormaInvoiceAccessories> ProFormaInvoiceAccessories { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.PIBreakDown.ProFormaInvoiceGeneral> ProFormaInvoiceGenerals { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Import.BTBOrImportLCInvoiceDetails> BTBOrImportLCInvoiceDetails { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Import.BTBOrImportLCShipmentDetails> BTBOrImportLCShipmentDetails { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.PIBreakDown.ProFormaInvoiceFabric> ProFormaInvoiceFabrics { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.PIBreakDown.ProFormaInvoiceServiceFabric> ProFormaInvoiceServiceFabrics { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.PIBreakDown.ProFormaInvoiceServiceYarn> ProFormaInvoiceServiceYarns { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.PIBreakDown.ProFormaInvoiceServiceEmbellishment> ProFormaInvoiceServiceEmbellishments { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.PIBreakDown.ProFormaInvoiceLabTest> ProFormaInvoiceLabTests { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.PIBreakDown.ProFormaInvoiceGarmentsSrvc> ProFormaInvoiceGarmentsSrvcs { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.PIBreakDown.ProFormaInvoiceDyesChemical> ProFormaInvoiceDyesChemicals { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Import.ImportDocAcceptanceNonLC> ImportDocAcceptanceNonLCs { get; set; }
        

        public DbSet<ImportDocAcceptanceNonLCForShipDtls> ImportDocAcceptanceNonLCForShipDtls { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Import.ImportPayment> ImportPayments { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Import.ImportPaymentEntry> ImportPaymentEntries { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Import.ImportPaymentForAtSight> ImportPaymentForAtSights { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Import.ImportPaymentForAtSightPaymentEntry> ImportPaymentForAtSightPaymentEntries { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.PIBreakDown.ProFormaInvoiceYarnChild> ProFormaInvoiceYarnChilds { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Import.CommercialOfficeNote> CommercialOfficeNotes { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Import.YarnBagSticker> YarnBagStickers { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Import.YarnBagStickerChild> YarnBagStickerChilds { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Import.BTBOrMarginLCAmendmentRecord> BTBOrMarginLCAmendmentRecords { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Import.ProFormaInvoiceV2PIDetails> ProFormaInvoiceV2PIDetails { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Import.ProFormaInvoiceV2PIDetailsChild> ProFormaInvoiceV2PIDetailsChilds { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Export.SalesContractAmendmentRecord> SalesContractAmendmentRecords { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Export.ExportLCAmendmentRecord> ExportLCAmendmentRecords { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.PIBreakDown.ProFormaInvoiceAccessoriesChild> ProFormaInvoiceAccessoriesChilds { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.PIBreakDown.ProFormaInvoiceGeneralChild> ProFormaInvoiceGeneralChilds { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.PIBreakDown.ProFormaInvoiceFabricChild> ProFormaInvoiceFabricChilds { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Export.ExportInvoiceUpdate> ExportInvoiceUpdates { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Export.ExportInvoiceUpdateShippingInformation> ExportInvoiceUpdateShippingInformations { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Export.PreExportFinance> PreExportFinances { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Export.NonLCExport> NonLCExports { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Export.DocSubmissiontoBuyer> DocSubmissiontoBuyers { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Export.ExportLCEntry> ExportLCEntries { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Export.ExportLCEntryDetails> ExportLCEntryDetails { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Export.SalesContractAmendmentDeails> SalesContractAmendmentDeails { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Export.ExportLCAmendmentDetails> ExportLCAmendmentDetails { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Export.DocSubmissiontoBank> DocSubmissiontoBanks { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Export.DocSubmissiontoBankInvoiceList> DocSubmissiontoBankInvoiceLists { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Export.DocSubmissiontoBankTransactionDetails> DocSubmissiontoBankTransactionDetails { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Export.ExportProceedsRealization> ExportProceedsRealizations { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Export.ExportProceedsRealizationDistributions> ExportProceedsRealizationDistributions { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Export.ExportProceedsRealizationDeductionsatSource> ExportProceedsRealizationDeductionsatSources { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Export.DocSubmissiontoBuyerDetails> DocSubmissiontoBuyerDetails { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Export.ExportProFormaInvoice> ExportProFormaInvoices { get; set; }
        

        public DbSet<GarmentsERP.Model.Commercial.Export.ExportProFormaInvoiceDetails> ExportProFormaInvoiceDetails { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.PurchaseRequisition> PurchaseRequisitions { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.PurchaseRequisitionDetails> PurchaseRequisitionDetails { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.ItemIssueRequisiton> ItemIssueRequisitons { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.ItemDetails> ItemDetails { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.YarnReceive> YarnReceives { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.NewReceiveItem> NewReceiveItems { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.YarnReceiveReturn> YarnReceiveReturns { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.ReturnItem> ReturnItems { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.YarnIssue> YarnIssues { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.NewIssueItem> NewIssueItems { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.ReturnItemInfo> ReturnItemInfoes { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.YarnTransferEntry> YarnTransferEntries { get; set; }
        

        public DbSet<GarmentsERP.Controllers.Inventory.ItemInfo> ItemInfoes { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.YarnOrderToOrderTransferEntry> YarnOrderToOrderTransferEntries { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.YarnOrderToOrderTransferFormOrder> YarnOrderToOrderTransferFormOrders { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.YarnOrderToOrder> YarnOrderToOrders { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.YarnOrderToOrderItemInfo> YarnOrderToOrderItemInfoes { get; set; }
        

        public DbSet<GarmentsERP.Model.Production.KnittingProduction> KnittingProductions { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.YarnBagReceive> YarnBagReceives { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.YarnBagReceiveDetails> YarnBagReceiveDetails { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.GateInEntry> GateInEntries { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.GateInEntryDetails> GateInEntryDetails { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.GatePassEntry> GatePassEntries { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.GatePassEntryItemPart> GatePassEntryItemParts { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.GateOutEntry> GateOutEntries { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.MaterialOrGoodsParking> MaterialOrGoodsParkings { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.MaterialOrGoodsParkingDetails> MaterialOrGoodsParkingDetails { get; set; }
        

        public DbSet<GarmentsERP.Model.Production.CuttingEntry> CuttingEntries { get; set; }
        

        public DbSet<GarmentsERP.Model.Production.CuttingDeliveryToInputChallan> CuttingDeliveryToInputChallans { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.KnitGreyFabricReceive> KnitGreyFabricReceives { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.KnitGreyFabricIssueIssuedNewItem> KnitGreyFabricIssueIssuedNewItems { get; set; }
        

        public DbSet<GarmentsERP.Model.Production.EmbellishmentIssueEntry> EmbellishmentIssueEntries { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.KnitGreyFabricReceiveReturn> KnitGreyFabricReceiveReturns { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.GreyFabricReceiveReturnItemInfo> GreyFabricReceiveReturnItemInfoes { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.KnitGreyFabricRollReceive> KnitGreyFabricRollReceives { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.WovenGreyFabricReceive> WovenGreyFabricReceives { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.WovenGreyFabricReceiveNewEntry> WovenGreyFabricReceiveNewEntries { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.WovenGreyFabricReceiveReturn> WovenGreyFabricReceiveReturns { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.WovenGreyFabricReceiveReturnReturnItemInfo> WovenGreyFabricReceiveReturnReturnItemInfoes { get; set; }
        

        public DbSet<GarmentsERP.Model.Production.EmbellishmentReceiveEntry> EmbellishmentReceiveEntries { get; set; }
        

        public DbSet<GarmentsERP.Model.Production.ActualProductionResourceEntryMaster> ActualProductionResourceEntryMasters { get; set; }
        

        public DbSet<GarmentsERP.Model.Production.ActualProductionResourceEntryChild> ActualProductionResourceEntryChilds { get; set; }
        

        public DbSet<GarmentsERP.Model.Production.SewingInput> SewingInputs { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.KnitGreyFabricIssue> KnitGreyFabricIssues { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.IssuedNewItem> IssuedNewItems { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.GreyFabricOrderToOrderTransferEntry> GreyFabricOrderToOrderTransferEntries { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.GreyFabricOrderToOrderTransferEntryFromOrder> GreyFabricOrderToOrderTransferEntryFromOrders { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.GreyFabricOrderToOrder> GreyFabricOrderToOrders { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.GreyFabricOrderToOrderItemInfo> GreyFabricOrderToOrderItemInfoes { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.GreyFabricRollIssue> GreyFabricRollIssues { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.GreyFabricRollIssueDetails> GreyFabricRollIssueDetails { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.GreyFabricTransferEntry> GreyFabricTransferEntries { get; set; }
        

        public DbSet<GarmentsERP.Model.Inventory.GreyFabricTransferEntryItemInfo> GreyFabricTransferEntryItemInfoes { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Production.SewingOutput> SewingOutputs { get; set; }
        

        public DbSet<GarmentsERP.Model.Production.SewingOutputGrossQty> SewingOutputGrossQties { get; set; }
        

        public DbSet<GarmentsERP.Model.Production.PrintIssueEntrypage> PrintIssueEntrypages { get; set; }
        

        public DbSet<GarmentsERP.Model.Production.PrintReceiveEntrypage> PrintReceiveEntrypages { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.KnitGreyFabricIssueReturn> KnitGreyFabricIssueReturns { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.KnitGreyFabricIssueReturnReturnItemInfo> KnitGreyFabricIssueReturnReturnItemInfoes { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.GreyFabricOrderToSampleTransferEntry> GreyFabricOrderToSampleTransferEntries { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.GreyFabricOrderToSampleTransferEntryFromOrder> GreyFabricOrderToSampleTransferEntryFromOrders { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.GreyFabricOrderToSample> GreyFabricOrderToSamples { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.GreyFabricOrderToSampleItemInfo> GreyFabricOrderToSampleItemInfoes { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.GreyFabricSampleToOrderTransferEntry> GreyFabricSampleToOrderTransferEntries { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.GreyFabricSampleToOrderTransferEntryFromSample> GreyFabricSampleToOrderTransferEntryFromSamples { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.GreyFabricSampleToOrder> GreyFabricSampleToOrders { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.GreyFabricSampleToOrderItemInfo> GreyFabricSampleToOrderItemInfoes { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.RollWiseGreyFabricTransferEntry> RollWiseGreyFabricTransferEntries { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.GreyFabricIssueReturnRollWiseDetails> GreyFabricIssueReturnRollWiseDetails { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.RollwiseGreyFabricOrderToOrderTransferEntry> RollwiseGreyFabricOrderToOrderTransferEntries { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.RollWiseGreyFabricOrderToOrderFromOrder> RollWiseGreyFabricOrderToOrderFromOrders { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.RollWiseGreyFabricOrderToOrder> RollWiseGreyFabricOrderToOrders { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.RollwiseGreyFabricOrderToOrderTransferEntryDetails> RollwiseGreyFabricOrderToOrderTransferEntryDetails { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.GreyFabricIssueReturnRollWise> GreyFabricIssueReturnRollWises { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.GreyFabricIssueDetails> GreyFabricIssueDetails { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.RollwiseGreyFabricOrderToSampleTransfer> RollwiseGreyFabricOrderToSampleTransfers { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.RollwiseGreyFabricOrderToSampleFromOrder> RollwiseGreyFabricOrderToSampleFromOrders { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.RollwiseGreyFabricOrderToSample> RollwiseGreyFabricOrderToSamples { get; set; }
        

        //blow Done
        

        public DbSet<GarmentsERP.Model.Inventory.RollwiseGreyFabricOrderToSampleDetails> RollwiseGreyFabricOrderToSampleDetails { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.RollwiseGreyFabricSampleToOrder> RollwiseGreyFabricSampleToOrders { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.RollwiseGreyFabricSampleToSample> RollwiseGreyFabricSampleToSamples { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.RollwiseGreyFabricSampleFromSample> RollwiseGreyFabricSampleFromSamples { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.RollwiseGreyFabricSampleToSampleTransfer> RollwiseGreyFabricSampleToSampleTransfers { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.RollwiseGreyFabricSampleToSampleDetails> RollwiseGreyFabricSampleToSampleDetails { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.RollwiseGreyFabricSampleToOrderDetails> RollwiseGreyFabricSampleToOrderDetails { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.RollwiseGreyFabricSampleToOrderFromSample> RollwiseGreyFabricSampleToOrderFromSamples { get; set; }
        


        

        public DbSet<GarmentsERP.Model.Inventory.RollwiseGreyFabricSampleToOrderTransfer> RollwiseGreyFabricSampleToOrderTransfers { get; set; }
        


        









        public DbSet<GarmentsERP.Model.Production.ExFactory> ExFactories { get; set; }
        public DbSet<GarmentsERP.Model.Production.Ironentry> Ironentries { get; set; }
        public DbSet<GarmentsERP.Model.Production.PackingAndFinishing> PackingAndFinishings { get; set; }
        public DbSet<GarmentsERP.Model.Production.BuyerInspection> BuyerInspections { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.FinishFabricRollReceiveByStore> FinishFabricRollReceiveByStores { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.FinishFabricRollReceiveByStoreDetails> FinishFabricRollReceiveByStoreDetails { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.WovenFinishFabricRollIssue> WovenFinishFabricRollIssues { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.WovenFinishFabricRollIssueDetails> WovenFinishFabricRollIssueDetails { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.FinishFabricRollIssue> FinishFabricRollIssues { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.FinishFabricRollIssueDetails> FinishFabricRollIssueDetails { get; set; }
        public DbSet<GarmentsERP.Model.Production.GarmentsDeliveryEntry> GarmentsDeliveryEntries { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.WovenFinishFabricReceive> WovenFinishFabricReceives { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.WovenFinishFabricNewReceiveItem> WovenFinishFabricNewReceiveItems { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.KnitFinishFabricIssue> KnitFinishFabricIssues { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.KnitFinishFabricIssueNewEntry> KnitFinishFabricIssueNewEntries { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.FinishRollSplittingBeforeIssue> FinishRollSplittingBeforeIssues { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.FinishRollSplittingBeforeIssueDetails> FinishRollSplittingBeforeIssueDetails { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.WovenFinishFabricIssue> WovenFinishFabricIssues { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.WovenFinishFabricIssueNewEntry> WovenFinishFabricIssueNewEntries { get; set; }
        public DbSet<GarmentsERP.Model.Production.GarmentsExFactoryReturn> GarmentsExFactoryReturns { get; set; }
        public DbSet<GarmentsERP.Model.Production.PolyEntry> PolyEntries { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.FinishFabricTransferEntry> FinishFabricTransferEntries { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.FinishFabricTransferEntryItemInfo> FinishFabricTransferEntryItemInfoes { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.FinishFabricOrderToOrderTransferEntry> FinishFabricOrderToOrderTransferEntries { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.FinishFabricOrderToOrder> FinishFabricOrderToOrders { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.FinishFabricOrderToOrderItemInfo> FinishFabricOrderToOrderItemInfoes { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.FinishFabricOrderToOrderFromOrder> FinishFabricOrdFinishFabricOrderToOrderFromOrderserToOrderFromOrders { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.FinishRollIssueReturn> FinishRollIssueReturns { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.FinishRollIssueReturnDetails> FinishRollIssueReturnDetails { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.WovenFinishRollIssueReturn> WovenFinishRollIssueReturns { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.WovenFinishRollIssueReturnDetails> WovenFinishRollIssueReturnDetails { get; set; }
        public DbSet<GarmentsERP.Model.Admin.UserCredentials> UserCredentials { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.RollWiseFinishFabricOrderToOrderTransferEntry> RollWiseFinishFabricOrderToOrderTransferEntries { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.RollWiseFinishFabricOrderToOrder> RollWiseFinishFabricOrderToOrders { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.RollWiseFinishFabricOrderToOrderFromOrder> RollWiseFinishFabricOrderToOrderFromOrders { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.RollWiseFinishFabricOrderToOrderDetails> RollWiseFinishFabricOrderToOrderDetails { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.RollWiseFinishFabricSampleToSampleTransferEntry> RollWiseFinishFabricSampleToSampleTransferEntry { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.RollWiseFinishFabricSampleToSampleFromSample> RollWiseFinishFabricSampleToSampleFromSamples { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.RollWiseFinishFabricSampleToSample> RollWiseFinishFabricSampleToSamples { get; set; }
        public DbSet<GarmentsERP.Model.Admin.MenuManagement> MenuManagements { get; set; }
        public DbSet<GarmentsERP.Model.Admin.PrivilegeManagement> PrivilegeManagements { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.RollWiseFinishFabricSampleToSamplDetails> RollWiseFinishFabricSampleToSamplDetails { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.TrimsReceiveEntryMultiRef> TrimsReceiveEntryMultiRefs { get; set; }
        //Done done
        public DbSet<GarmentsERP.Model.Inventory.TrimsReceiveEntryMultiRefNewEntry> TrimsReceiveReturnEntries { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.TrimsReceiveReturnEntry> TrimsReceiveReturnEntry { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.TrimsReceiveReturnEntryReturnItemInfo> TrimsReceiveReturnEntryReturnItemInfoes { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.TrimsIssue> TrimsIssues { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.TrimsIssueNewEntry> TrimsIssueNewEntries { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.TrimsIssueDisplay> TrimsIssueDisplays { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.TrimsIssueReturn> TrimsIssueReturns { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.TrimsIssueReturnNewEntry> TrimsIssueReturnNewEntries { get; set; }
        //done
        public DbSet<GarmentsERP.Model.Inventory.TrimsOrderToOrderTransferEntry> TrimsOrderToOrderTransferEntries { get; set; }

        public DbSet<GarmentsERP.Model.Inventory.TrimsOrderToOrder> TrimsOrderToOrders { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.TrimsOrderToOrderFromOrder> TrimsOrderToOrderFromOrders { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.TrimsOrderToOrderItemInfo> TrimsOrderToOrderItemInfoes { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.TrimsTransferEntry> TrimsTransferEntries { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.TrimsTransferEntryItemInfo> TrimsTransferEntryItemInfoes { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.TrimsIssueMultiRef> TrimsIssueMultiRefs { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.TrimsIssueMultiRefDetails> TrimsIssueMultiRefDetails { get; set; }
        public DbSet<GarmentsERP.Model.Admin.LoginHistory> LoginHistories { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.GeneralAccessories> GeneralAccessories { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.GeneralAccessoriesNewReceiveItem> GeneralAccessoriesNewReceiveItems { get; set; }


        public DbSet<GarmentsERP.Model.Inventory.SparePartsAndMachineries> SparePartsAndMachineries { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.SparePartsAndMachineriesNewReceiveItem> SparePartsAndMachineriesNewReceiveItemS { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.Stationeries> Stationeries { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.StationeriesNewReceiveItem> StationeriesNewReceiveItems { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.Electrical> Electricals { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.ElectricalNewReceiveItem> ElectricalNewReceiveItems { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.Maintenance> Maintenances { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.MaintenanceNewReceiveItem> MaintenanceNewReceiveItems { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.Medical> Medicals { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.MedicalNewReceiveItem> MedicalNewReceiveItems { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.ICT> ICTs { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.ICTNewReceiveItem> ICTNewReceiveItems { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.UtilitiesAndLubricants> UtilitiesAndLubricants { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.UtilitiesAndLubricantsNewReceiveItem> UtilitiesAndLubricantsNewReceiveItems { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.ConstructionMaterials> ConstructionMaterials { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.ConstructionMaterialsNewReceiveItem> ConstructionMaterialsNewReceiveItems { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.PrintingChemicalsAndDyes> PrintingChemicalsAndDyes { get; set; }

        public DbSet<GarmentsERP.Model.Inventory.PrintingChemicalsAndDyesNewReceiveItem> PrintingChemicalsAndDyesNewReceiveItems { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.GeneralItemReceiveReturn> GeneralItemReceiveReturns { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.GeneralItemReceiveNewReceiveItem> GeneralItemReceiveNewReceiveItems { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.GeneralAccessoriesGeneralItemIssue> GeneralAccessoriesGeneralItemIssues { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.GeneralAccessoriesGeneralItemIssueNewIssueItem> GeneralAccessoriesGeneralItemIssueNewIssueItems { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.SparePartsandMachineriesGeneralItemIssue> SparePartsandMachineriesGeneralItemIssues { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.SparePartsandMachineriesNewIssueItem> SparePartsandMachineriesNewIssueItems { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.StationeriesGeneralItemIssueNewIssueItem> StationeriesGeneralItemIssueNewIssueItems { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.StationeriesGeneralItemIssue> StationeriesGeneralItemIssues { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.ElectricalGeneralItemIssue> ElectricalGeneralItemIssues { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.ElectricalGeneralItemIssueNewIssueItem> ElectricalGeneralItemIssueNewIssueItems { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.MaintenanceGeneralItemIssue> MaintenanceGeneralItemIssues { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.MaintenanceGeneralItemIssueNewIssueItem> MaintenanceGeneralItemIssueNewIssueItems { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.MedicalGeneralItemIssue> MedicalGeneralItemIssues { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.MedicalGeneralItemIssueNewIssueItem> MedicalGeneralItemIssueNewIssueItems { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.ICTGeneralItemIssue> ICTGeneralItemIssues { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.ICTGeneralItemIssueNewIssueItem> ICTGeneralItemIssueNewIssueItems { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.UtilitiesAndLubricantsGeneralItemIssue> UtilitiesAndLubricantsGeneralItemIssues { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.UtilitiesAndLubricantsGeneralItemIssueNewIssueItem> UtilitiesAndLubricantsGeneralItemIssueNewIssueItems { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.ConstructionMaterialsGeneralItemIssue> ConstructionMaterialsGeneralItemIssues { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.ConstructionMaterialsGeneralItemIssueNewIssueItem> ConstructionMaterialsGeneralItemIssueNewIssueItems { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.PrintingChemicalsAndDyesGeneralItemIssue> PrintingChemicalsAndDyesGeneralItemIssues { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.PrintingChemicalsAndDyesGeneralItemIssueNewIssueItem> PrintingChemicalsAndDyesGeneralItemIssueNewIssueItems { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.GeneralItemIssue> GeneralItemIssues { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.GeneralItemIssueGeneralNewIssueItem> GeneralItemIssueGeneralNewIssueItems { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.GeneralItemReceive> GeneralItemReceives { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.GeneralItemReceiveGeneralNewReceiveItem> GeneralItemReceiveGeneralNewReceiveItems { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.GeneralItemTransfer> GeneralItemTransfers { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.GeneralItemTransferItemInfo> GeneralItemTransferItemInfoes { get; set; }
        public DbSet<GarmentsERP.Model.Admin.MenuMain> MenuMains { get; set; }
        public DbSet<GarmentsERP.Model.Admin.MenuSub> MenuSubs { get; set; }
        public DbSet<GarmentsERP.Model.Admin.MenuSubSub> MenuSubSubs { get; set; }
        public DbSet<GarmentsERP.Model.Admin.MenuSubSubSub> MenuSubSubSubs { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.GeneralItemIssueReturn> GeneralItemIssueReturns { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.GeneralItemIssueReturnReturnItemInfo> GeneralItemIssueReturnReturnItemInfoes { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.ScrapOutEntry> ScrapOutEntries { get; set; }
        public DbSet<GarmentsERP.Model.Inventory.ScrapOutEntryNewEntry> ScrapOutEntryNewEntries { get; set; }
        public DbSet<GarmentsERP.Model.TNA.TNATemplateEntry> TNATemplateEntries { get; set; }
        public DbSet<GarmentsERP.Model.TNA.TNATemplateEntryDetails> TNATemplateEntryDetails { get; set; }
        public DbSet<GarmentsERP.Model.TNA.TNAUpdateEntry> TNAUpdateEntries { get; set; }
        public DbSet<GarmentsERP.Model.MarchandisingModule.PriceQuotations.PriceQuotation> PriceQuotations { get; set; }



        public DbSet<GarmentsERP.Model.MarchandisingModule.PriceQuotation.PrcQutnCostComponentsMaster> PrcQutnCostComponentsMasters { get; set; }
        public DbSet<GarmentsERP.Model.MarchandisingModule.StripColors> StripColors { get; set; }
        public DbSet<GarmentsERP.Model.MarchandisingModule.PartialFabricBookingItemDtlsChild> PartialFabricBookingItemDtlsChilds { get; set; }
        public DbSet<GarmentsERP.Model.MarchandisingModule.TrimsBookingItemDtlsChild> TrimsBookingItemDtlsChilds { get; set; }
        public DbSet<GarmentsERP.Model.MarchandisingModule.EmbellishmentWODetailsChild> EmbellishmentWODetailsChilds { get; set; }
        public DbSet<GarmentsERP.Model.MarchandisingModule.ShortTrimsBookingItemDtlsChild> ShortTrimsBookingItemDtlsChilds { get; set; }
        public DbSet<GarmentsERP.Model.MarchandisingModule.AopServiceBookingItemForm> AopServiceBookingItemForms { get; set; }

        public DbSet<GarmentsERP.Model.Commercial.Export.ExportInformationDetails> ExportInformationDetails { get; set; }
        public DbSet<GarmentsERP.Model.Commercial.Export.ExportInformationDetailsSub> ExportInformationDetailsSubs { get; set; }
        public DbSet<GarmentsERP.Model.Commercial.Export.ReplacementLCForm> ReplacementLCForms { get; set; }
        public DbSet<GarmentsERP.Model.Commercial.Import.PiYarnInfoDetails> PiYarnInfoDetails { get; set; }
        public DbSet<GarmentsERP.Model.Commercial.Import.PiAccessoriesDetails> PiAccessoriesDetails { get; set; }
        public DbSet<GarmentsERP.Model.Commercial.Import.PiEmbellismentDetails> PiEmbellismentDetails { get; set; }


        public DbSet<GarmentsERP.Model.Commercial.Import.PiKnitFinishFabric> PiKnitFinishFabrics { get; set; }
        public DbSet<GarmentsERP.Model.Commercial.Import.PiWovenFabricDetails> PiWovenFabricDetails { get; set; }
        public DbSet<GarmentsERP.Model.Commercial.Import.PiAllOverPrint> PiAllOverPrints { get; set; }
        public DbSet<GarmentsERP.Model.Commercial.Import.PiYarnDyeing> PiYarnDyeings { get; set; }
        public DbSet<GarmentsERP.Model.Commercial.Import.PiFabric> PiFabrics { get; set; }
        public DbSet<MarchandisingModule.FabricColorSensitivity> FabricColorSensitivity { get; set; }
        public DbSet<StaticFabricSource> StaticFabricSource { get; set; }

        // public DbSet<FabricColorSensitivity> FabricColorSensitivity { get; set; }
        // Hrm Contex
        //public virtual DbSet<GarmentsERP.Model.HRM.HrmAttendance> HrmAttendances { get; set; }
        //public virtual DbSet<GarmentsERP.Model.HRM.ChangeTrackerHrmAttendance> ChangeTrackerHrmAttendances { get; set; }
        //public virtual DbSet<GarmentsERP.Model.HRM.HrmAttendanceFT> HrmAttendancesFT { get; set; }
        //public virtual DbSet<GarmentsERP.Model.HRM.HrmEmployee> HrmEmployees { get; set; }

        ///////////////
        ///

        //public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<ApprovalStatu> ApprovalStatus { get; set; }
        public virtual DbSet<BankLoan> BankLoan { get; set; }
        public virtual DbSet<CartoonConsumption> CartoonConsumptions { get; set; }
        public virtual DbSet<CartoonMeasurmentTrimsCon> CartoonMeasurmentTrimsCons { get; set; }
        public virtual DbSet<CollarNCuff> CollarNCuffs { get; set; }

        //public virtual DbSet<ColorRanx> ColorRanges
        public virtual DbSet<CommercialConverstionOrThirdTbl> CommercialConverstionOrThirdTbls { get; set; }
        public virtual DbSet<CommersialCommissionCost> CommersialCommissionCosts { get; set; }
        public virtual DbSet<ConversionCostChargeOrUnit> ConversionCostChargeOrUnits { get; set; }
        public virtual DbSet<CurrierCost> CurrierCosts { get; set; }
        public virtual DbSet<ExtraCommercialCost> ExtraCommercialCosts { get; set; }
        public virtual DbSet<FCBRStatementEntry> FCBRStatementEntries { get; set; }
        public virtual DbSet<FileActivitesNdHistory> FileActivitesNdHistories { get; set; }
        public virtual DbSet<LabTest> LabTests { get; set; }
        public virtual DbSet<LcEntryNBtbLcCommunicator> LcEntryNBtbLcCommunicators { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<ParticularType> ParticularTypes { get; set; }
        public virtual DbSet<PaymentBankLoan> PaymentBankLoans { get; set; }
        public virtual DbSet<PiAcceptance> PiAcceptances { get; set; }
        public virtual DbSet<PiEntryFromWo> PiEntryFromWoes { get; set; }
        public virtual DbSet<ServiceBookingAllChildDetail> ServiceBookingAllChildDetails { get; set; }
        public virtual DbSet<ServiceBookingAllMasterDtl> ServiceBookingAllMasterDtls { get; set; }
        public virtual DbSet<SewingThredConsumption> SewingThredConsumptions { get; set; }
        public virtual DbSet<StaticValueExtraCommercialCost> StaticValueExtraCommercialCosts { get; set; }
        public virtual DbSet<StaticValueOfCommersialCommissionCost> StaticValueOfCommersialCommissionCosts { get; set; }
        public virtual DbSet<TrimsMeasurmentAllItemGroup> TrimsMeasurmentAllItemGroups { get; set; }
        public virtual DbSet<YarnConsOptimaizationStripeColor> YarnConsOptimaizationStripeColors { get; set; }
        public virtual DbSet<FabricColorSensitivity1> FabricColorSensitivities1 { get; set; }
        public virtual DbSet<StaticCommercialCostName> StaticCommercialCostNames { get; set; }
        public virtual DbSet<StaticEmbelName> StaticEmbelNames { get; set; }
        public virtual DbSet<StaticSampleName> StaticSampleNames { get; set; }
        //public virtual DbSet<AddPrecostingJobSelectionView> AddPrecostingJobSelectionViews { get; set; }
        //public virtual DbSet<CommercialJobSelectionView> CommercialJobSelectionViews { get; set; }
        //public virtual DbSet<ImportDocumentAccptance_Views> ImportDocumentAccptance_Views { get; set; }
        //public virtual DbSet<MultipleJobWiseEmbelsTblView> MultipleJobWiseEmbelsTblViews { get; set; }
        //public virtual DbSet<PiEbellishmentMaster_view> PiEbellishmentMaster_view { get; set; }
        //public virtual DbSet<PiTrimsMaster_view> PiTrimsMaster_view { get; set; }
        //public virtual DbSet<PiYarnMaster_view> PiYarnMaster_view { get; set; }
        //public virtual DbSet<PrecostingView> PrecostingViews { get; set; }
        //public virtual DbSet<ProformaModal_view> ProformaModal_view { get; set; }
        //public virtual DbSet<View_BankLoan> View_BankLoan { get; set; }
        //public virtual DbSet<View_BtbMarginLc> View_BtbMarginLc { get; set; }
        //public virtual DbSet<View_BuyerProfile> View_BuyerProfile { get; set; }
        //public virtual DbSet<View_FabricCost> View_FabricCost { get; set; }
        //public virtual DbSet<View_fabricCostConsumption> View_fabricCostConsumption { get; set; }
        //public virtual DbSet<View_PartialFabricBookingItemDtlsChilds> View_PartialFabricBookingItemDtlsChilds { get; set; }
        //public virtual DbSet<View_PaymentBankLoan> View_PaymentBankLoan { get; set; }
        //public virtual DbSet<View_SupplierProfiles> View_SupplierProfiles { get; set; }
    }
}

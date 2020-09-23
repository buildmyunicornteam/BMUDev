using BuildMyUnicorn.Business_Layer;
using Model_Layer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Model_Layer.Helper;

namespace BuildMyUnicorn.Controllers
{
    public class IdeaController : Controller
    {
        [Authorize]
        public ActionResult Index(string IdeaID)
        {
           // DownloadPDF();
            ViewBag.IsEdit = false;
            if (string.IsNullOrEmpty(IdeaID))
            {
                IdeaViewModel Model = new IdeaManager().GetClientIdea();
                if (Model == null)
                {
                    ViewBag.IsEdit = true;
                }
            }
            else
            {
                ViewBag.IsEdit = true;
            }

            return View();



        }

        public ActionResult Create()
        {
            ViewBag.ProductDemandList = new List<ProductDemand> {
                    new ProductDemand { ID=1, Value="Yes"},
                    new ProductDemand { ID=2, Value="No"},
                    new ProductDemand { ID=3, Value="I dont know"}
                };
            ViewBag.InMarketAlreadyList = new List<InMarketAlready> {
                    new InMarketAlready { ID=1, Value="Something very similar"},
                    new InMarketAlready { ID=2, Value="Nothing at all"},
                    new InMarketAlready { ID=3, Value="Nothing quite like it"},
                    new InMarketAlready { ID=4, Value="Maybe something I have not found"}
                };
            ViewBag.ScalableList = new List<Scalable> {
                    new Scalable { ID=1, Value="scalable to meet a surge in demand"},
                    new Scalable { ID=2, Value="The first version will not be able to scale"},
                    new Scalable { ID=3, Value="To early to talk about scaling"}

                };
            ViewBag.EndGoalList = new List<EndGoal> {
                    new EndGoal { ID=1, Value="To be rich"},
                    new EndGoal { ID=2, Value="To work for myself"},
                    new EndGoal { ID=3, Value="To Change the world"},
                    new EndGoal { ID=4, Value="For the challenge"},
                    new EndGoal { ID=5, Value="Personal"}
                };
            ViewBag.CompanySetupList = new List<CompanySetup> {
                    new CompanySetup { ID=1, Value="Yes"},
                    new CompanySetup { ID=2, Value="No"}

                };
            ViewBag.CofounderList = new List<Cofounder> {
                    new Cofounder { ID=1, Value="Yes"},
                    new Cofounder { ID=2, Value="No"}

                };
            ViewBag.SupportTechnicallyList = new List<SupportTechnically> {
                    new SupportTechnically { ID=1, Value="Yes"},
                    new SupportTechnically { ID=2, Value="No"},
                    new SupportTechnically { ID=3, Value="I am the Tech Support"}

                };
            ViewBag.BuildFromList = new List<BuildFrom> {
                    new BuildFrom { ID=1, Value="I am"},
                    new BuildFrom { ID=2, Value="Get a development company"},
                    new BuildFrom { ID=3, Value="Hire a freelancer"},
                    new BuildFrom { ID=4, Value="Other"}
                };
            ViewBag.SellToList = new List<SellTo> {
                    new SellTo { ID=1, Value="B2B"},
                    new SellTo { ID=2, Value="B2C"},
                    new SellTo { ID=4, Value="Other"}
                };

            ViewBag.SaleStaffPlanList = new List<SaleStaffPlan> {
                    new SaleStaffPlan { ID=1, Value="Yes"},
                    new SaleStaffPlan { ID=2, Value="No"},
                    new SaleStaffPlan { ID=3, Value="Eventually"}

                };
            ViewBag.BusinessCostLList = new List<BusinessCost> {
                    new BusinessCost { ID=1, Value="0 – 1000"},
                    new BusinessCost { ID=2, Value="1001-5000"},
                    new BusinessCost { ID=3, Value="5001- 10000"},
                    new BusinessCost { ID=3, Value="10001 – 20000"},
                    new BusinessCost { ID=3, Value="20001 – 50000"},
                    new BusinessCost { ID=3, Value="50001 – 100000"},
                    new BusinessCost { ID=3, Value="100000 +"}
                };

            ViewBag.MasterStartup = new Master().GetMasterByTableName(new Startup().TableName);
            ViewBag.MasterTechnology = new Master().GetMasterByTableName(new Technology().TableName);
            ViewBag.MasterSelling = new Master().GetMasterByTableName(new Selling().TableName);
            ViewBag.MasterCharge = new Master().GetMasterByTableName(new Charge().TableName);
            ViewBag.MasterMoneyRasie = new Master().GetMasterByTableName(new MoneyRasie().TableName);
            IdeaViewModel Model = new IdeaManager().GetClientIdea();
            Idea obj = new Idea();
            if (Model != null)
            {
                obj.IdeaExplain = Model.IdeaExplain;
                obj.IdeaID = Model.IdeaID;
                obj.ProgressValue = Model.ProgressValue;
                AboutYou Aboutyouobj = new AboutYou();
                Company Companyobj = new Company();
                IdeaBreakDown IdeaBreakDownobj = new IdeaBreakDown();
                IdeaSelling IdeaSellingobj = new IdeaSelling();
                Money Moneyobj = new Money();
                IdeaBreakDownobj.StartupType = Model.StartupType;
                IdeaBreakDownobj.StartupTechnology = Model.StartupTechnology;
                IdeaBreakDownobj.ProblemSolve = Model.ProblemSolve;
                IdeaBreakDownobj.ProblemSolver = Model.ProblemSolver;
                IdeaBreakDownobj.FeedBackReceived = Model.FeedBackReceived;
                IdeaBreakDownobj.FeedBackFrom = Model.FeedBackFrom;
                IdeaBreakDownobj.ProductDemand = Model.ProductDemand;
                IdeaBreakDownobj.Niche = Model.Niche;
                IdeaBreakDownobj.InMarketAlready = Model.InMarketAlready;
                IdeaBreakDownobj.SpaceExist = Model.SpaceExist;
                IdeaBreakDownobj.Scalable = Model.Scalable;

                Aboutyouobj.Entrepreneur = Model.Entrepreneur;
                Aboutyouobj.YearsDoing = Model.YearsDoing;
                Aboutyouobj.Experience = Model.Experience;
                Aboutyouobj.Priorities = Model.Priorities;
                Aboutyouobj.EndGoal = Model.EndGoal;


                Companyobj.CompanySetup = Model.CompanySetup;
                Companyobj.CompanyName = Model.CompanyName;
                Companyobj.DomainName = Model.DomainName;
                Companyobj.HaveGotDomain = Model.HaveGotDomain;
                Companyobj.Cofounder = Model.Cofounder;
                Companyobj.SupportTechnically = Model.SupportTechnically;
                Companyobj.BuildFrom = Model.BuildFrom;
                Companyobj.BrandThought = Model.BrandThought;
                Companyobj.CompanyMission = Model.CompanyMission;
                Companyobj.CompanyLookFeel = Model.CompanyLookFeel;




                IdeaSellingobj.SellType = Model.SellType;
                IdeaSellingobj.ProductBuy = Model.ProductBuy;
                IdeaSellingobj.ProductCharge = Model.ProductCharge;
                IdeaSellingobj.ChargeGoing = Model.ChargeGoing;
                IdeaSellingobj.SellTo = Model.SellTo;
                IdeaSellingobj.CustomerFindPlan = Model.CustomerFindPlan;
                IdeaSellingobj.SaleStaffPlan = Model.SaleStaffPlan;

                Moneyobj.BusinessCost = Model.BusinessCost;
                Moneyobj.Affort = Model.Affort;
                Moneyobj.MoneyRaisePlan = Model.MoneyRaisePlan;
                Moneyobj.ProfitableMake = Model.ProfitableMake;
                Moneyobj.ProfitableThinkTime = Model.ProfitableThinkTime;



                obj.AboutYou = Aboutyouobj;
                obj.Company = Companyobj;
                obj.IdeaBreakDown = IdeaBreakDownobj;
                obj.IdeaSelling = IdeaSellingobj;
                ViewBag.ActionType = "UPDATE";
                obj.Money = Moneyobj;

            }
            else
            {

                obj.AboutYou = new AboutYou();
                obj.Company = new Company();
                obj.IdeaBreakDown = new IdeaBreakDown();
                obj.IdeaSelling = new IdeaSelling();
                obj.Money = new Money();
            }

            return PartialView("_CreateIdeaPartial", obj);
        }

        public ActionResult Detail()
        {

            /// Temporary List
            ViewBag.ProductDemandList = new List<ProductDemand> {
                    new ProductDemand { ID=1, Value="Yes"},
                    new ProductDemand { ID=2, Value="No"},
                    new ProductDemand { ID=3, Value="I dont know"}
                };
            ViewBag.InMarketAlreadyList = new List<InMarketAlready> {
                    new InMarketAlready { ID=1, Value="Something very similar"},
                    new InMarketAlready { ID=2, Value="Nothing at all"},
                    new InMarketAlready { ID=3, Value="Nothing quite like it"},
                    new InMarketAlready { ID=4, Value="Maybe something I have not found"}
                };
            ViewBag.ScalableList = new List<Scalable> {
                    new Scalable { ID=1, Value="scalable to meet a surge in demand"},
                    new Scalable { ID=2, Value="The first version will not be able to scale"},
                    new Scalable { ID=3, Value="To early to talk about scaling"}

                };
            ViewBag.EndGoalList = new List<EndGoal> {
                    new EndGoal { ID=1, Value="To be rich"},
                    new EndGoal { ID=2, Value="To work for myself"},
                    new EndGoal { ID=3, Value="To Change the world"},
                    new EndGoal { ID=4, Value="For the challenge"},
                    new EndGoal { ID=5, Value="Personal"}
                };
            ViewBag.CompanySetupList = new List<CompanySetup> {
                    new CompanySetup { ID=1, Value="Yes"},
                    new CompanySetup { ID=2, Value="No"}

                };
            ViewBag.CofounderList = new List<Cofounder> {
                    new Cofounder { ID=1, Value="Yes"},
                    new Cofounder { ID=2, Value="No"}

                };
            ViewBag.SupportTechnicallyList = new List<SupportTechnically> {
                    new SupportTechnically { ID=1, Value="Yes"},
                    new SupportTechnically { ID=2, Value="No"},
                    new SupportTechnically { ID=3, Value="I am the Tech Support"}

                };
            ViewBag.BuildFromList = new List<BuildFrom> {
                    new BuildFrom { ID=1, Value="I am"},
                    new BuildFrom { ID=2, Value="Get a development company"},
                    new BuildFrom { ID=3, Value="Hire a freelancer"},
                    new BuildFrom { ID=4, Value="Other"}
                };
            ViewBag.SellToList = new List<SellTo> {
                    new SellTo { ID=1, Value="B2B"},
                    new SellTo { ID=2, Value="B2C"},
                    new SellTo { ID=4, Value="Other"}
                };
            ViewBag.SaleStaffPlanList = new List<SaleStaffPlan> {
                    new SaleStaffPlan { ID=1, Value="Yes"},
                    new SaleStaffPlan { ID=2, Value="No"},
                    new SaleStaffPlan { ID=3, Value="Eventually"}

                };
            ViewBag.BusinessCostLList = new List<BusinessCost> {
                    new BusinessCost { ID=1, Value="0 – 1000"},
                    new BusinessCost { ID=2, Value="1001-5000"},
                    new BusinessCost { ID=3, Value="5001- 10000"},
                    new BusinessCost { ID=3, Value="10001 – 20000"},
                    new BusinessCost { ID=3, Value="20001 – 50000"},
                    new BusinessCost { ID=3, Value="50001 – 100000"},
                    new BusinessCost { ID=3, Value="100000 +"}
                };

            /// Temporary List
            /// Temporary Checkbox Vales
            ViewBag.MasterStartup = new Master().GetMasterByTableName(new Startup().TableName);
            ViewBag.MasterTechnology = new Master().GetMasterByTableName(new Technology().TableName);
            ViewBag.MasterSelling = new Master().GetMasterByTableName(new Selling().TableName);
            ViewBag.MasterCharge = new Master().GetMasterByTableName(new Charge().TableName);
            ViewBag.MasterMoneyRasie = new Master().GetMasterByTableName(new MoneyRasie().TableName);

            /// Temporary Checkbox Vales
            IdeaViewModel Model = new IdeaManager().GetClientIdea();
            Idea obj = new Idea();
            obj.IdeaExplain = Model.IdeaExplain;
            obj.IdeaID = Model.IdeaID;
            AboutYou Aboutyouobj = new AboutYou();
            Company Companyobj = new Company();
            IdeaBreakDown IdeaBreakDownobj = new IdeaBreakDown();
            IdeaSelling IdeaSellingobj = new IdeaSelling();
            Money Moneyobj = new Money();
            IdeaBreakDownobj.StartupType = Model.StartupType;
            IdeaBreakDownobj.StartupTechnology = Model.StartupTechnology;
            IdeaBreakDownobj.ProblemSolve = Model.ProblemSolve;
            IdeaBreakDownobj.ProblemSolver = Model.ProblemSolver;
            IdeaBreakDownobj.FeedBackReceived = Model.FeedBackReceived;
            IdeaBreakDownobj.FeedBackFrom = Model.FeedBackFrom;
            IdeaBreakDownobj.ProductDemand = Model.ProductDemand;
            IdeaBreakDownobj.Niche = Model.Niche;
            IdeaBreakDownobj.InMarketAlready = Model.InMarketAlready;
            IdeaBreakDownobj.SpaceExist = Model.SpaceExist;
            IdeaBreakDownobj.Scalable = Model.Scalable;

            Aboutyouobj.Entrepreneur = Model.Entrepreneur;
            Aboutyouobj.YearsDoing = Model.YearsDoing;
            Aboutyouobj.Experience = Model.Experience;
            Aboutyouobj.Priorities = Model.Priorities;
            Aboutyouobj.EndGoal = Model.EndGoal;


            Companyobj.CompanySetup = Model.CompanySetup;
            Companyobj.CompanyName = Model.CompanyName;
            Companyobj.DomainName = Model.DomainName;
            Companyobj.Cofounder = Model.Cofounder;
            Companyobj.SupportTechnically = Model.SupportTechnically;
            Companyobj.BuildFrom = Model.BuildFrom;
            Companyobj.BrandThought = Model.BrandThought;
            Companyobj.CompanyMission = Model.CompanyMission;
            Companyobj.CompanyLookFeel = Model.CompanyLookFeel;




            IdeaSellingobj.SellType = Model.SellType;
            IdeaSellingobj.ProductBuy = Model.ProductBuy;
            IdeaSellingobj.ProductCharge = Model.ProductCharge;
            IdeaSellingobj.ChargeGoing = Model.ChargeGoing;
            IdeaSellingobj.SellTo = Model.SellTo;
            IdeaSellingobj.CustomerFindPlan = Model.CustomerFindPlan;
            IdeaSellingobj.SaleStaffPlan = Model.SaleStaffPlan;

            Moneyobj.BusinessCost = Model.BusinessCost;
            Moneyobj.Affort = Model.Affort;
            Moneyobj.MoneyRaisePlan = Model.MoneyRaisePlan;
            Moneyobj.ProfitableMake = Model.ProfitableMake;
            Moneyobj.ProfitableThinkTime = Model.ProfitableThinkTime;



            obj.AboutYou = Aboutyouobj;
            obj.Company = Companyobj;
            obj.IdeaBreakDown = IdeaBreakDownobj;
            obj.IdeaSelling = IdeaSellingobj;
            obj.Money = Moneyobj;

            return PartialView("_DetailIdeaPartial", obj);
        }

        public string AddNewIdea(Idea model)
        {

            return new IdeaManager().AddNewIdea(model);
        }

        public string UpdateIdea(Idea model)
        {

            return new IdeaManager().UpdateIdea(model);
        }


        public void DownloadPDF()
        {
            IdeaViewModel Model = new IdeaManager().GetClientIdea();
            Idea obj = new Idea();
            obj.IdeaExplain = Model.IdeaExplain;
            obj.IdeaID = Model.IdeaID;
            AboutYou Aboutyouobj = new AboutYou();
            Company Companyobj = new Company();
            IdeaBreakDown IdeaBreakDownobj = new IdeaBreakDown();
            IdeaSelling IdeaSellingobj = new IdeaSelling();
            Money Moneyobj = new Money();
            IdeaBreakDownobj.StartupType = Model.StartupType;
            IdeaBreakDownobj.StartupTechnology = Model.StartupTechnology;
            IdeaBreakDownobj.ProblemSolve = Model.ProblemSolve;
            IdeaBreakDownobj.ProblemSolver = Model.ProblemSolver;
            IdeaBreakDownobj.FeedBackReceived = Model.FeedBackReceived;
            IdeaBreakDownobj.FeedBackFrom = Model.FeedBackFrom;
            IdeaBreakDownobj.ProductDemand = Model.ProductDemand;
            IdeaBreakDownobj.Niche = Model.Niche;
            IdeaBreakDownobj.InMarketAlready = Model.InMarketAlready;
            IdeaBreakDownobj.SpaceExist = Model.SpaceExist;
            IdeaBreakDownobj.Scalable = Model.Scalable;

            Aboutyouobj.Entrepreneur = Model.Entrepreneur;
            Aboutyouobj.YearsDoing = Model.YearsDoing;
            Aboutyouobj.Experience = Model.Experience;
            Aboutyouobj.Priorities = Model.Priorities;
            Aboutyouobj.EndGoal = Model.EndGoal;


            Companyobj.CompanySetup = Model.CompanySetup;
            Companyobj.CompanyName = Model.CompanyName;
            Companyobj.DomainName = Model.DomainName;
            Companyobj.Cofounder = Model.Cofounder;
            Companyobj.SupportTechnically = Model.SupportTechnically;
            Companyobj.BuildFrom = Model.BuildFrom;
            Companyobj.BrandThought = Model.BrandThought;
            Companyobj.CompanyMission = Model.CompanyMission;
            Companyobj.CompanyLookFeel = Model.CompanyLookFeel;




            IdeaSellingobj.SellType = Model.SellType;
            IdeaSellingobj.ProductBuy = Model.ProductBuy;
            IdeaSellingobj.ProductCharge = Model.ProductCharge;
            IdeaSellingobj.ChargeGoing = Model.ChargeGoing;
            IdeaSellingobj.SellTo = Model.SellTo;
            IdeaSellingobj.CustomerFindPlan = Model.CustomerFindPlan;
            IdeaSellingobj.SaleStaffPlan = Model.SaleStaffPlan;

            Moneyobj.BusinessCost = Model.BusinessCost;
            Moneyobj.Affort = Model.Affort;
            Moneyobj.MoneyRaisePlan = Model.MoneyRaisePlan;
            Moneyobj.ProfitableMake = Model.ProfitableMake;
            Moneyobj.ProfitableThinkTime = Model.ProfitableThinkTime;



            obj.AboutYou = Aboutyouobj;
            obj.Company = Companyobj;
            obj.IdeaBreakDown = IdeaBreakDownobj;
            obj.IdeaSelling = IdeaSellingobj;
            obj.Money = Moneyobj;
            //IList<TimeDetails> Model = db.GetTimeDetails(TimesheetParameter).ToList();
            string fileName = string.Empty;
            string status = "!OK";
            if (!(obj == null))
            {
                DateTime fileCreationDatetime = DateTime.Now;
                string InvoiceNumber = fileCreationDatetime.ToString(@"yyyyMMdd") + "" + fileCreationDatetime.ToString(@"HHmmss");
                fileName = string.Format("{0}.pdf", InvoiceNumber);

                string pdfPath = Server.MapPath(@"~\Content\") + fileName;
                using (FileStream msReport = new FileStream(pdfPath, FileMode.Create))
                {
                    using (Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 140f, 10f))
                    {
                        try
                        {
                            iTextSharp.text.Font FontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                            iTextSharp.text.Font FontNormalRed = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.RED);
                            iTextSharp.text.Font FontBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, msReport);
                            // pdfWriter.PageEvent = new ITextEvents(Guid.Parse(HttpContext.User.Identity.Name));
                            pdfWriter.PageEvent = new ITextEvents();
                            pdfDoc.Open();
                            //  int Counter = Model.Count() / 35;
                            // int RemainingItems = Model.Count() % 35;
                            int Counter = 1;
                            int RemainingItems = 1;
                            if (RemainingItems > 0)
                            {
                                Counter = Counter + 1;
                            }
                            int j = 0;
                            int loop = 1;

                            
                            for (int i = 1; i <= Counter; i++)
                            {
                                Phrase DateHeader = new Phrase("My First Question is this", FontBold);
                                //Phrase CheckinHeader = new Phrase("Check-in", FontBold);
                                //Phrase CheckoutHeader = new Phrase("Check-out", FontBold);
                                //Phrase HoursHeader = new Phrase("Hours", FontBold);
                                //Phrase FromVacHeader = new Phrase("-Vac", FontBold);
                                //Phrase FromSick = new Phrase("-Sick", FontBold);
                                //Phrase FromOT = new Phrase("-OT", FontBold);
                                //Phrase WOWWOH = new Phrase("WOW/WOH", FontBold);
                                //Phrase Authorized = new Phrase("Auth.", FontBold);
                                DateHeader.Font.SetColor(60, 60, 60);
                                //CheckinHeader.Font.SetColor(60, 60, 60);
                                //CheckoutHeader.Font.SetColor(60, 60, 60);
                                //HoursHeader.Font.SetColor(60, 60, 60);
                                //FromVacHeader.Font.SetColor(60, 60, 60);
                                //FromSick.Font.SetColor(60, 60, 60);
                                //FromOT.Font.SetColor(60, 60, 60);
                                //WOWWOH.Font.SetColor(60, 60, 60);
                                //Authorized.Font.SetColor(60, 60, 60);
                                PdfPTable ItemsHeader = new PdfPTable(9);
                                float[] Colswidth = new float[] { 1.5f, 1.5f, 1.5f, 1f, 1f, 1f, 1f, 2f, 1f };
                                //PdfPCell Col1Header = new PdfPCell(SerailHeader);
                                PdfPCell Col2Header = new PdfPCell(DateHeader);
                                //PdfPCell Col3Header = new PdfPCell(CheckinHeader);
                                //PdfPCell Col4Header = new PdfPCell(CheckoutHeader);
                                //PdfPCell Col5Header = new PdfPCell(HoursHeader);
                                //PdfPCell Col6Header = new PdfPCell(FromVacHeader);
                                //PdfPCell Col7Header = new PdfPCell(FromSick);
                                //PdfPCell Col8Header = new PdfPCell(FromOT);
                                //PdfPCell Col9Header = new PdfPCell(WOWWOH);
                                //PdfPCell Col10Header = new PdfPCell(Authorized);

                                //Col1Header.Border = 0;
                                Col2Header.Border = 0;
                                //Col3Header.Border = 0;
                                //Col4Header.Border = 0;
                                //Col5Header.Border = 0;
                                //Col6Header.Border = 0;
                                //Col7Header.Border = 0;
                                //Col8Header.Border = 0;
                                //Col9Header.Border = 0;
                                //Col10Header.Border = 0;

                                //Col10Header.BorderWidthBottom = 1;
                                //Col2Header.BorderWidthBottom = 1;
                                //Col3Header.BorderWidthBottom = 1;
                                //Col4Header.BorderWidthBottom = 1;
                                //Col5Header.BorderWidthBottom = 1;
                                //Col6Header.BorderWidthBottom = 1;
                                //Col7Header.BorderWidthBottom = 1;
                                //Col8Header.BorderWidthBottom = 1;
                                //Col9Header.BorderWidthBottom = 1;
                                //Col10Header.BorderWidthBottom = 1;

                                //Col3Header.PaddingBottom = 3;


                                //Col5Header.HorizontalAlignment = Element.ALIGN_RIGHT;
                                //Col6Header.HorizontalAlignment = Element.ALIGN_RIGHT;
                                //Col7Header.HorizontalAlignment = Element.ALIGN_RIGHT;
                                //Col8Header.HorizontalAlignment = Element.ALIGN_RIGHT;
                                //Col9Header.HorizontalAlignment = Element.ALIGN_RIGHT;
                                //Col10Header.HorizontalAlignment = Element.ALIGN_RIGHT;

                                //ItemsHeader.AddCell(Col1Header);
                                ItemsHeader.AddCell(Col2Header);
                                //ItemsHeader.AddCell(Col3Header);
                                //ItemsHeader.AddCell(Col4Header);
                                //ItemsHeader.AddCell(Col5Header);
                                //ItemsHeader.AddCell(Col6Header);
                                //ItemsHeader.AddCell(Col7Header);
                                //ItemsHeader.AddCell(Col8Header);
                                //ItemsHeader.AddCell(Col9Header);
                                //ItemsHeader.AddCell(Col10Header);
                                //ItemsHeader.SetWidths(Colswidth);


                                ItemsHeader.CompleteRow();
                                pdfDoc.Add(ItemsHeader);
                                for (; j < 1; j++)
                                {
                                    string AuthorizSymbol = "Yes";
                                    PdfPTable ItemsRow = new PdfPTable(9);
                                    Phrase Date = new Phrase(String.Format("{0:d}", "My dta is here"), FontNormal);
                                    // Phrase DateItem = new Phrase(DateTime.Now.ToString(), FontNormal);
                                   // Phrase CheckinItem = new Phrase(String.Format("{0:T}", Model[j].checkin), FontNormal);
                                    //Phrase CheckoutItem = new Phrase(String.Format("{0:T}", Model[j].checkout), FontNormal);
                                    // Phrase HoursItem = new Phrase(Model[j].te_hours.ToString("0.00"), FontNormal);
                                    //Phrase HoursItem = new Phrase("ONE", FontNormal);
                                    //Phrase FromVacItem = new Phrase("ome", FontNormal);
                                    //Phrase FromSickItem = new Phrase("", FontNormal);
                                    //Phrase FromOTItem = new Phrase("", FontNormal);
                                   // Phrase FromWOWWOHItem = new Phrase("", FontNormal);
                                    //Phrase IsAuthorized = new Phrase(AuthorizSymbol.ToString(), FontNormal);
                                    //if (Model[j].authorized == 0)
                                    //{
                                    //    AuthorizSymbol = "No";
                                    //    IsAuthorized = new Phrase(AuthorizSymbol.ToString(), FontNormalRed);
                                    //}
                                    // Phrase IsAuthorized = new Phrase(Model[j].authorized.ToString(), FontNormal);
                                    PdfPCell CellNumber = new PdfPCell(Date);
                                    //PdfPCell DateItemCell = new PdfPCell(DateItem);
                                   // PdfPCell CheckinItemCell = new PdfPCell(CheckinItem);
                                    //PdfPCell CheckoutItemCell = new PdfPCell(CheckoutItem);
                                   // PdfPCell HoursItemCell = new PdfPCell(HoursItem);
                                   // PdfPCell VacItemCell = new PdfPCell(FromVacItem);
                                   // PdfPCell SickItemCell = new PdfPCell(FromSickItem);
                                   // PdfPCell OTItemCell = new PdfPCell(FromOTItem);
                                    //PdfPCell WOWWOHItemCell = new PdfPCell(FromWOWWOHItem);
                                    //PdfPCell IsAuthorizedCell = new PdfPCell(IsAuthorized);
                                    CellNumber.BorderColor = new BaseColor(215, 215, 215);
                                    // DateItemCell.Border = 0;
                                    //CheckinItemCell.BorderColor = new BaseColor(215, 215, 215);
                                    //CheckoutItemCell.BorderColor = new BaseColor(215, 215, 215);
                                    //HoursItemCell.BorderColor = new BaseColor(215, 215, 215);
                                    //VacItemCell.BorderColor = new BaseColor(215, 215, 215);
                                    //SickItemCell.BorderColor = new BaseColor(215, 215, 215);
                                    //OTItemCell.BorderColor = new BaseColor(215, 215, 215);
                                    //WOWWOHItemCell.BorderColor = new BaseColor(215, 215, 215);
                                    //IsAuthorizedCell.BorderColor = new BaseColor(215, 215, 215);
                                    //CellNumber.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    // DateItemCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    //CheckinItemCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    //CheckoutItemCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    //HoursItemCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    //HoursItemCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                                    //VacItemCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    //VacItemCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                                    //SickItemCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    //SickItemCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                                    //OTItemCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    //OTItemCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                                    //WOWWOHItemCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    //WOWWOHItemCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                                    //IsAuthorizedCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    //IsAuthorizedCell.HorizontalAlignment = Element.ALIGN_CENTER;

                                    //CheckinItemCell.MinimumHeight = 18;
                                    //CheckinItemCell.Padding = 5;
                                    //if (j % 2 == 0)
                                    //{
                                    //    CellNumber.BackgroundColor = new BaseColor(240, 240, 240);
                                    //    //DateItemCell.BackgroundColor = new BaseColor(240, 240, 240);
                                    //    CheckinItemCell.BackgroundColor = new BaseColor(240, 240, 240);
                                    //    CheckoutItemCell.BackgroundColor = new BaseColor(240, 240, 240);
                                    //    HoursItemCell.BackgroundColor = new BaseColor(240, 240, 240);
                                    //    VacItemCell.BackgroundColor = new BaseColor(240, 240, 240);
                                    //    SickItemCell.BackgroundColor = new BaseColor(240, 240, 240);
                                    //    OTItemCell.BackgroundColor = new BaseColor(240, 240, 240);
                                    //    WOWWOHItemCell.BackgroundColor = new BaseColor(240, 240, 240);
                                    //    IsAuthorizedCell.BackgroundColor = new BaseColor(240, 240, 240);
                                    //}
                                    ItemsRow.AddCell(CellNumber);
                                    //ItemsRow.AddCell(DateItemCell);
                                    //ItemsRow.AddCell(CheckinItemCell);
                                    //ItemsRow.AddCell(CheckoutItemCell);
                                    //ItemsRow.AddCell(HoursItemCell);
                                    //ItemsRow.AddCell(VacItemCell);
                                    //ItemsRow.AddCell(SickItemCell);
                                    //ItemsRow.AddCell(OTItemCell);
                                    //ItemsRow.AddCell(WOWWOHItemCell);
                                    //ItemsRow.AddCell(IsAuthorizedCell);
                                    ItemsRow.SetWidths(Colswidth);
                                    ItemsRow.CompleteRow();
                                    pdfDoc.Add(ItemsRow);
                                    loop = loop + 1;
                                    if (loop >= 35)
                                    {
                                        loop = 1;
                                        j = j + 1;
                                        break;
                                    }


                                }

                                pdfDoc.NewPage();
                            }



                            pdfDoc.Close();
                            status = "OK";

                        }
                        catch (Exception e)
                        {
                            status = e.Message.ToString();
                        }

                    }
                }
            }
          //  return Json(new { status = status, fileName = fileName }, JsonRequestBehavior.AllowGet);
        }
    }

}

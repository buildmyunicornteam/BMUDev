using BuildMyUnicorn.Business_Layer;
using BuildMyUnicorn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BuildMyUnicorn.Controllers
{
    public class IdeaController : Controller
    {
        [Authorize]
        public ActionResult Index(string IdeaID)
        {
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
    }
}
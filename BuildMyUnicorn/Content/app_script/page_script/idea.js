
//console.log($("#jsIdea").val());

$(document).ready(function () {

    $('input[type="checkbox"]').click(function () {

        if ($(this).prop("checked") == true) {
            $(this).prop("checked", true);
            $(this).attr('checked', 'checked')
        }
        else if ($(this).prop("checked") == false) {
            $(this).prop("checked", false);
            $(this).removeAttr('checked', 'checked')
        }
    });

    $(document).on("click", ".JsUpdateIdea", function () {
   
        var IdeaID = $("#IdeaID").val();
        window.location.replace(GetBaseURL() + "Idea?IdeaID=" + IdeaID);
    });
});




//Custom design form example
$(".tab-wizard").steps({
    headerTag: "h6",
    bodyTag: "section",
    transitionEffect: "fade",
    titleTemplate: '<span class="step">#index#</span> #title#',
    labels: {
        finish: "Submit"
    },
    onFinished: function (event, currentIndex) {
        console.log($("form").serialize());
        console.log($('form').serializeArray());
        var data = {};
        console.log($("form").serializeArray().map(function (x) { data[x.name] = x.value; }));
        Swal.fire("Form Submitted!", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed lorem erat eleifend ex semper, lobortis purus sed.");

    }
});


var form = $(".validation-wizard").show();

$(".validation-wizard").steps({
    headerTag: "h6",
    bodyTag: "section",
    transitionEffect: "fade",
    titleTemplate: '<span class="step">#index#</span> #title#',
    labels: {
        finish: "Submit"
    },
    onStepChanging: function (event, currentIndex, newIndex) {
        return currentIndex > newIndex || !(3 === newIndex && Number($("#age-2").val()) < 18) && (currentIndex < newIndex && (form.find(".body:eq(" + newIndex + ") label.error").remove(), form.find(".body:eq(" + newIndex + ") .error").removeClass("error")), form.validate().settings.ignore = ":disabled,:hidden", form.valid())
    },
    onFinishing: function (event, currentIndex) {
        return form.validate().settings.ignore = ":disabled", form.valid()
    },
    onFinished: function (event, currentIndex) {
        var StartupType = [];
        var StartupTechnology = [];
        var SellType = [];
        var ProductCharge = [];
        var MoneyRaisePlan = [];
   
        $.each($("input[name='StartupType']:checked"), function () {
            StartupType.push($(this).val());
        });
        $.each($("input[name='StartupTechnology']:checked"), function () {
            StartupTechnology.push($(this).val());
        });
        $.each($("input[name='SellType']:checked"), function () {
            SellType.push($(this).val());
        });
        $.each($("input[name='ProductCharge']:checked"), function () {
            ProductCharge.push($(this).val());
        });
        $.each($("input[name='MoneyRaisePlan']:checked"), function () {
            MoneyRaisePlan.push($(this).val());
        });
     
     
       var IdeaModel = {
            "AboutYou": { "Entrepreneur": $("#Entrepreneur").val(), "YearsDoing": $("#YearsDoing").val(), "Experience": $("#Experience").val(), "Priorities": $("#Priorities").val(), "EndGoal": $("#EndGoal").val() },
            "Company": { "CompanySetup": $("#CompanySetup").val(), "CompanyName": $("#CompanyName").val(), "HaveGotDomain": $("#HaveGotDomain").val(), "DomainName": $("#DomainName").val(), "Cofounder": $("#Cofounder").val(), "SupportTechnically": $("#SupportTechnically").val(), "BuildFrom": $("#BuildFrom").val(), "BrandThought": $("#BrandThought").val(), "CompanyMission": $("#CompanyMission").val(), "CompanyLookFeel": $("#CompanyLookFeel").val() },
            "IdeaSelling": { "SellType": SellType.join(","), "ProductBuy": $("#ProductBuy").val(), "ProductCharge": ProductCharge.join(","), "ChargeGoing": $("#ChargeGoing").val(), "SellTo": $("#SellTo").val(), "CustomerFindPlan": $("#CustomerFindPlan").val(), "SaleStaffPlan": $("#SaleStaffPlan").val() },
            "Money": { "BusinessCost": $("#BusinessCost").val(), "Affort": $("#ProductBuy").val(), "ProductBuy": $("#ProductBuy").val(), "MoneyRaisePlan": MoneyRaisePlan.join(","), "ProfitableMake": $("#ProfitableMake").val(), "ProfitableThinkTime": $("#ProfitableThinkTime").val() },
            "IdeaBreakDown": { "StartupType": StartupType.join(","), "StartupTechnology": StartupTechnology.join(","), "ProblemSolve": $("#ProblemSolve").val(), "ProblemSolver": $("#ProblemSolver").val(), "FeedBackReceived": $("#FeedBackReceived").val(), "FeedBackFrom": $("#FeedBackFrom").val(), "ProductDemand": $("#ProductDemand").val(), "Niche": $("#Niche").val(), "InMarketAlready": $("#InMarketAlready").val(), "SpaceExist": $("#SpaceExist").val(), "Scalable": $("#Scalable").val() },
            "IdeaID": $("#IdeaID").val(),
            "IdeaExplain": $("#IdeaExplain").val()
        };

        var ActionType = $("#ActionType").val();
        var url = GetBaseURL() + "Idea/AddNewIdea"
        if (ActionType == "UPDATE")
            url = GetBaseURL() + "Idea/UpdateIdea"
        
        $.ajax({
            url: url,
            type: "POST",
            data: JSON.stringify(IdeaModel),
            contentType: "application/json",
            dataType: "json",
      
            error: function (response) {
                if (ActionType == "UPDATE") 
                    swal({
                        title: "Success!",
                        text: "Idea Submitted Successfuly!",
                        icon: "success",
                        button: "Close!",
                    });
                   
                  
                else
                    
                        swal({
                            title: "Success!",
                            text: "Idea Updated Successfuly!",
                            icon: "success",
                            button: "Close!",
                        });

                   
            },
            success: function (response) {
                alert(response);
            }
        });


           



       
        console.log($.parseJSON($("form").serialize()));
        console.log($.parseJSON($('form').serializeArray()));
       // var data = {};
       // $("form").serializeArray().map(function (x) { data[x.name] = x.value; })
        //console.log(data);
        Swal.fire("Form Submitted!", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed lorem erat eleifend ex semper, lobortis purus sed.");
    }
}), $(".validation-wizard").validate({
    ignore: "input[type=hidden]",
    errorClass: "text-danger",
    successClass: "text-success",
    highlight: function (element, errorClass) {
        $(element).removeClass(errorClass)
    },
    unhighlight: function (element, errorClass) {
        $(element).removeClass(errorClass)
    },
    errorPlacement: function (error, element) {
        error.insertAfter(element)
    },
    rules: {
        email: {
            email: !0
        }
    }
})

var serviceUri = "./Services/ODataService.svc/";

var metadata = OData.defaultMetadata;



// Make a request, setting the 'communicating' flag.
var makeRequest = function (request, success) {
    //KioscoViewModelFn.communicating(true);
    //$("#messageBar").text("Contacting server...").show();
    return OData.request(request, function (data) {
        //KioscoViewModelFn.communicating(false);
        //$("#messageBar").hide();
        success(data);
    }, function (err) {
        //KioscoViewModelFn.communicating(false);
        //$("#messageBar").text("Error while contacting server: " + err.message + " - " + JSON.stringify(err));
    });
};


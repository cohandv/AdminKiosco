// paging.js

// registers a knockout binding handler to change the visiblity of the previous page
// and next page buttons depending on whether the page exists
ko.bindingHandlers.hidden = {
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        element.style.visibility = value ? "hidden" : "visible";
    }
}

var FillData = function () {
    $.get(feedUrl, function (data) {
        viewModel.currentPage(feedUrl);
        viewModel.currentPageNumber(1);
        viewModel.previousPages.removeAll();
        viewModel.nextPage(data["@odata.nextLink"]);
        viewModel.ReloadRecords(data);
    });
}

// When the previous button is clicked, make a request to get the previous page viewed
var previousButtonClicked = function () {
    var previousPageLink = viewModel.previousPages.pop();
    $.get(previousPageLink, function (data) {
        viewModel.nextPage(viewModel.currentPage());
        viewModel.currentPage(previousPageLink);
        viewModel.currentPageNumber(viewModel.currentPageNumber() - 1);
        viewModel.ReloadRecords(data);
    });
}

// When the next button is clicked, make a request to get the next page using the link
// from the current page's request
var nextButtonClicked = function () {
    var nextPageLink = viewModel.nextPage();
    $.get(nextPageLink, function (data) {
        viewModel.previousPages.push(viewModel.currentPage());
        viewModel.currentPage(nextPageLink);
        viewModel.nextPage(data["@odata.nextLink"]);
        viewModel.currentPageNumber(viewModel.currentPageNumber() + 1);
        viewModel.ReloadRecords(data);
    });
}
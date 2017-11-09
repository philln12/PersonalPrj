
(function () {
    angular.module(AppName).controller("testController", TestController);
    TestController.$inject = ["$scope", "homeService", "alertService"];

    function TestController($scope, homeService, alertService) {
        var vm = this;
        vm.$onInit = _init;
        vm.oListModel = {};
        vm.oListIndexModel = [];
        vm.postol = _postol;
        vm.delete = _delete;
        vm.edit = _edit;
        vm.editol = _editol;
        vm.scrap = _scrap;
        vm.scrapeModel = {};
        vm.search = _search;
        vm.searchModel = {};
        vm.currentcity;
        vm.currentPostal;
        function _init() {
            vm.test = "Hello World"
            console.log(vm.test)
            homeService.Get()
                .then(function (data) {
                    console.log(data)

                    vm.oListIndexModel = data

                })
                .catch(function (data) {
                    console.log("error.");

                });

            homeService.getByIpAddress()
                .then(function (data) {
                    console.log(data)
                    console.log(data.city)
                    vm.currentcity = data.city;
                    vm.currentPostal = data.zip_code;

                })
                .catch(function (data) {
                    console.log("error.");

                });

        }
        function _postol() {

            homeService.Post(vm.oListModel)
                .then(function (data) {
                    console.log(data)
                    alertService.success("Listing Has Been Created");
                    console.log("good")
                    _init();
                    vm.oListModel = {};
                })
                .catch(function (data) {
                    console.log("error.");

                });

        }

        function _edit(itm) {
            console.log(itm)
            vm.oListModel = {
                'id': itm.Id,
                'locationName': itm.LocationName,
                'streetAddress': itm.StreetAddress,
                'city': itm.City,
                'state': itm.State,
                'postalCode': itm.PostalCode,
                'locationDescription': itm.LocationDescription,
                'locationUrl': itm.LocationUrl,


            };
            vm.button = true;
            vm.selectedIndex = true;
        }

        function _delete(itm) {
            console.log(itm);
            homeService.Delete(itm.Id)
                .then(function (data) {
                    console.log(data)
                    alertService.success("Delete Successful!");

                    var index = vm.oListIndexModel.indexOf(itm);
                    console.log(index);
                    vm.oListIndexModel.splice(index, 1);

                })
                .catch(function (data) {
                    console.log("error.");

                });

        }

        function _editol() {

            homeService.Update(vm.oListModel)
                .then(function (data) {
                    console.log(data)
                    alertService.success("Update Successful!");
                    vm.button = false;
                    vm.oListModel = {};
                    _init()

                })
                .catch(function (data) {
                    console.log("error.");

                });


        }

        function _scrap() {
            console.log("yes");

            homeService.Scraper(vm.scrapeModel)
                .then(function (data) {
                    console.log(data)
                    //tc.scrapeModel.url
                    //data.split("-").pop()
                    console.log(data.split("-"));
                    var temparray = data.split("-");
                    console.log(temparray[0]);
                    var tempaddressarray = temparray[3].split(",");
                    console.log(tempaddressarray);
                    vm.oListModel.locationName = temparray[0];
                    vm.oListModel.streetAddress = tempaddressarray[0];
                    vm.oListModel.city = tempaddressarray[1];
                    vm.oListModel.state = tempaddressarray[2];

                })
                .catch(function (data) {
                    console.log("error.");

                });


        }

        function _search() {
            console.log("test");
            console.log(vm.searchModel.restaurantName);
            console.log(vm.searchModel.restaurantName.split(' ').join('-'));
            var restaurant = vm.searchModel.restaurantName.split(' ').join('-');
            var city = vm.currentcity.split(' ').join('-');

            console.log("https://www.yelp.com/biz/mo-ran-gak-restaurant-garden-grove");
            console.log("https://www.yelp.com/biz/" + restaurant + "-" + city);
            var url = "https://www.yelp.com/biz/" + restaurant + "-" + city;


            homeService.Scraper({url: url })
                .then(function (data) {
                    console.log(data)
      
                    console.log(data.split("-"));
                    var temparray = data.split("-");
                    console.log(temparray[0]);
                    var tempaddressarray = temparray[3].split(",");
                    console.log(tempaddressarray);
                    vm.oListModel.locationName = temparray[0];
                    vm.oListModel.locationDescription = temparray[1];
                    vm.oListModel.streetAddress = tempaddressarray[0];
                    vm.oListModel.city = tempaddressarray[1];
                    vm.oListModel.state = tempaddressarray[2];
                    vm.oListModel.postalCode = vm.currentPostal
                })
                .catch(function (data) {
                    console.log("error.");
                    alertService.error("No " + vm.searchModel.restaurantName +" in this area.")
                });
        }







    }
})()

(function () {
    'use strict'
    angular.module(AppName).factory("homeService", HomeService);
    HomeService.$inject = ["$http", "$q"];

    function HomeService($http, $q) {
        //var apiRoot = "http://localhost:63050"
        var srv = {
            Get: _get,
            Post: _post,
            Delete: _delete,
            Update: _update,
            Scraper: _scraper,
            getByIpAddress: _getByIpAddress

        };
        return srv;

        function _get() {
            console.log("hitthis?")
            return $http.get("/api/Locations", { withCredentials: true })
                .then(function (response) {
                    return response.data;
                })
                .catch(function (data) {
                    return $q.reject(data);
                });
        }

        

        function _post(model) {
            console.log("hitthis?")
            return $http.post("/api/Locations/", model,{ withCredentials: true })
                .then(function (response) {
                    return response.data;
                })
                .catch(function (data) {
                    return $q.reject(data);
                });
        }

        function _delete(id) {
            return $http.delete("/api/Locations/"+id, { withCredentials: true })
                .then(function (response) {
                    return response.data;
                })
                .catch(function (data) {
                    return $q.reject(data);
                });

        }

        function _update(model) {
            return $http.put("/api/Locations/" + model.id, model, { withCredentials: true })
                .then(function (response) {
                    return response.data;
                })
                .catch(function (data) {
                    return $q.reject(data);
                });

        }

        function _scraper(model) {
            return $http.post("/api/Locations/YelpUrl", model, { withCredentials: true })
                .then(function (response) {
                    return response.data;
                })
                .catch(function (data) {
                    return $q.reject(data);
                });

        }

        function _getByIpAddress() {
            return $http.get("https://freegeoip.net/json/", { withCredentials: true })
                .then(function (response) {
                    return response.data;
                })
                .catch(function (data) {
                    return $q.reject(data);
                });
        }


    }
})();